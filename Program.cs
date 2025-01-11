using DictionnairePhonetiqueApp;

public class Program
{
    public static void Main(string[] args)
    {
        DictionnairePhonetique dictionnaire = new DictionnairePhonetique();
        CommandInterpreter interpreter = new CommandInterpreter(dictionnaire);

        Console.Write("Bienvenue au dictionnaire phonétique de l'espagnol.\n");
        Console.Write("Tapez 'load' pour charger le dictionnaire par défaut ou tapez 'help' pour voir les autres commandes.\n");

        while (true)
        {
            Console.Write("$ ");
            string line = Console.ReadLine();

            if (line.Trim().ToLower() == "exit")
            {
                Console.WriteLine("¡Adiós!");
                break;

            }
            string[] commandArgs = line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            try
            {
                Command command = interpreter.Interpret(commandArgs);
                command.Execute();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Erreur : {ex.Message}");
            }
        }
            
    }
}