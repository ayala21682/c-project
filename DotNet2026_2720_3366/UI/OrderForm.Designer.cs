namespace UI
{
    partial class OrderForm
    {
        private System.ComponentModel.IContainer components = null;

        // הגדרת הרכיבים הגרפיים של מסך ההזמנה
        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.CheckBox chkIsPreferred;
        private System.Windows.Forms.Button btnCheckCustomer;
        private System.Windows.Forms.TextBox txtProductId;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.DataGridView dgvProductsOnOrder;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Button btnFinalizeOrder;
        private System.Windows.Forms.Label lblCustId;
        private System.Windows.Forms.Label lblProdId;
        private System.Windows.Forms.Label lblAmt;

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
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            this.chkIsPreferred = new System.Windows.Forms.CheckBox();
            this.btnCheckCustomer = new System.Windows.Forms.Button();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.dgvProductsOnOrder = new System.Windows.Forms.DataGridView();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.btnFinalizeOrder = new System.Windows.Forms.Button();
            this.lblCustId = new System.Windows.Forms.Label();
            this.lblProdId = new System.Windows.Forms.Label();
            this.lblAmt = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductsOnOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // אזור זיהוי לקוח
            // 
            this.lblCustId.Location = new System.Drawing.Point(12, 20); this.lblCustId.Text = "תעודת זהות לקוח:";
            this.txtCustomerId.Location = new System.Drawing.Point(140, 20); this.txtCustomerId.Size = new System.Drawing.Size(120, 22);

            this.btnCheckCustomer.Location = new System.Drawing.Point(270, 17); this.btnCheckCustomer.Size = new System.Drawing.Size(110, 28);
            this.btnCheckCustomer.Text = "בדוק לקוח";
            this.btnCheckCustomer.Click += new System.EventHandler(this.btnCheckCustomer_Click);

            this.chkIsPreferred.Location = new System.Drawing.Point(390, 20); this.chkIsPreferred.Size = new System.Drawing.Size(150, 24);
            this.chkIsPreferred.Text = "לקוח מועדף / חבר מועדון";
            this.chkIsPreferred.Enabled = false;
            // 
            // אזור הוספת מוצרים
            // 
            this.lblProdId.Location = new System.Drawing.Point(12, 70); this.lblProdId.Text = "קוד מוצר להוספה:";
            this.txtProductId.Location = new System.Drawing.Point(140, 70); this.txtProductId.Size = new System.Drawing.Size(120, 22);

            this.lblAmt.Location = new System.Drawing.Point(270, 70); this.lblAmt.Text = "כמות:";
            this.txtAmount.Location = new System.Drawing.Point(320, 70); this.txtAmount.Size = new System.Drawing.Size(60, 22);

            this.btnAddProduct.Location = new System.Drawing.Point(390, 67); this.btnAddProduct.Size = new System.Drawing.Size(130, 28);
            this.btnAddProduct.Text = "הוסף לסל הקניות";
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // טבלת תצוגת פריטים בהזמנה
            // 
            this.dgvProductsOnOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductsOnOrder.Location = new System.Drawing.Point(12, 120);
            this.dgvProductsOnOrder.Name = "dgvProductsOnOrder";
            this.dgvProductsOnOrder.Size = new System.Drawing.Size(760, 240);
            this.dgvProductsOnOrder.TabIndex = 6;
            // 
            // סיכום וסגירה
            // 
            this.lblTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalPrice.Location = new System.Drawing.Point(12, 385);
            this.lblTotalPrice.Size = new System.Drawing.Size(400, 30);
            this.lblTotalPrice.Text = "סכום סופי לתשלום: 0.00 ₪";

            this.btnFinalizeOrder.Location = new System.Drawing.Point(572, 375);
            this.btnFinalizeOrder.Size = new System.Drawing.Size(200, 45);
            this.btnFinalizeOrder.Text = "בצע הזמנה (DoOrder)";
            this.btnFinalizeOrder.Click += new System.EventHandler(this.btnFinalizeOrder_Click);
            // 
            // OrderForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblCustId); this.Controls.Add(this.txtCustomerId); this.Controls.Add(this.btnCheckCustomer); this.Controls.Add(this.chkIsPreferred);
            this.Controls.Add(this.lblProdId); this.Controls.Add(this.txtProductId); this.Controls.Add(this.lblAmt); this.Controls.Add(this.txtAmount); this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.dgvProductsOnOrder);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.btnFinalizeOrder);
            this.Name = "OrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "עמדת מכירה - בניית הזמנה חדשה";
            this.Load += new System.EventHandler(this.OrderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductsOnOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}