using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ApplyCustomFont
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

                // Define the custom font name to apply uniformly
                string customFontName = "Arial";

                // Create a FontData object for the destination font
                Aspose.Slides.IFontData destFont = new Aspose.Slides.FontData(customFontName);

                // Retrieve all fonts used in the presentation
                Aspose.Slides.IFontData[] allFonts = pres.FontsManager.GetFonts();

                // Replace each source font with the custom font
                foreach (Aspose.Slides.IFontData sourceFont in allFonts)
                {
                    pres.FontsManager.ReplaceFont(sourceFont, destFont);
                }

                // Save the presentation
                string outPath = "CustomFontPresentation.pptx";
                pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Dispose the presentation
                pres.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}