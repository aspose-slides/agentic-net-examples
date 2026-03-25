using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        // Error constant identifiers
        public const string ErrorFileNotFound = "Input file not found.";
        public const string ErrorReadFailed = "Failed to read presentation.";
        public const string ErrorSaveFailed = "Failed to save presentation.";

        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine(ErrorFileNotFound);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Example operation: add an empty slide based on the first slide's layout
                    presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

                    // Save the presentation before exiting
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            // Specific catch for reading errors
            catch (Aspose.Slides.PptxReadException readEx)
            {
                Console.WriteLine(ErrorReadFailed + " " + readEx.Message);
            }
            // Generic catch for any other exceptions
            catch (Exception ex)
            {
                Console.WriteLine(ErrorSaveFailed + " " + ex.Message);
            }
        }
    }
}