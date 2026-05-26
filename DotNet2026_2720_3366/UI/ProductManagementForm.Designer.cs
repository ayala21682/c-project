namespace UI
{
    partial class ProductManagementForm
    {
        private System.ComponentModel.IContainer components = null;

       
        private System.Windows.Forms.TabControl tabControlManager;
        private System.Windows.Forms.TabPage tabProducts;
        private System.Windows.Forms.TabPage tabCustomers;
        private System.Windows.Forms.TabPage tabSales;

        // --- רכיבי לשונית מוצרים ---
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.CheckBox chkInStockOnly;
        private System.Windows.Forms.TextBox txtProdName;
        private System.Windows.Forms.TextBox txtProdPrice;
        private System.Windows.Forms.TextBox txtProdAmount;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
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
        private System.Windows.Forms.TextBox txtSaleProdId;
        private System.Windows.Forms.TextBox txtSaleAmount;
        private System.Windows.Forms.TextBox txtSalePrice;
        private System.Windows.Forms.CheckBox chkSaleAllCustomers;
        private System.Windows.Forms.DateTimePicker dtpSaleBegin;
        private System.Windows.Forms.DateTimePicker dtpSaleEnd;
        private System.Windows.Forms.Button btnSaleAdd;
        private System.Windows.Forms.Button btnSaleUpdate;
        private System.Windows.Forms.Button btnSaleDelete;
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
            tabControlManager = new TabControl();
            tabProducts = new TabPage();
            dgvProducts = new DataGridView();
            chkInStockOnly = new CheckBox();
            lblName = new Label();
            txtProdName = new TextBox();
            lblCategory = new Label();
            cmbCategory = new ComboBox();
            lblPrice = new Label();
            txtProdPrice = new TextBox();
            lblAmount = new Label();
            txtProdAmount = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            tabCustomers = new TabPage();
            dgvCustomers = new DataGridView();
            lblCustId = new Label();
            txtCustId = new TextBox();
            lblCustName = new Label();
            txtCustName = new TextBox();
            lblCustAddress = new Label();
            txtCustAddress = new TextBox();
            lblCustPhone = new Label();
            txtCustPhone = new TextBox();
            btnCustAdd = new Button();
            btnCustUpdate = new Button();
            btnCustDelete = new Button();
            tabSales = new TabPage();
            dgvSales = new DataGridView();
            lblSaleProdId = new Label();
            txtSaleProdId = new TextBox();
            lblSaleAmount = new Label();
            txtSaleAmount = new TextBox();
            lblSalePrice = new Label();
            txtSalePrice = new TextBox();
            chkSaleAllCustomers = new CheckBox();
            lblSaleBegin = new Label();
            dtpSaleBegin = new DateTimePicker();
            lblSaleEnd = new Label();
            dtpSaleEnd = new DateTimePicker();
            btnSaleAdd = new Button();
            btnSaleUpdate = new Button();
            btnSaleDelete = new Button();
            tabControlManager.SuspendLayout();
            tabProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            tabCustomers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            tabSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSales).BeginInit();
            SuspendLayout();
           
            // tabControlManager
          
            tabControlManager.Controls.Add(tabProducts);
            tabControlManager.Controls.Add(tabCustomers);
            tabControlManager.Controls.Add(tabSales);
            tabControlManager.Dock = DockStyle.Fill;
            tabControlManager.Location = new Point(0, 0);
            tabControlManager.Name = "tabControlManager";
            tabControlManager.SelectedIndex = 0;
            tabControlManager.Size = new Size(850, 500);
            tabControlManager.TabIndex = 0;
             
            // tabProducts
            
            tabProducts.Controls.Add(dgvProducts);
            tabProducts.Controls.Add(chkInStockOnly);
            tabProducts.Controls.Add(lblName);
            tabProducts.Controls.Add(txtProdName);
            tabProducts.Controls.Add(lblCategory);
            tabProducts.Controls.Add(cmbCategory);
            tabProducts.Controls.Add(lblPrice);
            tabProducts.Controls.Add(txtProdPrice);
            tabProducts.Controls.Add(lblAmount);
            tabProducts.Controls.Add(txtProdAmount);
            tabProducts.Controls.Add(btnAdd);
            tabProducts.Controls.Add(btnUpdate);
            tabProducts.Controls.Add(btnDelete);
            tabProducts.Location = new Point(4, 29);
            tabProducts.Name = "tabProducts";
            tabProducts.Size = new Size(842, 467);
            tabProducts.TabIndex = 0;
            tabProducts.Text = "ניהול מוצרים";
            
            // dgvProducts
            
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(12, 50);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.Size = new Size(500, 380);
            dgvProducts.TabIndex = 0;
            dgvProducts.SelectionChanged += dgvProducts_SelectionChanged;
            
            // chkInStockOnly
            
            chkInStockOnly.Location = new Point(12, 12);
            chkInStockOnly.Name = "chkInStockOnly";
            chkInStockOnly.Size = new Size(200, 24);
            chkInStockOnly.TabIndex = 1;
            chkInStockOnly.Text = "הצג מוצרים במלאי בלבד";
            chkInStockOnly.CheckedChanged += chkInStockOnly_CheckedChanged;
            
            // lblName
             
            lblName.Location = new Point(530, 90);
            lblName.Name = "lblName";
            lblName.Size = new Size(100, 23);
            lblName.TabIndex = 4;
            lblName.Text = "שם מוצר:";
            
            // txtProdName
            
            txtProdName.Location = new Point(630, 90);
            txtProdName.Name = "txtProdName";
            txtProdName.Size = new Size(140, 27);
            txtProdName.TabIndex = 5;
            
            // lblCategory
           
            lblCategory.Location = new Point(530, 130);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(100, 23);
            lblCategory.TabIndex = 6;
            lblCategory.Text = "קטגוריה:";
            
            // cmbCategory
            
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Location = new Point(630, 130);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(140, 28);
            cmbCategory.TabIndex = 7;
            
            // lblPrice
            
            lblPrice.Location = new Point(530, 170);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(100, 23);
            lblPrice.TabIndex = 8;
            lblPrice.Text = "מחיר:";
            
            // txtProdPrice
            
            txtProdPrice.Location = new Point(630, 170);
            txtProdPrice.Name = "txtProdPrice";
            txtProdPrice.Size = new Size(140, 27);
            txtProdPrice.TabIndex = 9;
             
            // lblAmount
            
            lblAmount.Location = new Point(530, 210);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(100, 23);
            lblAmount.TabIndex = 10;
            lblAmount.Text = "כמות מלאי:";
             
            // txtProdAmount
            
            txtProdAmount.Location = new Point(630, 210);
            txtProdAmount.Name = "txtProdAmount";
            txtProdAmount.Size = new Size(140, 27);
            txtProdAmount.TabIndex = 11;
            
            // btnAdd
             
            btnAdd.Location = new Point(530, 260);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(110, 40);
            btnAdd.TabIndex = 12;
            btnAdd.Text = "הוסף מוצר";
            btnAdd.Click += btnAdd_Click;
            
            // btnUpdate
             
            btnUpdate.Location = new Point(660, 260);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(110, 40);
            btnUpdate.TabIndex = 13;
            btnUpdate.Text = "עדכן מוצר";
            btnUpdate.Click += btnUpdate_Click;
            
            // btnDelete
            
            btnDelete.Location = new Point(530, 320);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(240, 40);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "מחק מוצר מסומן";
            btnDelete.Click += btnDelete_Click;

            // tabCustomers
       
            tabCustomers.Controls.Add(dgvCustomers);
            tabCustomers.Controls.Add(lblCustId);
            tabCustomers.Controls.Add(txtCustId);
            tabCustomers.Controls.Add(lblCustName);
            tabCustomers.Controls.Add(txtCustName);
            tabCustomers.Controls.Add(lblCustAddress);
            tabCustomers.Controls.Add(txtCustAddress);
            tabCustomers.Controls.Add(lblCustPhone);
            tabCustomers.Controls.Add(txtCustPhone);
            tabCustomers.Controls.Add(btnCustAdd);
            tabCustomers.Controls.Add(btnCustUpdate);
            tabCustomers.Controls.Add(btnCustDelete);
            tabCustomers.Location = new Point(4, 29);
            tabCustomers.Name = "tabCustomers";
            tabCustomers.Size = new Size(842, 467);
            tabCustomers.TabIndex = 1;
            tabCustomers.Text = "ניהול לקוחות";
            
            // dgvCustomers
            
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.Location = new Point(12, 50);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.RowHeadersWidth = 51;
            dgvCustomers.Size = new Size(500, 380);
            dgvCustomers.TabIndex = 0;
            dgvCustomers.SelectionChanged += dgvCustomers_SelectionChanged;
            
            // lblCustId
            
            lblCustId.Location = new Point(530, 50);
            lblCustId.Name = "lblCustId";
            lblCustId.Size = new Size(100, 23);
            lblCustId.TabIndex = 1;
            lblCustId.Text = "תעודת זהות:";
          
            // txtCustId
           
            txtCustId.Location = new Point(630, 50);
            txtCustId.Name = "txtCustId";
            txtCustId.Size = new Size(140, 27);
            txtCustId.TabIndex = 2;
            
            // lblCustName
       
            lblCustName.Location = new Point(530, 90);
            lblCustName.Name = "lblCustName";
            lblCustName.Size = new Size(100, 23);
            lblCustName.TabIndex = 3;
            lblCustName.Text = "שם מלא:";
           
            // txtCustName
            
            txtCustName.Location = new Point(630, 90);
            txtCustName.Name = "txtCustName";
            txtCustName.Size = new Size(140, 27);
            txtCustName.TabIndex = 4;
            
            // lblCustAddress
        
            lblCustAddress.Location = new Point(530, 130);
            lblCustAddress.Name = "lblCustAddress";
            lblCustAddress.Size = new Size(100, 23);
            lblCustAddress.TabIndex = 5;
            lblCustAddress.Text = "כתובת:";
            
            // txtCustAddress
            
            txtCustAddress.Location = new Point(630, 130);
            txtCustAddress.Name = "txtCustAddress";
            txtCustAddress.Size = new Size(140, 27);
            txtCustAddress.TabIndex = 6;
            
            // lblCustPhone
             
            lblCustPhone.Location = new Point(530, 170);
            lblCustPhone.Name = "lblCustPhone";
            lblCustPhone.Size = new Size(100, 23);
            lblCustPhone.TabIndex = 7;
            lblCustPhone.Text = "טלפון:";
            
            // txtCustPhone
             
            txtCustPhone.Location = new Point(630, 170);
            txtCustPhone.Name = "txtCustPhone";
            txtCustPhone.Size = new Size(140, 27);
            txtCustPhone.TabIndex = 8;
            
            // btnCustAdd
            
            btnCustAdd.Location = new Point(530, 220);
            btnCustAdd.Name = "btnCustAdd";
            btnCustAdd.Size = new Size(110, 40);
            btnCustAdd.TabIndex = 9;
            btnCustAdd.Text = "הוסף לקוח";
            btnCustAdd.Click += btnCustAdd_Click;
             
            // btnCustUpdate
             
            btnCustUpdate.Location = new Point(660, 220);
            btnCustUpdate.Name = "btnCustUpdate";
            btnCustUpdate.Size = new Size(110, 40);
            btnCustUpdate.TabIndex = 10;
            btnCustUpdate.Text = "עדכן לקוח";
            btnCustUpdate.Click += btnCustUpdate_Click;
             
            // btnCustDelete
             
            btnCustDelete.Location = new Point(530, 280);
            btnCustDelete.Name = "btnCustDelete";
            btnCustDelete.Size = new Size(240, 40);
            btnCustDelete.TabIndex = 11;
            btnCustDelete.Text = "מחק לקוח מסומן";
            btnCustDelete.Click += btnCustDelete_Click;
             
            // tabSales
            
            tabSales.Controls.Add(dgvSales);
            tabSales.Controls.Add(lblSaleProdId);
            tabSales.Controls.Add(txtSaleProdId);
            tabSales.Controls.Add(lblSaleAmount);
            tabSales.Controls.Add(txtSaleAmount);
            tabSales.Controls.Add(lblSalePrice);
            tabSales.Controls.Add(txtSalePrice);
            tabSales.Controls.Add(chkSaleAllCustomers);
            tabSales.Controls.Add(lblSaleBegin);
            tabSales.Controls.Add(dtpSaleBegin);
            tabSales.Controls.Add(lblSaleEnd);
            tabSales.Controls.Add(dtpSaleEnd);
            tabSales.Controls.Add(btnSaleAdd);
            tabSales.Controls.Add(btnSaleUpdate);
            tabSales.Controls.Add(btnSaleDelete);
            tabSales.Location = new Point(4, 29);
            tabSales.Name = "tabSales";
            tabSales.Size = new Size(842, 467);
            tabSales.TabIndex = 2;
            tabSales.Text = "ניהול מבצעים";
             
            // dgvSales
             
            dgvSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSales.Location = new Point(12, 50);
            dgvSales.Name = "dgvSales";
            dgvSales.RowHeadersWidth = 51;
            dgvSales.Size = new Size(480, 380);
            dgvSales.TabIndex = 0;
            dgvSales.SelectionChanged += dgvSales_SelectionChanged;
             
            // lblSaleProdId
             
            lblSaleProdId.Location = new Point(500, 90);
            lblSaleProdId.Name = "lblSaleProdId";
            lblSaleProdId.Size = new Size(100, 23);
            lblSaleProdId.TabIndex = 3;
            lblSaleProdId.Text = "קוד מוצר:";
             
            // txtSaleProdId

            txtSaleProdId.Location = new Point(630, 90);
            txtSaleProdId.Name = "txtSaleProdId";
            txtSaleProdId.Size = new Size(140, 27);
            txtSaleProdId.TabIndex = 4;
             
            // lblSaleAmount
             
            lblSaleAmount.Location = new Point(500, 130);
            lblSaleAmount.Name = "lblSaleAmount";
            lblSaleAmount.Size = new Size(100, 23);
            lblSaleAmount.TabIndex = 5;
            lblSaleAmount.Text = "כמות נדרשת:";
            
            // txtSaleAmount
            
            txtSaleAmount.Location = new Point(630, 130);
            txtSaleAmount.Name = "txtSaleAmount";
            txtSaleAmount.Size = new Size(140, 27);
            txtSaleAmount.TabIndex = 6;
             
            // lblSalePrice
             
            lblSalePrice.Location = new Point(500, 170);
            lblSalePrice.Name = "lblSalePrice";
            lblSalePrice.Size = new Size(100, 23);
            lblSalePrice.TabIndex = 7;
            lblSalePrice.Text = "מחיר מבצע:";
             
            // txtSalePrice
            
            txtSalePrice.Location = new Point(630, 170);
            txtSalePrice.Name = "txtSalePrice";
            txtSalePrice.Size = new Size(140, 27);
            txtSalePrice.TabIndex = 8;
             
            // chkSaleAllCustomers
            
            chkSaleAllCustomers.Location = new Point(630, 205);
            chkSaleAllCustomers.Name = "chkSaleAllCustomers";
            chkSaleAllCustomers.Size = new Size(150, 24);
            chkSaleAllCustomers.TabIndex = 9;
            chkSaleAllCustomers.Text = "תקף לכל הלקוחות";
            // 
            // lblSaleBegin
            // 
            lblSaleBegin.Location = new Point(500, 240);
            lblSaleBegin.Name = "lblSaleBegin";
            lblSaleBegin.Size = new Size(100, 23);
            lblSaleBegin.TabIndex = 10;
            lblSaleBegin.Text = "תאריך התחלה:";
             
            // dtpSaleBegin
             
            dtpSaleBegin.Location = new Point(606, 240);
            dtpSaleBegin.Name = "dtpSaleBegin";
            dtpSaleBegin.Size = new Size(228, 27);
            dtpSaleBegin.TabIndex = 11;
            
            // lblSaleEnd
            
            lblSaleEnd.Location = new Point(500, 280);
            lblSaleEnd.Name = "lblSaleEnd";
            lblSaleEnd.Size = new Size(100, 23);
            lblSaleEnd.TabIndex = 12;
            lblSaleEnd.Text = "תאריך סיום:";
            
            // dtpSaleEnd
             
            dtpSaleEnd.Location = new Point(606, 280);
            dtpSaleEnd.Name = "dtpSaleEnd";
            dtpSaleEnd.Size = new Size(228, 27);
            dtpSaleEnd.TabIndex = 13;
             
            // btnSaleAdd
             
            btnSaleAdd.Location = new Point(500, 330);
            btnSaleAdd.Name = "btnSaleAdd";
            btnSaleAdd.Size = new Size(100, 40);
            btnSaleAdd.TabIndex = 14;
            btnSaleAdd.Text = "הוסף מבצע";
            btnSaleAdd.Click += btnSaleAdd_Click;
             
            // btnSaleUpdate
             
            btnSaleUpdate.Location = new Point(610, 330);
            btnSaleUpdate.Name = "btnSaleUpdate";
            btnSaleUpdate.Size = new Size(100, 40);
            btnSaleUpdate.TabIndex = 15;
            btnSaleUpdate.Text = "עדכן מבצע";
            btnSaleUpdate.Click += btnSaleUpdate_Click;
             
            // btnSaleDelete
             
            btnSaleDelete.Location = new Point(720, 330);
            btnSaleDelete.Name = "btnSaleDelete";
            btnSaleDelete.Size = new Size(100, 40);
            btnSaleDelete.TabIndex = 16;
            btnSaleDelete.Text = "מחק מבצע";
            btnSaleDelete.Click += btnSaleDelete_Click;
             
            // ProductManagementForm
             
            ClientSize = new Size(850, 500);
            Controls.Add(tabControlManager);
            Name = "ProductManagementForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "מערכת ניהול מקיפה - מנהל";
            Load += ProductManagementForm_Load;
            tabControlManager.ResumeLayout(false);
            tabProducts.ResumeLayout(false);
            tabProducts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            tabCustomers.ResumeLayout(false);
            tabCustomers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            tabSales.ResumeLayout(false);
            tabSales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSales).EndInit();
            ResumeLayout(false);
        }

        #endregion
    }
}