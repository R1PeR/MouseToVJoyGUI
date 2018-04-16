using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace MouseToVjoyGUI
{
    public partial class Form1 : Form
    {
        Reader reader = new Reader(22);
        Double centerMultiplier;
        TextBox[] textBoxes;
        Process mtvj = new Process();
        public Form1()
        {
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            InitializeComponent();
            textBoxes = new TextBox[] { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10, textBox11, textBox12, textBox13, textBox14, textBox15, textBox16, textBox17, textBox18, textBox19};
            reader.readFile("config.txt");
            textBox1.Text = "" + reader.getData(0);
            textBox2.Text = "" + reader.getData(1);
            textBox3.Text = "" + reader.getData(2);
            textBox4.Text = "" + reader.getData(3);
            textBox5.Text = "" + reader.getData(4);
            textBox6.Text = "" + reader.getData(5);
            textBox7.Text = "" + reader.getData(6);
            textBox8.Text = "" + reader.getData(7);
            textBox9.Text = "" + reader.getData(8);
            textBox10.Text = "" + reader.getData(9);
            textBox11.Text = "" + reader.getData(10);
            textBox12.Text = "" + reader.getData(11);
            textBox13.Text = "" + reader.getData(12);
            textBox14.Text = "" + reader.getData(13);
            textBox15.Text = "" + reader.getData(14);
            checkedListBox1.SetItemChecked(0, Convert.ToBoolean(reader.getData(15)));
            checkedListBox1.SetItemChecked(1, Convert.ToBoolean(reader.getData(16)));
            checkedListBox1.SetItemChecked(2, Convert.ToBoolean(reader.getData(17)));
            textBox16.Text = "" + reader.getData(18);
            textBox17.Text = "" + reader.getData(19);
            textBox18.Text = "" + reader.getData(20);
            textBox19.Text = "" + reader.getData(21);
            chart1.ChartAreas[0].AxisX.Maximum = 100;
            chart1.ChartAreas[0].AxisX.Minimum = -100;
            chart1.Series["Series1"].Points.Clear();
            for (int i = 0; i < 19; i++)
            {
                Console.WriteLine(i + " " + reader.getData(i));
            }
            try
            {
                for (double x = -100; x < 100; x++)
                {

                    if (checkedListBox1.GetItemChecked(1))
                    {
                        if (x > 0)
                        {
                            centerMultiplier = Math.Pow(reader.getData(21), (1 - (x / 100)));
                            chart1.Series["Series1"].Points.AddXY(x, (reader.getData(0) / centerMultiplier));
                        }
                        else if (x < 0)
                        {
                            centerMultiplier = Math.Pow(reader.getData(21), (1 - (x / -100)));
                            chart1.Series["Series1"].Points.AddXY(x, reader.getData(0) / centerMultiplier);
                        }
                    }
                    else
                    {
                        if (x > 0)
                        {
                            chart1.Series["Series1"].Points.AddXY(x, reader.getData(0));
                        }
                        else if (x < 0)
                        {
                            chart1.Series["Series1"].Points.AddXY(x, reader.getData(0));
                        }

                    }
                }
            }
            catch (DivideByZeroException)
            {

            }
            mtvj.StartInfo.FileName = "MouseToVJoy.exe";
            mtvj.StartInfo.Arguments = "-noconsole";

        }

        private void onTextEnterWithDot(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != '.') {
                e.Handled = true;
            }
        }
        private void onTextEnter(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1 != null)
            {
                if (button1.Text == "ON")
                {
                    button1.Text = "OFF";
                    try
                    {
                        mtvj.Kill();
                    }
                    catch (InvalidOperationException) {

                    }
                    
                    for(int i = 0; i < 19; i++)
                    {
                        textBoxes[i].Enabled = true;
                    }
                }
                else if (button1.Text == "OFF")
                {
                    button1.Text = "ON";
                    for (int i = 0; i < 19; i++)
                    {
                        textBoxes[i].Enabled = false;
                    }
                    for(int i = 0;i < 19; i++)
                    {
                        Console.WriteLine(i +" " + reader.getData(i));
                    }
                    reader.setData(0, Convert.ToDouble(textBox1.Text));
                    reader.setData(1, Convert.ToDouble(textBox2.Text));
                    reader.setData(2, Convert.ToDouble(textBox3.Text));
                    reader.setData(3, Convert.ToDouble(textBox4.Text));
                    reader.setData(4, Convert.ToDouble(textBox5.Text));
                    reader.setData(5, Convert.ToDouble(textBox6.Text));
                    reader.setData(6, Convert.ToDouble(textBox7.Text));
                    reader.setData(7, Convert.ToDouble(textBox8.Text));
                    reader.setData(8, Convert.ToDouble(textBox9.Text));
                    reader.setData(9, Convert.ToDouble(textBox10.Text));
                    reader.setData(10, Convert.ToDouble(textBox11.Text));
                    reader.setData(11, Convert.ToDouble(textBox12.Text));
                    reader.setData(12, Convert.ToDouble(textBox13.Text));
                    reader.setData(13, Convert.ToDouble(textBox14.Text));
                    reader.setData(14, Convert.ToDouble(textBox15.Text));
                    reader.setData(15, Convert.ToInt16(checkedListBox1.GetItemCheckState(0)));
                    reader.setData(16, Convert.ToInt16(checkedListBox1.GetItemCheckState(1)));
                    reader.setData(17, Convert.ToInt16(checkedListBox1.GetItemCheckState(2)));
                    reader.setData(18, Convert.ToDouble(textBox16.Text));
                    reader.setData(19, Convert.ToDouble(textBox17.Text));
                    reader.setData(20, Convert.ToDouble(textBox18.Text));
                    reader.setData(21, Convert.ToDouble(textBox19.Text));
                    reader.writeFile("config.txt");
                    try {
                        mtvj.Start();
                    }
                    catch (Win32Exception) {
                        MessageBox.Show("Could not find MouseToVJoy.exe", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } 
                }
            }
        }

        private void onChange(object sender, EventArgs e)
        {
            
            chart1.Series["Series1"].Points.Clear();
            try
            {
                try
                {
                    reader.setData(0, Double.Parse(textBox1.Text));
                    reader.setData(21, Double.Parse(textBox19.Text));
                }
                catch (FormatException) {
                }
                for (double x = -100; x < 100; x++)
                {
             
                    if (checkedListBox1.GetItemChecked(1))
                    {
                        if (x > 0)
                        {
                            centerMultiplier = Math.Pow(reader.getData(21), (1 - (x / 100)));
                            chart1.Series["Series1"].Points.AddXY(x, (reader.getData(0) / centerMultiplier));
                        }
                        else if (x < 0)
                        {
                            centerMultiplier = Math.Pow(reader.getData(21), (1 - (x / -100)));
                            chart1.Series["Series1"].Points.AddXY(x, reader.getData(0) / centerMultiplier);
                        }
                    }
                    else
                    {
                        if (x > 0)
                        {
                            chart1.Series["Series1"].Points.AddXY(x, reader.getData(0));
                        }
                        else if (x < 0)
                        {
                            chart1.Series["Series1"].Points.AddXY(x, reader.getData(0));
                        }
                    }
    
                }
            }
                catch (DivideByZeroException)
            {

            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                mtvj.Kill();
            }
            catch (InvalidOperationException)
            {

            }
        }
    }
}
