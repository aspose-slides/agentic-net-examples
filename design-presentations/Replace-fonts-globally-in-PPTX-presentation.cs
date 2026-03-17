using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Paths to the source and destination files
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Define the font to be replaced and the new font
                IFontData sourceFont = new FontData("Arial");
                IFontData destinationFont = new FontData("Calibri");

                // Replace all occurrences of the source font with the destination font
                presentation.FontsManager.ReplaceFont(sourceFont, destinationFont);

                // Save the updated presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}