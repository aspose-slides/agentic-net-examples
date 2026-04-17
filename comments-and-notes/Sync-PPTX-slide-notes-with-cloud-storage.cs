using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlidesNotesFromJson
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths
            string inputPresentationPath = "input.pptx";
            string jsonNotesPath = "notes.json";
            string outputPresentationPath = "output.pptx";

            // Verify input files exist
            if (!File.Exists(inputPresentationPath))
            {
                Console.WriteLine("Input presentation file does not exist.");
                return;
            }

            if (!File.Exists(jsonNotesPath))
            {
                Console.WriteLine("JSON notes file does not exist.");
                return;
            }

            try
            {
                // Load presentation
                Presentation presentation = new Presentation(inputPresentationPath);

                // Read and deserialize JSON notes (expected format: { "0": "Note for slide 1", "1": "Note for slide 2", ... })
                string jsonContent = File.ReadAllText(jsonNotesPath);
                Dictionary<int, string> notesDictionary = JsonSerializer.Deserialize<Dictionary<int, string>>(jsonContent);

                // Assign notes to slides
                foreach (KeyValuePair<int, string> entry in notesDictionary)
                {
                    int slideIndex = entry.Key;
                    string noteText = entry.Value;

                    if (slideIndex < 0 || slideIndex >= presentation.Slides.Count)
                    {
                        Console.WriteLine($"Slide index {slideIndex} is out of range. Skipping.");
                        continue;
                    }

                    INotesSlideManager notesManager = presentation.Slides[slideIndex].NotesSlideManager;
                    INotesSlide notesSlide = notesManager.AddNotesSlide();
                    notesSlide.NotesTextFrame.Text = noteText;
                }

                // Save the updated presentation
                presentation.Save(outputPresentationPath, SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Handle unsupported file format here
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}