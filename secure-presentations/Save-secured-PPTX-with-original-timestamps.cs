// -----------------------------------------------------------------------------
// Example: Save secured PPTX with original timestamps using C#
//
// Description:
// Demonstrates how to save a secured PPTX file while preserving the original
// file timestamps using C# and Aspose.Slides for .NET. The example loads a
// password‑protected presentation, saves a copy, and then copies the creation
// and last‑write timestamps from the source file to the destination file.
// This pattern can be used for PowerPoint file automation where metadata
// integrity is required.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Save, Secured, Original Timestamps,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate copying secured PPTX files while retaining original timestamps.
// - Build C# utilities for PowerPoint presentation handling with metadata preservation.
// - Generate or transform secured PPTX files in .NET applications without altering file dates.
// - Validate and maintain presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "secured.pptx";
        string outputPath = "secured_copy.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Save the presentation preserving original metadata
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }

            // Preserve original file timestamps
            DateTime creationTime = File.GetCreationTime(inputPath);
            DateTime lastWriteTime = File.GetLastWriteTime(inputPath);
            File.SetCreationTime(outputPath, creationTime);
            File.SetLastWriteTime(outputPath, lastWriteTime);
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported for saving.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
