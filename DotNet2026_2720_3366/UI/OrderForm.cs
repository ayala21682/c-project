using System;
using System.Collections.Generic;
using System.Linq;
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
            try
            {
                _currentOrder = new Order
                {
                    ProductsOnOrder = new List<ProductInOrder>(),
                    TotalPrice = 0,
                    preferredCustomer = false
                };

                UpdateOrderSummary();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"שגיאה באתחול המסך: {ex.Message}", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCheckCustomer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerId.Text) || !int.TryParse(txtCustomerId.Text, out int customerId))
            {
                MessageBox.Show("נא להזין תעודת זהות תקינה (מספר בלבד).", "קלט לא תקין", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_currentOrder == null)
            {
                MessageBox.Show("ההזמנה הנוכחית אינה מאותחלת.", "שגיאה במערכת", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var customer = _bl.Customer.Read(customerId);

             
                if (customer == null)
                {
                    MessageBox.Show("הלקוח לא נמצא במערכת. ההזמנה תטופל כלקוח רגיל.", "לקוח לא קיים", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chkIsPreferred.Checked = false;
                    _currentOrder = _currentOrder with { preferredCustomer = false };
                    return;
                }

                chkIsPreferred.Checked = true;
                _currentOrder = _currentOrder with { preferredCustomer = true };

                string customerName = customer.CustomerName ?? "לקוח מועדון";
                MessageBox.Show($"הלקוח {customerName} זוהה בהצלחה!", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);

                UpdateOrderSummary();
            }
            catch (Exception)
            {
                MessageBox.Show("הלקוח אינו רשום במאגר. ההזמנה תמשיך כלקוח רגיל.", "הודעה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                chkIsPreferred.Checked = false;
                _currentOrder = _currentOrder with { preferredCustomer = false };
                UpdateOrderSummary();
            }
        }

      
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txtProductId.Text) || !int.TryParse(txtProductId.Text, out int productId))
            {
                MessageBox.Show("נא להזין קוד מוצר תקין.", "קלט לא תקין", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_currentOrder == null)
            {
                MessageBox.Show("לא ניתן להוסיף מוצר כיוון שההזמנה לא אותחלה.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int amount = (int)numAmount.Value;

                _bl.Order.AddProductToOrder(_currentOrder, productId, amount);

                _bl.Order.CalcTotalPrice(ref _currentOrder);

                UpdateOrderSummary();

                txtProductId.Clear();
                numAmount.Value = 1; 
                txtProductId.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"שגיאה בהוספת המוצר: {ex.Message}", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFinalizeOrder_Click(object sender, EventArgs e)
        {
            if (_currentOrder == null)
            {
                MessageBox.Show("ההזמנה אינה קיימת.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_currentOrder.ProductsOnOrder == null || !_currentOrder.ProductsOnOrder.Any())
            {
                MessageBox.Show("סל הקניות ריק! לא ניתן לבצע הזמנה ללא מוצרים.", "סל ריק", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _bl.Order.DoOrder(_currentOrder);

                MessageBox.Show("ההזמנה נקלטה ובוצעה בהצלחה! המלאי עודכן.", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"שגיאה במהלך סגירת ההזמנה: {ex.Message}", "שגיאה בסגירת הזמנה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateOrderSummary()
        {
            if (_currentOrder == null) return;

            dgvProductsOnOrder.DataSource = null;
            if (_currentOrder.ProductsOnOrder != null)
            {
                dgvProductsOnOrder.DataSource = _currentOrder.ProductsOnOrder.ToList();
            }

            lblTotalPrice.Text = $"סכום סופי לתשלום: {_currentOrder.TotalPrice:F2} ₪";
        }
    }
}