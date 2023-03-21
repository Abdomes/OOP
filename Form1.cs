namespace lw4_part2
{
    public partial class Form1 : Form
    {
        ABC model;
        public Form1()
        {
            InitializeComponent();
            model = new ABC();
            model.observers += new System.EventHandler(this.UpdateFromModel);
            model.Load_Form();
        }


        private void aTxtBx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                model.setValueA(Int32.Parse(aTxtBx.Text));
        }

        private void bTxtBx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                model.setValueB(Int32.Parse(bTxtBx.Text));
        }

        private void cTxtBx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                model.setValueC(Int32.Parse(cTxtBx.Text));
        }

        private void aTxtBx_LostFocus(object sender, System.EventArgs e)
        {
            model.setValueA(Int32.Parse(aTxtBx.Text));
        }
        private void bTxtBx_LostFocus(object sender, System.EventArgs e)
        {
            model.setValueB(Int32.Parse(bTxtBx.Text));
        }
        private void cTxtBx_LostFocus(object sender, System.EventArgs e)
        {
            model.setValueC(Int32.Parse(cTxtBx.Text));
        }

        private void aNmrcUD_ValueChanged(object sender, EventArgs e)
        {
            model.setValueA(Decimal.ToInt32(aNmrcUD.Value));
        }

        private void bNmrcUD_ValueChanged(object sender, EventArgs e)
        {
            model.setValueB(Decimal.ToInt32(bNmrcUD.Value));
        }

        private void cNmrcUD_ValueChanged(object sender, EventArgs e)
        {
            model.setValueC(Decimal.ToInt32(cNmrcUD.Value));
        }

        private void aTrckBr_MouseUp(object sender, MouseEventArgs e)
        {
            model.setValueA(Decimal.ToInt32(aTrckBr.Value));
        }

        private void bTrckBr_MouseUp(object sender, MouseEventArgs e)
        {
            model.setValueB(Decimal.ToInt32(bTrckBr.Value));
        }

        private void cTrckBr_MouseUp(object sender, MouseEventArgs e)
        {
            model.setValueC(Decimal.ToInt32(cTrckBr.Value));
        }

        private void UpdateFromModel(object sender, EventArgs e)
        {
            aTxtBx.Text = model.getValueA().ToString();
            bTxtBx.Text = model.getValueB().ToString();
            cTxtBx.Text = model.getValueC().ToString();

            aNmrcUD.Value = model.getValueA();
            bNmrcUD.Value = model.getValueB();
            cNmrcUD.Value = model.getValueC();

            aTrckBr.Value = model.getValueA();
            bTrckBr.Value = model.getValueB();
            cTrckBr.Value = model.getValueC();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            model.Close_Form();
        }
    }
}
