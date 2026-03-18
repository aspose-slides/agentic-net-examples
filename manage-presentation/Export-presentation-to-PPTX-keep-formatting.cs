using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
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