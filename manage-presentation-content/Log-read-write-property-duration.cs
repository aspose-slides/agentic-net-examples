// -----------------------------------------------------------------------------
// Example: Log read/write property duration using C#
//
// Description:
// Demonstrates how to log the duration of reading and writing document
// properties in a PowerPoint presentation using C# and Aspose.Slides for .NET.
// The example loads a PPTX file, reads its author and title properties, updates
// them, saves the presentation, and outputs the elapsed time for the read and
// write operations.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Document Properties, Read,
// Write, Duration, Performance Logging, Presentation Processing
//
// Use Cases:
// - Measure performance of document property access in PowerPoint files.
// - Build diagnostic tools that track read/write times for presentation metadata.
// - Optimize automation workflows that modify PPTX metadata.
// - Validate and benchmark Aspose.Slides property handling in .NET applications.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Diagnostics;
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

        Stopwatch readTimer = new Stopwatch();
        Stopwatch writeTimer = new Stopwatch();

        try
        {
            readTimer.Start();
            Presentation presentation = new Presentation(inputPath);
            IDocumentProperties documentProperties = presentation.DocumentProperties;
            Console.WriteLine("Author: " + documentProperties.Author);
            Console.WriteLine("Title: " + documentProperties.Title);
            readTimer.Stop();

            documentProperties.Author = "Diagnostic Tool";
            documentProperties.Title = "Processed Presentation";

            writeTimer.Start();
            presentation.Save(outputPath, SaveFormat.Pptx);
            writeTimer.Stop();

            Console.WriteLine("Read time (ms): " + readTimer.ElapsedMilliseconds);
            Console.WriteLine("Write time (ms): " + writeTimer.ElapsedMilliseconds);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
