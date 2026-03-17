using System;
using Aspose.Slides.Export;
using System.Drawing;

namespace SlideDeckCreator
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
                Aspose.Slides.ISlide firstSlide = presentation.Slides[0];

                // Add a rectangle shape
                Aspose.Slides.IShape rectangle = firstSlide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 200);
                rectangle.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                rectangle.FillFormat.SolidFillColor.Color = Color.LightBlue;

                // Add a text frame to the rectangle
                Aspose.Slides.ITextFrame textFrame = ((Aspose.Slides.IAutoShape)rectangle).AddTextFrame("Hello Aspose.Slides!");
                textFrame.Paragraphs[0].ParagraphFormat.Alignment = Aspose.Slides.TextAlignment.Center;

                // Add a second slide using the layout of the first slide
                Aspose.Slides.ILayoutSlide layout = presentation.Slides[0].LayoutSlide;
                Aspose.Slides.ISlide secondSlide = presentation.Slides.AddEmptySlide(layout);

                // Save the presentation
                presentation.Save("CreatedPresentation.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}