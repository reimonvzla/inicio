namespace Requerimientos.Formularios
{
    using System;
    using System.Threading;
    using System.Windows.Forms;

    public partial class FrmBase : Form
    {
        readonly FrmCargando loadForm = new FrmCargando();

        public FrmBase()
        {
            InitializeComponent();
        }

        public void StartLoading()
        {
            ShowLoading();
        }

        public void CloseLoading()
        {
            Thread.Sleep(200);
            loadForm.Invoke(new Action(loadForm.Close));
        }

        private void ShowLoading()
        {
            try
            {
                if (InvokeRequired)
                {
                    loadForm.Cursor = Cursors.WaitCursor;
                    loadForm.ShowDialog();
                }
                else
                {
                    Thread th = new Thread(ShowLoading)
                    {
                        IsBackground = false
                    };
                    th.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
