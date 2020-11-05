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

    public partial class FrmImportarArticulos : FrmBase
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

        List<LineaArticulo> lineas = new List<LineaArticulo>();
        List<SubLineaArticulo> sublineas = new List<SubLineaArticulo>();
        List<CategoriaArticulo> categorias = new List<CategoriaArticulo>();
        List<ColorArticulo> colores = new List<ColorArticulo>();
        List<ProcedenciaArticulo> procedencias = new List<ProcedenciaArticulo>();
        List<Proveedor> proveedores = new List<Proveedor>();
        List<Unidad> unidades = new List<Unidad>();
        List<Sucursal> sucursales = new List<Sucursal>();
        List<Ubicacion> ubicaciones = new List<Ubicacion>();
        
        public FrmImportarArticulos(object _ObjGlobalFormaUIPC, Empresa empresa, Sucursal sucursal, Usuario usuario)
        {
            //SpreadsheetInfo.SetLicense("EF21-1FW1-HWZF-CLQH");
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

        #region CargarTablas
        private void CargarTablas()
        {
            try
            {
                response = httpCliente.DownloadString($"http://{nomServer}:{puertoApi}/api/LineaArticuloProfit/GetLineasArticulos?Emp={Emp.CodEmpresa}");
                lineas = JsonConvert.DeserializeObject<List<LineaArticulo>>(response);

                response = httpCliente.DownloadString($"http://{nomServer}:{puertoApi}/api/LineaArticuloProfit/GetSubLineasArticulos?Emp={Emp.CodEmpresa}");
                sublineas = JsonConvert.DeserializeObject<List<SubLineaArticulo>>(response);

                response = httpCliente.DownloadString($"http://{nomServer}:{puertoApi}/api/CategoriaArticuloProfit/GetCategoriasArticulos?Emp={Emp.CodEmpresa}");
                categorias = JsonConvert.DeserializeObject<List<CategoriaArticulo>>(response);

                response = httpCliente.DownloadString($"http://{nomServer}:{puertoApi}/api/ColorArticuloProfit/GetColoresArticulos?Emp={Emp.CodEmpresa}");
                colores = JsonConvert.DeserializeObject<List<ColorArticulo>>(response);

                response = httpCliente.DownloadString($"http://{nomServer}:{puertoApi}/api/ProcedenciaArticuloProfit/GetProcedenciasArticulos?Emp={Emp.CodEmpresa}");
                procedencias = JsonConvert.DeserializeObject<List<ProcedenciaArticulo>>(response);

                response = httpCliente.DownloadString($"http://{nomServer}:{puertoApi}/api/ProveedorProfit/GetProveedores?Emp={Emp.CodEmpresa}");
                proveedores = JsonConvert.DeserializeObject<List<Proveedor>>(response);

                response = httpCliente.DownloadString($"http://{nomServer}:{puertoApi}/api/ArticuloProfit/GetUnidades?Emp={Emp.CodEmpresa}");
                unidades = JsonConvert.DeserializeObject<List<Unidad>>(response);

                response = httpCliente.DownloadString($"http://{nomServer}:{puertoApi}/api/UbicacionArticuloProfit/GetUbicaciones?Emp={Emp.CodEmpresa}");
                ubicaciones = JsonConvert.DeserializeObject<List<Ubicacion>>(response);

            }
            catch (WebException ex)
            {
                MessageBox.Show((ex.InnerException != null) ? ex.InnerException.Message : $"{ex.Message}");
                btnExaminar.Enabled = false;
            }
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

                var Qry = from data in MetodosFunciones.ImportarArchivo.CargarArchivoExcel(OpenFlDialog.FileName, "Hoja1")
                          select new
                          {
                              cod_articulo = data.Field<object>("Codigo") == null ? string.Empty : data.Field<object>("Codigo"),
                              nom_articulo = data.Field<object>("Descripcion") == null ? string.Empty : data.Field<object>("Descripcion"),
                              cod_linea = data.Field<object>("CodLinea") == null ? string.Empty : data.Field<object>("CodLinea"),
                              cod_sublinea = data.Field<object>("CodSublinea") == null ? string.Empty : data.Field<object>("CodSublinea"),
                              cod_categoria = data.Field<object>("CodCategoria") == null ? string.Empty : data.Field<object>("CodCategoria"),
                              cod_color = data.Field<object>("CodColor") == null ? string.Empty : data.Field<object>("CodColor"),
                              cod_procedencia = data.Field<object>("CodProcedencia") == null ? string.Empty : data.Field<object>("CodProcedencia"),
                              cod_ubicacion = data.Field<object>("CodUbicacion") == null ? string.Empty : data.Field<object>("CodUbicacion"),
                              cod_unidad = data.Field<object>("Unidad") == null ? string.Empty : data.Field<object>("Unidad"),
                              tipo_art = data.Field<object>("Tipo") == null ? string.Empty : data.Field<object>("Tipo"),
                              prec_vta = data.Field<object>("Precio") == null ? string.Empty : data.Field<object>("Precio"),
                              campo1 = data.Field<object>("Campo1") == null ? string.Empty : data.Field<object>("Campo1"),
                              comentario = data.Field<object>("Comentario") == null ? string.Empty : data.Field<object>("Comentario"),
                              tipo_imp = data.Field<object>("Tipo Impuesto") == null ? string.Empty : data.Field<object>("Tipo Impuesto"),
                              fec_registro = data.Field<object>("Fecha Creacion") == null ? string.Empty : data.Field<object>("Fecha Creacion"),
                          };

                foreach (var row in Qry)
                {
                    listHojaExcel.Rows.Add(row.cod_articulo, row.nom_articulo, row.cod_linea, row.cod_sublinea, row.cod_categoria,
                        row.cod_color, row.cod_procedencia, row.cod_ubicacion, row.cod_unidad, row.tipo_art, row.prec_vta,
                        row.campo1, row.comentario, row.tipo_imp, row.fec_registro);
                }

                btnProcesar.Enabled = true;
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

                List<Articulo> articulos = new List<Articulo>();
                DateTime fecha;

                //System.Diagnostics.Debugger.Launch();

                #region Validando datos
                foreach (DataGridViewRow iDataRow in listHojaExcel.Rows)
                {
                    #region variables
                    var Coart = iDataRow.Cells[0].Value;
                    var Desart = iDataRow.Cells[1].Value;
                    var Colin = iDataRow.Cells[2].Value;
                    var Cosublin = iDataRow.Cells[3].Value;
                    var Cocat = iDataRow.Cells[4].Value;
                    var Cocol = iDataRow.Cells[5].Value;
                    var Coproc = iDataRow.Cells[6].Value;
                    var CoUbi = iDataRow.Cells[7].Value;
                    var Couni = iDataRow.Cells[8].Value;
                    var TipIv = iDataRow.Cells[9].Value;
                    var Precv = Convert.ToDecimal(iDataRow.Cells[10].Value);
                    var tipoImp = iDataRow.Cells[13].Value;
                    var fecReg =  iDataRow.Cells[14].Value;
                    #endregion

                    #region Validacion celdas nulas

                    #region valida coart
                    if (Coart == null)
                    {
                        CloseLoading();
                        MessageBox.Show("Codigo articulo en blanco.");
                        return;
                    }
                    #endregion

                    #region valida nombre art
                    if (Desart == null)
                    {
                        CloseLoading();
                        MessageBox.Show("Descripcion de articulo en blanco.");
                        return;
                    }
                    #endregion

                    #region valida linea
                    var linea = lineas.FirstOrDefault(l => l.CoLin.Trim() == Colin.ToString().Trim());
                    if (linea == null)
                    {
                        CloseLoading();
                        MessageBox.Show($"La línea {Colin} no existe.");
                        return;
                    }
                    #endregion

                    #region valida la sublinea dentro de la linea
                    var sublin = sublineas.FirstOrDefault(sl => sl.CoSubl.Trim() == Cosublin.ToString().Trim() && sl.CoLin.Trim() == Colin.ToString().Trim());
                    if (sublin == null)
                    {
                        CloseLoading();
                        MessageBox.Show($"La Sub-linea {Cosublin} no existe para la linea {Colin}");
                        return;
                    }
                    #endregion

                    #region valida categoria
                    var categoria = categorias.FirstOrDefault(c => c.CoCat.Trim() == Cocat.ToString().Trim());
                    if (categoria == null)
                    {
                        CloseLoading();
                        MessageBox.Show($"La Categoria {Cocat} no existe.");
                        return;
                    }
                    #endregion

                    #region valida color
                    var color = colores.FirstOrDefault(c => c.CoColor.Trim() == Cocol.ToString().Trim());
                    if (color == null)
                    {
                        CloseLoading();
                        MessageBox.Show($"El color {Cocol} no existe.");
                        return;
                    }
                    #endregion

                    #region valida procedencia
                    var procedencia = procedencias.FirstOrDefault(p => p.CodProc.Trim() == Coproc.ToString().Trim());
                    if (procedencia == null)
                    {
                        CloseLoading();
                        MessageBox.Show($"La procedencia {Coproc} no existe.");
                        return;
                    }
                    #endregion

                    #region valida unidad
                    var unidad = unidades.FirstOrDefault(u => u.CoUni.Trim() == Couni.ToString().Trim());
                    if (unidad == null)
                    {
                        CloseLoading();
                        MessageBox.Show($"La unidad {Couni} no existe.");
                        return;
                    }
                    #endregion

                    #region valida ubicacion
                    var ubicacion = ubicaciones.FirstOrDefault(u => u.CoUbicacion.Trim() == CoUbi.ToString().Trim());
                    if (ubicacion == null)
                    {
                        CloseLoading();
                        MessageBox.Show($"La ubicacion {CoUbi} no existe.");
                        return;
                    }
                    #endregion

                    #region valida Articulo
                    if (TipIv == null)
                    {
                        CloseLoading();
                        MessageBox.Show($"Debe indicar un tipo de articulo (S=Sercicio, V=Venta).");
                        return;
                    }
                    #endregion

                    #region valida preciovta
                    if (Precv <= 0)
                    {
                        CloseLoading();
                        MessageBox.Show($"Precio de venta inválido.");
                        return;
                    }
                    #endregion

                    #region valida Tipo impuesto
                    if (tipoImp == null)
                    {
                        CloseLoading();
                        MessageBox.Show($"Debe indicar un tipo impuesto.");
                        return;
                    }
                    #endregion

                    #region Validar celada vacia
                    if (iDataRow.Cells[14].Value == null)
                    {
                        CloseLoading();
                        MessageBox.Show("Fecha registro no debe estar vacio.");
                        return;
                    }
                    #endregion

                    #region Validar tipo fecha
                    if (!DateTime.TryParse(iDataRow.Cells[14].Value.ToString(), out fecha))
                    {
                        CloseLoading();
                        MessageBox.Show("La fecha de registro no es válida", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    #endregion

                    #endregion

                    articulos.Add(new Articulo
                    {
                        #region Campos
                        CoArt = Coart.ToString().Trim(),
                        ArtDes = Desart.ToString().Trim(),
                        CoLin = Colin.ToString().Trim(),
                        CoSubl = Cosublin.ToString().Trim(),
                        CoCat = Cocat.ToString().Trim(),
                        CoColor = Cocol.ToString().Trim(),
                        CodProc = Coproc.ToString().Trim(),
                        CoUbicacion = CoUbi.ToString().Trim(),
                        Tipo = TipIv.ToString().Trim(),
                        Comentario = iDataRow.Cells[12].Value == null ? string.Empty : iDataRow.Cells[12].Value.ToString().Trim(),
                        CoUsIn = Usr.CodUsuario.Trim(),
                        CoSucuIn = Suc.CoSucur.Trim(),
                        FeUsIn = DateTime.Now,
                        CoUsMo = string.Empty,
                        CoSucuMo = string.Empty,
                        FeUsMo = Convert.ToDateTime("01/01/1900"),
                        Campo1 = iDataRow.Cells[11].Value == null ? string.Empty : iDataRow.Cells[11].Value.ToString().Trim(),
                        Campo8 = Couni.ToString().Trim(),
                        MontComi = Convert.ToDecimal(Precv),
                        TipoImp = tipoImp.ToString(),
                        FechaReg = Convert.ToDateTime(fecReg)
                        #endregion
                    });
                }
                #endregion

                #region Recorrido del objeto para enviarlo a la API
                foreach (var iObjeto in articulos)
                {
                    string ObjetoString = JsonConvert.SerializeObject(iObjeto);

                    httpCliente.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                    response = httpCliente.UploadString($"http://{nomServer}:{puertoApi}/api/ArticuloProfit/Guardar?Emp={Emp.CodEmpresa}", "POST", ObjetoString);
                    resp = JsonConvert.DeserializeObject<Response>(response);

                    if (resp.Status == "OK")
                    {
                        List<Resultado> resultadoFinal = new List<Resultado>
                            {
                                new Resultado
                                {
                                    NroFactura = iObjeto.CoArt.Trim(),
                                    Monto = iObjeto.MontComi
                                }
                            };

                        result.listResultados.Rows.Add(iObjeto.CoArt.Trim(), 0);
                        btnResultados.Enabled = true;
                    }
                    else
                    {
                        throw new ArgumentException(resp.Message);
                    }
                }
                CloseLoading();
                MessageBox.Show("Proceso realizado satisfactoriamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
