using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ResizeShapeToFitText
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle autoshape
            Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 30, 30, 350, 100);

            // Create a portion with sample text
            Aspose.Slides.Portion portion = new Aspose.Slides.Portion("Lorem ipsum dolor sit amet, consectetur adipiscing elit.");

            // Set text color to black
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
            portion.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;

            // Add the portion to the shape's text frame
            autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

            // Set the shape to autofit the text (resize shape to fit text)
            Aspose.Slides.ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
            textFrameFormat.AutofitType = Aspose.Slides.TextAutofitType.Shape;

            // Save the presentation
            presentation.Save("ResizedShapeFitText.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}