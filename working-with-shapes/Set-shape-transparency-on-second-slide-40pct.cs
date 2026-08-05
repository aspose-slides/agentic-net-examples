// -----------------------------------------------------------------------------
// Example: Set shape transparency on second slide 40pct using C#
//
// Description:
// Demonstrates how to set shape transparency on second slide 40pct using C# 
// and Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Shape, Transparency, Second, 
// Slide, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate set shape transparency on second slide 40pct.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace SetShapeTransparency
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load existing presentation if file exists, otherwise create a new one
            Presentation pres;
            if (File.Exists(inputPath))
            {
                try
                {
                    pres = new Presentation(inputPath);
                }
                catch (Exception ex)
                {
                    // Handle unsupported format
                    Console.WriteLine("Failed to load presentation: " + ex.Message);
                    // Create a new presentation as fallback
                    pres = new Presentation();
                }
            }
            else
            {
                pres = new Presentation();
            }

            // Ensure there is a second slide
            if (pres.Slides.Count < 2)
            {
                // Add a blank slide if missing
                pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
            }

            // Get the second slide (index 1)
            ISlide secondSlide = pres.Slides[1];

            // Desired transparency: 40% => alpha = 0.4 * 255 ≈ 102
            byte desiredAlpha = (byte)(0.4f * 255);

            // Iterate through all shapes on the second slide
            foreach (IShape shape in secondSlide.Shapes)
            {
                // Only process shapes that have a FillFormat
                if (shape.FillFormat != null && shape.FillFormat.SolidFillColor != null)
                {
                    Color originalColor = shape.FillFormat.SolidFillColor.Color;
                    // Preserve original RGB, apply new alpha
                    Color newColor = Color.FromArgb(desiredAlpha, originalColor.R, originalColor.G, originalColor.B);
                    shape.FillFormat.SolidFillColor.Color = newColor;
                }
            }

            // Save the presentation
            try
            {
                pres.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle save errors (e.g., unsupported format)
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }
        }
    }
}
