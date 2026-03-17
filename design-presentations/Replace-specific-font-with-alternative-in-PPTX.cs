using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FontReplacementExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the source presentation
                var inputPath = "input.pptx";
                // Path to the output presentation
                var outputPath = "output.pptx";

                // Load the presentation
                using (var presentation = new Presentation(inputPath))
                {
                    // Define the font to be replaced (source) and the replacement font (destination)
                    var sourceFont = new FontData("Arial");
                    var destFont = new FontData("Calibri");

                    // Replace the font throughout the presentation
                    presentation.FontsManager.ReplaceFont(sourceFont, destFont);

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}