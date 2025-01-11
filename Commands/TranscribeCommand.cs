using DictionnairePhonetiqueApp;

public class TranscribeCommand : Command
{
    public TranscribeCommand(DictionnairePhonetique dictionnaire, string[] commandArguments)
            : base(dictionnaire, commandArguments)
        {
            if (commandArguments.Length < 1)
            {
                isValid = false;
            }
        }
    
    public override void Execute()
    {
        if (!isValid)
        {
            Console.Error.WriteLine("Écrivez un mot à trasncrire !");
            return;
        }
        string mot = arguments[0];
        string transcription = DictionnairePhonetique.Transcrire(mot);
    
        Console.WriteLine($"La transcription phonetique de '{mot}' est: /{transcription}/");
        DictionnairePhonetique.TraitsTranscription(transcription);
    }
}