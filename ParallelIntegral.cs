using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace zadanie2vb {
    class ParallelIntegral {
        const int n = 10000000;
        double dx;
        double[] xi = new double[n];
        double[] Pi = new double[n];
        double[] fi = new double[n];

        public double dxOfTrapezoidsP(double x1, double x2) {
            double dx = 0;
            if (x2 < x1) {
                Console.Write("Koniec jest przed początkiem");
            }
            else if (x1 == x2) {
                Console.Write("Poczatek i koniec w tym samym miejscu");
            }
            else
                dx = (x2 - x1) / n;
            return dx;
        }

        public double[] emptyTableP(double[] table, int length) {
            for (int i = 0; i < length; ++i)
                table[i] = 0;
            return table;
        }

        public double[] quadraticFunctionP(double a, double b, double c) {
            for (int i = 0; i < n; ++i) {
                fi[i] = a * xi[i] * xi[i] + b * xi[i] + c;
            }
            return fi;
        }

        public double[] anotherFunctionP(double a, double b, double c) {
            for (int i = 0; i < n; ++i) {
                fi[i] = a * xi[i] * xi[i] * xi[i] + b * xi[i] * xi[i] + c * xi[i];
            }
            return fi;
        }
        public double areaOfTrapezoidsP(double[] fi, double dx) {
            double suma = 0;
            for (int i = 1; i < n; i++)
                Pi[i] = 0.5 * (fi[i - 1] + fi[i]) * dx;
            for (int i = 0; i < n - 1; i++)
                suma = suma + Pi[i];
            return suma;
        }

        public double testFunction(double[] fi, double dx, double[] Pi) {
            double suma=0;
            
            Parallel.For(1, n, i => {
                Pi[i] = 0.5 * (fi[i - 1] + fi[i]) * dx;
            });
            for (int i = 0; i < n - 1; i++)
                suma = suma + Pi[i];
            return suma;
        }

        public double integraleP(double x1, double x2, double a, double b, double c) {

            double suma = 0.0;
            double suma1 = 0.0;
            double dx = 0;

            Parallel.Invoke(() => {
                emptyTableP(xi, n);
            }, () => {
                emptyTableP(Pi, n);
            }, () => {
                emptyTableP(fi, n);
            });

            xi[0] = x1;
            fi[0] = a * x1 * x1 + b * x1 + c;
            dx= dxOfTrapezoidsP(x1, x2);

            Parallel.For(1, n - 1, i => {
                xi[i] = x1 + i * dx;
            });
           /* for (int i = 1; i < n - 1; i++)
                xi[i] = x1 + i * dx;
            */
            
            suma=testFunction(quadraticFunctionP(a, b, c), dx, Pi);
            return suma;
        }
    }
}
