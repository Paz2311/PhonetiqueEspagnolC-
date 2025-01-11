using DictionnairePhonetiqueApp;

public abstract class Command 
{
    protected DictionnairePhonetique DictionnairePhonetique;
    protected bool isValid = true;
    protected string[] arguments;

    public Command() { }

    public Command(DictionnairePhonetique dictionnairePhonetique, string[] commandArguments)
    {
        DictionnairePhonetique = dictionnairePhonetique;
        arguments = commandArguments;
    }

    public abstract void Execute();
}
