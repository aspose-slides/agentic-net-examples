using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";
            var sourceFontName = "Arial";
            var replacementFontName = "Calibri";

            using (var presentation = new Presentation(inputPath))
            {
                IFontData sourceFont = new FontData(sourceFontName);
                IFontData destFont = new FontData(replacementFontName);
                presentation.FontsManager.ReplaceFont(sourceFont, destFont);
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}