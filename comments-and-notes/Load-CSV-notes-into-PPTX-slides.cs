using System;
using System.IO;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            string presentationPath = "input.pptx";
            string csvPath = "notes.csv";
            string outputPath = "output.pptx";

            // Verify input files exist
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("Presentation file not found: " + presentationPath);
                return;
            }

            if (!File.Exists(csvPath))
            {
                Console.WriteLine("CSV file not found: " + csvPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(presentationPath))
                {
                    // Read CSV lines (format: slideNumber,NoteText)
                    using (StreamReader reader = new StreamReader(csvPath))
                    {
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            if (string.IsNullOrWhiteSpace(line))
                                continue;

                            string[] parts = line.Split(new char[] { ',' }, 2);
                            if (parts.Length < 2)
                                continue;

                            int slideNumber;
                            if (!int.TryParse(parts[0], out slideNumber))
                                continue;

                            string noteText = parts[1];

                            // Ensure slide number is within range
                            if (slideNumber >= 1 && slideNumber <= presentation.Slides.Count)
                            {
                                Aspose.Slides.INotesSlideManager notesManager = presentation.Slides[slideNumber - 1].NotesSlideManager;
                                Aspose.Slides.INotesSlide notesSlide = notesManager.AddNotesSlide();
                                notesSlide.NotesTextFrame.Text = noteText;
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            // Handle unsupported format exceptions
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                // Format not supported
            }
            // General exception handling
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}