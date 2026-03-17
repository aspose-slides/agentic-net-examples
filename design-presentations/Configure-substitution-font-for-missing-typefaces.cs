using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
            {
                Aspose.Slides.IFontData sourceFont = new Aspose.Slides.FontData("MissingFont");
                Aspose.Slides.IFontData destFont = new Aspose.Slides.FontData("Arial");
                presentation.FontsManager.ReplaceFont(sourceFont, destFont);
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}