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

                // Add a rectangle AutoShape
                Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 300);

                // Add a TextFrame with sample text
                autoShape.AddTextFrame("All these columns are limited to be within a single text container -- you can add or delete text and the new or remaining text automatically adjusts itself to flow within the container. You cannot have text flow from one container to other though.");

                // Get the TextFrameFormat
                Aspose.Slides.ITextFrameFormat textFormat = autoShape.TextFrame.TextFrameFormat;

                // Set the number of columns
                textFormat.ColumnCount = 2;

                // Set column spacing (optional)
                textFormat.ColumnSpacing = 20;

                // Save the modified presentation
                presentation.Save("ColumnsOutput.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}