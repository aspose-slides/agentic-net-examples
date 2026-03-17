using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ZoomControlExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation from a file
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

                // Set the zoom level for slide view (percentage)
                presentation.ViewProperties.SlideViewProperties.Scale = 150;

                // Set the zoom level for notes view (percentage)
                presentation.ViewProperties.NotesViewProperties.Scale = 120;

                // Enable automatic scaling to best fit the window (optional)
                presentation.ViewProperties.SlideViewProperties.VariableScale = true;

                // Save the modified presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}