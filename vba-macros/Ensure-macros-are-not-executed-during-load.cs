using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace VerifyMacros
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptm");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation with option to delete embedded binary objects (including macros)
                Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
                loadOptions.DeleteEmbeddedBinaryObjects = true;

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath, loadOptions))
                {
                    // Verify that macros (VBA project) are not present after loading
                    if (presentation.VbaProject == null)
                    {
                        Console.WriteLine("Macros are not present after loading.");
                    }
                    else
                    {
                        Console.WriteLine("Macros are still present after loading.");
                    }

                    // Save the presentation (macros will not be executed during save)
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                // Format not supported
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}