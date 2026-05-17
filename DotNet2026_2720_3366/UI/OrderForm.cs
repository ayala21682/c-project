using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BO;

namespace UI
{
    public partial class OrderForm : Form
    {
        private readonly BlApi.IBl _bl = BlApi.Factory.Get();
        private Order? _currentOrder;

        public OrderForm()
        {
            InitializeComponent();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            _currentOrder = new Order
            {
                ProductsOnOrder = new List<ProductInOrder>(),
                TotalPrice = 0,
                preferredCustomer = false
            };

            RefreshOrderDisplay();
        }

        private void btnCheckCustomer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerId.Text) || !int.TryParse(txtCustomerId.Text, out int customerId))
            {
                MessageBox.Show("נא להזין תעודת זהות תקינה.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_currentOrder == null) return;

            try
            {
                var customer = _bl.Customer.Read(customerId);
                if (customer != null)
                {
                    chkIsPreferred.Checked = true;
                    _currentOrder = _currentOrder with { preferredCustomer = true };

                    string name = customer.CustomerName ?? "לקוח מיועד";
                    MessageBox.Show($"הלקוח {name} זוהה בהצלחה.", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("הלקוח אינו רשום במערכת. ההזמנה תטופל כלקוח רגיל.", "הודעה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                chkIsPreferred.Checked = false;
                _currentOrder = _currentOrder with { preferredCustomer = false };
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductId.Text) || !int.TryParse(txtProductId.Text, out int productId) ||
                string.IsNullOrWhiteSpace(txtAmount.Text) || !int.TryParse(txtAmount.Text, out int amount))
            {
                MessageBox.Show("נא להזין קוד מוצר וכמות תקינים.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_currentOrder == null) return;

            try
            {
                // קבלת האובייקט המעודכן מה-BL (בהנחה והפונקציה מחזירה Order או מעדכנת ב-ref)
                var sales = _bl.Order.AddProductToOrder(_currentOrder, productId, amount);

                _bl.Order.CalcTotalPrice(ref _currentOrder);

                RefreshOrderDisplay();

                txtProductId.Clear();
                txtAmount.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "שגיאה בהוספת מוצר", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFinalizeOrder_Click(object sender, EventArgs e)
        {
            if (_currentOrder == null || _currentOrder.ProductsOnOrder == null || _currentOrder.ProductsOnOrder.Count == 0)
            {
                MessageBox.Show("סל הקניות ריק. לא ניתן לבצע הזמנה ללא פריטים.", "התראה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _bl.Order.DoOrder(_currentOrder);
                MessageBox.Show("ההזמנה נקלטה במערכת בהצלחה! המלאי עודכן.", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה במהלך סגירת ההזמנה: " + ex.Message, "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshOrderDisplay()
        {
            if (_currentOrder == null) return;

            dgvProductsOnOrder.DataSource = null;
            dgvProductsOnOrder.DataSource = _currentOrder.ProductsOnOrder;

            lblTotalPrice.Text = $"סכום סופי לתשלום: {_currentOrder.TotalPrice:F2} ₪";
        }
    }
}