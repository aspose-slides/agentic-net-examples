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
            string outputPath = "output.xps";

            // Load the presentation file
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Save the presentation to XPS format using default settings
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Xps);
            }

            Console.WriteLine("Presentation successfully converted to XPS.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}