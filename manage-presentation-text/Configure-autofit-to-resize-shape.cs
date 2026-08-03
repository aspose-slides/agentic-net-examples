// -----------------------------------------------------------------------------
// Example: Configure autofit to resize shape using C#
//
// Description:
// Demonstrates how to configure the TextFrame autofit to resize a shape
// automatically based on its text content using Aspose.Slides for .NET.
// The example creates a presentation, adds a rectangle shape with a text
// frame, sets the autofit type to Shape, modifies the text, and saves the
// result as a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Configure, Autofit, Resize, Shape, TextFrame, Presentation Processing
//
// Use Cases:
// - Automatically adjust shape size to fit dynamic text.
// - Build .NET utilities that modify PowerPoint layouts.
// - Generate PPTX files with content‑driven shape dimensions.
// - Validate autofit behavior in automated presentation workflows.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

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

            // Add a rectangle auto shape
            Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 30, 30, 350, 100);

            // Add a text frame with initial text
            shape.AddTextFrame("Initial text");

            // Get the text frame
            Aspose.Slides.ITextFrame txtFrame = shape.TextFrame;

            // Set autofit type to Shape (resize shape to fit text)
            txtFrame.TextFrameFormat.AutofitType = Aspose.Slides.TextAutofitType.Shape;

            // Set the text content
            Aspose.Slides.IParagraph paragraph = txtFrame.Paragraphs[0];
            Aspose.Slides.IPortion portion = paragraph.Portions[0];
            portion.Text = "This is a sample text that will cause the shape to resize automatically.";

            // Set text color to black
            portion.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

            // Save the presentation
            presentation.Save("AutofitShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
