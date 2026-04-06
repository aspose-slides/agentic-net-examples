using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportNotesToExcel
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PowerPoint file path
            string presentationPath = "input.pptx";
            // Output CSV file path (Excel can open CSV)
            string csvPath = "NotesExport.csv";

            // Verify that the presentation file exists
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("Presentation file not found: " + presentationPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(presentationPath))
                {
                    // Collect notes from each slide
                    List<string> notesList = new List<string>();

                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        // Access the notes slide manager for the current slide
                        INotesSlideManager notesManager = presentation.Slides[i].NotesSlideManager;
                        // Retrieve the notes slide (may be null)
                        INotesSlide notesSlide = notesManager.NotesSlide;
                        if (notesSlide != null && notesSlide.NotesTextFrame != null)
                        {
                            string noteText = notesSlide.NotesTextFrame.Text;
                            notesList.Add(noteText);
                        }
                        else
                        {
                            // If no notes, add an empty string to keep cell order
                            notesList.Add(string.Empty);
                        }
                    }

                    // Write notes to CSV (each note in a separate cell/row)
                    using (StreamWriter writer = new StreamWriter(csvPath, false))
                    {
                        foreach (string note in notesList)
                        {
                            // Escape double quotes by doubling them
                            string escaped = note.Replace("\"", "\"\"");
                            writer.WriteLine("\"" + escaped + "\"");
                        }
                    }

                    // Save the presentation before exiting (no modifications made)
                    presentation.Save(presentationPath, SaveFormat.Pptx);
                }

                Console.WriteLine("Notes exported successfully to: " + csvPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported by Aspose.Slides.
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}