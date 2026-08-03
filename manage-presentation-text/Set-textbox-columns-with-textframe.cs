// -----------------------------------------------------------------------------
// Example: Set textbox columns with textframe using C#
//
// Description:
// Demonstrates how to configure a textbox to display its content in multiple
// columns by setting the TextFrame column count using Aspose.Slides for .NET.
// The example creates a presentation, adds a rectangle shape with a text
// frame, sets the column count to two, and saves the result as a PPTX file.
// This pattern can be used to format text layout in PowerPoint slides
// programmatically.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Textbox, Columns, Textframe,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Create PowerPoint slides with multi‑column text boxes.
// - Automate layout adjustments for text frames in presentations.
// - Build .NET tools that generate or modify PPTX files with columnar text.
// - Ensure consistent text formatting across slides in batch processing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Output file path
        string outFilePath = "ColumnsDemo.pptx";

        // Create a new presentation
        Presentation pres = new Presentation();

        // Add a rectangle auto shape to the first slide
        IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

        // Add a text frame with sample text
        shape.AddTextFrame("This is a sample text that will be split into two columns.");

        // Get the text frame format and set the number of columns to 2
        TextFrameFormat format = (TextFrameFormat)shape.TextFrame.TextFrameFormat;
        format.ColumnCount = 2;

        // Save the presentation
        pres.Save(outFilePath, SaveFormat.Pptx);
    }
}
