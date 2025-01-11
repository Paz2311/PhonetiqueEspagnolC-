namespace DictionnairePhonetiqueApp;

public class AddCommand : Command
{
    public AddCommand(DictionnairePhonetique dictionnaire, string[] commandArguments)
        : base(dictionnaire, commandArguments)
    {
        if (commandArguments.Length < 6)
        {
            isValid = false;
        }
    }

    public override void Execute()
    {
        if (!isValid)
        {
            Console.Error.WriteLine("Ouppps ! Ce n'est pas la bonne quantité de traits");
            return;
        }

       
        string input = string.Join(" ", arguments);
        string[] parts = input.Split(";");

        if (parts.Length != 6)
        {
            Console.Error.WriteLine($"Invalid format, expected 6 arguments separated by ';'.");
            return;
        }

        string graphie = parts[0].Trim();
        string symbole = parts[1].Trim();
        string typePhoneme = parts[2].Trim();
        string trait1 = parts[3].Trim();
        string trait2 = parts[4].Trim();
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
                Console.Error.WriteLine($"Unrecognized phoneme type in line: {input}");
                return;
            }

            DictionnairePhonetique.AjouterPhoneme(graphie, phoneme);
            
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error processing the input: {ex.Message}");
        }
    }
}