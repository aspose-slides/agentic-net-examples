using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReplaceFontsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.pptx";
                string outputPath = "output.pptx";

                using (Presentation presentation = new Presentation(inputPath))
                {
                    IFontData sourceFont = new FontData("Arial");
                    IFontData destFont = new FontData("Calibri");

                    presentation.FontsManager.ReplaceFont(sourceFont, destFont);

                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}