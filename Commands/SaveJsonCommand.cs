using System.Text.Json;
using System.Text.Json.Serialization;
using DictionnairePhonetiqueApp;
using System.Text.Encodings.Web;
using System.Text.Unicode;

public class SaveJsonCommand : Command
{
    private string nomDossier = "DataJson";

    public SaveJsonCommand(DictionnairePhonetique dictionnaire, string[] commandArguments)
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

            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                SaveDictionnaireAsJson(streamWriter);
            }

            Console.WriteLine($"Dictionnaire sauvegardé en JSON avec succès ! : {path}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur au moment de sauvegarder le fichier JSON : {ex.Message}");
        }
    }

    private void SaveDictionnaireAsJson(StreamWriter file)
    {
        
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
        };
    
        var jsonSerializable = DictionnairePhonetique.SauvegardeDictionnaireJson();
        string json = JsonSerializer.Serialize(jsonSerializable, options);
        file.Write(json);
        
    }

    private string AddExtension(string path)
    {
        if (!path.EndsWith(".json"))
        {
            return $"{path}.json";
        }

        return path;
    }
}