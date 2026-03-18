using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InsertColumnsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
                {
                    // Get the first slide
                    Aspose.Slides.ISlide slide = presentation.Slides[0];

                    // Add a rectangle AutoShape
                    Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(
                        ShapeType.Rectangle, 100, 100, 300, 300);

                    // Add a TextFrame with sample text
                    autoShape.AddTextFrame(
                        "All these columns are limited to be within a single text container -- " +
                        "you can add or delete text and the new or remaining text automatically adjusts " +
                        "itself to flow within the container. You cannot have text flow from one container " +
                        "to other though -- we told you PowerPoint's column options for text are limited!");

                    // Access the TextFrame format
                    Aspose.Slides.ITextFrameFormat textFormat = autoShape.TextFrame.TextFrameFormat;

                    // Set number of columns and spacing
                    textFormat.ColumnCount = 3;
                    textFormat.ColumnSpacing = 15;

                    // Save the presentation
                    string outPath = "ColumnsExample.pptx";
                    presentation.Save(outPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}