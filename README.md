# Dictionnaire Phonétique de l'Espagnol en C#
Projet final du cours Programmation Objet 1, dans le cadre du Master2 - Traitement Automatique des Langues

Lors de l'apprentissage de l'espagnol en tant que langue étrangère, cet outil, créé en C#, se présente comme une opportunité pour connaître les traits des sons de l'espagnol latino-américain et ibérique. 

Il permet de:
- Charger un dictionnaire phonétique en format .txt ou .json
- Ajouter des phonèmes en ligne de commande.
- Voir les phonèmes associés à une graphie.
- Transcrire un mot et voir les traits phonétiques associés à celui-ci.
- Sauvegarder le dictionnaire en format .csv ou .json

L'application a un dictionnaire par défaut. Celui-ci à été construit _à la main_ à partir  du livre _Nueva Gramatica de la Lengua Española, Fonética y Fonologia(2011)_. Les sons choisis sont des sons dits _standards_ qu'on peut trouver dans pratiquement toutes les variations de l'espagnol. Pour l'instant, le dictionnaire accepte seulement des sons vocaliques et consonatiques, les semi-consonnes n'ont pas été incluses. 

Étant donné que le monde de la phonétique si vaste, celle-ci est une première version qui pourrait continuer à etre developpée pour prendre en compte les allophones et les contextes de chaque son. 

## Le pas à pas pour son utilisation

Lancez le programme avec `dotnet run`. Vous pouvez voir toutes les commandes disponibles avec la commande `help`.

###  Chargez votre dictionnaire
Vous pouvez charger le dictionnaire .txt par défaut, en tappant `load` ou le dictionnaire .json par défaut, en tapant `loadjson`. Si vous voulez charger votre propre dictionnaire, utilisez la commande `load <nom de votre dictionnaire>` ou `loadjson <nom de votre dictionnaire>`. Sur le terminal, vous verrez ensuite la quantité de phonèmes qui on été ajoutés, de cette façon : 

```markdown
$ load
Ajouté : a -> /a/ (Voyelle Orale, Aperture: Ouverte, Position: Centrale_anterieure, Arrondie: Non_arrondie)
Ajouté : e -> /e/ (Voyelle Orale, Aperture: Mi_fermee, Position: Anterieure, Arrondie: Non_arrondie)
Ajouté : i -> /i/ (Voyelle Orale, Aperture: Fermee, Position: Anterieure, Arrondie: Non_arrondie)
Ajouté : o -> /o/ (Voyelle Orale, Aperture: Mi_fermee, Position: Posterieure, Arrondie: Arrondie)
Ajouté : u -> /u/ (Voyelle Orale, Aperture: Fermee, Position: Posterieure, Arrondie: Arrondie)
Ajouté : p -> /p/ (Consonne, Point Articulation: Bilabiale, Mode Articulation: Occlusive, Sonorite: Sourde)
Ajouté : t -> /t/ (Consonne, Point Articulation: Dentale, Mode Articulation: Occlusive, Sonorite: Sourde)
Ajouté : k -> /k/ (Consonne, Point Articulation: Velaire, Mode Articulation: Occlusive, Sonorite: Sourde)
Ajouté : q -> /k/ (Consonne, Point Articulation: Velaire, Mode Articulation: Occlusive, Sonorite: Sourde)
Ajouté : b -> /b/ (Consonne, Point Articulation: Bilabiale, Mode Articulation: Occlusive, Sonorite: Sonore)
Ajouté : d -> /d/ (Consonne, Point Articulation: Dentale, Mode Articulation: Occlusive, Sonorite: Sonore)
Ajouté : g -> /g/ (Consonne, Point Articulation: Velaire, Mode Articulation: Occlusive, Sonorite: Sourde)
Ajouté : f -> /f/ (Consonne, Point Articulation: Labio_dentale, Mode Articulation: Fricative, Sonorite: Sourde)
Ajouté : s -> /s/ (Consonne, Point Articulation: Bilabiale, Mode Articulation: Fricative, Sonorite: Sourde)
Ajouté : c -> /s/ (Consonne, Point Articulation: Bilabiale, Mode Articulation: Fricative, Sonorite: Sourde)
Ajouté : j -> /x/ (Consonne, Point Articulation: Velaire, Mode Articulation: Fricative, Sonorite: Sourde)
Ajouté : y -> /ʝ/ (Consonne, Point Articulation: Palatale, Mode Articulation: Fricative, Sonorite: Sonore)
Ajouté : ll -> /ʎ/ (Consonne, Point Articulation: Palatale, Mode Articulation: Laterale, Sonorite: Sonore)
Ajouté : ch -> /t͡ʃ/ (Consonne, Point Articulation: Palatale, Mode Articulation: Affriquee, Sonorite: Sourde)
Ajouté : l -> /l/ (Consonne, Point Articulation: Bilabiale, Mode Articulation: Laterale, Sonorite: Sonore)
Ajouté : m -> /m/ (Consonne, Point Articulation: Bilabiale, Mode Articulation: Nasale, Sonorite: Sonore)
Ajouté : n -> /n/ (Consonne, Point Articulation: Bilabiale, Mode Articulation: Nasale, Sonorite: Sonore)
Ajouté : ñ -> /ɲ/ (Consonne, Point Articulation: Palatale, Mode Articulation: Nasale, Sonorite: Sonore)
Ajouté : r -> /ɾ/ (Consonne, Point Articulation: Bilabiale, Mode Articulation: Percusive, Sonorite: Sonore)
Ajouté : r -> /r/ (Consonne, Point Articulation: Bilabiale, Mode Articulation: Vibrante, Sonorite: Sonore)
Ajouté : c -> /k/ (Consonne, Point Articulation: Velaire, Mode Articulation: Occlusive, Sonorite: Sourde)
Ajouté : z -> /s/ (Consonne, Point Articulation: Bilabiale, Mode Articulation: Fricative, Sonorite: Sourde)
27 phonèmes chargés avec succès !
```

### 2. Ajoutez votre propre entrée au dictionnaire
Disons que vous êtes proffesseur.e d'espagnol et un étudiant veut savoir pourquoi le _z_ est prononcé différement en Amérique Latine et en Espagne. Vous pourriez ajouter votre propre son avec la commande `add <son>`. Attention, vous devez suivre le bon format. C'est à dire, vous devez ajouter un son qui possède __six caractéristiques, sans accents__. 

Voici les options que l'application sprend en charge :

__ApertureVoyelle__
- Ouverte
- Mi_ouverte
- Mi_fermee
- Fermee

__PositionVoyelle__
- Anterieure
- Centrale_anterieure
- Centrale
- Centrale_posterieure
- Posterieure
- ArrondieVoyelle
- Arrondie
- Non_arrondie

__PointArticulationConsonne__
- Bilabiale
- Labio_dentale
- Dentale
- Alveolaire
- Post_alveoraire
- Palatale
- Velaire
- Uvulaire
- Glotale

__ModeArticulationConsonne__
- Occlusive
- Nasale
- Vibrante
- Percusive
- Affriquee
- Fricative
- Approximante_lateral
- Laterale

__SonariteConsonne__
- Sonore
- Sourde

Donc, 
- Pour les consonnes `<graphie; /symboleAPI/; consonne; point d'articulation; mode d'articulation; sonorité>`. 
Par exemple, `z; /θ/; Consonne; Dentale; Fricative; Sourde`

- Pour les voyelles `<graphie; /symboleAPI/; voyelle; aperture voyelle; position voyelle; arrondie ou non>`.
 Par exemple, `e; /e/; Voyelle; Mi_fermee; Anterieure; Non-arrondie`


### Consultez votre dictionnaire
Avec la commande `show` vous pouvez regarder tout le dictionnaire et voir la quantité d'entrées que celui-ci possède. Si vous voulez regarder seulement les phonèmes qui sont associés à une graphie. Vous pouvez taper `show <graphie>`. Voici les résultats de `show <r>`:

```Phonèmes associés à 'r':
        /ɾ/ (Consonne, Point Articulation: Alveolaire, Mode Articulation: Percusive, Sonorite: Sonore)
        /r/ (Consonne, Point Articulation: Alveolaire, Mode Articulation: Vibrante, Sonorite: Sonore)
```


### Trancrivez un mot
Avec la commande `transcribe <mot>` vous pourrez voir la transcription phonetique (en format de l'Alphabete Phonetique International) du mot, ainsi que les caractéristiques phonétiques de chaque son qui le compose ! Ce dictionnaire prend en compte les distinctions entre le _r_ intervocalique et vibrant, et les variations de la graphie _c_. Pour l'instant d'autres particularités n'ont pas encore été envisagées.
Vous pouvez essayer avec des mots comme _cilantro_, _niño_, _raton_, _amor_, _calma_, _jamon_, _yuca_.  

```
La transcription phonetique de 'yuca' est: /ʝuka/
        /ʝ/ (Consonne, Point Articulation: Palatale, Mode Articulation: Fricative, Sonorite: Sonore)
        /u/ (Voyelle Orale, Aperture: Fermee, Position: Posterieure, Arrondie: Arrondie)
        /k/ (Consonne, Point Articulation: Velaire, Mode Articulation: Occlusive, Sonorite: Sourde)
        /a/ (Voyelle Orale, Aperture: Ouverte, Position: Centrale_anterieure, Arrondie: Non_arrondie)
```

### Sauvegardez votre dictionnaire 
Gardez votre dictionnaire en format .json ou .csv avec les commandes `savejson <nom du fichier>` ou `save <nom du fichier>`. L'application crééra un directoire nommé _Data_ ou _DataJson_ où vous pourrez trouver vos fichiers.

#### Remarques sur le programme et possibilités d'amélioration
La construction de ce programme a représenté un défi, car nous avons un objet (phonème) qui peut parfois posséder certaines caractéristiques et d'autres fois non, selon qu'il s'agisse d'un son vocalique ou consonantique. Cela a nécessité la définition de propriétés nullables et a rendu très difficile la transformation des caractéristiques du phonème en DTO, raison pour laquelle la sérialisation et la désérialisation en JSON ont été effectuées directement à partir de l'objet lui-même, ce qui n'est pas recommandé.

Pour l'avenir, un travail méticuleux sur la transcription pourrait être envisagé. Ainsi, le programme pourrait prendre en compte des graphies composées comme _ll, ch, k_. De plus, il serait intéressant que la transcription s'adapte aux variations régionales. Cette application est un programme de base qui pourrait être développé davantage à l'avenir.

