// -----------------------------------------------------------------------------
// Example: Add ellipse default black line using C#
//
// Description:
// Demonstrates how to add a default black line to ellipse shapes that have no
// line defined in a PowerPoint presentation using C# and Aspose.Slides for .NET.
// The example loads an existing presentation (or creates a new one), iterates
// through all slides and shapes, identifies ellipses with a line width of zero,
// and assigns a 1‑point solid black line. The modified presentation is then saved.
// This pattern can be used to ensure visual consistency of ellipse shapes in
// PPTX files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Ellipse, Default, Black, Line,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Ensure all ellipse shapes have a visible black outline.
// - Automate correction of missing line formatting in PPTX files.
// - Build C# tools for PowerPoint presentation processing and validation.
// - Integrate shape formatting logic into .NET applications handling PPTX content.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        Aspose.Slides.Presentation presentation = null;
        try
        {
            // Load existing presentation if it exists, otherwise create a new one
            if (File.Exists(inputPath))
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            else
            {
                presentation = new Aspose.Slides.Presentation();
            }
        }
        catch (Exception ex)
        {
            // Handle loading errors (e.g., unsupported format)
            Console.WriteLine("Error loading presentation: " + ex.Message);
            return;
        }

        // Iterate over all slides
        foreach (Aspose.Slides.ISlide slide in presentation.Slides)
        {
            // Iterate over all shapes on the slide
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                // Cast to IAutoShape to access ShapeType and LineFormat
                Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                if (autoShape != null && autoShape.ShapeType == Aspose.Slides.ShapeType.Ellipse)
                {
                    // If the ellipse has no line (width == 0), assign a default black line
                    if (autoShape.LineFormat != null && autoShape.LineFormat.Width == 0)
                    {
                        autoShape.LineFormat.Width = 1;
                        if (autoShape.LineFormat.FillFormat != null)
                        {
                            autoShape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                            autoShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
                        }
                    }
                }
            }
        }

        try
        {
            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle saving errors (e.g., unsupported format)
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
        finally
        {
            if (presentation != null)
            {
                presentation.Dispose();
            }
        }
    }
}
