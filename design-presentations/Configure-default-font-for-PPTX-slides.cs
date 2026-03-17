using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var loadOptions = new LoadOptions(Aspose.Slides.LoadFormat.Auto);
            loadOptions.DefaultRegularFont = "Calibri";

            using (var presentation = new Presentation("input.pptx", loadOptions))
            {
                var sourceFont = new FontData("Arial");
                var destFont = new FontData("Calibri");
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