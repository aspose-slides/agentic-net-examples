using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveNotesAndConvertToXps
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPath = "output.xps";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                Presentation pres = new Presentation(inputPath);

                // Remove notes from each slide
                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    ISlide slide = pres.Slides[i];
                    INotesSlideManager notesMgr = slide.NotesSlideManager;
                    if (notesMgr != null && notesMgr.NotesSlide != null)
                    {
                        notesMgr.RemoveNotesSlide();
                    }
                }

                // Save as XPS with default options
                XpsOptions options = new XpsOptions();
                pres.Save(outputPath, SaveFormat.Xps, options);

                // Save presentation before exit (already saved as XPS)
                pres.Dispose();
                Console.WriteLine("Presentation converted to XPS without speaker notes: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}