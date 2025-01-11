using DictionnairePhonetiqueApp;

public class ShowCommand : Command
{
    public ShowCommand(DictionnairePhonetique dictionnaire, string[] commandArguments)
        : base(dictionnaire, commandArguments)
    {
    }
    public override void Execute()
    {
        if (DictionnairePhonetique.EstVide())
        {
            Console.WriteLine("Ooooups ! Le dictionnaire est vide. Considérez ajouter (add) un phonème ou charger (load) votre dictionnaire");
            return;
        }
        
        if (arguments.Length == 0)
        {
            DictionnairePhonetique.AfficherDictionnaire();
            Console.WriteLine($"Le dictionnaire contient {DictionnairePhonetique.CompterEntrees()} entrées.");
            return;
        }

        string key = arguments[0];
        if (DictionnairePhonetique.ContientCle(key))
        {
            Console.WriteLine($"Phonèmes associés à '{key}':");
            foreach (var phoneme in DictionnairePhonetique.ObtenirPhonemes(key))
            {
                Console.WriteLine($"\t{phoneme}");
            }
        }    
        else
        {
            Console.WriteLine($"Désolée, aucun phonème trouvé pour '{key}'.");
        }

        
    }
}