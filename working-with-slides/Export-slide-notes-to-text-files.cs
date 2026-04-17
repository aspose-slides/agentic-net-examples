using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output directory for notes files
            string outputDir = "NotesOutput";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            try
            {
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
                {
                    for (int i = 0; i < pres.Slides.Count; i++)
                    {
                        Aspose.Slides.ISlide slide = pres.Slides[i];
                        Aspose.Slides.INotesSlideManager notesMgr = slide.NotesSlideManager;
                        Aspose.Slides.INotesSlide notesSlide = notesMgr.NotesSlide;
                        string notesText = string.Empty;

                        if (notesSlide != null && notesSlide.NotesTextFrame != null)
                        {
                            notesText = notesSlide.NotesTextFrame.Text;
                        }

                        string noteFilePath = Path.Combine(outputDir, "Slide_" + (i + 1).ToString() + "_Notes.txt");
                        File.WriteAllText(noteFilePath, notesText);
                    }

                    // Save presentation before exit (no modifications made)
                    string savedPath = Path.Combine(outputDir, "SavedPresentation.pptx");
                    pres.Save(savedPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}