using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "source.odp";
            string outputPath = "output.pptx";

            Aspose.Slides.Presentation sourcePresentation = new Aspose.Slides.Presentation(sourcePath);
            sourcePresentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}