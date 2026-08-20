// -----------------------------------------------------------------------------
// Example: Lock table aspect ratio before scaling using C#
//
// Description:
// Demonstrates how to lock a table's aspect ratio before scaling it using C# 
// and Aspose.Slides for .NET. The example creates a presentation, adds a table,
// locks its aspect ratio, doubles its size, and saves the result as a PPTX file.
// This pattern can be used to automate PowerPoint table transformations while 
// preserving visual proportions.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Lock, Table, Aspect, Ratio, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate locking table aspect ratio before scaling in presentations.
// - Build C# utilities for PowerPoint table manipulation.
// - Generate or modify PPTX files while maintaining table proportions.
// - Validate presentation layouts programmatically.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Define column widths and row heights for the table
        double[] columnWidths = new double[] { 100, 100, 100 };
        double[] rowHeights = new double[] { 50, 50, 50 };

        // Add a table to the slide
        Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

        // Lock the aspect ratio of the table
        table.ShapeLock.AspectRatioLocked = true;

        // Scale the table to double its original size
        table.Width *= 2;
        table.Height *= 2;

        // Save the presentation
        try
        {
            presentation.Save("LockedAspectRatioDoubleSize.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }
    }
}
