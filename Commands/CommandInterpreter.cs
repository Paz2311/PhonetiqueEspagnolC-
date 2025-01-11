using DictionnairePhonetiqueApp; 

public class CommandInterpreter
{
    private DictionnairePhonetique dictionnaire;

    public CommandInterpreter(DictionnairePhonetique dictionnaire)
        {
            this.dictionnaire = dictionnaire;
        }
    
    public Command Interpret(string[] arguments)
    {
        if (arguments.Length < 1)
        {
            Console.Error.WriteLine("Ajouter des arguments suffissants !");

        }

        string commandName = arguments[0];
        string[] commandArguments = arguments.Skip(1).ToArray();

        switch (commandName.ToLower())
        {
                case "load":
                    return new LoadCommand(dictionnaire, commandArguments);

                case "add":
                    return new AddCommand(dictionnaire, commandArguments);
            
                case "show":
                    return new ShowCommand(dictionnaire, commandArguments);

                case "save":
                    return new SaveCommand(dictionnaire, commandArguments);

                case "loadjson":
                    return new LoadJsonCommand(dictionnaire, commandArguments);

                case "savejson":
                    return new SaveJsonCommand(dictionnaire, commandArguments);               
        
                case "transcribe":
                    return new TranscribeCommand(dictionnaire, commandArguments);

                case "help":
                        return new HelpCommand();


            default:
                Console.Error.WriteLine($"Je ne reconnais pas cette commande'{commandName}' ");
                return null;

        }
    }
}


