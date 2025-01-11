using DictionnairePhonetiqueApp;

public class HelpCommand : Command
{
    public override void Execute()
    {
        Console.WriteLine("Liste de commandes disponibles :\n\n");
        Console.WriteLine("  load");
        Console.WriteLine("     - Charger le dicctionnaire par défaut du programme.\n");
        Console.WriteLine("  load <fichier>");
        Console.WriteLine("     - Charger un dictionnaire despuis un fichier txt.\n");
        Console.WriteLine("  add <_;_;_;_;_;_> ");
        Console.WriteLine("     - Ajouter une entrée au dictionnaire chargé.");
        Console.WriteLine("         Pour les consonnes <graphie; /symboleAPI/; consonne; point d'articulation; mode d'articulation; sonorité>");
        Console.WriteLine("                   z; /θ/; Consonne; Dentale; Fricative; Sourde");
        Console.WriteLine("         Pour les voyelles <graphie; /symboleAPI/; voyelle; aperture voyelle; position voyelle; arrondie ou non>");
        Console.WriteLine("                   e; /e/; Voyelle; Mi_fermee; Anterieure; Non_arrondie\n");
        Console.WriteLine("  show ");
        Console.WriteLine("      - Afficher le dictionnaire actuel.\n");
        Console.WriteLine("  show <graphie>");
        Console.WriteLine("      - Afficher les phonemes associés à une graphie.\n");
        Console.WriteLine("  save <fichier>");
        Console.WriteLine("      - Sauvegarder le dictionnaire dans un fichier.\n");
        Console.WriteLine("  loadjson");
        Console.WriteLine("      - Charger le dictionnaire JSON par défaut.\n");
        Console.WriteLine("  loadjson <fichier>");
        Console.WriteLine("      - Charger un dictionnaire au format JSON.\n");
        Console.WriteLine("  savejson <fichier>");
        Console.WriteLine("      - Sauvegarder le dictionnaire au format JSON.\n");
        Console.WriteLine("  transcribe <mot>");
        Console.WriteLine("      - Transcrire un mot avec l'Alphabet Phonétique Internationale et montrer les traits de chaque son.\n");
        Console.WriteLine("  help");
        Console.WriteLine("      - Afficher cette aide.\n");
        Console.WriteLine("  exit");
        Console.WriteLine("      - Quitter le programme.\n");
    }
}