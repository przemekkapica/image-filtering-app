using System;
using System.Windows.Forms;

namespace image_filtering_app
{
    public partial class FilterSettings : Form
    {
        public FilterSettings()
        {
            InitializeComponent();

            numericUpDown1.Value = (decimal)FilterValues.gammaValue;
            numericUpDown2.Value = (decimal)FilterValues.brightnessValue;
            numericUpDown3.Value = (decimal)FilterValues.contrastValue;
            numericUpDown4.Value = FilterValues.inversionValue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FilterValues.gammaValue = (double)numericUpDown1.Value;
            FilterValues.brightnessValue = (double)numericUpDown2.Value;
            FilterValues.contrastValue = (double)numericUpDown3.Value;
            FilterValues.inversionValue = (int)numericUpDown4.Value;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ConstantsEditor_Load(object sender, EventArgs e)
        {

        }
    }
}
