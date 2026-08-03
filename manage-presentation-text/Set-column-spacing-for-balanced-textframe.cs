// -----------------------------------------------------------------------------
// Example: Set column spacing for textframe using C#
//
// Description:
// Demonstrates how to set the number of columns and column spacing for a text
// frame in a PowerPoint slide using C# and Aspose.Slides for .NET. The example
// creates a presentation, adds a rectangle shape with a text frame, configures
// two columns with a custom spacing, inserts sample text, and saves the file.
// This pattern can be used to automate column layout adjustments in PPTX
// documents.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Column, Spacing, Textframe,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate column layout configuration for text frames in presentations.
// - Build C# utilities for customizing PPTX content programmatically.
// - Generate or modify PowerPoint files with specific column spacing.
// - Validate and test column formatting before publishing.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ColumnSpacingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output file path
            string outputPath = "ColumnSpacingDemo.pptx";

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a rectangle auto shape to the first slide
            Aspose.Slides.IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 100, 100, 400, 300);

            // Add an empty text frame to the shape
            shape.AddTextFrame(string.Empty);

            // Configure text frame columns and spacing
            Aspose.Slides.TextFrameFormat format = (Aspose.Slides.TextFrameFormat)shape.TextFrame.TextFrameFormat;
            format.ColumnCount = 2;          // Set number of columns
            format.ColumnSpacing = 20;       // Set spacing between columns (points)

            // Set sample text
            shape.TextFrame.Text = "This is sample text that will be split into columns with custom spacing. " +
                                   "The text will automatically adjust to the defined column layout.";

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
