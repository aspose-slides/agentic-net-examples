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
            string outputPath = "output.ppt";

            // Load the PPTX presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Create PPT save options
                Aspose.Slides.Export.PptOptions options = new Aspose.Slides.Export.PptOptions();

                // Save the presentation as PPT preserving formatting
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Ppt, options);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}