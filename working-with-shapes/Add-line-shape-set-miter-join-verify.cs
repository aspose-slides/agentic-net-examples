// -----------------------------------------------------------------------------
// Example: Add line shape set miter join verify using C#
//
// Description:
// Demonstrates how to add a line shape, set its line join style to Miter, retrieve
// the effective line format data, and verify the miter limit using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Line, Shape, Miter, Join, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a line shape with a miter join and verify its properties.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate line join settings before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = "LineJoinMiter.pptx";

            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a line shape to the slide
                Aspose.Slides.IAutoShape lineShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Line, 100, 100, 300, 0);

                // Set line join style to Miter
                lineShape.LineFormat.JoinStyle = Aspose.Slides.LineJoinStyle.Miter;

                // Optionally set line width
                lineShape.LineFormat.Width = 5;

                // Retrieve effective line format data
                Aspose.Slides.ILineFormatEffectiveData effectiveData = lineShape.LineFormat.GetEffective();

                // Verify the miter limit (read‑only property)
                float miterLimit = effectiveData.MiterLimit;
                Console.WriteLine("Effective Miter Limit: " + miterLimit);

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File not found: " + ex.Message);
            }
            catch (NotSupportedException ex)
            {
                // Format not supported
                Console.WriteLine("Format not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
