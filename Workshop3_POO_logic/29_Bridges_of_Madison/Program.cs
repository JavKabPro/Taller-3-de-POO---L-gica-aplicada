using System.ComponentModel;

var itString = string.Empty;

do
{
    Console.Write("Ingrese puente (0 'salir para terminar): ");
    itString = Console.ReadLine();
    if (itString!.ToLower() == "salir")
        break;
    
    bool isValid = itString.Length >= 2 && itString.StartsWith("*")&& itString.EndsWith("*");   //It must start and end with '*'.
    if (isValid)
    {
        string inside = itString.Substring(1, itString.Length - 2);     //Get and verify the inside part of the string.
        if (inside.Contains("*"))                                                               //It must not contain '*'.
        {
            isValid = false;
        }
    }
    if (isValid)
    {
        string inside = itString.Substring(1, itString.Length - 2);     //Get the inside part of the string again.
        for (int i = 0; i < inside.Length - 1; i++)                     //Iterate for, through the inside part of the string.                                 
        {
            if (inside[i] == '=' && inside[i+1] =='=')
            {
                bool lOk = false;
                bool rOk = false;
                if (i > 0 && inside[i - 1] == '+')
                {
                    lOk = true;
                }
                if (i + 2 < inside.Length && inside[i + 2] == '+')
                {
                    rOk = true;
                }
                if (!(lOk || rOk))
                {
                    isValid = false;
                    break;                                              //Unnecessary to continue checking.
                }
            }
        }
    }
    if (isValid)
    {
        string inside = itString.Substring(1, itString.Length - 2);
        int countRef = 0;
        int mid = inside.Length / 2;
        for (int i = 0; i < inside.Length - 2; i++)
        {
            if (inside[i] == '=' && inside[i + 1] == '=' && inside[i + 2] == '=')
            {
                countRef++;
                if (i != mid - 1)
                {
                    isValid = false;
                    break;
                }
            }
        }
        if (countRef > 1)
        {
            isValid = false;
        }
    }
    if (isValid)
    {
        string inside = itString.Substring(1, itString.Length - 2);
        for (int i = 0; i < inside.Length / 2; i++)
        {
            if (inside[i] != inside[inside.Length - 1 - i])
            {
                isValid = false;
                break;
            }
        }
    }
    if (isValid)
    {
        Console.WriteLine($"El puente {itString}, es VALIDO.");
    }
    else
    {
        Console.WriteLine($"El puente {itString}, es INVALIDO.");
    }
} while (true);
Console.WriteLine("Game Over.");
    