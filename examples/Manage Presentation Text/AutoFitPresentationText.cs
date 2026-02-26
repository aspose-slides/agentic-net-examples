using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AutoFitDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Add a rectangle autoshape
                Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 30, 30, 350, 100);

                // Create a text portion
                Aspose.Slides.Portion portion = new Aspose.Slides.Portion(
                    "This text will be auto‑fitted inside the shape.");

                // Set text color to black
                portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
                portion.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;

                // Add the portion to the shape's text frame
                autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

                // Enable autofit for the text frame (fit text to shape)
                Aspose.Slides.ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
                textFrameFormat.AutofitType = Aspose.Slides.TextAutofitType.Shape;

                // Save the presentation
                pres.Save("AutoFitPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}