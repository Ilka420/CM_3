double[] first = X(); 
double[] second = Fn(first);
Console.WriteLine("Коэффициенты матрицы:"); 
NK(first, second);
Console.WriteLine();
Enter:
Lag(first, second); 

    static double[] X()
    {

    double[] x = new double[14]; 
        for (int i = 0; i < 14; i++)
        {
            x[i] = 0.02 * i;
            Console.WriteLine($"x{i + 1} = {x[i]}");
        }

    Console.WriteLine("\n"); 
    return x;

    }

    static double[] Fn(double[] x)

    {
        double[] f = new double[14]; 

        for (int i = 0; i < 14; i++)
    {   
        f[i] = Math.Sin(1.8 * x[i] * x[i] + 2.12);
        Console.WriteLine($"F(x{i + 1}) = {Math.Round(f[i], 4)}");
    }

    Console.WriteLine("\n"); 
    return f;

    }

static double Lag(double[] aX, double[] aFunc)

{

Console.Write("Введите одно из значений x: "); double x = double.Parse(Console.ReadLine()); Console.Write("Введите номер узла: ");

int z = int.Parse(Console.ReadLine());

double L, f, a;

if ((z == 1) || (z == 14))

{

    L = aFunc[z - 1];
    f = aFunc[z - 1];

    a = 2.8675 * aX[z - 1] * aX[z - 1] + 0.1133 * aX[z - 1];

    Console.WriteLine($"L = {Math.Round(L, 4)}"); 
    Console.WriteLine($"F{z} = {Math.Round(f, 4)}"); 
    Console.WriteLine($"f{z} = {Math.Round(a, 4)}");

}

else

{

double s1 = ((x - aX[z - 1]) * (x - aX[z])) / ((aX[z - 2] - aX[z - 1]) * (aX[z - 2] - aX[z])) * aFunc[z - 2];

double s2 = ((x - aX[z - 2]) * (x - aX[z])) / ((aX[z - 1] - aX[z - 2]) * (aX[z - 1] - aX[z])) *

aFunc[z - 1];

double s3 = ((x - aX[z - 2]) * (x - aX[z - 1])) / ((aX[z] - aX[z - 2]) * (aX[z] - aX[z - 1])) * aFunc[z];

L = s1 + s2 + s3; f = aFunc[z - 1];

a = 2.8675 * aX[z - 1] * aX[z - 1] + 0.1133 * aX[z - 1] + 1.0619;

Console.WriteLine($"L = {Math.Round(L, 4)}"); Console.WriteLine($"F{z} = {Math.Round(f, 4)}"); Console.WriteLine($"f{z} = {Math.Round(a, 4)}");

}

Console.WriteLine("\n"); return L;

}

static void NK(double[] aX, double[] aFunc)

{

    double[] A1 = new double[3] { 0, 0, 0 };
    double[] A2 = new double[3] { 0, 0, 0 };
    double[] A3 = new double[3] { 0, 0, 0 };
    double[] B = new double[3] { 0, 0, 0 };

    for (int i = 0; i < 14; i++)

    {

        int n = 0;

        for (int j = 2; j >= 0; j--)

        {

            A1[n] = A1[n] + Math.Pow(aX[i], 2) *

                Math.Pow(aX[i], j);

            A2[n] = A2[n] + Math.Pow(aX[i], 1) *

                Math.Pow(aX[i], j);

            A3[n] = A3[n] + Math.Pow(aX[i], j);

            B[n] = B[n] + aFunc[i] * Math.Pow(aX[i], j);
            n++;

        }

    }

    double[] Stroka1 = new double[3] { 0, 0, 0 };
    double[] Stroka2 = new double[3] { 0, 0, 0 };
    double[] Stroka3 = new double[3] { 0, 0, 0 };
    double[] Stroka4 = new double[3] { 0, 0, 0 };
    for (int k = 0; k < 3; k++)
    {

        Stroka1[k] = 2 * A1[k];

        Stroka2[k] = 2 * A2[k];

        Stroka3[k] = 2 * A3[k];

        Stroka4[k] = 2 * B[k];

    }

    Console.Write($"{Math.Round(Stroka1[0], 4)}\t");
    for (int k = 1; k < 3; k++)

    {

        Console.Write($"{Math.Round(Stroka1[k], 4)}\t");

    }

    Console.WriteLine();

    for (int k = 0; k < 3; k++)

    {

        Console.Write($"{Math.Round(Stroka2[k], 4)}\t");

    }

    Console.WriteLine();

    for (int k = 0; k < 3; k++)

    {

        Console.Write($"{Math.Round(Stroka3[k], 4)}\t");

    }

    Console.WriteLine("\n");
    Console.WriteLine("Свободные члены: ");

    for (int k = 0; k < 3; k++)

    {

        Console.Write($"{Math.Round(Stroka4[k], 4)}\t");

    }
    Console.WriteLine();
}