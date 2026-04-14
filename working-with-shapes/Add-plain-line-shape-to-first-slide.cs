using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddPlainLineShape
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a plain line shape to the first slide
                // Parameters: ShapeType, X, Y, Width, Height
                slide.Shapes.AddAutoShape(ShapeType.Line, 50f, 150f, 300f, 0f);

                // Define output file path
                string outputPath = "LineShapePresentation.pptx";

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // The requested SaveFormat is not supported
            }
            catch (PptxUnsupportedFormatException)
            {
                // Presentation file format is unsupported
            }
        }
    }
}