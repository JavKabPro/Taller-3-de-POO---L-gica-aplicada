using System;
class HarvestingOnHorseback
{
    static void Main(string[] args)
    {
        Console.Write("Ingrese ubicación de los frutos: ");         //Input the location of the fruits.
        string? pos = Console.ReadLine();
        if (pos == null) pos = "";
        Console.Write("Ingrese ubicación del caballo: ");           //Input the location of the horse in the chessboard.
        string? horse = Console.ReadLine();
        if (horse == null) horse = "";
        Console.Write("Ingrese los movimientos de caballo: ");      //Input the horse moves. Put UR, UL, DR, DL, RU, RD, LU, LD...
        string? moves = Console.ReadLine();
        if (moves == null) moves = "";

        char[,] chess = new char[8, 8];                             //Create an 8x8 chessboard.
        for (int r = 0; r < 8; r++)
        {
            for (int c = 0; c < 8; c++)
            {
                chess[r, c] = ' ';
            }
        }

        int n = pos.Length, idx = 0;
        char row, col, fruit;
        while (idx < n)
        {
            if (pos[idx] == ',')
            {
                idx++;
                continue;
            }

            if (idx + 2 < n)
            {
                col = pos[idx];
                row = pos[idx + 1];
                fruit = pos[idx + 2];

                int rr = er(row);
                int cc = ec(col);
                if (rr >= 0 && cc >= 0)
                    chess[rr, cc] = fruit;

                idx += 3;
            }
        }

        row = horse[1];
        col = horse[0];
        int posRow = er(row);
        int posCol = ec(col);
        string harvest = "";

        if (chess[posRow, posCol] != ' ')
        {
            harvest += chess[posRow, posCol];
            chess[posRow, posCol] = ' ';
        }

        n = moves.Length;
        idx = 0;
        while (idx < n)
        {
            if (idx + 1 < n)
            {
                string[] movimientos = moves.Split(',', StringSplitOptions.RemoveEmptyEntries);

                foreach (string motion in movimientos)
                {
                    switch (motion)
                    {
                        case "UL":
                            posRow -= 2;
                            posCol -= 1;
                            break;
                        case "UR":
                            posRow -= 2;
                            posCol += 1;
                            break;
                        case "LU":
                            posRow -= 1;
                            posCol -= 2;
                            break;
                        case "LD":
                            posRow += 1;
                            posCol -= 2;
                            break;
                        case "RU":
                            posRow -= 1;
                            posCol += 2;
                            break;
                        case "RD":
                            posRow += 1;
                            posCol += 2;
                            break;
                        case "DL":
                            posRow += 2;
                            posCol -= 1;
                            break;
                        case "DR":
                            posRow += 2;
                            posCol += 1;
                            break;
                    }

                    if (posRow >= 0 && posRow < 8 && posCol >= 0 && posCol < 8 && chess[posRow, posCol] != ' ')
                    {
                        harvest += chess[posRow, posCol];
                        chess[posRow, posCol] = ' ';
                    }
                }
                idx += 2;

                if (posRow >= 0 && posRow < 8 && posCol >= 0 && posCol < 8 && chess[posRow, posCol] != ' ')
                {
                    harvest += chess[posRow, posCol];
                    chess[posRow, posCol] = ' ';
                }
            }
        }
        Console.WriteLine("Los frutos recogidos son: " + harvest);
    }

    public static int er(char r)
    {
        switch (r)
        {
            case '8': return 0;
            case '7': return 1;
            case '6': return 2;
            case '5': return 3;
            case '4': return 4;
            case '3': return 5;
            case '2': return 6;
            case '1': return 7;
        }
        return -1;
    }

    public static int ec(char c)
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
            case 'H': return 7;
        }
        return -1;
    }
}