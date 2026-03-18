using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a rectangle shape to hold error constants
                Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 500, 300);

                // Cast to IAutoShape to access the TextFrame
                Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                if (autoShape != null)
                {
                    string errorConstants = "Error Constants:\n" +
                                            "PptxEditException\n" +
                                            "PptEditException\n" +
                                            "PptxReadException\n" +
                                            "PptReadException\n" +
                                            "CannotCombine2DAnd3DChartsException";

                    // Set the text of the shape
                    autoShape.TextFrame.Text = errorConstants;
                }

                // Save the presentation
                presentation.Save("ErrorConstantsPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Aspose.Slides.PptxEditException ex)
            {
                Console.WriteLine("PptxEditException: " + ex.Message);
            }
            catch (Aspose.Slides.PptEditException ex)
            {
                Console.WriteLine("PptEditException: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General exception: " + ex.Message);
            }
        }
    }
}