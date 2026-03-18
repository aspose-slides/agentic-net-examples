using System;
using System.Drawing;
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

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a rectangle auto shape
                Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 100, 100, 400, 200);

                // Add an empty text frame to the shape
                shape.AddTextFrame("");

                // Remove shape fill
                shape.FillFormat.FillType = Aspose.Slides.FillType.NoFill;

                // Access the text frame
                Aspose.Slides.ITextFrame txtFrame = shape.TextFrame;

                // Set vertical anchor to bottom
                txtFrame.TextFrameFormat.AnchoringType = Aspose.Slides.TextAnchorType.Bottom;

                // Access the first paragraph and portion
                Aspose.Slides.IParagraph para = txtFrame.Paragraphs[0];
                Aspose.Slides.IPortion portion = para.Portions[0];

                // Set the text and its color
                portion.Text = "Anchored Text";
                portion.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                portion.PortionFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

                // Save the presentation
                string outputPath = "AnchoredTextFrame.pptx";
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Clean up
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}