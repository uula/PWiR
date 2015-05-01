using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie2vb {
    class Integral {
        const int n = 10000000;
       // const int n = 10;
        double dx;
        double[] xi = new double[n];
        double[] Pi =new double[n];
        double[] fi= new double[n];


    public double[] nextPoint(double x1, double x2, double dx){
	    xi[0] = x1;
	    for (int i = 1; i < n - 1; i++)
		    xi[i] = x1 + i*dx;
	    return xi;
    }
    public double[] emptyTable(double[] table, int length){
	    for (int i = 0; i < length; ++i)
		    table[i] = 0;
	    return table;
    }
    public double dxOfTrapezoids(double x1, double x2){
        double dx=0;
	    if (x2 < x1){
            Console.Write("Koniec jest przed początkiem");
	    }
	    else if (x1 == x2){
            Console.Write("Poczatek i koniec w tym samym miejscu");
	    }
	    else
		    dx = (x2 - x1) / n;
	    return dx;
    }
    public double[] quadraticFunction(double a, double b, double c){
	    for (int i = 0; i < n; ++i){
		    fi[i] = a*xi[i] * xi[i] + b*xi[i] + c;
	    }
	    return fi;
    }

    public double[] anotherFunction(double a, double b, double c){
	    for (int i = 0; i < n; ++i){
		    fi[i] = a*xi[i] * xi[i] * xi[i] + b*xi[i] * xi[i] + c*xi[i];
	    }
	    return fi;
    }
    public double areaOfTrapezoids(double[] fi, double dx){
	    double suma = 0;
	    for (int i = 1; i < n; i++)
		    Pi[i] = 0.5*(fi[i - 1] + fi[i])*dx;
	    for (int i = 0; i < n - 1; i++)
		    suma = suma + Pi[i];
	    return suma;
    }
    public double integrale(double x1, double x2, double a, double b, double c){
	    double suma = 0.0;
	    emptyTable(xi, n);
	    emptyTable(Pi, n);
	    emptyTable(fi, n);
        dx = dxOfTrapezoids(x1, x2);
		nextPoint(x1, x2, dx);
		suma = areaOfTrapezoids(quadraticFunction(a, b, c), dx);
		return suma;
	 }

    }
}
