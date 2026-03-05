using System;
using Aspose.Slides;

namespace InsertColumnInPresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle auto shape
            Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle,
                100f, 100f, 300f, 300f);

            // Add a text frame to the shape
            shape.AddTextFrame("All these columns are limited to be within a single text container -- you can add or delete text and the new or remaining text automatically adjusts itself to stay within the container.");

            // Cast the read-only ITextFrameFormat to TextFrameFormat to modify properties
            Aspose.Slides.TextFrameFormat textFrameFormat = (Aspose.Slides.TextFrameFormat)shape.TextFrame.TextFrameFormat;

            // Set the number of columns
            textFrameFormat.ColumnCount = 2;

            // Optionally set column spacing
            textFrameFormat.ColumnSpacing = 20.0;

            // Save the presentation
            presentation.Save("ColumnsTest.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}