using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths for input PPTX and output PPT files
        string inputPath = "input.pptx";
        string outputPath = "output.ppt";

        try
        {
            // Load the PPTX presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Save the presentation in PPT format, preserving all content and layout
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Ppt);
            }
        }
        catch (Exception ex)
        {
            // Output any errors that occur during conversion
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}