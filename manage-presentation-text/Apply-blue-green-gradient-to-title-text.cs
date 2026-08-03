// -----------------------------------------------------------------------------
// Example: Apply blue green gradient to title text using C#
//
// Description:
// Demonstrates how to apply a blue‑to‑green gradient fill to title text in a
// PowerPoint presentation using C# and Aspose.Slides for .NET. The example
// creates a new presentation, adds a title shape, applies a gradient fill to
// each text portion, and saves the result as a PPTX file. Developers can use
// this pattern to automate PPTX workflows, customize text styling, or integrate
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, Blue, Green, Gradient,
// Text, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate applying a blue‑green gradient to title text in presentations.
// - Build C# tools for PowerPoint text styling and processing.
// - Generate or transform PPTX files with custom text effects in .NET apps.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output file path
        string outputPath = "TitleGradient.pptx";

        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape to act as the title placeholder
            Aspose.Slides.IAutoShape titleShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50, 50, 600, 100);
            titleShape.TextFrame.Text = "Gradient Title";

            // Apply a blue‑to‑green gradient fill to each text portion in the title
            foreach (Aspose.Slides.IParagraph paragraph in titleShape.TextFrame.Paragraphs)
            {
                foreach (Aspose.Slides.IPortion portion in paragraph.Portions)
                {
                    portion.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Gradient;

                    // Clear any existing gradient stops
                    portion.PortionFormat.FillFormat.GradientFormat.GradientStops.Clear();

                    // Add gradient stops: blue at the start (position 0), green at the end (position 1)
                    portion.PortionFormat.FillFormat.GradientFormat.GradientStops.Add(0f, System.Drawing.Color.Blue);
                    portion.PortionFormat.FillFormat.GradientFormat.GradientStops.Add(1f, System.Drawing.Color.Green);
                }
            }

            // Save the presentation, handling unsupported format exceptions
            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
        }
    }
}
