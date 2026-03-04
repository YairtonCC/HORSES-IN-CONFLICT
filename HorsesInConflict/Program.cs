using System;


class HorsesInConflict
{
    public static void Main(string[] args)
    {
        Console.Write("Ingrese ubicación de los caballos: ");
        string cab = Console.ReadLine();

        int[,] tab = new int[8, 8];
        int[,] pos = new int[64, 2];
        int tope = 0;

        string[] caballos = cab.Split(',');

        foreach (string c in caballos)
        {
            string trimmed = c.Trim();
            if (trimmed.Length < 2) continue;

            char col = trimmed[0];
            char fil = trimmed[1];

            tab[Ef(fil), Ec(col)] = 1;
            pos[tope, 0] = Ef(fil);
            pos[tope, 1] = Ec(col);
            tope++;
        }

        Show(tab);

        for (int i = 0; i < tope; i++)
        {
            Console.Write("\nAnalizando Caballo en "
                + EfInv(pos[i, 0]) + EcInv(pos[i, 1]) + " => ");

            bool conflicto = false;

            int[,] movimientos = {
                { -2, -1 }, { -2, 1 }, { -1, -2 }, { -1, 2 },
                { 1, -2 }, { 1, 2 }, { 2, -1 }, { 2, 1 }
            };

            for (int m = 0; m < movimientos.GetLength(0); m++)
            {
                int fil = pos[i, 0] + movimientos[m, 0];
                int col = pos[i, 1] + movimientos[m, 1];

                if (fil >= 0 && fil <= 7 && col >= 0 && col <= 7)
                {
                    if (tab[fil, col] == 1)
                    {
                        Console.Write("Conflicto con "
                            + EfInv(fil) + EcInv(col) + "\t");
                        conflicto = true;
                    }
                }
            }

            if (!conflicto)
                Console.Write("");
        }
    }

    public static void Show(int[,] tab)
    {
        Console.WriteLine("  0 1 2 3 4 5 6 7");
        for (int i = 0; i < 8; i++)
        {
            Console.Write(i + " ");
            for (int j = 0; j < 8; j++)
            {
                Console.Write(tab[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    public static int Ef(char f)
    {
        switch (f)
        {
            case '8': return 0;
            case '7': return 1;
            case '6': return 2;
            case '5': return 3;
            case '4': return 4;
            case '3': return 5;
            case '2': return 6;
            default: return 7;
        }
    }

    public static int Ec(char c)
    {
        switch (c)
        {
            case 'A': return 0;
            case 'B': return 1;
            case 'C': return 2;
            case 'D': return 3;
            case 'E': return 4;
            case 'F': return 5;
            case 'G': return 6;
            default: return 7;
        }
    }

    public static char EfInv(int f)
    {
        switch (f)
        {
            case 0: return '8';
            case 1: return '7';
            case 2: return '6';
            case 3: return '5';
            case 4: return '4';
            case 5: return '3';
            case 6: return '2';
            default: return '1';
        }
    }

    public static char EcInv(int c)
    {
        switch (c)
        {
            case 0: return 'A';
            case 1: return 'B';
            case 2: return 'C';
            case 3: return 'D';
            case 4: return 'E';
            case 5: return 'F';
            case 6: return 'G';
            default: return 'H';
        }
    }
}
