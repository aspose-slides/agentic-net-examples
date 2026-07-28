// -----------------------------------------------------------------------------
// Example: Add encryption status custom property using C#
//
// Description:
// Demonstrates how to add a custom document property that reflects the
// encryption status of a PowerPoint presentation using C# and Aspose.Slides
// for .NET. The example loads an existing PPTX file, checks whether it is
// encrypted, adds a custom property named "IsEncrypted" with the corresponding
// boolean value, and saves the modified presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Encryption, Custom Property,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate the addition of encryption status metadata to PowerPoint files.
// - Build .NET tools that need to track or report presentation security state.
// - Integrate encryption status checks into larger PPTX workflow pipelines.
// - Validate presentation properties before distribution or publishing.
// -----------------------------------------------------------------------------

using System;
using System.IO;
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

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Determine encryption status
            bool isEncrypted = presentation.ProtectionManager.IsEncrypted;

            // Add a custom document property indicating encryption status
            Aspose.Slides.IDocumentProperties documentProperties = presentation.DocumentProperties;
            documentProperties["IsEncrypted"] = isEncrypted;

            // Save the updated presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., external URL errors)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
