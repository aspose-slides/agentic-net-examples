using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Modify view settings
            presentation.ViewProperties.GridSpacing = 10.0f; // Set grid spacing
            presentation.ViewProperties.LastView = Aspose.Slides.ViewType.SlideView; // Set last view mode
            presentation.ViewProperties.ShowComments = Aspose.Slides.NullableBool.True; // Show comments
            presentation.ViewProperties.SlideViewProperties.Scale = 100; // Set slide view zoom to 100%
            presentation.ViewProperties.NotesViewProperties.Scale = 80; // Set notes view zoom to 80%

            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}