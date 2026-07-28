// -----------------------------------------------------------------------------
// Example: Set subject and keywords and export PPTX using C#
//
// Description:
// Demonstrates how to set the Subject and Keywords properties of a presentation
// and export it as a PPTX file using Aspose.Slides for .NET. The example creates a
// new presentation, modifies its document properties, and saves the result to an
// output folder in a standalone console application. This pattern can be used to
// automate metadata handling and PPTX generation in .NET projects.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Subject, Keywords, Export,
// Presentation Metadata, DocumentProperties, Office Automation
//
// Use Cases:
// - Automate setting Subject and Keywords metadata in PowerPoint files.
// - Build C# utilities for creating or modifying PPTX presentations.
// - Generate PPTX files with custom document properties in .NET applications.
// - Integrate presentation metadata handling into larger automation workflows.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output directory and file name
        string outputDir = "Output";
        if (!Directory.Exists(outputDir))
            Directory.CreateDirectory(outputDir);
        string outPath = Path.Combine(outputDir, "NewPresentation.pptx");

        // Create a new presentation
        Presentation presentation = new Presentation();

        // Set Subject and Keywords
        presentation.DocumentProperties.Subject = "Sample Subject";
        presentation.DocumentProperties.Keywords = "Sample Keywords";

        try
        {
            // Save as PPTX
            presentation.Save(outPath, SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        finally
        {
            // Dispose presentation
            presentation.Dispose();
        }
    }
}
