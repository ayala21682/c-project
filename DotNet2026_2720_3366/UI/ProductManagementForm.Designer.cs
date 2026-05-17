namespace UI
{
    partial class ProductManagementForm
    {
        private System.ComponentModel.IContainer components = null;

        // רכיבי הניווט הראשיים
        private System.Windows.Forms.TabControl tabControlManager;
        private System.Windows.Forms.TabPage tabProducts;
        private System.Windows.Forms.TabPage tabCustomers;
        private System.Windows.Forms.TabPage tabSales;

        // --- רכיבי לשונית מוצרים ---
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.CheckBox chkInStockOnly;
        private System.Windows.Forms.TextBox txtProdId;
        private System.Windows.Forms.TextBox txtProdName;
        private System.Windows.Forms.TextBox txtProdPrice;
        private System.Windows.Forms.TextBox txtProdAmount;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblCategory;

        // --- רכיבי לשונית לקוחות ---
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.TextBox txtCustId;
        private System.Windows.Forms.TextBox txtCustName;
        private System.Windows.Forms.TextBox txtCustAddress;
        private System.Windows.Forms.TextBox txtCustPhone;
        private System.Windows.Forms.Button btnCustAdd;
        private System.Windows.Forms.Button btnCustUpdate;
        private System.Windows.Forms.Button btnCustDelete;
        private System.Windows.Forms.Label lblCustId;
        private System.Windows.Forms.Label lblCustName;
        private System.Windows.Forms.Label lblCustAddress;
        private System.Windows.Forms.Label lblCustPhone;

        // --- רכיבי לשונית מבצעים ---
        private System.Windows.Forms.DataGridView dgvSales;
        private System.Windows.Forms.TextBox txtSaleId;
        private System.Windows.Forms.TextBox txtSaleProdId;
        private System.Windows.Forms.TextBox txtSaleAmount;
        private System.Windows.Forms.TextBox txtSalePrice;
        private System.Windows.Forms.CheckBox chkSaleAllCustomers;
        private System.Windows.Forms.DateTimePicker dtpSaleBegin;
        private System.Windows.Forms.DateTimePicker dtpSaleEnd;
        private System.Windows.Forms.Button btnSaleAdd;
        private System.Windows.Forms.Button btnSaleUpdate;
        private System.Windows.Forms.Button btnSaleDelete;
        private System.Windows.Forms.Label lblSaleId;
        private System.Windows.Forms.Label lblSaleProdId;
        private System.Windows.Forms.Label lblSaleAmount;
        private System.Windows.Forms.Label lblSalePrice;
        private System.Windows.Forms.Label lblSaleBegin;
        private System.Windows.Forms.Label lblSaleEnd;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabControlManager = new System.Windows.Forms.TabControl();
            this.tabProducts = new System.Windows.Forms.TabPage();
            this.tabCustomers = new System.Windows.Forms.TabPage();
            this.tabSales = new System.Windows.Forms.TabPage();

            // אתחול מוצרים
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.chkInStockOnly = new System.Windows.Forms.CheckBox();
            this.txtProdId = new System.Windows.Forms.TextBox();
            this.txtProdName = new System.Windows.Forms.TextBox();
            this.txtProdPrice = new System.Windows.Forms.TextBox();
            this.txtProdAmount = new System.Windows.Forms.TextBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblId = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();

            // אתחול לקוחות
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.txtCustId = new System.Windows.Forms.TextBox();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.txtCustAddress = new System.Windows.Forms.TextBox();
            this.txtCustPhone = new System.Windows.Forms.TextBox();
            this.btnCustAdd = new System.Windows.Forms.Button();
            this.btnCustUpdate = new System.Windows.Forms.Button();
            this.btnCustDelete = new System.Windows.Forms.Button();
            this.lblCustId = new System.Windows.Forms.Label();
            this.lblCustName = new System.Windows.Forms.Label();
            this.lblCustAddress = new System.Windows.Forms.Label();
            this.lblCustPhone = new System.Windows.Forms.Label();

            // אתחול מבצעים
            this.dgvSales = new System.Windows.Forms.DataGridView();
            this.txtSaleId = new System.Windows.Forms.TextBox();
            this.txtSaleProdId = new System.Windows.Forms.TextBox();
            this.txtSaleAmount = new System.Windows.Forms.TextBox();
            this.txtSalePrice = new System.Windows.Forms.TextBox();
            this.chkSaleAllCustomers = new System.Windows.Forms.CheckBox();
            this.dtpSaleBegin = new System.Windows.Forms.DateTimePicker();
            this.dtpSaleEnd = new System.Windows.Forms.DateTimePicker();
            this.btnSaleAdd = new System.Windows.Forms.Button();
            this.btnSaleUpdate = new System.Windows.Forms.Button();
            this.btnSaleDelete = new System.Windows.Forms.Button();
            this.lblSaleId = new System.Windows.Forms.Label();
            this.lblSaleProdId = new System.Windows.Forms.Label();
            this.lblSaleAmount = new System.Windows.Forms.Label();
            this.lblSalePrice = new System.Windows.Forms.Label();
            this.lblSaleBegin = new System.Windows.Forms.Label();
            this.lblSaleEnd = new System.Windows.Forms.Label();

            this.tabControlManager.SuspendLayout();
            this.tabProducts.SuspendLayout();
            this.tabCustomers.SuspendLayout();
            this.tabSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).BeginInit();
            this.SuspendLayout();

            // 
            // tabControlManager
            // 
            this.tabControlManager.Controls.Add(this.tabProducts);
            this.tabControlManager.Controls.Add(this.tabCustomers);
            this.tabControlManager.Controls.Add(this.tabSales);
            this.tabControlManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlManager.Location = new System.Drawing.Point(0, 0);
            this.tabControlManager.Name = "tabControlManager";
            this.tabControlManager.SelectedIndex = 0;
            this.tabControlManager.Size = new System.Drawing.Size(850, 500);

            // ==========================================
            // לשונית מוצרים (tabProducts)
            // ==========================================
            this.tabProducts.Text = "ניהול מוצרים";
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(12, 50);
            this.dgvProducts.Size = new System.Drawing.Size(500, 380);
            this.dgvProducts.SelectionChanged += new System.EventHandler(this.dgvProducts_SelectionChanged);

            this.chkInStockOnly.Location = new System.Drawing.Point(12, 12);
            this.chkInStockOnly.Size = new System.Drawing.Size(200, 24);
            this.chkInStockOnly.Text = "הצג מוצרים במלאי בלבד";
            this.chkInStockOnly.CheckedChanged += new System.EventHandler(this.chkInStockOnly_CheckedChanged);

            this.lblId.Location = new System.Drawing.Point(530, 50); this.lblId.Text = "קוד מוצר:";
            this.txtProdId.Location = new System.Drawing.Point(630, 50); this.txtProdId.Size = new System.Drawing.Size(140, 22); this.txtProdId.ReadOnly = true;

            this.lblName.Location = new System.Drawing.Point(530, 90); this.lblName.Text = "שם מוצר:";
            this.txtProdName.Location = new System.Drawing.Point(630, 90); this.txtProdName.Size = new System.Drawing.Size(140, 22);

            this.lblCategory.Location = new System.Drawing.Point(530, 130); this.lblCategory.Text = "קטגוריה:";
            this.cmbCategory.Location = new System.Drawing.Point(630, 130); this.cmbCategory.Size = new System.Drawing.Size(140, 24);
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblPrice.Location = new System.Drawing.Point(530, 170); this.lblPrice.Text = "מחיר:";
            this.txtProdPrice.Location = new System.Drawing.Point(630, 170); this.txtProdPrice.Size = new System.Drawing.Size(140, 22);

            this.lblAmount.Location = new System.Drawing.Point(530, 210); this.lblAmount.Text = "כמות מלאי:";
            this.txtProdAmount.Location = new System.Drawing.Point(630, 210); this.txtProdAmount.Size = new System.Drawing.Size(140, 22);

            this.btnAdd.Location = new System.Drawing.Point(530, 260); this.btnAdd.Size = new System.Drawing.Size(110, 40); this.btnAdd.Text = "הוסף מוצר"; this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnUpdate.Location = new System.Drawing.Point(660, 260); this.btnUpdate.Size = new System.Drawing.Size(110, 40); this.btnUpdate.Text = "עדכן מוצר"; this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            this.btnDelete.Location = new System.Drawing.Point(530, 320); this.btnDelete.Size = new System.Drawing.Size(240, 40); this.btnDelete.Text = "מחק מוצר מסומן"; this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.tabProducts.Controls.AddRange(new System.Windows.Forms.Control[] { this.dgvProducts, this.chkInStockOnly, this.lblId, this.txtProdId, this.lblName, this.txtProdName, this.lblCategory, this.cmbCategory, this.lblPrice, this.txtProdPrice, this.lblAmount, this.txtProdAmount, this.btnAdd, this.btnUpdate, this.btnDelete });

            // ==========================================
            // לשונית לקוחות (tabCustomers)
            // ==========================================
            this.tabCustomers.Text = "ניהול לקוחות";
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Location = new System.Drawing.Point(12, 50);
            this.dgvCustomers.Size = new System.Drawing.Size(500, 380);
            this.dgvCustomers.SelectionChanged += new System.EventHandler(this.dgvCustomers_SelectionChanged);

            this.lblCustId.Location = new System.Drawing.Point(530, 50); this.lblCustId.Text = "תעודת זהות:";
            this.txtCustId.Location = new System.Drawing.Point(630, 50); this.txtCustId.Size = new System.Drawing.Size(140, 22);

            this.lblCustName.Location = new System.Drawing.Point(530, 90); this.lblCustName.Text = "שם מלא:";
            this.txtCustName.Location = new System.Drawing.Point(630, 90); this.txtCustName.Size = new System.Drawing.Size(140, 22);

            this.lblCustAddress.Location = new System.Drawing.Point(530, 130); this.lblCustAddress.Text = "כתובת:";
            this.txtCustAddress.Location = new System.Drawing.Point(630, 130); this.txtCustAddress.Size = new System.Drawing.Size(140, 22);

            this.lblCustPhone.Location = new System.Drawing.Point(530, 170); this.lblCustPhone.Text = "טלפון:";
            this.txtCustPhone.Location = new System.Drawing.Point(630, 170); this.txtCustPhone.Size = new System.Drawing.Size(140, 22);

            this.btnCustAdd.Location = new System.Drawing.Point(530, 220); this.btnCustAdd.Size = new System.Drawing.Size(110, 40); this.btnCustAdd.Text = "הוסף לקוח"; this.btnCustAdd.Click += new System.EventHandler(this.btnCustAdd_Click);
            this.btnCustUpdate.Location = new System.Drawing.Point(660, 220); this.btnCustUpdate.Size = new System.Drawing.Size(110, 40); this.btnCustUpdate.Text = "עדכן לקוח"; this.btnCustUpdate.Click += new System.EventHandler(this.btnCustUpdate_Click);
            this.btnCustDelete.Location = new System.Drawing.Point(530, 280); this.btnCustDelete.Size = new System.Drawing.Size(240, 40); this.btnCustDelete.Text = "מחק לקוח מסומן"; this.btnCustDelete.Click += new System.EventHandler(this.btnCustDelete_Click);

            this.tabCustomers.Controls.AddRange(new System.Windows.Forms.Control[] { this.dgvCustomers, this.lblCustId, this.txtCustId, this.lblCustName, this.txtCustName, this.lblCustAddress, this.txtCustAddress, this.lblCustPhone, this.txtCustPhone, this.btnCustAdd, this.btnCustUpdate, this.btnCustDelete });

            // ==========================================
            // לשונית מבצעים (tabSales)
            // ==========================================
            this.tabSales.Text = "ניהול מבצעים";
            this.dgvSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSales.Location = new System.Drawing.Point(12, 50);
            this.dgvSales.Size = new System.Drawing.Size(480, 380);
            this.dgvSales.SelectionChanged += new System.EventHandler(this.dgvSales_SelectionChanged);

            this.lblSaleId.Location = new System.Drawing.Point(500, 50); this.lblSaleId.Text = "קוד מבצע:";
            this.txtSaleId.Location = new System.Drawing.Point(630, 50); this.txtSaleId.Size = new System.Drawing.Size(140, 22); this.txtSaleId.ReadOnly = true;

            this.lblSaleProdId.Location = new System.Drawing.Point(500, 90); this.lblSaleProdId.Text = "קוד מוצר:";
            this.txtSaleProdId.Location = new System.Drawing.Point(630, 90); this.txtSaleProdId.Size = new System.Drawing.Size(140, 22);

            this.lblSaleAmount.Location = new System.Drawing.Point(500, 130); this.lblSaleAmount.Text = "כמות נדרשת:";
            this.txtSaleAmount.Location = new System.Drawing.Point(630, 130); this.txtSaleAmount.Size = new System.Drawing.Size(140, 22);

            this.lblSalePrice.Location = new System.Drawing.Point(500, 170); this.lblSalePrice.Text = "מחיר מבצע:";
            this.txtSalePrice.Location = new System.Drawing.Point(630, 170); this.txtSalePrice.Size = new System.Drawing.Size(140, 22);

            this.chkSaleAllCustomers.Location = new System.Drawing.Point(630, 205);
            this.chkSaleAllCustomers.Size = new System.Drawing.Size(150, 24);
            this.chkSaleAllCustomers.Text = "תקף לכל הלקוחות";

            this.lblSaleBegin.Location = new System.Drawing.Point(500, 240); this.lblSaleBegin.Text = "תאריך התחלה:";
            this.dtpSaleBegin.Location = new System.Drawing.Point(630, 240); this.dtpSaleBegin.Size = new System.Drawing.Size(140, 22);

            this.lblSaleEnd.Location = new System.Drawing.Point(500, 280); this.lblSaleEnd.Text = "תאריך סיום:";
            this.dtpSaleEnd.Location = new System.Drawing.Point(630, 280); this.dtpSaleEnd.Size = new System.Drawing.Size(140, 22);

            this.btnSaleAdd.Location = new System.Drawing.Point(500, 330); this.btnSaleAdd.Size = new System.Drawing.Size(100, 40);
            this.btnSaleAdd.Text = "הוסף מבצע"; this.btnSaleAdd.Click += new System.EventHandler(this.btnSaleAdd_Click);
            this.btnSaleUpdate.Location = new System.Drawing.Point(610, 330); this.btnSaleUpdate.Size = new System.Drawing.Size(100, 40);
            this.btnSaleUpdate.Text = "עדכן מבצע"; this.btnSaleUpdate.Click += new System.EventHandler(this.btnSaleUpdate_Click);
            this.btnSaleDelete.Location = new System.Drawing.Point(720, 330); this.btnSaleDelete.Size = new System.Drawing.Size(100, 40);
            this.btnSaleDelete.Text = "מחק מבצע"; this.btnSaleDelete.Click += new System.EventHandler(this.btnSaleDelete_Click);

            this.tabSales.Controls.AddRange(new System.Windows.Forms.Control[] { this.dgvSales, this.lblSaleId, this.txtSaleId, this.lblSaleProdId, this.txtSaleProdId, this.lblSaleAmount, this.txtSaleAmount, this.lblSalePrice, this.txtSalePrice, this.chkSaleAllCustomers, this.lblSaleBegin, this.dtpSaleBegin, this.lblSaleEnd, this.dtpSaleEnd, this.btnSaleAdd, this.btnSaleUpdate, this.btnSaleDelete });

            // 
            // ProductManagementForm
            // 
            this.ClientSize = new System.Drawing.Size(850, 500);
            this.Controls.Add(this.tabControlManager);
            this.Name = "ProductManagementForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "מערכת ניהול מקיפה - מנהל";
            this.Load += new System.EventHandler(this.ProductManagementForm_Load);
            this.tabControlManager.ResumeLayout(false);
            this.tabProducts.ResumeLayout(false);
            this.tabProducts.PerformLayout();
            this.tabCustomers.ResumeLayout(false);
            this.tabCustomers.PerformLayout();
            this.tabSales.ResumeLayout(false);
            this.tabSales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}