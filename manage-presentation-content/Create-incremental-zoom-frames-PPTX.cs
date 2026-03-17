using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ZoomFramesDemo
{
    class Program
    {
        static void Main()
        {
            try
            {
                var pres = new Presentation();

                // Add a second slide based on the layout of the first slide
                var secondSlide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

                // Add a zoom frame on the first slide that links to the second slide
                var zoom1 = pres.Slides[0].Shapes.AddZoomFrame(100, 100, 200, 150, secondSlide);
                zoom1.AlternativeText = "Zoom to Slide 2";

                // Add a zoom frame on the second slide that links back to the first slide
                var zoom2 = secondSlide.Shapes.AddZoomFrame(100, 100, 200, 150, pres.Slides[0]);
                zoom2.AlternativeText = "Zoom to Slide 1";

                // Save the presentation
                pres.Save("ZoomFrames.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}