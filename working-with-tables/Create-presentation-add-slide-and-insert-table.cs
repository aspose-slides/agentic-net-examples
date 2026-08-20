// -----------------------------------------------------------------------------
// Example: Create presentation add slide and insert table using C#
//
// Description:
// Demonstrates how to create a presentation, add a slide, and insert a table using C# 
// and Aspose.Slides for .NET. The example shows the required 
// presentation‑processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Presentation, Slide, Insert, 
// Table, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate creation of a presentation, add a slide, and insert a table.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TableExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a new blank slide based on the layout of the first slide
            Aspose.Slides.ISlide slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

            // Define custom column widths (in points) for a 3‑column table
            double[] columnWidths = new double[] { 100.0, 150.0, 200.0 };
            // Define row heights (in points) for a 4‑row table
            double[] rowHeights = new double[] { 50.0, 50.0, 50.0, 50.0 };

            // Add a 3‑by‑4 table at position (50, 50) on the slide
            Aspose.Slides.ITable table = slide.Shapes.AddTable(50.0f, 50.0f, columnWidths, rowHeights);

            // Save the presentation to disk
            presentation.Save("TablePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
