using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output file path
        string outputPath = "CustomSlideNumber.pptx";

        // Desired first slide number (e.g., start from 5)
        int startSlideNumber = 5;

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Set the first slide number for chapter alignment
        presentation.FirstSlideNumber = startSlideNumber;

        try
        {
            // Save the presentation in PPTX format
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle format not supported or other save errors
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }

        // Clean up resources
        presentation.Dispose();
    }
}