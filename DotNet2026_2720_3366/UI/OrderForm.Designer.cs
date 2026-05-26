namespace UI
{
    partial class OrderForm
    {
        private System.ComponentModel.IContainer components = null;

        
        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.Button btnCheckCustomer;
        private System.Windows.Forms.CheckBox chkIsPreferred;
        private System.Windows.Forms.TextBox txtProductId;
        private System.Windows.Forms.NumericUpDown numAmount; 
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.DataGridView dgvProductsOnOrder;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Button btnFinalizeOrder;
        private System.Windows.Forms.Label lblCustIdTag;
        private System.Windows.Forms.Label lblProdIdTag;
        private System.Windows.Forms.Label lblAmountTag;

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
            this.btnCheckCustomer = new System.Windows.Forms.Button();
            this.chkIsPreferred = new System.Windows.Forms.CheckBox();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.numAmount = new System.Windows.Forms.NumericUpDown();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.dgvProductsOnOrder = new System.Windows.Forms.DataGridView();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.btnFinalizeOrder = new System.Windows.Forms.Button();
            this.lblCustIdTag = new System.Windows.Forms.Label();
            this.lblProdIdTag = new System.Windows.Forms.Label();
            this.lblAmountTag = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductsOnOrder)).BeginInit();
            this.SuspendLayout();
            
            // lblCustIdTag
            
            this.lblCustIdTag.Location = new System.Drawing.Point(540, 25);
            this.lblCustIdTag.Size = new System.Drawing.Size(100, 20);
            this.lblCustIdTag.Text = "תעודת זהות לקוח:";
           
            // txtCustomerId
          
            this.txtCustomerId.Location = new System.Drawing.Point(400, 22);
            this.txtCustomerId.Size = new System.Drawing.Size(130, 22);
          
            // btnCheckCustomer
         
            this.btnCheckCustomer.Location = new System.Drawing.Point(280, 20);
            this.btnCheckCustomer.Size = new System.Drawing.Size(110, 26);
            this.btnCheckCustomer.Text = "אימות לקוח";
            this.btnCheckCustomer.Click += new System.EventHandler(this.btnCheckCustomer_Click);
           
            // chkIsPreferred
            
            this.chkIsPreferred.Enabled = false;
            this.chkIsPreferred.Location = new System.Drawing.Point(120, 22);
            this.chkIsPreferred.Size = new System.Drawing.Size(150, 24);
            this.chkIsPreferred.Text = "לקוח מועדון/מועדף";
            
            // lblProdIdTag
            
            this.lblProdIdTag.Location = new System.Drawing.Point(540, 75);
            this.lblProdIdTag.Size = new System.Drawing.Size(100, 20);
            this.lblProdIdTag.Text = "קוד מוצר:";
            
            // txtProductId
            
            this.txtProductId.Location = new System.Drawing.Point(400, 72);
            this.txtProductId.Size = new System.Drawing.Size(130, 22);
            
            // lblAmountTag
           
            this.lblAmountTag.Location = new System.Drawing.Point(540, 115);
            this.lblAmountTag.Size = new System.Drawing.Size(100, 20);
            this.lblAmountTag.Text = "כמות:";
            // numAmount
            
            this.numAmount.Location = new System.Drawing.Point(400, 113);
            this.numAmount.Size = new System.Drawing.Size(130, 22);
            this.numAmount.Minimum = new decimal(new int[] { 1, 0, 0, 0 }); // הגנה: כמות מינימלית 1
            this.numAmount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            
            // btnAddProduct
           
            this.btnAddProduct.Location = new System.Drawing.Point(400, 155);
            this.btnAddProduct.Size = new System.Drawing.Size(240, 35);
            this.btnAddProduct.Text = "הוסף מוצר לסל";
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
          
            // dgvProductsOnOrder
            
            this.dgvProductsOnOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductsOnOrder.Location = new System.Drawing.Point(12, 72);
            this.dgvProductsOnOrder.Size = new System.Drawing.Size(360, 260);
           
            // lblTotalPrice
           
            this.lblTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalPrice.Location = new System.Drawing.Point(12, 345);
            this.lblTotalPrice.Size = new System.Drawing.Size(360, 25);
            this.lblTotalPrice.Text = "סכום סופי לתשלום: 0.00 ₪";
         
            // btnFinalizeOrder
          
            this.btnFinalizeOrder.BackColor = System.Drawing.Color.LightGreen;
            this.btnFinalizeOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnFinalizeOrder.Location = new System.Drawing.Point(400, 335);
            this.btnFinalizeOrder.Size = new System.Drawing.Size(240, 45);
            this.btnFinalizeOrder.Text = "בצע הזמנה (DoOrder)";
            this.btnFinalizeOrder.Click += new System.EventHandler(this.btnFinalizeOrder_Click);
            
            // OrderForm
           
            this.ClientSize = new System.Drawing.Size(660, 400);
            this.Controls.Add(this.lblCustIdTag);
            this.Controls.Add(this.txtCustomerId);
            this.Controls.Add(this.btnCheckCustomer);
            this.Controls.Add(this.chkIsPreferred);
            this.Controls.Add(this.lblProdIdTag);
            this.Controls.Add(this.txtProductId);
            this.Controls.Add(this.lblAmountTag);
            this.Controls.Add(this.numAmount);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.dgvProductsOnOrder);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.btnFinalizeOrder);
            this.Name = "OrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "קופאי - בניית הזמנה חדשה";
            this.Load += new System.EventHandler(this.OrderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductsOnOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}