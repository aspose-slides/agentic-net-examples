using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Apply a custom zoom preset of 75 percent for printing view
        presentation.ViewProperties.SlideViewProperties.Scale = 75;
        presentation.ViewProperties.NotesViewProperties.Scale = 75;

        // Verify scaling by reading back the values
        int slideScale = presentation.ViewProperties.SlideViewProperties.Scale;
        int notesScale = presentation.ViewProperties.NotesViewProperties.Scale;
        Console.WriteLine("Slide view scale: " + slideScale + "%");
        Console.WriteLine("Notes view scale: " + notesScale + "%");

        // Save the presentation before exiting
        string outputPath = "Zoom75.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}