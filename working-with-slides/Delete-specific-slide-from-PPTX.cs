using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source presentation
            string inputPath = "input.pptx";
            // Path where the modified presentation will be saved
            string outputPath = "output.pptx";

            // Load the presentation from the file
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Remove the slide at the desired zero‑based index (e.g., first slide)
            presentation.Slides.RemoveAt(0);

            // Save the updated presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}