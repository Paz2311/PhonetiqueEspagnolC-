using System;
using System.IO;
using System.Text.Json;
using DictionnairePhonetiqueApp;

public class LoadJsonCommand : Command
{
    private const string DefaultPath = "dico.json";

    public LoadJsonCommand(DictionnairePhonetique dictionnaire, string[] commandArguments)
        : base(dictionnaire, commandArguments)
    {
    }

    public override void Execute()
    {
        string path;
        if (arguments.Length > 0)
        {
            path = arguments[0];
        }
        else
        {
            path = DefaultPath;
        }

        if (!File.Exists(path))
        {
            Console.Error.WriteLine($"Le fichier {path} n'a pas été trouvé.");
            return;
        }
        
        try
        {
            
            string json = File.ReadAllText(path);

            
            var dictionnaire = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(json);

            if (dictionnaire != null)
            {
                foreach (var entry in dictionnaire)
                {
                    string graphie = entry.Key;
                    List<string> phonemeAttributes = entry.Value;

                    
                    string symbole = phonemeAttributes[0];
                    string typePhoneme = phonemeAttributes[1];
                    string trait1 = phonemeAttributes[2];
                    string trait2 = phonemeAttributes[3];
                    string trait3 = phonemeAttributes[4];

                    Phoneme phoneme;
                    if (typePhoneme.Equals("Voyelle", StringComparison.OrdinalIgnoreCase))
                    {
                        
                        ApertureVoyelle.TryParse(trait1, out ApertureVoyelle aperture);
                        PositionVoyelle.TryParse(trait2, out PositionVoyelle position);
                        ArrondieVoyelle.TryParse(trait3, out ArrondieVoyelle arrondie);

                        phoneme = new Phoneme(
                            symbole,
                            estVoyelle: true,
                            estConsonne: false,
                            aperture: aperture,
                            position: position,
                            arrondie: arrondie,
                            pointArticulation: null,
                            modeArticulation: null,
                            sonorite: null
                        );
                    }
                    else if (typePhoneme.Equals("Consonne", StringComparison.OrdinalIgnoreCase))
                    {
                        
                        PointArticulationConsonne.TryParse(trait1, out PointArticulationConsonne pointArticulation);
                        ModeArticulationConsonne.TryParse(trait2, out ModeArticulationConsonne modeArticulation);
                        SonoriteConsonne.TryParse(trait3, out SonoriteConsonne sonorite);

                        phoneme = new Phoneme(
                            symbole,
                            estVoyelle: false,
                            estConsonne: true,
                            aperture: null,
                            position: null,
                            arrondie: null,
                            pointArticulation: pointArticulation,
                            modeArticulation: modeArticulation,
                            sonorite: sonorite
                        );
                    }
                    else
                    {
                        Console.Error.WriteLine($"Type de phonème non reconnu : {typePhoneme}");
                        continue;
                    }

                    
                    DictionnairePhonetique.AjouterPhoneme(graphie, phoneme);
                }

                Console.WriteLine("Le dictionnaire a été chargé correctement :)");
            }
        }

       
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Ouuups. Problème au moment de charger le dico ! {ex.Message}");
        }
    }
}
