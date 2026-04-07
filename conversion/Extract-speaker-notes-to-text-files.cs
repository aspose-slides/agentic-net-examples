using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input presentation path
        string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Create output directory
                string outDir = Path.Combine(Environment.CurrentDirectory, "output");
                if (!Directory.Exists(outDir))
                {
                    Directory.CreateDirectory(outDir);
                }

                // Iterate through slides
                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    ISlide slide = pres.Slides[i];

                    // Save slide as TIFF image
                    string imagePath = Path.Combine(outDir, $"slide_{i + 1}.tiff");
                    slide.GetImage().Save(imagePath, Aspose.Slides.ImageFormat.Tiff);

                    // Extract speaker notes if present
                    INotesSlide notesSlide = slide.NotesSlideManager.NotesSlide;
                    if (notesSlide != null && notesSlide.NotesTextFrame != null)
                    {
                        string notesText = notesSlide.NotesTextFrame.Text;
                        string notesPath = Path.Combine(outDir, $"slide_{i + 1}_notes.txt");
                        File.WriteAllText(notesPath, notesText);
                    }
                }

                // Save the (potentially modified) presentation
                string presOutPath = Path.Combine(outDir, "presentation_out.pptx");
                pres.Save(presOutPath, SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}