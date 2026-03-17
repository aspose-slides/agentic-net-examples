using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            LoadOptions loadOptions = new LoadOptions();
            dynamic dynLoadOptions = loadOptions;
            dynLoadOptions.TextAsShapes = true;

            using (Presentation pres = new Presentation(inputPath, loadOptions))
            {
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}