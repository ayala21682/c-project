using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BO;

namespace UI
{
    public partial class ProductManagementForm : Form
    {
        private readonly BlApi.IBl _bl = BlApi.Factory.Get();

        public ProductManagementForm()
        {
            InitializeComponent();
        }

        private void ProductManagementForm_Load(object sender, EventArgs e)
        {
            cmbCategory.DataSource = Enum.GetValues(typeof(BO.Category));
            RefreshAllData();
        }

        private void RefreshAllData()
        {
            LoadProducts();
            LoadCustomers();
            LoadSales();
        }

        // ====================================================================
        // לוגיקת מוצרים (Products)
        // ====================================================================
        private void LoadProducts()
        {
            try
            {
                IEnumerable<BO.Product>? products = _bl.Product.ReadAll();
                if (products == null) return;

                // סינון קפדני שמוודא שכל איבר ברשימה אינו null
                if (chkInStockOnly.Checked)
                {
                    products = products.Where(p => p != null && p.Amount > 0);
                }
                else
                {
                    products = products.Where(p => p != null);
                }

                dgvProducts.DataSource = null;
                dgvProducts.DataSource = products.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה בטעינת המוצרים: " + ex.Message, "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkInStockOnly_CheckedChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtProdName.Text) ||
                    !double.TryParse(txtProdPrice.Text, out double price) ||
                    !int.TryParse(txtProdAmount.Text, out int amount) ||
                    cmbCategory.SelectedItem == null)
                {
                    MessageBox.Show("נא למלא את כל שדות המוצר בצורה תקינה.", "קלט לא תקין", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                BO.Category selectedCategory = (BO.Category)cmbCategory.SelectedItem;

                BO.Product newProduct = new BO.Product(
                    ProductId: 0,
                    ProductName: txtProdName.Text,
                    ProductCategorey: selectedCategory,
                    Price: price,
                    Amount: amount,
                    ListOfSales: new List<SaleInProduct>()
                );

                _bl.Product.Create(newProduct);
                MessageBox.Show("המוצר התווסף בהצלחה!", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearProductFields();
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה בהוספת מוצר: " + ex.Message, "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtProdId.Text, out int id) ||
                    !double.TryParse(txtProdPrice.Text, out double price) ||
                    !int.TryParse(txtProdAmount.Text, out int amount) ||
                    cmbCategory.SelectedItem == null)
                {
                    MessageBox.Show("נא לבחור מוצר תקין מהטבלה ולמלא שדות תקינים לעדכון.", "התראה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                BO.Product? productToUpdate = _bl.Product.Read(id);
                if (productToUpdate != null)
                {
                    BO.Category selectedCategory = (BO.Category)cmbCategory.SelectedItem;

                    productToUpdate = productToUpdate with
                    {
                        ProductName = txtProdName.Text,
                        ProductCategorey = selectedCategory,
                        Price = price,
                        Amount = amount
                    };

                    _bl.Product.Update(productToUpdate);
                    MessageBox.Show("המוצר עודכן בהצלחה!", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProducts();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה בעדכון מוצר: " + ex.Message, "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null) return;
            var cellValue = dgvProducts.CurrentRow.Cells["ProductId"].Value;
            if (cellValue == null) return;

            int idToDelete = (int)cellValue;

            var result = MessageBox.Show($"האם למחוק את מוצר {idToDelete}?", "אישור מחיקה", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    _bl.Product.Delete(idToDelete);
                    MessageBox.Show("המוצר נמחק.", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearProductFields();
                    LoadProducts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "שגיאה במחיקה");
                }
            }
        }

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow != null && dgvProducts.Columns.Contains("ProductId"))
            {
                try
                {
                    txtProdId.Text = dgvProducts.CurrentRow.Cells["ProductId"].Value?.ToString() ?? "";
                    txtProdName.Text = dgvProducts.CurrentRow.Cells["ProductName"].Value?.ToString() ?? "";
                    txtProdPrice.Text = dgvProducts.CurrentRow.Cells["Price"].Value?.ToString() ?? "";
                    txtProdAmount.Text = dgvProducts.CurrentRow.Cells["Amount"].Value?.ToString() ?? "";

                    if (dgvProducts.Columns.Contains("ProductCategorey"))
                    {
                        var catValue = dgvProducts.CurrentRow.Cells["ProductCategorey"].Value;
                        if (catValue != null) cmbCategory.SelectedItem = catValue;
                    }
                }
                catch { }
            }
        }

        private void ClearProductFields()
        {
            txtProdId.Clear();
            txtProdName.Clear();
            txtProdPrice.Clear();
            txtProdAmount.Clear();
            if (cmbCategory.Items.Count > 0) cmbCategory.SelectedIndex = 0;
        }

        // ====================================================================
        // לוגיקת לקוחות (Customers)
        // ====================================================================
        private void LoadCustomers()
        {
            try
            {
                var customers = _bl.Customer.ReadAll();
                dgvCustomers.DataSource = null;
                dgvCustomers.DataSource = customers?.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה בטעינת לקוחות: " + ex.Message, "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCustAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtCustId.Text, out int id) || string.IsNullOrWhiteSpace(txtCustName.Text))
                {
                    MessageBox.Show("נא למלא תעודת זהות ושם לקוח תקינים.", "קלט חסר", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                BO.Customer newCustomer = new BO.Customer(id, txtCustName.Text, txtCustAddress.Text, txtCustPhone.Text);
                _bl.Customer.Create(newCustomer);
                MessageBox.Show("הלקוח נוסף בהצלחה!", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearCustomerFields();
                LoadCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה בהוספת לקוח: " + ex.Message, "שגיאה");
            }
        }

        private void btnCustUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtCustId.Text, out int id) || string.IsNullOrWhiteSpace(txtCustName.Text)) return;

                BO.Customer customerToUpdate = new BO.Customer(id, txtCustName.Text, txtCustAddress.Text, txtCustPhone.Text);
                _bl.Customer.Update(customerToUpdate);
                MessageBox.Show("נתוני הלקוח עודכנו בהצלחה!", "הצלחה");
                LoadCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה בעדכון לקוח: " + ex.Message, "שגיאה");
            }
        }

        private void btnCustDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow?.Cells["CustomerId"].Value is int id)
            {
                if (MessageBox.Show($"האם למחוק את לקוח {id}?", "אישור מחיקה", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        _bl.Customer.Delete(id);
                        ClearCustomerFields();
                        LoadCustomers();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "שגיאה במחיקה");
                    }
                }
            }
        }

        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow != null)
            {
                txtCustId.Text = dgvCustomers.CurrentRow.Cells["CustomerId"].Value?.ToString() ?? "";
                txtCustName.Text = dgvCustomers.CurrentRow.Cells["CustomerName"].Value?.ToString() ?? "";
                txtCustAddress.Text = dgvCustomers.CurrentRow.Cells["Address"].Value?.ToString() ?? "";
                txtCustPhone.Text = dgvCustomers.CurrentRow.Cells["PhoneNumber"].Value?.ToString() ?? "";
            }
        }

        private void ClearCustomerFields()
        {
            txtCustId.Clear();
            txtCustName.Clear();
            txtCustAddress.Clear();
            txtCustPhone.Clear();
        }

        // ====================================================================
        // לוגיקת מבצעים (Sales)
        // ====================================================================
        private void LoadSales()
        {
            try
            {
                var sales = _bl.Sale.ReadAll();
                dgvSales.DataSource = null;
                dgvSales.DataSource = sales?.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה בטעינת מבצעים: " + ex.Message, "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaleAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtSaleProdId.Text, out int productId) ||
                    !int.TryParse(txtSaleAmount.Text, out int amount) ||
                    !double.TryParse(txtSalePrice.Text, out double salePrice))
                {
                    MessageBox.Show("נא להזין נתוני מבצע תקינים ומספריים.", "קלט לא תקין", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                BO.Sale newSale = new BO.Sale(
                    SaleId: 0,
                    ProductId: productId,
                    RequiredAmount: amount,
                    SalePrice: salePrice,
                    ForAllCustomers: chkSaleAllCustomers.Checked,
                    BeginSale: dtpSaleBegin.Value,
                    EndSale: dtpSaleEnd.Value
                );

                _bl.Sale.Create(newSale);
                MessageBox.Show("המבצע נוצר בהצלחה!", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearSaleFields();
                LoadSales();
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה ביצירת מבצע: " + ex.Message, "שגיאה");
            }
        }

        private void btnSaleUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtSaleId.Text, out int id) ||
                    !int.TryParse(txtSaleProdId.Text, out int productId) ||
                    !int.TryParse(txtSaleAmount.Text, out int amount) ||
                    !double.TryParse(txtSalePrice.Text, out double salePrice))
                {
                    MessageBox.Show("נא לוודא שכל השדות מלאים ותקינים.", "קלט לא תקין", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // הגנה: בדיקה האם המוצר קיים במערכת לפני שיוך המבצע
                var linkedProduct = _bl.Product.Read(productId);
                if (linkedProduct == null)
                {
                    MessageBox.Show($"שגיאה: לא נמצא מוצר עם קוד {productId}. לא ניתן לעדכן מבצע למוצר שאינו קיים.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                BO.Sale saleToUpdate = new BO.Sale(id, productId, amount, salePrice, chkSaleAllCustomers.Checked, dtpSaleBegin.Value, dtpSaleEnd.Value);
                _bl.Sale.Update(saleToUpdate);

                MessageBox.Show("המבצע עודכן בהצלחה!", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSales();
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה בעדכון מבצע: " + ex.Message, "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaleDelete_Click(object sender, EventArgs e)
        {
            if (dgvSales.CurrentRow?.Cells["SaleId"].Value is int id)
            {
                if (MessageBox.Show($"האם למחוק את מבצע מספר {id}?", "אישור מחיקה", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        _bl.Sale.Delete(id);
                        ClearSaleFields();
                        LoadSales();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "שגיאה במחיקה");
                    }
                }
            }
        }

        private void dgvSales_SelectionChanged(object sender, EventArgs e)
        {
            // בדיקה שהשורה הנוכחית קיימת ואינה ריקה (מונע קריסה כשהטבלה מתרעננת)
            if (dgvSales.CurrentRow == null || dgvSales.CurrentRow.Index < 0) return;

            try
            {
                txtSaleId.Text = dgvSales.CurrentRow.Cells["SaleId"].Value?.ToString() ?? "";
                txtSaleProdId.Text = dgvSales.CurrentRow.Cells["ProductId"].Value?.ToString() ?? "";
                txtSaleAmount.Text = dgvSales.CurrentRow.Cells["RequiredAmount"].Value?.ToString() ?? "";
                txtSalePrice.Text = dgvSales.CurrentRow.Cells["SalePrice"].Value?.ToString() ?? "";

                chkSaleAllCustomers.Checked = dgvSales.CurrentRow.Cells["ForAllCustomers"].Value is bool allCust && allCust;

                if (dgvSales.CurrentRow.Cells["BeginSale"].Value is DateTime beginDate)
                    dtpSaleBegin.Value = beginDate;
                else
                    dtpSaleBegin.Value = DateTime.Now;

                if (dgvSales.CurrentRow.Cells["EndSale"].Value is DateTime endDate)
                    dtpSaleEnd.Value = endDate;
                else
                    dtpSaleEnd.Value = DateTime.Now;
            }
            catch
            {
                // מונע קריסות זמניות בזמן מעבר בין שורות
            }
        }

        private void ClearSaleFields()
        {
            txtSaleId.Clear();
            txtSaleProdId.Clear();
            txtSaleAmount.Clear();
            txtSalePrice.Clear();
            chkSaleAllCustomers.Checked = false;
            dtpSaleBegin.Value = DateTime.Now;
            dtpSaleEnd.Value = DateTime.Now;
        }
    }
}