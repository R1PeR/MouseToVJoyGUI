using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseToVjoyGUI
{
    class Reader
    {
        public double[] data;

        public Reader(int sizeData) {
            data = new double[sizeData];
        }
        public void readFile(String fileName) {
            try
            {
                StreamReader fileStream = new StreamReader(fileName);
                String line;
                int i = 0;
                while ((line = fileStream.ReadLine()) != null && i < data.Length)
                {
                    line = line.Substring(line.LastIndexOf(" ")+1);
                    try
                    {
                        data[i] = double.Parse(line);
                    }
                    catch (FormatException) {
                        MessageBox.Show("Wrong format on config.txt - line:"+i, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    i++;
                }
                fileStream.Close();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Could not find config.txt", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void writeFile(String fileName) {
            FileStream fileStream = new FileStream(fileName, FileMode.Create);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            streamWriter.WriteLine("Sensitivity = " + getData(0));
            streamWriter.WriteLine("AttackTimeThrottle = " + getData(1));
            streamWriter.WriteLine("ReleaseTimeThrottle = " + getData(2));
            streamWriter.WriteLine("AttackTimeBreak = " + getData(3));
            streamWriter.WriteLine("ReleaseTimeBreak = " + getData(4));
            streamWriter.WriteLine("AttackTimeClutch = " + getData(5));
            streamWriter.WriteLine("ReleaseTimeClutch = " + getData(6));
            streamWriter.WriteLine("ThrottleKey = " + getData(7));
            streamWriter.WriteLine("BreakKey = " + getData(8));
            streamWriter.WriteLine("ClutchKey = " + getData(9));
            streamWriter.WriteLine("GearShiftUpKey = " + getData(10));
            streamWriter.WriteLine("GearShiftDownKey = " + getData(11));
            streamWriter.WriteLine("HandBrakeKey = " + getData(12));
            streamWriter.WriteLine("MouseLockKey = " + getData(13));
            streamWriter.WriteLine("MouseCenterKey = " + getData(14));
            streamWriter.WriteLine("UseMouse = " + getData(15));
            streamWriter.WriteLine("UseCenterReduction = " + getData(16));
            streamWriter.WriteLine("UseForceFeedback = " + getData(17));
            streamWriter.WriteLine("UseWheelAsShifter = " + getData(18));
            streamWriter.WriteLine("AccelerationThrottle = " + getData(19));
            streamWriter.WriteLine("AccelerationBreak = " + getData(20));
            streamWriter.WriteLine("AccelerationClutch = " + getData(21));
            streamWriter.WriteLine("CenterMultiplier = " + getData(22));
            streamWriter.WriteLine("\n");
            streamWriter.WriteLine("Use keycodes from 0 TO 165");
            streamWriter.WriteLine("\n");
            streamWriter.WriteLine("http://keycode.info");
            streamWriter.Close();
            fileStream.Close();
        }
        public double getData(int n){
            return data[n];
        }
        public void setData(int n, double number) {

            data[n] = number;

        }
    }
}
