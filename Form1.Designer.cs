namespace lw_part1
{
    partial class frm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrlChckBx = new System.Windows.Forms.CheckBox();
            this.CrossChckBx = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // ctrlChckBx
            // 
            this.ctrlChckBx.AutoSize = true;
            this.ctrlChckBx.Location = new System.Drawing.Point(23, 11);
            this.ctrlChckBx.Name = "ctrlChckBx";
            this.ctrlChckBx.Size = new System.Drawing.Size(64, 24);
            this.ctrlChckBx.TabIndex = 0;
            this.ctrlChckBx.Text = "CTRL";
            this.ctrlChckBx.UseVisualStyleBackColor = true;
            // 
            // CrossChckBx
            // 
            this.CrossChckBx.AutoSize = true;
            this.CrossChckBx.Location = new System.Drawing.Point(23, 41);
            this.CrossChckBx.Name = "CrossChckBx";
            this.CrossChckBx.Size = new System.Drawing.Size(87, 24);
            this.CrossChckBx.TabIndex = 1;
            this.CrossChckBx.Text = "Сrossing";
            this.CrossChckBx.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.Location = new System.Drawing.Point(130, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(667, 452);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CrossChckBx);
            this.Controls.Add(this.ctrlChckBx);
            this.KeyPreview = true;
            this.Name = "frm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frm_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckBox ctrlChckBx;
        private CheckBox CrossChckBx;
        private Panel panel1;
    }
}
