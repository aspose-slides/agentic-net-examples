using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Define start and end coordinates for the line
                float startX = 100f;
                float startY = 100f;
                float endX = 300f;
                float endY = 200f;

                // Calculate width and height based on end coordinates
                float lineWidth = endX - startX;
                float lineHeight = endY - startY;

                // Add a line shape to the slide
                Aspose.Slides.IAutoShape lineShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, startX, startY, lineWidth, lineHeight);

                // Set line thickness (optional)
                lineShape.LineFormat.Width = 2f;

                // Save the presentation
                presentation.Save("LineShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}