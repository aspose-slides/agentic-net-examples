using System;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle AutoShape
            Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 300);

            // Add a TextFrame with initial text
            Aspose.Slides.ITextFrame textFrame = autoShape.AddTextFrame("All these columns are forced to stay within a single text container -- you can add or delete text and the new or remaining text automatically adjusts itself to stay within the container.");

            // Get the TextFrame format
            Aspose.Slides.ITextFrameFormat format = textFrame.TextFrameFormat;

            // Set number of columns
            format.ColumnCount = 2;

            // Set column spacing
            format.ColumnSpacing = 20;

            // Save the presentation
            presentation.Save("ColumnsDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}