using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CustomLineValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation pres = new Presentation();

                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Add a custom line shape (horizontal line)
                // Start point (50, 150), length 300 points
                IAutoShape lineShape = slide.Shapes.AddAutoShape(ShapeType.Line, 50f, 150f, 300f, 0f);

                // Retrieve start coordinates
                float startX = lineShape.X;
                float startY = lineShape.Y;

                // Retrieve end coordinates (X + Width, Y + Height)
                float endX = lineShape.X + lineShape.Width;
                float endY = lineShape.Y + lineShape.Height;

                // Expected coordinates
                float expectedStartX = 50f;
                float expectedStartY = 150f;
                float expectedEndX = 350f; // 50 + 300
                float expectedEndY = 150f; // 150 + 0

                // Validate positions
                bool isStartCorrect = Math.Abs(startX - expectedStartX) < 0.001f && Math.Abs(startY - expectedStartY) < 0.001f;
                bool isEndCorrect = Math.Abs(endX - expectedEndX) < 0.001f && Math.Abs(endY - expectedEndY) < 0.001f;

                if (isStartCorrect && isEndCorrect)
                {
                    Console.WriteLine("Custom line positioned correctly.");
                }
                else
                {
                    Console.WriteLine("Custom line positioning mismatch.");
                }

                // Save the presentation
                string outputPath = "CustomLineValidation_out.pptx";
                pres.Save(outputPath, SaveFormat.Pptx);

                // Dispose the presentation
                pres.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other exceptions
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // If the exception is due to unsupported format, the format is not supported.
            }
        }
    }
}