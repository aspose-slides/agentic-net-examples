using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get reference to the first (default) slide
        Aspose.Slides.ISlide firstSlide = presentation.Slides[0];

        // Add a second slide by cloning the first slide
        Aspose.Slides.ISlide secondSlide = presentation.Slides.AddClone(firstSlide);

        // Add a Zoom frame on the first slide that links to the second slide
        Aspose.Slides.IZoomFrame zoomFrame = firstSlide.Shapes.AddZoomFrame(150f, 20f, 100f, 100f, secondSlide);

        // Set alternative text for the zoom frame
        zoomFrame.AlternativeText = "Zoom to second slide";

        // Save the presentation to a PPTX file
        presentation.Save("ZoomFramesPresentation.pptx", SaveFormat.Pptx);
    }
}