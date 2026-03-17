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
            var outputPath = "output.ppt";

            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Convert PPTX to PPT format
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Ppt);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}