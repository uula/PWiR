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


namespace zadanie2vb {
    public partial class formCalka : Form {
        public const int n = 10000000;
        private double integraleP;
        public formCalka() {
            InitializeComponent();
        }

        private void buttonCount_Click(object sender, EventArgs e) {
            try {
                double a, b, c, x1, x2;
                double integrale;
                double[] fi = new double[n];
                double[] xi = new double[n];
                Integral i = new Integral();
                ParallelIntegral iP = new ParallelIntegral();
                DrawClass d = new DrawClass();
                Stopwatch s1 = new Stopwatch();
                Stopwatch s2 = new Stopwatch();

            
                    a = Convert.ToDouble(textBoxA.Text);
                    b = Convert.ToDouble(textBoxB.Text);
                    c = Convert.ToDouble(textBoxC.Text);
                    x1 = Convert.ToDouble(textBoxX1.Text);
                    x2 = Convert.ToDouble(textBoxX2.Text);
                 

                        lFunction.Text = "f(x)=" + a + "x^2+" + b + "x+" + c;

                        s1.Start();
                        integrale = i.integrale(x1, x2, a, b, c);
                        s1.Stop();

                        s2.Start();
                        integraleP = iP.integraleP(x1, x2, a, b, c);
                        s2.Stop();

                        lTimeParC.Text = Convert.ToString(s2.ElapsedMilliseconds) + "ms";
                        lTimeNoPaC.Text = Convert.ToString(s1.ElapsedMilliseconds) + "ms";
                        labelIntegral.Text = Convert.ToString(integrale);

                        fi = i.quadraticFunction(a, b, c);
                        xi = i.nextPoint(x1, x2, i.dxOfTrapezoids(x1, x2));

                        lParallel.Text = Convert.ToString(d.integralFunction(fi, xi, pictureBox1, x1, x2)) + "ms";
                        lnTime.Text = Convert.ToString(d.drawIntegralFunctionNoParallel(fi, xi, pictureBox2, x1, x2)) + "ms";
                    
            }
            catch (Exception) {
                MessageBox.Show("Wczytywane wartości nieprawidłowe!");
                textBoxA.Text = "";
                textBoxB.Text = "";
                textBoxC.Text = "";
                textBoxX1.Text = "";
                textBoxX2.Text = "";
                labelIntegral.Text = "";
                lFunction.Text = "";
                lTimeParC.Text = "";
                lTimeNoPaC.Text = "";
                lnTime.Text = "";
               // lnParallelT.Text = "";
                pictureBox1.Refresh();
                pictureBox2.Refresh();
            }
        }

        private void buttonReset_Click(object sender, EventArgs e) {
            textBoxA.Text = "";
            textBoxB.Text = "";
            textBoxC.Text = "";
            textBoxX1.Text = "";
            textBoxX2.Text = "";
            labelIntegral.Text = "";
            lFunction.Text = "";
            lTimeParC.Text = "";
            lTimeNoPaC.Text = "";
            lnTime.Text = "";
            lnParallelT.Text = "";
            pictureBox1.Refresh();
            pictureBox2.Refresh();
        }

        private void label4_Click(object sender, EventArgs e) {

        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e) {

        }

    }
}
