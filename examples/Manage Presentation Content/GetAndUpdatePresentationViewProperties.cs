using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Retrieve current view zoom values
        int currentSlideZoom = presentation.ViewProperties.SlideViewProperties.Scale;
        int currentNotesZoom = presentation.ViewProperties.NotesViewProperties.Scale;
        Console.WriteLine("Current Slide View Zoom: " + currentSlideZoom);
        Console.WriteLine("Current Notes View Zoom: " + currentNotesZoom);

        // Update view zoom values (e.g., set to 150%)
        presentation.ViewProperties.SlideViewProperties.Scale = 150;
        presentation.ViewProperties.NotesViewProperties.Scale = 150;

        // Save the updated presentation in PPTX format
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}