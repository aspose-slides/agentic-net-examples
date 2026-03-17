using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ZoomDemo
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Add a second slide to link to
                Aspose.Slides.ISlide secondSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

                // Set view scaling for slide view and notes view (percentage)
                presentation.ViewProperties.SlideViewProperties.Scale = 150;
                presentation.ViewProperties.NotesViewProperties.Scale = 150;

                // Add a zoom frame on the first slide linking to the second slide
                Aspose.Slides.IZoomFrame zoomFrame = presentation.Slides[0].Shapes.AddZoomFrame(100, 100, 200, 150, secondSlide);
                zoomFrame.ReturnToParent = true;

                // Save the presentation
                presentation.Save("ZoomDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}