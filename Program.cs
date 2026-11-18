
GuitarString myHighEString = new("E", 2);//starting octave 2
myHighEString.PrintFrets();




while (true)
{
    Console.WriteLine("\nSelect a fret: ");
    int fret = int.Parse(Console.ReadLine());
    Console.WriteLine($"Guess the note for fret {fret}");
    string noteGuess = Console.ReadLine();
    if (myHighEString.CheckNote(fret, noteGuess))
    {
        myHighEString.PlayString(noteGuess);
        Console.WriteLine("Good job! Next Guess!");
    }
    else
    {
        Console.WriteLine("Better luck next time!");
    }
    
}



class GuitarString
{

    Dictionary<string, double> noteToFreq = new() //key = note    value = freq at octave 0
    {
        ["C"] = 16.35,
        ["C#"] = 17.32,
        ["D"] = 18.35,
        ["D#"] = 19.45,
        ["E"] = 20.60,
        ["F"] = 21.83,
        ["F#"] = 23.12,
        ["G"] = 24.50,
        ["G#"] = 25.96,
        ["A"] = 27.50,
        ["A#"] = 29.14,
        ["B"] = 30.87
    };

    string[] ChromaticNotesSharps = ["C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B"]; //12 entries 
    string[] ChromaticNotesFlats = ["C", "Db", "D", "Eb", "E", "F", "Gb", "G", "Ab", "A", "Bb", "B"];
    string[] StringNotes = new string[20];
    int startingOctave { get; set; }
    public GuitarString(string UnfrettedNote, int Octave)
    {
        startingOctave = Octave; //set octave
        //find where first note is in chromatic scale
        int indexOfUnfretted = Array.IndexOf(ChromaticNotesSharps, UnfrettedNote); //find index of unfretted note

        //assign notes to frets
        for (int i = 0; i < 20 ; i ++)
        {
            StringNotes[i] = ChromaticNotesSharps[(indexOfUnfretted+i)%12];
        }
    }
    
    public void PrintFrets() //print out the string's fret numbers w/ notes
    {
        Console.WriteLine("Fret\t|\tNote");        
        int i = 0;
        foreach (string note in StringNotes)
        {
            Console.WriteLine($"{i}\t|\t{note}");
            i++;
        }
    }

    public bool CheckNote(int fret, string Note)
    {
        if (StringNotes[fret] == Note)
        {
            return true;
        }
        return false;
    }

    public void PlayString(string Note, int Octave)
    {
        int frequency = (int)Math.Round(noteToFreq[Note] * Math.Pow(2, Octave)); //we lose a tiny bit of precision here as we must use an int for Console.Beep()
        Console.Beep(frequency , 1000);

    }
    public void PlayString(string Note) //default octave 4 overload
    {
        int frequency = (int)Math.Round(noteToFreq[Note] * Math.Pow(2, 4)); //we lose a tiny bit of precision here as we must use an int for Console.Beep()
        Console.Beep(frequency , 1000);

    }


}