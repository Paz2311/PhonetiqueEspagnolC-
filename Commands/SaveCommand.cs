using DictionnairePhonetiqueApp;

public class SaveCommand : Command 
{
    private string nomDossier = "Data";
    public SaveCommand(DictionnairePhonetique dictionnaire, string[] commandArguments)
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
            Console.WriteLine("Ecrivez un nom de fichier, s'il vous plaît !");
            return;
        }
        string path = AddExtension(arguments[0]);
        path = $"{nomDossier}/{path}";
        try
        {
            Directory.CreateDirectory(nomDossier);

            StreamWriter streamWriter = new StreamWriter(path);
            
            SaveDictionnaire(streamWriter);
            streamWriter.Flush();
            streamWriter.Close();
            
            Console.WriteLine($"Dictionnaire gardé avec succès! : {path}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur au moment de garder le fichier : {ex.Message}");
        }
    }

    void SaveDictionnaire(StreamWriter file)
    {
        DictionnairePhonetique.SauvegardeDictionnaire(file);
    }

    string AddExtension(string path)
    {
        if (!path.Contains("."))
        {
            return $"{path}.csv";
        }

        return path;
    }
}