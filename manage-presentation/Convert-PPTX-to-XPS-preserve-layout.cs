using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var inputPath = "input.pptx";
            var outputPath = "output.xps";

            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                presentation.Save(outputPath, SaveFormat.Xps);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}