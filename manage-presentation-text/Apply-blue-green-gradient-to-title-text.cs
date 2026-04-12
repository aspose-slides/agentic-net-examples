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