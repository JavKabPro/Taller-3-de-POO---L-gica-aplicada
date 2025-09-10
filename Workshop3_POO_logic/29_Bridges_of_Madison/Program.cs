using System;
var itString = string.Empty;                                        //Initialize the input string.
do
{
    Console.Write("Ingrese puente (o pulse 'salir' para terminar): ");
    itString = Console.ReadLine();                                  //Read the input string.
    if (itString!.ToLower() == "salir")                             //If the input is "salir", exit the loop.
        break;
    
    bool isValid = itString.Length >= 2 && itString.StartsWith("*")&& itString.EndsWith("*");   //It must start and end with '*'.
    string inside = string.Empty;                                       //If the first a part of first rule pass, continue. (1.Rule)   
    if (isValid)
        inside = itString.Substring(1, itString.Length - 2);            //Get and verify the inside part of the string.
        
        if (inside.Contains("*"))                                       //It must not contain '*'.
            isValid = false;
   
        if (isValid && inside.Contains("*"))
            isValid = false;                                            //It must not contain '*'.
    if (isValid)
    {
        for (int i = 0; i < inside.Length - 1; i++)                 //Iterate for, through the inside part of the string. (2. rulle)                                
        {
            if (inside[i] == '=' && inside[i + 1] == '=')                //If there are two '=' in a row, it is invalid.
            {
                bool lOk = (i > 0 && inside[i - 1] == '+'); ;           //Check if there is a '+' to the left.
                bool rOk = (i + 2 < inside.Length && inside[i + 2] == '+'); //Verify if there is a '+' to the right.
                if (!(lOk || rOk))                                      //If there is no '+' on either side, it is invalid.
                {
                    isValid = false;
                    break;                                              //Unnecessary to continue checking.
                }
            }

        }
    }
    if (isValid)
    {
        int countRef = 0;                               //Count the number of '===' references.
        int mid = inside.Length / 2;                    //Calculate the middle.
        for (int i = 0; i < inside.Length - 2; i++)     //Iterate through the inside part of the string. (3.Rule)
        {
            if (inside[i] == '=' && inside[i + 1] == '=' && inside[i + 2] == '=')   //The reference === must be in the middle.
            {
                countRef++;                             //Count the number of references.
                if (i != mid - 1)                       //If the reference is not in the middle, it is invalid.
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
        for (int i = 0; i < inside.Length / 2; i++)             //Check for symmetry. (4.Rule)
        {
            if (inside[i] != inside[inside.Length - 1 - i])     //If the characters are not the same, it is invalid.
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
    