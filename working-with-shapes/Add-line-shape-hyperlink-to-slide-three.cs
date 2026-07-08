using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace HyperlinkLineExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output file path
            string outputPath = "LineHyperlink.pptx";

            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Get reference to the first slide
                Aspose.Slides.ISlide firstSlide = presentation.Slides[0];

                // Add a second slide to navigate to
                Aspose.Slides.ISlide secondSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

                // Add a line shape on the first slide
                Aspose.Slides.IAutoShape lineShape = (Aspose.Slides.IAutoShape)firstSlide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Line, 50, 100, 300, 0);

                // Assign an internal hyperlink that jumps to the second slide
                lineShape.HyperlinkClick = new Aspose.Slides.Hyperlink(secondSlide);
                lineShape.HyperlinkClick.Tooltip = "Navigate to Slide 2";

                // Save the presentation
                try
                {
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
                catch (Exception ex)
                {
                    // Handle cases where the format is not supported
                    // (e.g., SaveFormat not available for the current version)
                    Console.WriteLine("Error saving presentation: " + ex.Message);
                }
            }

            // Indicate completion
            Console.WriteLine("Presentation saved to " + outputPath);
        }
    }
}