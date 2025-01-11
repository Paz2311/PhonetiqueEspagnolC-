using System;
using System.IO;
using DictionnairePhonetiqueApp; 
public class LoadCommand : Command
{
    private const string DefaultPath = "dico.txt";
    public LoadCommand(DictionnairePhonetique dictionnaire, string[] commandArguments)
        : base(dictionnaire, commandArguments)
    {
        // J'enlève la verification d'arguments parce que j'ai mis un dictionnaire par defaut
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
            Console.Error.WriteLine($"File [{path}] not found");

            return;
        }

        StreamReader reader = new StreamReader(path);

        int count = 0;
        while(!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            string[] parts = line.Split(";");
            if (parts.Length != 6)
            {
                Console.Error.WriteLine($"Error loading line [{line}]");

                continue;
            }

            string graphie = parts[0].Trim();
            string symbole = parts[1].Trim();
            string typePhoneme = parts[2].Trim();
            string trait1 = parts[3].Trim(); 
            string trait2 = parts[4]. Trim();
            string trait3 = parts[5].Trim();

            try
            {
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
                    Console.Error.WriteLine($"Type de phonème non reconnu dans la ligne [{line}]");
                    return;
                }

                DictionnairePhonetique.AjouterPhoneme(graphie, phoneme);
                count++;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Erreur en traitant la ligne [{line}]: {ex.Message}");
            }
        }    
        

        Console.WriteLine($"{count} phonèmes chargés avec succès !");

        reader.Close();
    }    
}