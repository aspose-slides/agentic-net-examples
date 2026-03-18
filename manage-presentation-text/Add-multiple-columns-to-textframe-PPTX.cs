using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlidesColumnExample
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

                // Add a rectangle auto shape to hold the text frame
                Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 100, 100, 400, 300);

                // Add a text frame with initial text
                shape.AddTextFrame(
                    "All these columns are forced to stay within a single text container -- " +
                    "you can add or delete text and the new or remaining text automatically adjusts " +
                    "itself to stay within the container. You cannot have text spill over from one " +
                    "container to another, though -- because PowerPoint's column options for text are limited!");

                // Get the text frame and its format
                Aspose.Slides.ITextFrame textFrame = shape.TextFrame;
                Aspose.Slides.ITextFrameFormat format = textFrame.TextFrameFormat;

                // Set the number of columns and spacing between them
                format.ColumnCount = 3;
                format.ColumnSpacing = 20;

                // Save the presentation
                string outputPath = "ColumnsDemo.pptx";
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}