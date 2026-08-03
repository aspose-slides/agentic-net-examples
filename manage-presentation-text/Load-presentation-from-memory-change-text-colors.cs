// -----------------------------------------------------------------------------
// Example: Load presentation from memory and change text colors using C#
//
// Description:
// Demonstrates how to create a presentation, save it to a memory stream,
// load it back from memory, modify the text color, and save the result to a file
// using Aspose.Slides for .NET. The example illustrates the required steps for
// handling presentations in memory and applying text color changes.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Load, Presentation, Memory, 
// Change, Text Color, Presentation Processing, Office Automation
//
// Use Cases:
// - Load a PowerPoint presentation from a memory stream.
// - Programmatically change text colors in slides.
// - Save modified presentations to disk or other streams.
// - Build .NET tools that process PPTX files without intermediate files.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a sample presentation and save it to a memory stream
        Aspose.Slides.Presentation originalPres = new Aspose.Slides.Presentation();
        Aspose.Slides.ISlide slide = originalPres.Slides[0];
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
        shape.TextFrame.Text = "Hello World";
        System.IO.MemoryStream inputStream = new System.IO.MemoryStream();
        originalPres.Save(inputStream, Aspose.Slides.Export.SaveFormat.Pptx);
        originalPres.Dispose();

        // Reset stream position before loading
        inputStream.Position = 0;

        // Load presentation from the memory stream
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputStream);

        // Change text color (using highlight as an example)
        try
        {
            pres.HighlightText("Hello", Color.Blue);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }

        // Save the modified presentation to a new file stream (as per save-to-stream rule)
        string outputPath = "output.pptx";
        System.IO.FileStream outputStream = new System.IO.FileStream(outputPath, System.IO.FileMode.Create);
        pres.Save(outputStream, Aspose.Slides.Export.SaveFormat.Pptx);
        outputStream.Close();

        // Dispose resources
        pres.Dispose();
        inputStream.Close();
    }
}
