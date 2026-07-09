using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace HyperlinkLineExample
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

                // Add a line shape to the slide
                Aspose.Slides.IShape lineShape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Line,
                    100f,   // X position
                    150f,   // Y position
                    400f,   // Width (length of the line)
                    0f);    // Height (horizontal line)

                // Assign an external hyperlink that opens an email with a subject line
                Aspose.Slides.IHyperlinkManager hyperlinkManager = lineShape.HyperlinkManager;
                hyperlinkManager.SetExternalHyperlinkClick("mailto:test@example.com?subject=Hello%20World");

                // Save the presentation
                presentation.Save("LineWithEmailHyperlink.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format)
                // Format not supported: handle accordingly
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}