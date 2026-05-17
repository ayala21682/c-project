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

        // פעולה שתתבצע בעת לחיצה על כפתור מנהל המערכת
        private void btnManagerArea_Click(object sender, EventArgs e)
        {
            // יצירת מופע של מסך ניהול מוצרים ופתיחתו כחלון דיאלוג
            ProductManagementForm managerForm = new ProductManagementForm();
            managerForm.ShowDialog();
        }

        // פעולה שתתבצע בעת לחיצה על כפתור הקופאי
        private void btnCashierArea_Click(object sender, EventArgs e)
        {
            // יצירת מופע של מסך קופאי (יצירת הזמנה) ופתיחתו
            OrderForm cashierForm = new OrderForm();
            cashierForm.ShowDialog();
        }
    }
}