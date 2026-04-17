using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportPptToPng
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input presentation path
            string inputPath = "input.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Iterate through all slides and export each as PNG with default resolution
                    for (int index = 0; index < presentation.Slides.Count; index++)
                    {
                        Aspose.Slides.ISlide slide = presentation.Slides[index];
                        using (Aspose.Slides.IImage image = slide.GetImage())
                        {
                            string outputFile = string.Format("slide_{0}.png", slide.SlideNumber);
                            image.Save(outputFile, Aspose.Slides.ImageFormat.Png);
                        }
                    }

                    // Save the presentation before exiting (no modifications made)
                    presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}