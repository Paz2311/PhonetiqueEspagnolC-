//https://learn.microsoft.com/fr-fr/dotnet/csharp/language-reference/builtin-types/enum
public enum ApertureVoyelle

{
    Ouverte,
    Mi_ouverte,
    Mi_fermee,
    Fermee
}

public enum PositionVoyelle
{
    Anterieure,
    Centrale_anterieure,
    Centrale,
    Centrale_posterieure,
    Posterieure
}

public enum ArrondieVoyelle
{
    Arrondie, 
    Non_arrondie
}

public enum PointArticulationConsonne
{
    Bilabiale, 
    Labio_dentale,
    Dentale,
    Alveolaire, 
    Post_alveoraire,
    Palatale, 
    Velaire, 
    Uvulaire, 
    Glotale

}

public enum ModeArticulationConsonne
{
    Occlusive,
    Nasale,
    Vibrante,
    Percusive,
    Affriquee,  
    Fricative,
    Approximante_lateral,
    Laterale

}

public enum SonoriteConsonne
{
    Sonore,
    Sourde
}
