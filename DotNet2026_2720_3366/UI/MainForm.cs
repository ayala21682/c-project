using System;
using System.Windows.Forms;

namespace UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnManagerArea_Click(object sender, EventArgs e)
        {
            ProductManagementForm managerForm = new ProductManagementForm();
            managerForm.ShowDialog();
        }

        private void btnCashierArea_Click(object sender, EventArgs e)
        {
            OrderForm cashierForm = new OrderForm();
            cashierForm.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}