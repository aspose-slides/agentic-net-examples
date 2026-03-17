using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source PowerPoint file
            string inputPath = "input.pptx";

            // Path for the resulting PDF file
            string outputPath = "output.pdf";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Save the presentation as PDF
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);

            // Release resources
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Output any errors that occur during conversion
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}