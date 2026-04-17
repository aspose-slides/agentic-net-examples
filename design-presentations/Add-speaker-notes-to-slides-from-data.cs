using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string presentationPath = "input.pptx";
        string notesPath = "notes.txt";
        string outputPath = "output.pptx";

        // Check if the presentation file exists
        if (!File.Exists(presentationPath))
        {
            Console.WriteLine("Presentation file not found: " + presentationPath);
            return;
        }

        // Check if the external notes data file exists
        if (!File.Exists(notesPath))
        {
            Console.WriteLine("Notes data file not found: " + notesPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation presentation = new Presentation(presentationPath))
            {
                // Read notes from the external file (format: slideNumber|note text)
                Dictionary<int, string> notesDictionary = new Dictionary<int, string>();
                string[] lines = File.ReadAllLines(notesPath);
                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    string[] parts = line.Split(new char[] { '|' }, 2);
                    if (parts.Length == 2 && int.TryParse(parts[0], out int slideNumber))
                    {
                        notesDictionary[slideNumber] = parts[1];
                    }
                }

                // Add notes to each slide based on the dictionary
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    int slideNumber = i + 1; // Slides are 1‑based for the user
                    if (notesDictionary.TryGetValue(slideNumber, out string noteText))
                    {
                        INotesSlideManager notesManager = presentation.Slides[i].NotesSlideManager;
                        INotesSlide notesSlide = notesManager.AddNotesSlide();
                        notesSlide.NotesTextFrame.Text = noteText;
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        // Handle unsupported file format exceptions
        catch (Aspose.Slides.PptxUnsupportedFormatException)
        {
            // Format not supported
        }
        catch (Aspose.Slides.PptUnsupportedFormatException)
        {
            // Format not supported
        }
        // Handle any other exceptions (e.g., file I/O, network errors)
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}