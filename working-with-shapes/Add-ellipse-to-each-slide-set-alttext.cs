// -----------------------------------------------------------------------------
// Example: Add ellipse to each slide set alttext using C#
//
// Description:
// Demonstrates how to add an ellipse shape to every slide in a presentation
// and assign sequential Alternative Text (AltText) to each shape using C# and
// Aspose.Slides for .NET. The example creates a presentation, clones slides,
// adds ellipses, sets AltText, and saves the result as a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Ellipse, Each, Slide, Alttext,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding ellipses with unique AltText to each slide.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchEllipse
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add additional slides for demonstration
            for (int i = 0; i < 2; i++)
            {
                presentation.Slides.AddClone(presentation.Slides[0]);
            }

            // Iterate through each slide and add an ellipse with sequential AltText
            int shapeId = 1;
            foreach (ISlide slide in presentation.Slides)
            {
                IAutoShape ellipse = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Ellipse, 100, 100, 200, 100);
                ellipse.AlternativeText = "Ellipse_" + shapeId;
                shapeId++;
            }

            // Define output path
            string outputDir = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Output");
            if (!System.IO.Directory.Exists(outputDir))
            {
                System.IO.Directory.CreateDirectory(outputDir);
            }
            string outPath = System.IO.Path.Combine(outputDir, "BatchEllipse_out.pptx");

            // Save presentation with exception handling for unsupported format
            try
            {
                presentation.Save(outPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Format not supported or other save error
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
        }
    }
}
