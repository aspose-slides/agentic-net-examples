using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ZoomBackgroundStripper
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx");

                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = pres.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                        // Check if the shape is a Zoom object
                        Aspose.Slides.IZoomObject zoomObject = shape as Aspose.Slides.IZoomObject;
                        if (zoomObject != null)
                        {
                            // Strip the background from the zoom frame
                            zoomObject.ShowBackground = false;
                        }
                    }
                }

                // Save the modified presentation
                pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}