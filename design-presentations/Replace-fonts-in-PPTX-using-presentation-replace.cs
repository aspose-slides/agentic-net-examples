using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (var presentation = new Aspose.Slides.Presentation("input.pptx"))
            {
                var sourceFont = new Aspose.Slides.FontData("Arial");
                var destFont = new Aspose.Slides.FontData("Calibri");
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