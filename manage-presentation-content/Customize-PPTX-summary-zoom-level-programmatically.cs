using System;
using Aspose.Slides.Export;

namespace AdjustZoomExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

                // Adjust the zoom level for slide view (percentage)
                presentation.ViewProperties.SlideViewProperties.Scale = 150;

                // Optionally adjust the zoom level for notes view
                presentation.ViewProperties.NotesViewProperties.Scale = 150;

                // Save the modified presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

                // Release resources
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}