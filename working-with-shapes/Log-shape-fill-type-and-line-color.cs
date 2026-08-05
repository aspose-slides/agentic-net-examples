// -----------------------------------------------------------------------------
// Example: Log shape fill type and line color using C#
//
// Description:
// Demonstrates how to log shape fill type and line color using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Shape, Fill, Type, Line, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate log shape fill type and line color.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
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
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        Aspose.Slides.Presentation presentation = null;
        try
        {
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            // format not supported
            return;
        }

        for (int i = 0; i < presentation.Slides.Count; i++)
        {
            Aspose.Slides.ISlide slide = presentation.Slides[i];
            for (int j = 0; j < slide.Shapes.Count; j++)
            {
                Aspose.Slides.IShape shape = slide.Shapes[j];
                Aspose.Slides.FillType fillType = Aspose.Slides.FillType.NotDefined;
                if (shape.FillFormat != null)
                {
                    fillType = shape.FillFormat.FillType;
                }

                System.Drawing.Color lineColor = System.Drawing.Color.Empty;
                if (shape.LineFormat != null && shape.LineFormat.FillFormat != null && shape.LineFormat.FillFormat.FillType == Aspose.Slides.FillType.Solid)
                {
                    lineColor = shape.LineFormat.FillFormat.SolidFillColor.Color;
                }

                Console.WriteLine($"Slide {i + 1}, Shape {j + 1}: FillType = {fillType}, LineColor = {lineColor}");
            }
        }

        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to save presentation: " + ex.Message);
        }
        finally
        {
            if (presentation != null)
                presentation.Dispose();
        }
    }
}
