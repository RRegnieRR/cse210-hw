using System;
using System.IO;
/* I implemented a better system for saving and loading so that the user only writes the title of the file instead of having to type "journal.txt" or other format and just write "journal". Also when loading its not necessary to type the name of the file, just select wich of all the .txt files available would like to open */
class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        string journalFolder = AppDomain.CurrentDomain.BaseDirectory;
        string choice = "";

        while (choice != "5")
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            choice = Console.ReadLine();

            Console.WriteLine();
            
            if (choice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");

                Entry entry = new Entry();
                entry._date = DateTime.Now.ToShortDateString();
                entry._promptText = prompt;
                entry._entryText = Console.ReadLine();

                journal.AddEntry(entry);
                Console.WriteLine();
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                string[] files = Directory.GetFiles(journalFolder, "*.txt");
                Array.Sort(files);

                if (files.Length == 0)
                {
                    Console.WriteLine("No journal files found.");
                    Console.WriteLine();
                    continue;
                }

                Console.WriteLine("Select a file to load:");
                for (int i = 0; i < files.Length; i++)
                {
                    string title = Path.GetFileNameWithoutExtension(files[i]);
                    Console.WriteLine($"{i + 1}. {title}");
                }

                Console.Write("Which file would you like to load? ");
                string selectionText = Console.ReadLine();

                int selectionNumber;
                if (!int.TryParse(selectionText, out selectionNumber))
                {
                    Console.WriteLine("Please type a number from the list.");
                    Console.WriteLine();
                    continue;
                }

                if (selectionNumber < 1 || selectionNumber > files.Length)
                {
                    Console.WriteLine("That number is not in the list.");
                    Console.WriteLine();
                    continue;
                }

                string selectedFile = files[selectionNumber - 1];
                journal.LoadFromFile(selectedFile);
                Console.WriteLine();
            }
            else if (choice == "4")
            {
                Console.Write("What is the title of the file? ");
                string title = Console.ReadLine();
                title = title.Trim();

                if (title == "")
                {
                    Console.WriteLine("Please enter a title.");
                    Console.WriteLine();
                    continue;
                }

                string fileName;
                if (title.EndsWith(".txt"))
                {
                    fileName = title;
                }
                else
                {
                    fileName = $"{title}.txt";
                }
                string filePath = Path.Combine(journalFolder, fileName);

                journal.SaveToFile(filePath);
                Console.WriteLine($"Saved as {fileName}");
                Console.WriteLine();
            }
            else if (choice == "5")
            {
                // Quit
            }
            else
            {
                Console.WriteLine("Please enter a number from the menu.");
                Console.WriteLine();
            }
        }
    }
}
