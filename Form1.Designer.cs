namespace lw4_part2
{
    partial class Form1
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
            this.aTxtBx = new System.Windows.Forms.TextBox();
            this.bTxtBx = new System.Windows.Forms.TextBox();
            this.cTxtBx = new System.Windows.Forms.TextBox();
            this.aNmrcUD = new System.Windows.Forms.NumericUpDown();
            this.bNmrcUD = new System.Windows.Forms.NumericUpDown();
            this.cNmrcUD = new System.Windows.Forms.NumericUpDown();
            this.aTrckBr = new System.Windows.Forms.TrackBar();
            this.bTrckBr = new System.Windows.Forms.TrackBar();
            this.cTrckBr = new System.Windows.Forms.TrackBar();
            this.aLabel = new System.Windows.Forms.Label();
            this.comp1Label = new System.Windows.Forms.Label();
            this.bLable = new System.Windows.Forms.Label();
            this.comp2Lable = new System.Windows.Forms.Label();
            this.cLable = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.aNmrcUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bNmrcUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cNmrcUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aTrckBr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bTrckBr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTrckBr)).BeginInit();
            this.SuspendLayout();
            // 
            // aTxtBx
            // 
            this.aTxtBx.Location = new System.Drawing.Point(65, 146);
            this.aTxtBx.Name = "aTxtBx";
            this.aTxtBx.Size = new System.Drawing.Size(150, 27);
            this.aTxtBx.TabIndex = 0;
            this.aTxtBx.Text = "0";
            this.aTxtBx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.aTxtBx_KeyDown);
            this.aTxtBx.LostFocus += new System.EventHandler(this.aTxtBx_LostFocus);
            // 
            // bTxtBx
            // 
            this.bTxtBx.Location = new System.Drawing.Point(238, 146);
            this.bTxtBx.Name = "bTxtBx";
            this.bTxtBx.Size = new System.Drawing.Size(150, 27);
            this.bTxtBx.TabIndex = 1;
            this.bTxtBx.Text = "0";
            this.bTxtBx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bTxtBx_KeyDown);
            this.bTxtBx.LostFocus += new System.EventHandler(this.bTxtBx_LostFocus);
            // 
            // cTxtBx
            // 
            this.cTxtBx.Location = new System.Drawing.Point(410, 146);
            this.cTxtBx.Name = "cTxtBx";
            this.cTxtBx.Size = new System.Drawing.Size(150, 27);
            this.cTxtBx.TabIndex = 14;
            this.cTxtBx.Text = "0";
            this.cTxtBx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cTxtBx_KeyDown);
            this.cTxtBx.LostFocus += new System.EventHandler(this.cTxtBx_LostFocus);
            // 
            // aNmrcUD
            // 
            this.aNmrcUD.Location = new System.Drawing.Point(65, 179);
            this.aNmrcUD.Name = "aNmrcUD";
            this.aNmrcUD.Size = new System.Drawing.Size(150, 27);
            this.aNmrcUD.TabIndex = 3;
            this.aNmrcUD.ValueChanged += new System.EventHandler(this.aNmrcUD_ValueChanged);
            // 
            // bNmrcUD
            // 
            this.bNmrcUD.Location = new System.Drawing.Point(238, 179);
            this.bNmrcUD.Name = "bNmrcUD";
            this.bNmrcUD.Size = new System.Drawing.Size(150, 27);
            this.bNmrcUD.TabIndex = 4;
            this.bNmrcUD.ValueChanged += new System.EventHandler(this.bNmrcUD_ValueChanged);
            // 
            // cNmrcUD
            // 
            this.cNmrcUD.Location = new System.Drawing.Point(410, 179);
            this.cNmrcUD.Name = "cNmrcUD";
            this.cNmrcUD.Size = new System.Drawing.Size(150, 27);
            this.cNmrcUD.TabIndex = 5;
            this.cNmrcUD.ValueChanged += new System.EventHandler(this.cNmrcUD_ValueChanged);
            // 
            // aTrckBr
            // 
            this.aTrckBr.Location = new System.Drawing.Point(65, 212);
            this.aTrckBr.Maximum = 100;
            this.aTrckBr.Name = "aTrckBr";
            this.aTrckBr.Size = new System.Drawing.Size(150, 56);
            this.aTrckBr.TabIndex = 6;
            this.aTrckBr.MouseUp += new System.Windows.Forms.MouseEventHandler(this.aTrckBr_MouseUp);
            // 
            // bTrckBr
            // 
            this.bTrckBr.Location = new System.Drawing.Point(238, 212);
            this.bTrckBr.Maximum = 100;
            this.bTrckBr.Name = "bTrckBr";
            this.bTrckBr.Size = new System.Drawing.Size(150, 56);
            this.bTrckBr.TabIndex = 7;
            this.bTrckBr.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bTrckBr_MouseUp);
            // 
            // cTrckBr
            // 
            this.cTrckBr.Location = new System.Drawing.Point(410, 212);
            this.cTrckBr.Maximum = 100;
            this.cTrckBr.Name = "cTrckBr";
            this.cTrckBr.Size = new System.Drawing.Size(150, 56);
            this.cTrckBr.TabIndex = 8;
            this.cTrckBr.MouseUp += new System.Windows.Forms.MouseEventHandler(this.cTrckBr_MouseUp);
            // 
            // aLabel
            // 
            this.aLabel.AutoSize = true;
            this.aLabel.Font = new System.Drawing.Font("Segoe UI", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.aLabel.Location = new System.Drawing.Point(111, 69);
            this.aLabel.Name = "aLabel";
            this.aLabel.Size = new System.Drawing.Size(57, 62);
            this.aLabel.TabIndex = 9;
            this.aLabel.Text = "A";
            // 
            // comp1Label
            // 
            this.comp1Label.AutoSize = true;
            this.comp1Label.Font = new System.Drawing.Font("Segoe UI", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comp1Label.Location = new System.Drawing.Point(174, 69);
            this.comp1Label.Name = "comp1Label";
            this.comp1Label.Size = new System.Drawing.Size(91, 62);
            this.comp1Label.TabIndex = 10;
            this.comp1Label.Text = "<=";
            // 
            // bLable
            // 
            this.bLable.AutoSize = true;
            this.bLable.Font = new System.Drawing.Font("Segoe UI", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bLable.Location = new System.Drawing.Point(282, 69);
            this.bLable.Name = "bLable";
            this.bLable.Size = new System.Drawing.Size(54, 62);
            this.bLable.TabIndex = 11;
            this.bLable.Text = "B";
            // 
            // comp2Lable
            // 
            this.comp2Lable.AutoSize = true;
            this.comp2Lable.Font = new System.Drawing.Font("Segoe UI", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comp2Lable.Location = new System.Drawing.Point(351, 69);
            this.comp2Lable.Name = "comp2Lable";
            this.comp2Lable.Size = new System.Drawing.Size(91, 62);
            this.comp2Lable.TabIndex = 12;
            this.comp2Lable.Text = "<=";
            // 
            // cLable
            // 
            this.cLable.AutoSize = true;
            this.cLable.Font = new System.Drawing.Font("Segoe UI", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cLable.Location = new System.Drawing.Point(458, 69);
            this.cLable.Name = "cLable";
            this.cLable.Size = new System.Drawing.Size(56, 62);
            this.cLable.TabIndex = 13;
            this.cLable.Text = "C";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cLable);
            this.Controls.Add(this.comp2Lable);
            this.Controls.Add(this.bLable);
            this.Controls.Add(this.comp1Label);
            this.Controls.Add(this.aLabel);
            this.Controls.Add(this.cTrckBr);
            this.Controls.Add(this.bTrckBr);
            this.Controls.Add(this.aTrckBr);
            this.Controls.Add(this.cNmrcUD);
            this.Controls.Add(this.bNmrcUD);
            this.Controls.Add(this.aNmrcUD);
            this.Controls.Add(this.cTxtBx);
            this.Controls.Add(this.bTxtBx);
            this.Controls.Add(this.aTxtBx);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.aNmrcUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bNmrcUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cNmrcUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aTrckBr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bTrckBr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTrckBr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox aTxtBx;
        private TextBox bTxtBx;
        private TextBox cTxtBx;
        private NumericUpDown aNmrcUD;
        private NumericUpDown bNmrcUD;
        private NumericUpDown cNmrcUD;
        private TrackBar aTrckBr;
        private TrackBar bTrckBr;
        private TrackBar cTrckBr;
        private Label aLabel;
        private Label comp1Label;
        private Label bLable;
        private Label comp2Lable;
        private Label cLable;
    }
}
