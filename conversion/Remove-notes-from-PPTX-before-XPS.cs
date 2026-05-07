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
            string inputPath = "input.pptx";
            string outputPath = "output.xps";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Remove notes from each slide
                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        Aspose.Slides.INotesSlideManager notesManager = presentation.Slides[i].NotesSlideManager;
                        notesManager.RemoveNotesSlide();
                    }

                    // Save to XPS format
                    Aspose.Slides.Export.XpsOptions xpsOptions = new Aspose.Slides.Export.XpsOptions();
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Xps, xpsOptions);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}