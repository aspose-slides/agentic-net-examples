using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReplaceFontExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
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
                Presentation presentation = new Presentation(inputPath);

                // Define source and destination fonts
                IFontData sourceFont = new FontData("Arial");
                IFontData destFont = new FontData("Calibri");

                // Replace the source font with the destination font
                presentation.FontsManager.ReplaceFont(sourceFont, destFont);

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);

                // Dispose the presentation object
                presentation.Dispose();

                Console.WriteLine("Font replacement completed successfully.");
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format, loading errors)
                Console.WriteLine("An error occurred: " + ex.Message);
                // If the exception is due to an unsupported format, you may add a comment here.
                // Format not supported.
            }
        }
    }
}