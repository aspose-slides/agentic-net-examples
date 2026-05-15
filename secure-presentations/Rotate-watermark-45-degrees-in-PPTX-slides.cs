using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace WatermarkRotationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Define watermark text
                string watermarkText = "CONFIDENTIAL";

                // Iterate through all slides and add rotated watermark
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    ISlide slide = presentation.Slides[i];

                    // Add a rectangular auto shape to hold the watermark
                    IAutoShape watermarkShape = slide.Shapes.AddAutoShape(
                        ShapeType.Rectangle,
                        100,   // X position
                        100,   // Y position
                        400,   // Width
                        100);  // Height

                    // Add text frame with the watermark text
                    watermarkShape.AddTextFrame(watermarkText);

                    // Set shape fill to no fill (transparent)
                    watermarkShape.FillFormat.FillType = FillType.NoFill;

                    // Set line format to no fill (no border)
                    watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;

                    // Rotate the shape 45 degrees for diagonal placement
                    watermarkShape.Rotation = 45f;

                    // Optionally, rotate the text inside the shape as well
                    watermarkShape.TextFrame.TextFrameFormat.RotationAngle = 45f;
                }

                // Save the presentation
                presentation.Save("WatermarkRotated.pptx", SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Handle accordingly
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file I/O, network)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}