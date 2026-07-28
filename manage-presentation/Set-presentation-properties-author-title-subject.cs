// -----------------------------------------------------------------------------
// Example: Set presentation properties author title subject using C#
//
// Description:
// Demonstrates how to set the built‑in document properties Author, Title, and
// Subject of a PowerPoint presentation using Aspose.Slides for .NET. The
// example loads an existing PPTX file when provided, or creates a new
// presentation if the input file is missing, then saves the modified file.
//
// Keywords:
// C#, Aspose.Slides for .NET, PowerPoint, PPTX, DocumentProperties, Author,
// Title, Subject, Presentation creation, File I/O
//
// Use Cases:
// - Programmatically assign author, title, and subject metadata to PPTX files.
// - Automate batch processing of presentations to ensure consistent properties.
// - Generate new presentations with predefined metadata when source files are absent.
// - Integrate property setting into .NET applications that manipulate PowerPoint content.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SetPresentationProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path (optional)
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            // Output presentation path
            string outputPath = Path.Combine(Path.GetDirectoryName(inputPath) ?? "", Path.GetFileNameWithoutExtension(inputPath) + "_out.pptx");

            // Verify input file exists if it is expected to be loaded
            if (File.Exists(inputPath))
            {
                try
                {
                    // Load existing presentation
                    using (Presentation presentation = new Presentation(inputPath))
                    {
                        // Set built‑in document properties
                        IDocumentProperties docProps = presentation.DocumentProperties;
                        docProps.Author = "John Doe";
                        docProps.Title = "Sample Presentation";
                        docProps.Subject = "Demonstration of property setting";

                        // Save the presentation
                        presentation.Save(outputPath, SaveFormat.Pptx);
                    }
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                }
                catch (Exception)
                {
                    // Handle other exceptions (e.g., file access issues)
                }
            }
            else
            {
                // Input file does not exist – create a new presentation instead
                try
                {
                    using (Presentation presentation = new Presentation())
                    {
                        IDocumentProperties docProps = presentation.DocumentProperties;
                        docProps.Author = "John Doe";
                        docProps.Title = "New Presentation";
                        docProps.Subject = "Created without source file";

                        presentation.Save(outputPath, SaveFormat.Pptx);
                    }
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                }
                catch (Exception)
                {
                    // Handle other exceptions
                }
            }
        }
    }
}
