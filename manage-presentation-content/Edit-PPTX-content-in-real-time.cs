using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load an existing presentation
                using (Presentation presentation = new Presentation("input.pptx"))
                {
                    // Get the first slide
                    ISlide slide = presentation.Slides[0];

                    // Add a rectangle shape with some text
                    IAutoShape rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
                    rectangle.AddTextFrame("Hello World");

                    // Set slide transition duration (in milliseconds)
                    slide.SlideShowTransition.Duration = 2000;

                    // Add a zoom frame to demonstrate setting a float property (requires 'F' suffix)
                    if (presentation.Slides.Count > 1)
                    {
                        IZoomFrame zoomFrame = slide.Shapes.AddZoomFrame(150, 20, 50, 50, presentation.Slides[1]);
                        zoomFrame.TransitionDuration = 2.5f; // Float literal with 'F' suffix
                    }

                    // Save the modified presentation
                    presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}