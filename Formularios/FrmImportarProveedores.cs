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

    public partial class FrmImportarProveedores : FrmBase
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

        public FrmImportarProveedores(object _ObjGlobalFormaUIPC, Empresa empresa, Sucursal sucursal, Usuario usuario)
        {
            //SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            InitializeComponent();
            ObjGlobalFormaUIPC = _ObjGlobalFormaUIPC;
            Emp = empresa;
            Suc = sucursal;
            Usr = usuario;
            StartLoading();
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
                              codigo = data.Field<object>("Codigo") == null ? string.Empty : data.Field<object>("Codigo"),
                              nombre = data.Field<object>("Descripcion") == null ? string.Empty : data.Field<object>("Descripcion"),
                              direccion = data.Field<object>("Direccion 1") == null ? string.Empty : data.Field<object>("Direccion 1"),
                              direccionE = data.Field<object>("Direccion Entrega") == null ? string.Empty : data.Field<object>("Direccion Entrega"),
                              telefonos = data.Field<object>("Telefonos") == null ? string.Empty : data.Field<object>("Telefonos"),
                              responsable = data.Field<object>("Responsable") == null ? string.Empty : data.Field<object>("Responsable"),
                              rif = data.Field<object>("Rif") == null ? string.Empty : data.Field<object>("Rif"),
                              nit = data.Field<object>("Nit") == null ? string.Empty : data.Field<object>("Nit"),
                              isNacional = data.Field<object>("Nacional?") == null ? string.Empty : data.Field<object>("Nacional?"),
                              correo = data.Field<object>("Correo") == null ? string.Empty : data.Field<object>("Correo"),
                              ciudad = data.Field<object>("Ciudad") == null ? string.Empty : data.Field<object>("Ciudad"),
                              tipoCli = data.Field<object>("Tipo") == null ? string.Empty : data.Field<object>("Tipo"),
                              tipoPer = data.Field<object>("Tipo Persona") == null ? string.Empty : data.Field<object>("Tipo Persona"),
                              coTab = data.Field<object>("Tabulador") == null ? string.Empty : data.Field<object>("Tabulador"),
                              co_zona = data.Field<object>("Zona") == null ? string.Empty : data.Field<object>("Zona"),
                              co_ingr = data.Field<object>("CtaIngresoEgreso") == null ? string.Empty : data.Field<object>("CtaIngresoEgreso"),
                              co_pais = data.Field<object>("Pais") == null ? string.Empty : data.Field<object>("Pais"),
                              co_segmento = data.Field<object>("Segmento") == null ? string.Empty : data.Field<object>("Segmento"),
                              co_condP = data.Field<object>("Forma Pago") == null ? string.Empty : data.Field<object>("Forma Pago")
                          };

                foreach (var row in Qry)
                {
                    listHojaExcel.Rows.Add(row.codigo, row.nombre, row.direccion, row.direccionE, row.telefonos, row.responsable,
                              row.rif, row.nit, row.isNacional, row.correo, row.ciudad, row.tipoCli, row.tipoPer, row.coTab, row.co_zona,
                              row.co_ingr, row.co_pais, row.co_segmento, row.co_condP);
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

                List<Proveedor> proveedores = new List<Proveedor>();
                
                int linea = 0;

                #region Validando datos
                foreach (DataGridViewRow iDataRow in listHojaExcel.Rows)
                {
                    #region Validar proveedor
                    var Coprov = iDataRow.Cells[0].Value;
                    var Prodes = iDataRow.Cells[1].Value;
                    if (Coprov == null)
                    {
                        CloseLoading();
                        MessageBox.Show("Codigo proveedor no puede estar vacío.");
                        return;
                    }

                    if (Prodes==null)
                    {
                        CloseLoading();
                        MessageBox.Show("Nombre proveedor no puede estar vacío");
                        return;
                    }
                    #endregion

                    linea++;

                    #region Validar objeto
                    var direc1 = iDataRow.Cells[2].Value == null ? string.Empty : iDataRow.Cells[2].Value.ToString().Trim();
                    var dirEnt2 = iDataRow.Cells[3].Value == null ? string.Empty : iDataRow.Cells[3].Value.ToString().Trim();
                    //var direc2 = iDataRow.Cells[4].Value == null ? string.Empty : iDataRow.Cells[4].Value.ToString().Trim();
                    var telefonos = iDataRow.Cells[4].Value == null ? string.Empty : iDataRow.Cells[4].Value.ToString().Trim();
                    var respons = iDataRow.Cells[5].Value == null ? string.Empty : iDataRow.Cells[5].Value.ToString().Trim();
                    var rif = iDataRow.Cells[6].Value == null ? string.Empty : iDataRow.Cells[6].Value.ToString().Trim();
                    var nit = iDataRow.Cells[7].Value == null ? string.Empty : iDataRow.Cells[7].Value.ToString().Trim();
                    var nacional = iDataRow.Cells[8].Value.ToString().Trim() != "NO";
                    var email = iDataRow.Cells[9].Value == null ? string.Empty : iDataRow.Cells[9].Value.ToString().Trim();
                    var ciudad = iDataRow.Cells[10].Value == null ? string.Empty : iDataRow.Cells[10].Value.ToString().Trim();

                    #region Validaciones celdas vacias que son obligatorias

                    #region Tipo proveedor
                    var tipoProv = iDataRow.Cells[11].Value;
                    if (tipoProv == null)
                    {
                        CloseLoading();
                        MessageBox.Show($"Tipo proveedor no debe estar vacio. Linea: {linea}");
                        return;
                    }

                    response = httpCliente.DownloadString($"http://{nomServer}:{puertoApi}/api/TipoProveedorProfit/GetTipoProveedor?Emp={Emp.CodEmpresa}&CodTipo={tipoProv.ToString().Trim()}");
                    TipoProveedor tipPr = JsonConvert.DeserializeObject<TipoProveedor>(response);

                    if (tipPr==null)
                    {
                        CloseLoading();
                        MessageBox.Show($"Tipo proveedor {tipoProv.ToString().Trim()} no existe. Linea: {linea}");
                        return;
                    }
                    #endregion

                    #region Tipo persona
                    var tipoPer = iDataRow.Cells[12].Value;
                    if (tipoPer == null)
                    {
                        CloseLoading();
                        MessageBox.Show($"Tipo de persona no debe estar vacio. Linea: {linea}");
                        return;
                    }
                    if (Convert.ToInt32(tipoPer.ToString().Trim()) > 4)
                    {
                        CloseLoading();
                        MessageBox.Show($"Tipo de persona {tipoPer.ToString().Trim()} no existe. Linea: {linea}");
                        return;
                    } 
                    #endregion

                    #region Tabulador ISLR
                    var coTab = iDataRow.Cells[13].Value;
                    if (coTab == null)
                    {
                        CloseLoading();
                        MessageBox.Show($"El tabulador ISLR no debe estar vacio. Linea: {linea}");
                        return;
                    } 
                    #endregion

                    #region Zonas
                    var coZon = iDataRow.Cells[14].Value;
                    if (coZon == null)
                    {
                        CloseLoading();
                        MessageBox.Show($"Tipo de persona no debe estar vacio. Linea: {linea}");
                        return;
                    }
                    response = httpCliente.DownloadString($"http://{nomServer}:{puertoApi}/api/ZonaProfit/GetZona?Emp={Emp.CodEmpresa}&CodZona={coZon.ToString().Trim()}");
                    Zona zona = JsonConvert.DeserializeObject<Zona>(response);
                    if (zona == null)
                    {
                        CloseLoading();
                        MessageBox.Show($"La zona {coZon.ToString().Trim()} no existe. Linea: {linea}");
                        return;
                    }
                    #endregion

                    #region Cuentas ingreso/egreso
                    var coCtaIngrEgr = iDataRow.Cells[15].Value;
                    if (coCtaIngrEgr == null)
                    {
                        CloseLoading();
                        MessageBox.Show($"Cuenta ingreso/egreso no debe estar vacio. Linea: {linea}");
                        return;
                    }
                    response = httpCliente.DownloadString($"http://{nomServer}:{puertoApi}/api/CuentaIngresoEgresoProfit/GetCuentaIngrEgr?Emp={Emp.CodEmpresa}&CodCtaIngrEgr={coCtaIngrEgr.ToString().Trim()}");
                    CuentaIngrEgre cuenta = JsonConvert.DeserializeObject<CuentaIngrEgre>(response);
                    if (cuenta == null)
                    {
                        CloseLoading();
                        MessageBox.Show($"Cuenta ingreso/egreso {coCtaIngrEgr.ToString().Trim()} no debe estar vacio. Linea: {linea}");
                        return;
                    }
                    #endregion

                    #region Pais
                    var coPais = iDataRow.Cells[16].Value;
                    if (coPais == null)
                    {
                        CloseLoading();
                        MessageBox.Show($"codigo pais no debe estar vacio. Linea: {linea}");
                        return;
                    }
                    #endregion

                    #region Segmento
                    var coSeg = iDataRow.Cells[17].Value;
                    if (coSeg == null)
                    {
                        CloseLoading();
                        MessageBox.Show($"Segmento no debe estar vacio. Linea: {linea}");
                        return;
                    }
                    response = httpCliente.DownloadString($"http://{nomServer}:{puertoApi}/api/SegmentoProfit/GetSegmento?Emp={Emp.CodEmpresa}&CodSegmento={coSeg.ToString().Trim()}");
                    Segmento segmento = JsonConvert.DeserializeObject<Segmento>(response);
                    if (segmento == null)
                    {
                        CloseLoading();
                        MessageBox.Show($"El segmento {coSeg.ToString().Trim()} no existe. Linea: {linea}");
                        return;
                    }
                    #endregion

                    #region Forma pago
                    var coCond = iDataRow.Cells[18].Value;
                    if (coCond == null)
                    {
                        CloseLoading();
                        MessageBox.Show($"Forma de pago no debe estar vacio. Linea: {linea}");
                        return;
                    }
                    response = httpCliente.DownloadString($"http://{nomServer}:{puertoApi}/api/CondicionPagoProfit/GetCondicionPago?Emp={Emp.CodEmpresa}&CodCondicionPago={coCond.ToString().Trim()}");
                    CondicionPago formaPago = JsonConvert.DeserializeObject<CondicionPago>(response);
                    if (formaPago == null)
                    {
                        CloseLoading();
                        MessageBox.Show($"La forma de pago {coCond.ToString().Trim()} no existe. Linea: {linea}");
                        return;
                    }
                    #endregion

                    #endregion

                    #endregion

                    proveedores.Add(new Proveedor
                    {
                        #region Campos
                        CoProv = iDataRow.Cells[0].Value.ToString().Trim(),
                        ProvDes = iDataRow.Cells[1].Value.ToString().Trim(),
                        Direc1 = direc1,
                        //Direc2 = direc2,
                        Telefonos = telefonos,
                        Respons = respons,
                        Rif = rif,
                        Nit = nit,
                        Nacional = nacional,
                        ContribuE = false, //contrib,
                        Email = email,
                        TipoAdi = 1,
                        Ciudad = ciudad,
                        CoUsIn = Usr.CodUsuario.Trim(),
                        FeUsIn = DateTime.Now,
                        CoSucuIn = Suc.CoSucur.Trim(),
                        CoUsMo = string.Empty,
                        FeUsMo = Convert.ToDateTime("01/01/1900"),
                        CoSucuMo = string.Empty,
                        TipPro = tipoProv.ToString(),
                        TipoPer = tipoPer.ToString(),
                        CoTab = coTab.ToString(),
                        CoZon = coZon.ToString(),
                        CoCtaIngrEgr = coCtaIngrEgr.ToString(),
                        CoPais = coPais.ToString(),
                        CoSeg = coSeg.ToString(),
                        CondPag = coCond.ToString()
                        #endregion
                    });
                }
                #endregion

                #region Recorrido del objeto para enviarlo a la API
                foreach (var iObjeto in proveedores)
                {
                    string ObjetoString = JsonConvert.SerializeObject(iObjeto);
                    

                    httpCliente.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                    response = httpCliente.UploadString($"http://{nomServer}:{puertoApi}/api/ProveedorProfit/Guardar?Emp={Emp.CodEmpresa}", "POST", ObjetoString);
                    resp = JsonConvert.DeserializeObject<Response>(response);

                    if (resp.Status == "OK")
                    {
                        List<Resultado> resultadoFinal = new List<Resultado>
                            {
                                new Resultado
                                {
                                    NroFactura = iObjeto.CoProv.Trim(),
                                    Monto = 0
                                }
                            };

                        result.listResultados.Rows.Add(iObjeto.CoProv.Trim(), 0);
                        btnResultados.Enabled = true;
                    }
                    else
                    {
                        CloseLoading();
                        MessageBox.Show(resp.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
