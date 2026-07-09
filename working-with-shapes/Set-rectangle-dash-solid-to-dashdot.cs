using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesDemo
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                using (Presentation presentation = new Presentation())
                {
                    // Get the first slide
                    ISlide slide = presentation.Slides[0];

                    // Add a rectangle shape
                    IShape rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 200);

                    // Set line dash style to Solid
                    rectangle.LineFormat.DashStyle = LineDashStyle.Solid;

                    Console.WriteLine("Press Enter to change line dash style to DashDot...");
                    // Use ReadLine to avoid console input redirection issues
                    Console.ReadLine();

                    // Change line dash style to DashDot
                    rectangle.LineFormat.DashStyle = LineDashStyle.DashDot;

                    // Save the presentation
                    presentation.Save("RectangleDashStyle_out.pptx", SaveFormat.Pptx);
                }
            }
            // Handle unsupported format exceptions with a comment
            catch (PptUnsupportedFormatException)
            {
                // Format not supported
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported
            }
            // Catch any other exceptions
            catch (Exception)
            {
                // General error handling
            }
        }
    }
}