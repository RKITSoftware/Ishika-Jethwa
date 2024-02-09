using System;
using System.Windows.Forms;
using TempratureLibrary;

namespace Temprature
{
    public partial class Form1 : Form
    {
        TempratureClass calc = new TempratureClass();
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
            if (radio_ToF.Checked) toTemp = 'F';
            if (radio_ToC.Checked) toTemp = 'C';
            if (radio_ToK.Checked) toTemp = 'K';

            switch (fromTemp)
            {
                case 'C':
                    switch (toTemp)
                    {
                        case 'F':
                            label_answer.Text = "Answer = " + calc.CelsiusToFahrenheit(double.Parse(textBox1.Text)).ToString();
                            break;
                        case 'K':
                            label_answer.Text = "Answer = " + calc.CelsiusToKelvin(double.Parse(textBox1.Text)).ToString();
                            break;

                    }
                    break;

                case 'F':
                    switch (toTemp)
                    {
                        case 'C':
                            label_answer.Text = "Answer = " + calc.FahrenheitToCelsius(double.Parse(textBox1.Text)).ToString();
                            break;
                        case 'K':
                            label_answer.Text = "Answer = " + calc.FahrenheitToKelvin(double.Parse(textBox1.Text)).ToString();
                            break;

                    }
                    break;

                case 'K':
                    switch (toTemp)
                    {
                        case 'C':
                            label_answer.Text = "Answer = " + calc.KelvinToCelsius(double.Parse(textBox1.Text)).ToString();
                            break;
                        case 'F':
                            label_answer.Text = "Answer = " + calc.KelvinToFahrenheit(double.Parse(textBox1.Text)).ToString();
                            break;

                    }
                    break;

            }

        }
    }
}
