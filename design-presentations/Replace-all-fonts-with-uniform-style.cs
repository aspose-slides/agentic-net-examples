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
                // Load the presentation
                Presentation presentation = new Presentation("input.pptx");

                // Define source and destination fonts
                IFontData sourceFont = new FontData("Arial");
                IFontData destFont = new FontData("Calibri");

                // Replace all occurrences of the source font with the destination font
                presentation.FontsManager.ReplaceFont(sourceFont, destFont);

                // Save the updated presentation
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}