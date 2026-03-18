using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                var presentation = new Presentation();

                // Get the first slide (declare as ISlide to avoid CS0266)
                var slide = presentation.Slides[0];

                // Example: add a rectangle shape to the slide
                var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
                shape.TextFrame.Text = "Custom Function Placeholder";

                // TODO: Invoke custom function on the slide if applicable
                // e.g., slide.Function(...); // Replace with actual method when available
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // Ensure the presentation is saved before exit
                using (var presentation = new Presentation())
                {
                    presentation.Save("CustomFunctionPresentation.pptx", SaveFormat.Pptx);
                }
            }
        }
    }
}