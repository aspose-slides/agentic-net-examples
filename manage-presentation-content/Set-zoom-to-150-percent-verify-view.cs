using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Apply a zoom level of 150% to slide view and notes view
        presentation.ViewProperties.SlideViewProperties.Scale = 150;
        presentation.ViewProperties.NotesViewProperties.Scale = 150;

        // Define output file path
        string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "ZoomedPresentation.pptx");

        try
        {
            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }
        finally
        {
            // Ensure resources are released
            presentation.Dispose();
        }
    }
}