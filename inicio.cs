namespace Requerimientos
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Windows.Forms;
    using Entidades;
    using Requerimientos.Formularios;
    using Softech.Base.BusinessObjects;

    public class inicio
    {
        public Object ObjGlobalFormaUIPCMetodo = new Object();
        public Object ObjGlobalPForma = new Object();
        readonly ToolBar Barra = new ToolBar();
        public Empresa ObjEmpresa = new Empresa();
        public Sucursal ObjSucursal = new Sucursal();
        public Usuario ObjUsuario = new Usuario();

        #region Iniciar aplicacion
        public bool IniciarAplicacion(Object forma, Object FormaUIPC)
        {
            ObjGlobalFormaUIPCMetodo = FormaUIPC;
            ObjGlobalPForma = forma;

            List<string[,]> ListBarra = new List<string[,]>();
            List<string[,]> Nombres = new List<string[,]>();

            string[,] Nom1 = new string[1, 2];
            Nom1[0, 0] = "Importar ordenes de compra";
            Nom1[0, 1] = "Importar datos desde un archivo excel según una estructura estipulada.";
            ListBarra.Add(Nom1);

            string[,] Nom2 = new string[1, 2];
            Nom2[0, 0] = "Importar pedidos";
            Nom2[0, 1] = "Importar datos desde un archivo excel según una estructura estipulada.";
            ListBarra.Add(Nom2);

            string[,] Nom3 = new string[1, 2];
            Nom3[0, 0] = "Importar artículos";
            Nom3[0, 1] = "Importar datos desde un archivo excel según una estructura estipulada.";
            ListBarra.Add(Nom3);

            string[,] Nom4 = new string[1, 2];
            Nom4[0, 0] = "Importar clientes";
            Nom4[0, 1] = "Importar datos desde un archivo excel según una estructura estipulada.";
            ListBarra.Add(Nom4);

            string[,] Nom5 = new string[1, 2];
            Nom5[0, 0] = "Importar proveedores";
            Nom5[0, 1] = "Importar datos desde un archivo excel según una estructura estipulada.";
            ListBarra.Add(Nom5);

            /*Diseño de barra*/
            Barra.AutoSize = false;
            Barra.Width = 150;
            Barra.Height = 35;
            Barra.Dock = DockStyle.Bottom;
            Barra.Parent = (Form)forma;

            /*Botones barra*/
            var n = ListBarra.Count();
            ToolBarButton[] boton1 = new ToolBarButton[n];
            int i = 0;
            foreach (string[,] opciones in ListBarra)
            {
                boton1[i] = new ToolBarButton(opciones[0, 0].ToString());
                boton1[i].ToolTipText = opciones[0, 1].ToString();
                Barra.Buttons.Add(boton1[i]);
                i++;
            }
            Barra.ButtonClick += new ToolBarButtonClickEventHandler(Barra1_ButtonClick);

            return true;
        }
        #endregion

        #region Evento clic barra
        private void Barra1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            #region Empresa
            string[] Emp = (string[])ObjGlobalFormaUIPCMetodo.GetType().GetMethod("ObtenerEmpresaActual").Invoke(ObjGlobalFormaUIPCMetodo, new object[] { });
            ObjEmpresa.CodEmpresa = Emp[0].Trim();
            ObjEmpresa.DescEmpresa = Emp[1].Trim();
            #endregion

            #region Sucursal
            string[] Suc = (string[])ObjGlobalFormaUIPCMetodo.GetType().GetMethod("ObtenerSucursalActual").Invoke(ObjGlobalFormaUIPCMetodo, new object[] { });
            ObjSucursal.CoSucur = Suc[0];
            ObjSucursal.SucurDes = Suc[1];
            #endregion

            #region Usuario
            string[] Usr = (string[])ObjGlobalFormaUIPCMetodo.GetType().GetMethod("ObtenerUsuarioActual").Invoke(ObjGlobalFormaUIPCMetodo, new object[] { });
            ObjUsuario.CodUsuario = Usr[0];
            ObjUsuario.DescUsuario = Usr[1];
            ObjUsuario.Prioridad = Convert.ToDecimal(Usr[2]);
            #endregion

            if (ObjUsuario.Prioridad < 100)
            {
                MessageBox.Show("No tienes prioridad suficiente para acceder a este módulo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            #region Formularios
            switch (Barra.Buttons.IndexOf(e.Button))
            {
                case 0:
                    FrmImportarOrdenesCompra frmOrdenes = new FrmImportarOrdenesCompra(ObjGlobalFormaUIPCMetodo, ObjEmpresa, ObjSucursal, ObjUsuario);
                    frmOrdenes.lblEmpresa.Text += $" {ObjEmpresa.DescEmpresa}";
                    frmOrdenes.lblSucursal.Text += $" {ObjSucursal.SucurDes.Trim()}";
                    frmOrdenes.lblUsuario.Text += $" [{ObjUsuario.CodUsuario.Trim()}] [{ObjUsuario.DescUsuario.Trim()}]";
                    frmOrdenes.lblMaquina.Text += $" {Environment.MachineName}";
                    frmOrdenes.ShowDialog();
                    break;
                case 1:
                    FrmImportarPedidosVenta frmPedidos = new FrmImportarPedidosVenta(ObjGlobalFormaUIPCMetodo, ObjEmpresa, ObjSucursal, ObjUsuario);
                    frmPedidos.lblEmpresa.Text += $" {ObjEmpresa.DescEmpresa.Trim()}";
                    frmPedidos.lblSucursal.Text += $" {ObjSucursal.SucurDes.Trim()}";
                    frmPedidos.lblUsuario.Text += $" [{ObjUsuario.CodUsuario.Trim()}] [{ObjUsuario.DescUsuario.Trim()}]";
                    frmPedidos.lblMaquina.Text += $" {Environment.MachineName}";
                    frmPedidos.ShowDialog();
                    break;
                case 2:
                    FrmImportarArticulos frmArticulos = new FrmImportarArticulos(ObjGlobalFormaUIPCMetodo, ObjEmpresa, ObjSucursal, ObjUsuario);
                    frmArticulos.lblEmpresa.Text += $" {ObjEmpresa.DescEmpresa.Trim()}";
                    frmArticulos.lblSucursal.Text += $" {ObjSucursal.SucurDes.Trim()}";
                    frmArticulos.lblUsuario.Text += $" [{ObjUsuario.CodUsuario.Trim()}] [{ObjUsuario.DescUsuario.Trim()}]";
                    frmArticulos.lblMaquina.Text += $" {Environment.MachineName}";
                    frmArticulos.ShowDialog();
                    break;
                case 3:
                    FrmImportarClientes frmClientes = new FrmImportarClientes(ObjGlobalFormaUIPCMetodo, ObjEmpresa, ObjSucursal, ObjUsuario);
                    frmClientes.lblEmpresa.Text += $" {ObjEmpresa.DescEmpresa.Trim()}";
                    frmClientes.lblSucursal.Text += $" {ObjSucursal.SucurDes.Trim()}";
                    frmClientes.lblUsuario.Text += $" [{ObjUsuario.CodUsuario.Trim()}] [{ObjUsuario.DescUsuario.Trim()}]";
                    frmClientes.lblMaquina.Text += $" {Environment.MachineName}";
                    frmClientes.ShowDialog();
                    break;
                case 4:
                    FrmImportarProveedores frmProveedores = new FrmImportarProveedores(ObjGlobalFormaUIPCMetodo, ObjEmpresa, ObjSucursal, ObjUsuario);
                    frmProveedores.lblEmpresa.Text += $" {ObjEmpresa.DescEmpresa.Trim()}";
                    frmProveedores.lblSucursal.Text += $" {ObjSucursal.SucurDes.Trim()}";
                    frmProveedores.lblUsuario.Text += $" [{ObjUsuario.CodUsuario.Trim()}] [{ObjUsuario.DescUsuario.Trim()}]";
                    frmProveedores.lblMaquina.Text += $" {Environment.MachineName}";
                    frmProveedores.ShowDialog();
                    break;
                default:
                    break;
            }
            #endregion
        } 
        #endregion
    }
}