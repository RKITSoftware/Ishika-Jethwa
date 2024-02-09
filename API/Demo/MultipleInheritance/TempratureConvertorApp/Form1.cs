using System;
using System.Windows.Forms;
using TemperatureConverterLibrary;

namespace TempratureConvertorApp
{
    public partial class Form1 : Form
    {
        TemperatureConverter calc = new TemperatureConverter();
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            char fromTemp = 'F';
            char toTemp = 'F';

            if (radio_F.Checked) fromTemp = 'F';
            if (radio_C.Checked) fromTemp = 'C';
            if (radio_K.Checked) fromTemp = 'K';
            if (radio_ToF.Checked) fromTemp = 'F';
            if (radio_ToC.Checked) fromTemp = 'C';
            if (radio_ToK.Checked) fromTemp = 'K';

            switch (fromTemp)
            {
                case 'C':
                    switch (toTemp)
                    {
                        case 'F':
                            label_answer.Text = "Answer = " + calc.CelsiusToFahrenheit(double.Parse(textBox1.Text)).ToString();
                            break;
                           
                    }
                    break;

                case 'F':
                    switch (toTemp)
                    {
                        case 'C':
                            label_answer.Text = "Answer = " + calc.FahrenheitToCelsius(double.Parse(textBox1.Text)).ToString();
                            break;
                            
                    }
                    break;

                case 'K':
                    switch (toTemp)
                    {
                        case 'C':
                            label_answer.Text = "Answer = " + calc.KelvinToCelsius(double.Parse(textBox1.Text)).ToString();
                            break;
                           
                    }
                    break;

            }



        }
    }
}
