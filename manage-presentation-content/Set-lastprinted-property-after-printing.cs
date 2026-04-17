using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesMacro
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Path to the presentation file (first argument or default)
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPath = "output.pptx";

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
                    // Simulate printing operation here (actual printing not shown)

                    // After printing, set the LastPrinted property to current date and time
                    Aspose.Slides.IDocumentProperties docProps = presentation.DocumentProperties;
                    docProps.LastPrinted = DateTime.Now;

                    // Save the presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                // Handle unsupported PPTX format
                Console.WriteLine("Unsupported PPTX format: " + ex.Message);
            }
            catch (Aspose.Slides.PptUnsupportedFormatException ex)
            {
                // Handle unsupported PPT format
                Console.WriteLine("Unsupported PPT format: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., printing service errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}