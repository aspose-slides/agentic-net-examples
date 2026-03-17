using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ZoomFrameExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide firstSlide = presentation.Slides[0];

                // Add a second slide based on the layout of the first slide
                Aspose.Slides.ILayoutSlide layout = firstSlide.LayoutSlide;
                Aspose.Slides.ISlide secondSlide = presentation.Slides.AddEmptySlide(layout);

                // Add a zoom frame to the first slide that links to the second slide
                Aspose.Slides.IZoomFrame zoomFrame = firstSlide.Shapes.AddZoomFrame(100f, 100f, 200f, 150f, secondSlide);

                // Adjust zoom frame properties
                zoomFrame.X = 120f;
                zoomFrame.Y = 80f;
                zoomFrame.Width = 250f;
                zoomFrame.Height = 180f;
                zoomFrame.ShowBackground = false;
                zoomFrame.TransitionDuration = 2.0f;
                zoomFrame.ImageType = Aspose.Slides.ZoomImageType.Preview;

                // Save the presentation
                presentation.Save("ZoomFrameOutput.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}