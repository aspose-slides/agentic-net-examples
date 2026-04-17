using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesNotesExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define data directory
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            // Define input and output file paths
            string inputPath = Path.Combine(dataDir, "input.pptx");
            string outputJsonPath = Path.Combine(dataDir, "notes.json");
            string outputPresentationPath = Path.Combine(dataDir, "output.pptx");

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // List to hold notes information
                    List<Dictionary<string, string>> notesList = new List<Dictionary<string, string>>();

                    // Iterate through slides
                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        ISlide slide = presentation.Slides[i];
                        INotesSlideManager notesManager = slide.NotesSlideManager;
                        INotesSlide notesSlide = notesManager.NotesSlide;

                        if (notesSlide != null && notesSlide.NotesTextFrame != null)
                        {
                            string noteText = notesSlide.NotesTextFrame.Text;

                            Dictionary<string, string> entry = new Dictionary<string, string>();
                            entry["SlideNumber"] = (i + 1).ToString();
                            entry["NoteText"] = noteText ?? string.Empty;

                            notesList.Add(entry);
                        }
                    }

                    // Serialize notes to JSON
                    string json = JsonSerializer.Serialize(notesList, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(outputJsonPath, json);

                    // Save presentation before exit
                    presentation.Save(outputPresentationPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // Note: If the file format is not supported, an exception will be thrown.
            }
        }
    }
}