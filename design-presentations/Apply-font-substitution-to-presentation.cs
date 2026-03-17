using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FontSubstitutionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation
                Presentation presentation = new Presentation("input.pptx");

                // Define the source (missing) font and the substitute font
                IFontData sourceFont = new FontData("MissingFontName");
                IFontData substituteFont = new FontData("Arial");

                // Replace the missing font with the substitute font across the presentation
                presentation.FontsManager.ReplaceFont(sourceFont, substituteFont);

                // Save the updated presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}