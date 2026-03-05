using System;
using Aspose.Slides.Export;

namespace RemoveZoomBackgroundExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a Section Zoom Frame (or regular Zoom Frame) to the first slide
            // Parameters: X, Y, Width, Height, target slide (second slide)
            Aspose.Slides.IZoomFrame zoomFrame = presentation.Slides[0].Shapes.AddZoomFrame(150, 20, 50, 50, presentation.Slides[1]);

            // Remove the background of the zoom object image
            zoomFrame.ShowBackground = false;

            // Save the presentation to a PPTX file
            presentation.Save("RemoveZoomBackground_out.pptx", SaveFormat.Pptx);
        }
    }
}