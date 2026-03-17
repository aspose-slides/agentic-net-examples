using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertPresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Define input and output file paths
                string inputPath = "input.ppt";
                string outputPath = "output.pptx";

                // Load the existing PPT presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Create PPTX save options using the factory
                    SaveOptionsFactory optionsFactory = new SaveOptionsFactory();
                    IPptxOptions pptxOptions = optionsFactory.CreatePptxOptions();

                    // Save the presentation as PPTX with the specified options
                    presentation.Save(outputPath, SaveFormat.Pptx, pptxOptions);
                }
            }
            catch (Exception ex)
            {
                // Output any errors that occur during conversion
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}