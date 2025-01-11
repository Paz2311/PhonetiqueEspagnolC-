using DictionnairePhonetiqueApp;

public class Phoneme
{
    public string Symbole { get; private set; } 
    public bool EstVoyelle { get; private set; } 
    public bool EstConsonne { get; private set; } 
    
    public ApertureVoyelle? Aperture { get; private set; }
    public PositionVoyelle? Position { get; private set; }
    public ArrondieVoyelle? Arrondie { get; private set; }
    public string SonoriteVoyelle {get; }

    public PointArticulationConsonne? PointArticulation { get; private set; } 
    public ModeArticulationConsonne? ModeArticulation { get; private set; } 
    public SonoriteConsonne? Sonorite { get; private set; }

    public Phoneme(
        string symbole,
        bool estVoyelle,
        bool estConsonne, 
        ApertureVoyelle? aperture = null,
        PositionVoyelle? position = null,
        ArrondieVoyelle? arrondie = null,
        PointArticulationConsonne? pointArticulation = null,
        ModeArticulationConsonne? modeArticulation = null,
        SonoriteConsonne? sonorite = null)
    {
        Symbole = symbole;
        EstVoyelle = estVoyelle;
        EstConsonne = estConsonne;

        if (estVoyelle)
        {
            // Toutes les voyelles de l'espagnol sont orales. Celles qui subissent une assimilation
            // à côté d'une consonne sont nasalisées, mais ne sont pas nasales en soi
            SonoriteVoyelle = "Orale";
            Aperture = aperture;
            Position = position;
            Arrondie = arrondie;
            
        }
        else if (estConsonne)
        {
            PointArticulation = pointArticulation;
            ModeArticulation = modeArticulation;
            Sonorite = sonorite;
        }
 
    }

    public override string ToString()
    {
        if (EstVoyelle)
        {
            return $"{Symbole} (Voyelle {SonoriteVoyelle}, Aperture: {Aperture}, Position: {Position}, Arrondie: {Arrondie})";
        }
        else if (EstConsonne)
        {
            return $"{Symbole} (Consonne, Point Articulation: {PointArticulation}, Mode Articulation: {ModeArticulation}, Sonorite: {Sonorite})";
        }
        return $"{Symbole} inconnu)";
        
    }
    public object PhonemePourJson()
    {
        if (EstVoyelle)
        {
            return new
            {
                Symbole,
                Type = "Voyelle",
                Aperture,
                Position,
                Arrondie
            };
        }
        else if (EstConsonne)
        {
            return new
            {
                Symbole,
                Type = "Consonne",
                PointArticulation,
                ModeArticulation,
                Sonorite
            };
        }
        return new
        {
            Symbole,
            Type = "Inconnu"
        };
    }

}
