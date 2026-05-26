namespace UI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

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
            btnManagerArea = new Button();
            btnCashierArea = new Button();
            lblTitle = new Label();
            SuspendLayout();
            
            // btnManagerArea
           
            btnManagerArea.Location = new Point(314, 160);
            btnManagerArea.Name = "btnManagerArea";
            btnManagerArea.Size = new Size(172, 70);
            btnManagerArea.TabIndex = 0;
            btnManagerArea.Text = "כניסת מנהל מערכת";
            btnManagerArea.UseVisualStyleBackColor = true;
            btnManagerArea.Click += btnManagerArea_Click;
            
            // btnCashierArea
             
            btnCashierArea.Location = new Point(314, 260);
            btnCashierArea.Name = "btnCashierArea";
            btnCashierArea.Size = new Size(172, 79);
            btnCashierArea.TabIndex = 1;
            btnCashierArea.Text = "כניסת קופאי\r\n(יצירת הזמנה)";
            btnCashierArea.UseVisualStyleBackColor = true;
            btnCashierArea.Click += btnCashierArea_Click;
             
            // lblTitle
            
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DeepPink;
            lblTitle.Location = new Point(12, 40);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(776, 60);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "GlamStore - חנות איפור וטיפוח";
            lblTitle.TextAlign = ContentAlignment.TopCenter;
           
            // MainForm
            
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblTitle);
            Controls.Add(btnCashierArea);
            Controls.Add(btnManagerArea);
            Name = "MainForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "מערכת ניהול - GlamStore";
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnManagerArea;
        private Button btnCashierArea;
        private Label lblTitle; 
    }
}