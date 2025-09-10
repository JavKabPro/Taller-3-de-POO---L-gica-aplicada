var itString = string.Empty;

do
{
    Console.Write("Ingrese puente (0 'salir para terminar): ");
    itString = Console.ReadLine();
    if (itString!.ToLower() == "salir")
        break;
    
    bool isValid = itString.Length >= 2 && itString.StartsWith("*")&& itString.EndsWith("*");
    
    if (isValid)
    {
        Console.WriteLine($"El puente {itString}, es VALIDO.");
    }
    else
    {
        Console.WriteLine($"El número {itString}, es INVALIDO.");
    }
      
} while (true);
Console.WriteLine("Game Over.");
    