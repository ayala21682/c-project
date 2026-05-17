namespace UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnManagerArea = new Button();
            btnCashierArea = new Button();
            SuspendLayout();
            // 
            // btnManagerArea
            // 
            btnManagerArea.Location = new Point(274, 119);
            btnManagerArea.Name = "btnManagerArea";
            btnManagerArea.Size = new Size(172, 70);
            btnManagerArea.TabIndex = 0;
            btnManagerArea.Text = "כניסת מנהל מערכת";
            btnManagerArea.UseVisualStyleBackColor = true;
            btnManagerArea.Click += btnManagerArea_Click;
            // 
            // btnCashierArea
            // 
            btnCashierArea.Location = new Point(274, 232);
            btnCashierArea.Name = "btnCashierArea";
            btnCashierArea.Size = new Size(172, 79);
            btnCashierArea.TabIndex = 1;
            btnCashierArea.Text = "כניסת קופאי (יצירת הזמנה)";
            btnCashierArea.UseVisualStyleBackColor = true;
            btnCashierArea.Click += btnCashierArea_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCashierArea);
            Controls.Add(btnManagerArea);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
        }

        #endregion

        private Button btnManagerArea;
        private Button btnCashierArea;
    }
}