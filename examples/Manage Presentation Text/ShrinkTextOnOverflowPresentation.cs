using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ShrinkTextOnOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape to hold the text
            Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 30, 30, 350, 100);

            // Create a long portion of text
            Aspose.Slides.Portion portion = new Aspose.Slides.Portion(
                "This is a very long text that should shrink automatically if it overflows the shape boundaries. " +
                "The text will be reduced in size to fit within the rectangle.");

            // Set text color and fill type
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
            portion.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;

            // Add the portion to the shape's first paragraph
            autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

            // Enable normal autofit (shrink text on overflow)
            Aspose.Slides.ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
            textFrameFormat.AutofitType = Aspose.Slides.TextAutofitType.Normal;

            // Save the presentation as PPTX
            presentation.Save("ShrunkTextPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}