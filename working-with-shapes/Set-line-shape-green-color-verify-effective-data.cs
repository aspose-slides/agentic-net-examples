// -----------------------------------------------------------------------------
// Example: Set line shape green color verify effective data using C#
//
// Description:
// Demonstrates how to add a line shape to a slide, set its line color to green,
// retrieve the effective line format data, and save the presentation using 
// Aspose.Slides for .NET. This example shows the required steps for PowerPoint 
// file manipulation and can be used as a reference for automating shape 
// formatting and validation in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Line Shape, Green Color, 
// Effective Data, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting a line shape's green color and verify its effective format.
// - Build C# utilities for PowerPoint shape formatting and validation.
// - Generate or modify PPTX files programmatically in .NET.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

                // Add a line shape to the first slide
                Aspose.Slides.IAutoShape lineShape = (Aspose.Slides.IAutoShape)pres.Slides[0].Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Line, 50, 50, 300, 0);

                // Set line width
                lineShape.LineFormat.Width = 5;

                // Set line color to green
                lineShape.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Green;

                // Retrieve effective line format data
                Aspose.Slides.ILineFormatEffectiveData effectiveLineFormat = lineShape.LineFormat.GetEffective();

                // Output the effective line color
                Console.WriteLine("Effective line color: " + effectiveLineFormat.FillFormat.SolidFillColor);

                // Save the presentation
                pres.Save("LineShapeGreen.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle any errors (e.g., unsupported format)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
