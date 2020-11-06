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

    public partial class FrmImportarPedidosVenta : FrmBase
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

        List<Cliente> clientes = new List<Cliente>();
        List<Transporte> transportes = new List<Transporte>();
        List<Articulo> articulos = new List<Articulo>();
        List<Almacen> almacenes = new List<Almacen>();

        public FrmImportarPedidosVenta(object _ObjGlobalFormaUIPC, Empresa empresa, Sucursal sucursal, Usuario usuario)
        {
            //SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
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
                              cod_Cliente = data.Field<object>("CodCliente") == null ? string.Empty : data.Field<object>("CodCliente"),
                              fec_Emision = data.Field<object>("Fecha Emision") == null ? string.Empty : data.Field<object>("Fecha Emision"),
                              fec_Vencimiento = data.Field<object>("Fecha Vence") == null ? string.Empty : data.Field<object>("Fecha Vence"),
                              cod_Articulo = data.Field<object>("CodArticulo") == null ? string.Empty : data.Field<object>("CodArticulo"),
                              des_Articulo = data.Field<object>("Descripcion") == null ? string.Empty : data.Field<object>("Descripcion"),
                              cod_Almacen = data.Field<object>("Almacen") == null ? string.Empty : data.Field<object>("Almacen"),
                              total_art = data.Field<object>("Cantidad") == null ? string.Empty : data.Field<object>("Cantidad"),
                              prec_vta = data.Field<object>("Precio") == null ? string.Empty : data.Field<object>("Precio"),
                              tipo_imp = data.Field<object>("Tipo IVA") == null ? string.Empty : data.Field<object>("Tipo IVA"),
                              cod_Transporte = data.Field<object>("Transporte") == null ? string.Empty : data.Field<object>("Transporte"),
                              por_descuento = data.Field<object>("PorcDescuento") == null ? string.Empty : data.Field<object>("PorcDescuento"),
                          };

                foreach (var row in Qry)
                {
                    listHojaExcel.Rows.Add(row.num_Documento, row.cod_Moneda, row.cod_Cliente, row.fec_Emision, row.fec_Vencimiento, row.cod_Articulo, row.des_Articulo, row.cod_Almacen, row.total_art, row.prec_vta, row.tipo_imp, row.cod_Transporte, row.por_descuento);
                }

                btnProcesar.Enabled = true;
            }
        }
        #endregion

        #region Cargar tablas
        private void CargarTablas()
        {
            try
            {
                //System.Diagnostics.Debugger.Launch();

                response = httpCliente.DownloadString($"http://{nomServer}:{puertoApi}/api/AlmacenProfit/GetAlmacenes?Emp={Emp.CodEmpresa}");
                almacenes = JsonConvert.DeserializeObject<List<Almacen>>(response);

                response = httpCliente.DownloadString($"http://{nomServer}:{puertoApi}/api/ArticuloProfit/GetArticulos?Emp={Emp.CodEmpresa}");
                articulos = JsonConvert.DeserializeObject<List<Articulo>>(response);

                response = httpCliente.DownloadString($"http://{nomServer}:{puertoApi}/api/TransporteProfit/GetTransportes?Emp={Emp.CodEmpresa}");
                transportes = JsonConvert.DeserializeObject<List<Transporte>>(response);

                response = httpCliente.DownloadString($"http://{nomServer}:{puertoApi}/api/ClienteProfit/GetClientes?Emp={Emp.CodEmpresa}");
                clientes = JsonConvert.DeserializeObject<List<Cliente>>(response);

            }
            catch (Exception ex)
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
                //System.Diagnostics.Debugger.Launch();

                #region Validar datagridview
                if (listHojaExcel.Rows.Count <= 0)
                {
                    CloseLoading();
                    MessageBox.Show("No existen datos que procesar...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                #endregion

                List<EncabPedidoVenta> PedidoV = new List<EncabPedidoVenta>();
                List<DetaPedidoVenta> PedidoV_Reng = new List<DetaPedidoVenta>();
                int index = 0, rengNum = 0;
                string nroPedidoVenta = string.Empty;
                DateTime fecha;
                decimal porDesc;
                decimal tasaMoneda = 0;

                #region Recorrido de datagrid para procesar a pedido
                foreach (DataGridViewRow iDataRow in listHojaExcel.Rows)
                {
                    if (iDataRow.Cells[0].Value == null)
                    {
                        CloseLoading();
                        MessageBox.Show("Campo Nro documento no debe estar vacío.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (nroPedidoVenta != iDataRow.Cells[0].Value.ToString().Trim()) // Agregar un nuevo encabezado e iniciliza rengNum
                    {
                        rengNum = 0;
                        PedidoV_Reng = new List<DetaPedidoVenta>();
                        index++;

                        tasaMoneda = MetodosFunciones.ObtenerTasa(ObjGlobalFormaUIPC, Convert.ToDateTime(iDataRow.Cells[3].Value), iDataRow.Cells[1].Value.ToString().Trim(), "V");

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

                        #region Verifica cliente
                        if (iDataRow.Cells[2].Value == null)
                        {
                            CloseLoading();
                            MessageBox.Show("Codigo cliente no debe estar vacio.");
                            return;
                        }
                        Cliente cli = clientes.FirstOrDefault(p => p.CoCli.Trim() == iDataRow.Cells[2].Value.ToString().Trim());
                        if (cli == null)
                        {
                            CloseLoading();
                            MessageBox.Show($"El cliente {iDataRow.Cells[2].Value.ToString().Trim()} no existe.");
                            return;
                        }
                        #endregion

                        #region Verifica transporte
                        if (iDataRow.Cells[11].Value == null)
                        {
                            CloseLoading();
                            MessageBox.Show("El Código de Transporte no puede estar vacio.");
                            return;
                        }

                        Transporte tra = transportes.FirstOrDefault(p => p.CoTran.Trim() == iDataRow.Cells[11].Value.ToString().Trim());
                        if (tra == null)
                        {
                            CloseLoading();
                            MessageBox.Show($"El código de transporte {iDataRow.Cells[11].Value.ToString().Trim()} no existe.");
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

                        #region Encabezado
                        PedidoV.Add(new EncabPedidoVenta
                        {
                            #region Campos
                            DocNum = iDataRow.Cells[0].Value.ToString().Trim(),
                            Descrip = iDataRow.Cells[6].Value == null ? string.Empty : iDataRow.Cells[6].Value.ToString().Trim(),
                            CoCli = cli.CoCli,
                            CoVen = cli.CoVen.Trim(), //Backend
                            CoCond = cli.CondPag, //Backend
                            CoMone = iDataRow.Cells[1].Value == null ? string.Empty : iDataRow.Cells[1].Value.ToString().Trim(), //Moneda
                            CoTran = tra.CoTran.Trim(),
                            Tasa = tasaMoneda,
                            FecEmis = Convert.ToDateTime(iDataRow.Cells[3].Value),
                            FecReg = DateTime.Now,
                            FecVenc = Convert.ToDateTime(iDataRow.Cells[4].Value),
                            Status = "0",
                            CoSucuIn = Suc.CoSucur.Trim(),
                            CoUsIn = Usr.CodUsuario.Trim(),
                            FeUsIn = DateTime.Now,
                            FeUsMo = DateTime.Now,
                            CoUsMo = Usr.CodUsuario.Trim(),
                            CoSucuMo = Suc.CoSucur.Trim()
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
                    if (art == null)
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

                    #region Verifica precio
                    if (iDataRow.Cells[9].Value == null)
                    {
                        CloseLoading();
                        MessageBox.Show("Precio no debe estar vacio.");
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
                        decimal precVta = Convert.ToDecimal(iDataRow.Cells[9].Value);
                        decimal montDesc = Convert.ToDecimal(iDataRow.Cells[9].Value) * Convert.ToDecimal(iDataRow.Cells[12].Value) / 100;
                        decimal totalArt = Convert.ToDecimal(iDataRow.Cells[8].Value);
                        String porcDesc = iDataRow.Cells[12].Value.ToString().Trim();

                        #region Detalle
                        PedidoV_Reng.Add(new DetaPedidoVenta
                        {
                            DocNum = iDataRow.Cells[0].Value.ToString().Trim(),
                            RengNum = rengNum,
                            CoArt = iDataRow.Cells[5].Value.ToString().Trim(),
                            TotalArt = totalArt,
                            Pendiente = totalArt,
                            CoPrecio = "01",
                            PrecVta = precVta * tasaMoneda,
                            RengNeto = (precVta * totalArt - montDesc) * tasaMoneda,
                            CoAlma = iDataRow.Cells[7].Value.ToString().Trim(),
                            CoSucuIn = Suc.CoSucur.Trim(),
                            TipoImp = iDataRow.Cells[10].Value.ToString().Trim(), //Calculo de monto_imp en el backend
                            CoUsIn = Usr.CodUsuario.Trim(),
                            FeUsIn = DateTime.Now,
                            FeUsMo = DateTime.Now,
                            CoUsMo = Usr.CodUsuario.Trim(),
                            CoSucuMo = Suc.CoSucur.Trim(),
                            PorcDesc = porcDesc,
                            MontoDesc = montDesc * tasaMoneda
                        });
                        #endregion
                    }

                    #region Actualización de montos encabezado
                    PedidoV[index - 1].DetaPedidoVenta = PedidoV_Reng;
                    /* J.T 03-10-2020 -> LO ELIMINO PORQUE SE VA A CALCULAR EN EL BACKEND
                    PedidoV[index - 1].TotalBruto = (from t in PedidoV[index - 1].DetaPedidoVenta select t.RengNeto).Sum();
                    PedidoV[index - 1].MontoImp = (from t in PedidoV[index - 1].DetaPedidoVenta where t.TipoImp == "1" select t.RengNeto).Sum();
                    PedidoV[index - 1].TotalNeto = (from t in PedidoV[index - 1].DetaPedidoVenta select t.RengNeto).Sum();
                    PedidoV[index - 1].Saldo = (from t in PedidoV[index - 1].DetaPedidoVenta select t.RengNeto).Sum();
                    */
                    #endregion

                    nroPedidoVenta = iDataRow.Cells[0].Value.ToString().Trim();
                }
                #endregion

                //System.Diagnostics.Debugger.Launch();

                #region Recorrido del objeto para enviarlo a la API
                foreach (var iObjeto in PedidoV)
                {
                    string ObjetoString = JsonConvert.SerializeObject(iObjeto);

                    httpCliente.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                    response = httpCliente.UploadString($"http://{nomServer}:{puertoApi}/api/PedidoVentaProfit/Guardar?Emp={Emp.CodEmpresa}", "POST", ObjetoString);
                    resp = JsonConvert.DeserializeObject<Response>(response);
                    nroPedidoVenta = resp.NroDocumentoGenerado01.Trim();

                    if (resp.Status == "OK")
                    {
                        //System.Diagnostics.Debugger.Launch();

                        List<Resultado> resultadoFinal = new List<Resultado>
                            {
                                new Resultado
                                {
                                    NroFactura = nroPedidoVenta,
                                    Monto = iObjeto.Saldo
                                }
                            };

                        result.listResultados.Rows.Add(nroPedidoVenta, iObjeto.Saldo);
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
