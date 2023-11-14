﻿namespace MJU23v_D10_inl_sveng
{
    internal class Program
    {
        static List<SweEngGloss> dictionary;
        class SweEngGloss
        {
            public string word_swe, word_eng;
            public SweEngGloss(string word_swe, string word_eng)
            {
                this.word_swe = word_swe; this.word_eng = word_eng;
            }
            public SweEngGloss(string line)
            {
                string[] words = line.Split('|');
                this.word_swe = words[0]; this.word_eng = words[1];
            }
        }
        static void Main(string[] args)
        {
            string defaultFile = "../../Programmering/MJU23v_D10_inl_sveng/dict/sweeng.lis";
            Console.WriteLine("Welcome to the dictionary app!");
            do
            {
                Console.Write("> ");
                string[] argument = Console.ReadLine().Split();
                string command = argument[0];
                if (command == "quit")
                {
                    Console.WriteLine("Goodbye!");
                    //FIXME quit program
                }
                else if (command == "load")
                {
                    // TODO: System.IO.FileNotFoundException                    
                    if (argument.Length == 2)
                    {
                        using (StreamReader sr = new StreamReader(argument[1]))
                        {
                            dictionary = new List<SweEngGloss>(); // Empty it!
                            string line = sr.ReadLine();
                            while (line != null)
                            {
                                SweEngGloss gloss = new SweEngGloss(line);
                                dictionary.Add(gloss);
                                line = sr.ReadLine();
                            }
                        }
                    }
                    else if (argument.Length == 1)
                    {
                        using (StreamReader sr = new StreamReader(defaultFile))
                        {
                            dictionary = new List<SweEngGloss>(); // Empty it!
                            string line = sr.ReadLine();
                            while (line != null)
                            {
                                SweEngGloss gloss = new SweEngGloss(line);
                                dictionary.Add(gloss);
                                line = sr.ReadLine();
                            }
                        }
                    }
                }
                else if (command == "list")
                {
                    //TODO: System.NullReferenceException
                    foreach (SweEngGloss gloss in dictionary)
                    {
                        Console.WriteLine($"{gloss.word_swe,-10}  - {gloss.word_eng,-10}");
                    }
                }
                else if (command == "new")
                {
                    if (argument.Length == 3)
                    {
                        dictionary.Add(new SweEngGloss(argument[1], argument[2]));
                    }
                    else if (argument.Length == 1)
                    {
                        Console.WriteLine("Write word in Swedish: ");
                        string s = Console.ReadLine();
                        Console.Write("Write word in English: ");
                        string e = Console.ReadLine();
                        dictionary.Add(new SweEngGloss(s, e));
                    }
                }
                else if (command == "delete")
                {
                    // TODO: When wrong word: System.ArgumentOutOfRangeException
                    if (argument.Length == 3)
                    {
                        int foundWord = -1;
                        for (int i = 0; i < dictionary.Count; i++)
                        {
                            SweEngGloss gloss = dictionary[i];
                            if (gloss.word_swe == argument[1] && gloss.word_eng == argument[2])
                                foundWord = i;
                        }
                        dictionary.RemoveAt(foundWord);
                    }
                    else if (argument.Length == 1)
                    {
                        Console.WriteLine("Write word in Swedish: ");
                        string s = Console.ReadLine();
                        Console.Write("Write word in English: ");
                        string e = Console.ReadLine();
                        int foundWord = -1;
                        for (int i = 0; i < dictionary.Count; i++)
                        {
                            SweEngGloss gloss = dictionary[i];
                            if (gloss.word_swe == s && gloss.word_eng == e)
                                foundWord = i;
                        }
                        dictionary.RemoveAt(foundWord);
                    }
                }
                else if (command == "translate")
                {
                    // TODO: when no word: System.NullReferenceException
                    if (argument.Length == 2)
                    {
                        foreach (SweEngGloss gloss in dictionary)
                        {
                            if (gloss.word_swe == argument[1])
                                Console.WriteLine($"English for {gloss.word_swe} is {gloss.word_eng}");
                            if (gloss.word_eng == argument[1])
                                Console.WriteLine($"Swedish for {gloss.word_eng} is {gloss.word_swe}");
                        }
                    }
                    else if (argument.Length == 1)
                    {
                        Console.WriteLine("Write word to be translated: ");
                        string wordToTranslate = Console.ReadLine();
                        foreach (SweEngGloss gloss in dictionary)
                        {
                            if (gloss.word_swe == wordToTranslate)
                                Console.WriteLine($"English for {gloss.word_swe} is {gloss.word_eng}");
                            if (gloss.word_eng == wordToTranslate)
                                Console.WriteLine($"Swedish for {gloss.word_eng} is {gloss.word_swe}");
                        }
                    }
                }
                else if (command == "help")
                {
                    Console.WriteLine("Avaliable commands: ");
                    Console.WriteLine("  delete                      - empty the contact list");
                    Console.WriteLine("  delete /sweword/ /engword/  - delete a person");
                    Console.WriteLine("  list                        - list the contact list");
                    Console.WriteLine("  load                        - load contact list data from the file address.lis");
                    Console.WriteLine("  new                         - create new person");
                    Console.WriteLine("  new /sweword/ /engword/     - create new person with personal name and surname");
                    Console.WriteLine("  translate                   - translates a word");
                    Console.WriteLine("  translate /word/            - create new person");
                    Console.WriteLine("  quit                        - quit the program");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"Unknown command: '{command}'");
                }
            }
            while (true);
        }
    }
}