using System;
class HarvestingOnHorseback
{

    static void Main(string[] args)
    {
        Console.Write("Ingrese ubicación de los frutos: ");         
        string? pos = Console.ReadLine();
        if (pos == null) pos = "";
        Console.Write("Ingrese ubicación del caballo: ");           
        string? horse = Console.ReadLine();
        if (horse == null) horse = "";
        Console.Write("Ingrese los movimientos de caballo: ");     
        string? moves = Console.ReadLine();
        if (moves == null) moves = "";

        char[,] chess = new char[8, 8];                             
        for (int r = 0; r < 8; r++)
             for (int c = 0; c < 8; c++)
                 chess[r, c] = ' ';
      
        int n = pos.Length, idx = 0;
        while (idx < n)
        {
            if (pos[idx] == ',')
            {
                idx++;
                continue;
            }
            char col = pos[idx];
            char row = pos[idx + 1];
            char fruit = pos[idx + 2];

            chess[er(row), ec(col)] = fruit;
            idx += 3;
        }

            char  rowH = horse[1];
            char colH = horse[0];
            int posRow = er(rowH);
            int posCol = ec(colH);
            string harvest = "";

        if (chess[posRow, posCol] != ' ')
        {
            harvest += chess[posRow, posCol];
            chess[posRow, posCol] = ' ';
        }
        
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
        
        Console.WriteLine("Los frutos recogidos son: " + harvest);
    }
    /// <summary>
    /// Converts a character representing a numeric value into its corresponding zero-based index.
    /// </summary>
    /// <param name="r">A character representing a numeric value between '1' and '8'.</param>
    /// <returns>The zero-based index corresponding to the input character, where '8' maps to 0, '7' maps to 1, and go until '1' maps to 7.
    ///For now, the program can only be passed these values, otherwise it returns -1, represent rows of chess .</returns>
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
    /// <summary>
    /// This method converts a character representing a column from 'A' to 'H', into its corresponding zero-based index.
    /// </summary>
    /// <param name="c">A character represent columns of chess </param>
    /// <returns></returns>
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