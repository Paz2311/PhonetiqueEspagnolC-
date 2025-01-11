// https://learn.microsoft.com/fr-fr/dotnet/api/system.collections.generic.dictionary-2?view=net-8.0
namespace DictionnairePhonetiqueApp

{
    public class DictionnairePhonetique
    {
        private Dictionary<string, List<Phoneme>> dictionnaire;

        public DictionnairePhonetique()
        {
            dictionnaire = new Dictionary<string, List<Phoneme>>();
        }

        public bool EstVide()
        {
            return dictionnaire.Count == 0;
        }

        public bool ContientCle(string key)
        {
            return dictionnaire.ContainsKey(key);
        }

        public int CompterEntrees()
        {
            int totalEntries = 0;
            foreach (var entry in dictionnaire)
            {
                totalEntries++;
            }
            return totalEntries;
        }

        public List<Phoneme> ObtenirPhonemes(string key)
        {
            if (dictionnaire.ContainsKey(key))
            {
                return dictionnaire[key];
            }
            else
            {
                Console.WriteLine($"Clé '{key}' non trouvée dans le dictionnaire.");
                return new List<Phoneme>(); 
            }
        }

        public void AjouterPhoneme(string graphie, Phoneme phoneme)
        {
            if (!dictionnaire.ContainsKey(graphie))
            {
                dictionnaire[graphie] = new List<Phoneme>();
            }
            dictionnaire[graphie].Add(phoneme);
            Console.WriteLine($"Ajouté : {graphie} -> {phoneme}");
        }

        public void AfficherDictionnaire()
        {
            Console.WriteLine("Dictionnaire phonétique :");
            foreach (var item in dictionnaire)
            {
                Console.WriteLine($"{item.Key} -> ");
                foreach (var phoneme in item.Value)
                {
                    Console.WriteLine($"\t{phoneme}");
                }
            }
        }
        public void SauvegardeDictionnaire(StreamWriter file)
        {
            foreach (var item in dictionnaire)
            {
                string graphie = item.Key;
                string phonemes = string.Join(", ", item.Value.Select(p => p.ToString()));
                file.WriteLine($"{graphie};{phonemes}");

            }

        }
        public Dictionary<string, List<object>> SauvegardeDictionnaireJson()
        {
            return dictionnaire.ToDictionary(
                    entry => entry.Key,
                    entry => entry.Value.Select(phoneme => phoneme.PhonemePourJson()).ToList()
                );
        }

        public string Transcrire(string mot)
        {
            string transcription = "";
            for (int i = 0; i < mot.Length; i++)
            {
                string graphie = mot[i].ToString().ToLower();
                if (dictionnaire.ContainsKey(graphie))
                {
                    var phoneme = dictionnaire[graphie][0];
                    if (graphie == "r")
                    {
                        bool estPercusive = false;
                        if (i > 0 && i < mot.Length - 1) 
                        {
                            string lettrePrecedente = mot[i - 1].ToString().ToLower();
                            string lettreSuivante = mot[i + 1].ToString().ToLower();
                            if (dictionnaire.ContainsKey(lettrePrecedente) && dictionnaire.ContainsKey(lettreSuivante))
                            {
                                var phonemePrecedent = dictionnaire[lettrePrecedente][0];
                                var phonemeSuivant = dictionnaire[lettreSuivante][0];

                                if ((phonemePrecedent.EstVoyelle && phonemeSuivant.EstVoyelle) || 
                                    (phonemePrecedent.EstConsonne && phonemeSuivant.EstVoyelle))
                                {
                                    estPercusive = true;
                                }
                            }
                        } 
                        if (estPercusive)
                        {
                            transcription += "ɾ"; 
                        }
                        else
                        {
                            transcription += "r";  
                        }
                    }    
                    else if (graphie == "c" && i + 1 < mot.Length)
                    {
                        string lettreSuivante = mot[i + 1].ToString().ToLower();

                        if (dictionnaire.ContainsKey(lettreSuivante))
                        {
                            var phonemeSuivant = dictionnaire[lettreSuivante][0];
                            if (phonemeSuivant.EstVoyelle)
                            {
                                if (lettreSuivante == "o" || lettreSuivante == "u" || lettreSuivante == "a")
                                {
                                    transcription += "k";  
                                }
                                else
                                {
                                    transcription += "s";  
                                }
                            }
                            else
                            {
                                transcription += phoneme.Symbole.Replace("/", "");
                            }
                        }
                        else
                        {
                            transcription += phoneme.Symbole.Replace("/", "");
                        }
                    }
                    
                    else
                    {
                        transcription += phoneme.Symbole.Replace("/", "");
                    }
                }
                else
                {
                    transcription += graphie;
                    Console.WriteLine($"Oh no ! Le dictionnaire ne contient pas la graphie {graphie}");
                }
            }

            return transcription;
        }

        public void TraitsTranscription(string transcription)
        {
            foreach (char symbole in transcription)
            {
                string symboleStr = symbole.ToString(); 
                bool encontrado = false;
                foreach (var item in dictionnaire)
                {
                    foreach (var phoneme in item.Value)
                    {
                        if (phoneme.Symbole.Replace("/", "") == symboleStr)
                        {
                            Console.WriteLine($"\t{phoneme}");
                            encontrado = true;
                            break;
                        }
                    }
                    if (encontrado)
                    {
                        break;
                    }
                }

                if (!encontrado)
                {
                    Console.WriteLine("Pas trouvé");
                    continue;
                }
            }
        }
    
    }   

}

