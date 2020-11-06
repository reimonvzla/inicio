namespace Requerimientos.Formularios
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Linq;
    using System.Net;
    using System.Windows.Forms;
    using Newtonsoft.Json;
    //using GemBox.Spreadsheet;
    //using GemBox.Spreadsheet.WinFormsUtilities;
    using Entidades;
    using Utilitarios;

    public partial class FrmImportarOrdenesCompra : FrmBase
    {
        private readonly Object ObjGlobalFormaUIPC = new Object();
        private readonly Empresa Emp;
        private readonly Sucursal Suc;
        private readonly Usuario Usr;

        readonly string puertoApi = ConfigurationManager.AppSettings.Get("PuertoAPI");
        readonly string nomServer = ConfigurationManager.AppSettings.Get("NomServer");
        readonly WebClient httpCliente = new WebClient();
        
        Response resp = new Response();
        string response;
        readonly FrmResultados result = new FrmResultados();

        List<Proveedor> proveedores = new List<Proveedor>();
        List<Almacen> almacenes = new List<Almacen>();
        List<Articulo> articulos = new List<Articulo>();
        List<UnidadesArticulo> artunidad = new List<UnidadesArticulo>();

        public FrmImportarOrdenesCompra(object _ObjGlobalFormaUIPC, Empresa empresa, Sucursal sucursal, Usuario usuario)
        {
            //SpreadsheetInfo.SetLicense("E43X-6VAB-CTVW-E9C8");//("FREE-LIMITED-KEY");
            InitializeComponent();
            ObjGlobalFormaUIPC = _ObjGlobalFormaUIPC;
            Emp = empresa;
            Suc = sucursal;
            Usr = usuario;
            StartLoading();
            CargarTablas();
        }

        #region Load
        private void FrmImportarOrdenesCompra_Load(object sender, EventArgs e)
        {
            CloseLoading();
        }
        #endregion

        #region Examinar
        private void btnExaminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFlDialog = new OpenFileDialog();
            OpenFlDialog.Filter = "XLS files (*.xls, *.xlt)|*.xls;*.xlt|XLSX files (*.xlsx, *.xlsm, *.xltx, *.xltm)|*.xlsx;*.xlsm;*.xltx;*.xltm|ODS files (*.ods, *.ots)|*.ods;*.ots|CSV files (*.csv, *.tsv)|*.csv;*.tsv|HTML files (*.html, *.htm)|*.html;*.htm";
            OpenFlDialog.FilterIndex = 2;

            if (OpenFlDialog.ShowDialog() == DialogResult.OK)
            {
                txtRuta.Text = OpenFlDialog.FileName.Trim();
                //var workBook = ExcelFile.Load(OpenFlDialog.FileName);
                //DataGridViewConverter.ExportToDataGridView(workBook.Worksheets.ActiveWorksheet, listHojaExcel, new ExportToDataGridViewOptions() { ColumnHeaders = true });

                var Qry = from data in MetodosFunciones.ImportarArchivo.CargarArchivoExcel(OpenFlDialog.FileName, "Hoja1")
                          select new
                          {
                              num_Documento = data.Field<object>("Nro Documento") == null ? string.Empty : data.Field<object>("Nro Documento"),
                              cod_Moneda = data.Field<object>("Moneda") == null ? string.Empty : data.Field<object>("Moneda"),
                              cod_Proveedor = data.Field<object>("CodProveedor") == null ? string.Empty : data.Field<object>("CodProveedor"),
                              fec_Emision = data.Field<object>("Fecha Emision") == null ? string.Empty : data.Field<object>("Fecha Emision"),
                              fec_Vencimiento = data.Field<object>("Fecha Vence") == null ? string.Empty : data.Field<object>("Fecha Vence"),
                              cod_Articulo = data.Field<object>("CodArticulo") == null ? string.Empty : data.Field<object>("CodArticulo"),
                              des_Articulo = data.Field<object>("Descripcion") == null ? string.Empty : data.Field<object>("Descripcion"),
                              cod_Almacen = data.Field<object>("Almacen") == null ? string.Empty : data.Field<object>("Almacen"),
                              total_art = data.Field<object>("Cantidad") == null ? string.Empty : data.Field<object>("Cantidad"),
                              prec_vta = data.Field<object>("Cost Unitario") == null ? string.Empty : data.Field<object>("Cost Unitario"),
                              tipo_imp = data.Field<object>("Tipo IVA") == null ? string.Empty : data.Field<object>("Tipo IVA"),
                              comentario = data.Field<object>("Comentario") == null ? string.Empty : data.Field<object>("Comentario"),
                              por_descuento = data.Field<object>("PorcDescuento") == null ? string.Empty : data.Field<object>("PorcDescuento"),
                          };

                foreach (var row in Qry)
                {
                    listHojaExcel.Rows.Add(row.num_Documento, row.cod_Moneda, row.cod_Proveedor, row.fec_Emision, row.fec_Vencimiento, row.cod_Articulo, row.des_Articulo, row.cod_Almacen, row.total_art, row.prec_vta, row.tipo_imp, row.comentario,row.por_descuento);
                }

                btnProcesar.Enabled = true;
            }
        }
        #endregion

        #region Cargando tablas principales
        private void CargarTablas()
        {
            try
            {
                response = httpCliente.DownloadString($"http://{nomServer}:{puertoApi}/api/ProveedorProfit/GetProveedores?Emp={Emp.CodEmpresa}");
                proveedores = JsonConvert.DeserializeObject<List<Proveedor>>(response);

                response = httpCliente.DownloadString($"http://{nomServer}:{puertoApi}/api/AlmacenProfit/GetAlmacenes?Emp={Emp.CodEmpresa}");
                almacenes = JsonConvert.DeserializeObject<List<Almacen>>(response);

                response = httpCliente.DownloadString($"http://{nomServer}:{puertoApi}/api/ArticuloProfit/GetArticulos?Emp={Emp.CodEmpresa}");
                articulos = JsonConvert.DeserializeObject<List<Articulo>>(response);

                response = httpCliente.DownloadString($"http://{nomServer}:{puertoApi}/api/ArticuloProfit/GetUnidadesArticulos?Emp={Emp.CodEmpresa}");
                artunidad = JsonConvert.DeserializeObject<List<UnidadesArticulo>>(response);

            }
            catch (WebException ex)
            {
                MessageBox.Show((ex.InnerException != null) ? ex.InnerException.Message : $"{ex.Message}");
                btnExaminar.Enabled = false;
            }
        }
        #endregion

        #region Procesar
        private void btnProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                StartLoading();

                #region Validar datagridview
                if (listHojaExcel.Rows.Count <= 0)
                {
                    CloseLoading();
                    MessageBox.Show("No existen datos que procesar...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                #endregion

                List<EncabOrdenCompra> OrdenC = new List<EncabOrdenCompra>();
                List<DetaOrdenCompra> OrdenC_Reng = new List<DetaOrdenCompra>();
                int index = 0, rengNum = 0;
                string nroOrdenCompra = string.Empty;
                DateTime fecha; //Para validar las fechas q viene de excel si son validas.
                decimal porDesc;
                decimal tasaMoneda = 0;

                #region Recorrido de datagrid para procesar a oc
                foreach (DataGridViewRow iDataRow in listHojaExcel.Rows)
                {
                    if (iDataRow.Cells[0].Value == null)
                    {
                        CloseLoading();
                        MessageBox.Show("Campo Nro documento no debe estar vacío.","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return;
                    }
                    if (nroOrdenCompra != iDataRow.Cells[0].Value.ToString().Trim()) // Agregar un nuevo encabezado e iniciliza rengNum
                    {
                        rengNum = 0;
                        OrdenC_Reng = new List<DetaOrdenCompra>();
                        index++;
                        
                        tasaMoneda = MetodosFunciones.ObtenerTasa(ObjGlobalFormaUIPC, Convert.ToDateTime(iDataRow.Cells[3].Value), iDataRow.Cells[1].Value.ToString().Trim(), "C");

                        #region Verifica documento
                        if (iDataRow.Cells[0].Value == null)
                        {
                            CloseLoading();
                            MessageBox.Show("#Documento no debe estar vacio.");
                            return;
                        }
                        #endregion

                        #region Verifica moneda
                        if (iDataRow.Cells[1].Value == null)
                        {
                            CloseLoading();
                            MessageBox.Show("Moneda no debe estar vacio.");
                            return;
                        }
                        #endregion

                        #region Verifica proveedor
                        if (iDataRow.Cells[2].Value == null)
                        {
                            CloseLoading();
                            MessageBox.Show("Codigo proveedor no debe estar vacio.");
                            return;
                        } 

                        Proveedor prov = proveedores.FirstOrDefault(p => p.CoProv.Trim() == iDataRow.Cells[2].Value.ToString().Trim());
                        if (prov == null)
                        {
                            CloseLoading();
                            MessageBox.Show($"El proveedor {iDataRow.Cells[2].Value.ToString().Trim()} no existe.");
                            return;
                        }
                        #endregion

                        #region Verificar fecha emision
                        if (iDataRow.Cells[3].Value == null)
                        {
                            CloseLoading();
                            MessageBox.Show("Fecha emisión no debe estar vacio.");
                            return;
                        }
                        #endregion

                        #region Verificar fecha vencimiento
                        if (iDataRow.Cells[4].Value == null)
                        {
                            CloseLoading();
                            MessageBox.Show("Fecha vencimiento no debe estar vacio.");
                            return;
                        }
                        #endregion

                        #region Fecha emis invalida
                        if (!DateTime.TryParse(iDataRow.Cells[3].Value.ToString(), out fecha))
                        {
                            CloseLoading();
                            MessageBox.Show("La fecha emisión no es válida", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        } 
                        #endregion

                        #region Fecha venc invalida
                        if (!DateTime.TryParse(iDataRow.Cells[4].Value.ToString(), out fecha))
                        {
                            CloseLoading();
                            MessageBox.Show("La fecha vencimeinto no es válida", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        #endregion

                        //System.Diagnostics.Debugger.Launch();
                        #region Encabezado
                        OrdenC.Add(new EncabOrdenCompra
                        {
                            #region Campos
                            DocNum = iDataRow.Cells[0].Value.ToString().Trim(),
                            Descrip = iDataRow.Cells[6].Value == null ? string.Empty : iDataRow.Cells[6].Value.ToString().Trim(),
                            CoProv = prov.CoProv,
                            CoCond = prov.CondPag,
                            Nac = prov.Nacional,
                            CoMone = iDataRow.Cells[1].Value == null ? string.Empty : iDataRow.Cells[1].Value.ToString().Trim(), //Moneda
                            Tasa = tasaMoneda,
                            FecEmis = Convert.ToDateTime(iDataRow.Cells[3].Value),
                            FecReg = DateTime.Now,
                            FecVenc = Convert.ToDateTime(iDataRow.Cells[4].Value),
                            Status = "0",
                            CoSucuIn = Suc.CoSucur.Trim(),
                            CoUsIn = Usr.CodUsuario.Trim(),
                            FeUsIn = DateTime.Now,
                            FeUsMo = Convert.ToDateTime("01/01/1900"),
                            CoUsMo = string.Empty,
                            CoSucuMo = string.Empty,
                            Comentario = iDataRow.Cells[11].Value == null ? string.Empty : iDataRow.Cells[11].Value.ToString().Trim()
                            #endregion
                        });
                        #endregion
                    }

                    #region Verifica articulo
                    if (iDataRow.Cells[5].Value == null)
                    {
                        CloseLoading();
                        MessageBox.Show("Codigo articulo no debe estar vacio.");
                        return;
                    }
                    Articulo art = articulos.FirstOrDefault(a => a.CoArt.Trim() == iDataRow.Cells[5].Value.ToString().Trim());
                    if (art==null) 
                    {
                        CloseLoading();
                        MessageBox.Show($"El articulo {iDataRow.Cells[5].Value.ToString().Trim()} no existe.");
                        return;
                    }
                    #endregion

                    #region Verifica almacen
                    if (iDataRow.Cells[7].Value == null)
                    {
                        CloseLoading();
                        MessageBox.Show("Almacen no debe estar vacio.");
                        return;
                    }
                    Almacen alm = almacenes.FirstOrDefault(a => a.CoAlma.Trim() == iDataRow.Cells[7].Value.ToString().Trim());
                    if (alm == null)
                    {
                        CloseLoading();
                        MessageBox.Show($"El almacen {iDataRow.Cells[7].Value.ToString().Trim()} no existe.");
                        return;
                    }
                    #endregion

                    #region Verifica cantidad
                    if (iDataRow.Cells[8].Value == null)
                    {
                        CloseLoading();
                        MessageBox.Show("Cantidad no debe estar vacio.");
                        return;
                    }
                    #endregion

                    #region Verifica cost unit
                    if (iDataRow.Cells[9].Value == null)
                    {
                        CloseLoading();
                        MessageBox.Show("Cost. Unitario no debe estar vacio.");
                        return;
                    }
                    #endregion

                    #region Verifica neto
                    //if (iDataRow.Cells[10].Value == null)
                    //{
                    //    CloseLoading();
                    //    MessageBox.Show("Neto no debe estar vacio.");
                    //    return;
                    //}
                    #endregion

                    #region Verifica tipo iva
                    if (iDataRow.Cells[10].Value == null)
                    {
                        CloseLoading();
                        MessageBox.Show("Tipo iva no debe estar vacio.");
                        return;
                    }
                    #endregion

                    #region porcentaje descuento invalido
                    if (iDataRow.Cells[12].Value == null)
                    {
                        CloseLoading();
                        MessageBox.Show("Porcentaje descuento no debe estar vacío. Coloque un valor por defecto = 0 en tal caso.");
                        return;
                    }
                    
                    if (Convert.ToDecimal(iDataRow.Cells[12].Value) < 0 || Convert.ToDecimal(iDataRow.Cells[12].Value) > 100)
                    {
                        CloseLoading();
                        MessageBox.Show("Porcentaje descuento valor permitito entre 0 y 100.");
                        return;
                    }

                    if (!Decimal.TryParse(iDataRow.Cells[12].Value.ToString(), out porDesc))
                    {
                        CloseLoading();
                        MessageBox.Show("Porcentaje descuento tiene que ser un valor numérico.");
                        return;
                    }
                    #endregion

                    rengNum++;

                    if (Convert.ToDecimal(iDataRow.Cells[9].Value) > 0)
                    {

                        Decimal costUni = Convert.ToDecimal(iDataRow.Cells[9].Value);
                        Decimal montDesc = Convert.ToDecimal(iDataRow.Cells[9].Value) * Convert.ToDecimal(iDataRow.Cells[12].Value) / 100;
                        Decimal totalArt = Convert.ToDecimal(iDataRow.Cells[8].Value);
                        String porcDesc = iDataRow.Cells[12].Value.ToString().Trim();

                        #region Detalle
                        OrdenC_Reng.Add(new DetaOrdenCompra
                        {
                            DocNum = iDataRow.Cells[0].Value.ToString().Trim(),
                            RengNum = rengNum,
                            CoArt = iDataRow.Cells[5].Value.ToString().Trim(),
                            CoAlma = iDataRow.Cells[7].Value.ToString().Trim(),
                            TotalArt = totalArt,
                            Pendiente = totalArt,
                            CostUnit = costUni * tasaMoneda,
                            RengNeto = (costUni * totalArt - montDesc) * tasaMoneda,
                            TipoImp = iDataRow.Cells[10].Value.ToString().Trim(), //Calculo de monto_imp en el backend
                            CoSucuIn = Suc.CoSucur.Trim(),
                            CoUsIn = Usr.CodUsuario.Trim(),
                            FeUsIn = DateTime.Now,
                            FeUsMo = Convert.ToDateTime("01/01/1900"),
                            CoUsMo = string.Empty,
                            CoSucuMo = string.Empty,
                            CostUnitOm = costUni,
                            PorcDesc = porcDesc,
                            MontoDesc = montDesc * tasaMoneda
                        });
                        #endregion
                    }

                    #region Actualización de montos encabezado
                    OrdenC[index - 1].DetaOrdenCompra = OrdenC_Reng;
                    // J.T 03-10-2020 -> Lo elimine para calcularlo en el BACKEND
                    //OrdenC[index - 1].TotalBruto = (from t in OrdenC[index - 1].DetaOrdenCompra select t.RengNeto).Sum();
                    //OrdenC[index - 1].MontoImp = (from t in OrdenC[index - 1].DetaOrdenCompra where t.TipoImp == "1" select t.RengNeto).Sum();
                    //OrdenC[index - 1].TotalNeto = (from t in OrdenC[index - 1].DetaOrdenCompra select t.RengNeto).Sum();
                    //OrdenC[index - 1].Saldo = (from t in OrdenC[index - 1].DetaOrdenCompra select t.RengNeto).Sum();
                    #endregion

                    nroOrdenCompra = iDataRow.Cells[0].Value.ToString().Trim();
                }
                #endregion

                //System.Diagnostics.Debugger.Launch();

                #region Recorrido del objeto para enviarlo a la API
                foreach (var iObjeto in OrdenC)
                {
                    string ObjetoString = JsonConvert.SerializeObject(iObjeto);

                    httpCliente.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                    response = httpCliente.UploadString($"http://{nomServer}:{puertoApi}/api/OrdenCompraProfit/Guardar?Emp={Emp.CodEmpresa}", "POST", ObjetoString);
                    resp = JsonConvert.DeserializeObject<Response>(response);
                    nroOrdenCompra = resp.NroDocumentoGenerado01.Trim();

                    if (resp.Status == "OK")
                    {
                        //System.Diagnostics.Debugger.Launch();

                        List<Resultado> resultadoFinal = new List<Resultado>
                            {
                                new Resultado
                                {
                                    NroFactura = nroOrdenCompra,
                                    Monto = iObjeto.Saldo
                                }
                            };

                        result.listResultados.Rows.Add(nroOrdenCompra, iObjeto.Saldo);
                    }
                    else
                    {
                        CloseLoading();
                        MessageBox.Show(resp.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                CloseLoading();
                MessageBox.Show("Proceso realizado satisfactoriamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnResultados.Enabled = true;
                #endregion
            }
            catch (WebException ex)
            {
                using (var reader = new System.IO.StreamReader(ex.Response.GetResponseStream()))
                {
                    response = reader.ReadToEnd();
                    resp = JsonConvert.DeserializeObject<Response>(response);
                }
                CloseLoading();
                MessageBox.Show((ex.InnerException != null) ? ex.InnerException.Message : $"{(resp != null ? "Ups!" : ex.Message)} ({(resp != null ? resp.Message : string.Empty)})", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Ver resultados
        private void btnResultados_Click(object sender, EventArgs e)
        {
            result.ShowDialog();
        } 
        #endregion
    }
}
