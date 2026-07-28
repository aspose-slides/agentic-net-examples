// -----------------------------------------------------------------------------
// Example: Set PDF properties author title subject using C#
//
// Description:
// Demonstrates how to set PDF properties author, title, and subject using C# 
// and Aspose.Slides for .NET. The example loads an existing PowerPoint file 
// (or creates a new one), updates the built‑in document properties, and saves 
// the presentation as a PDF. The resulting PDF file contains the specified 
// metadata, which can be used for document management, search indexing, or 
// compliance purposes.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Properties, Author, Title, 
// Subject, Document Metadata, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting PDF metadata (author, title, subject) for presentations.
// - Build C# tools that convert PPTX files to PDF with custom document properties.
// - Integrate PDF generation with specific metadata into .NET applications.
// - Ensure generated PDFs contain required metadata for publishing or archiving.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pdf";

            // Load existing presentation if it exists; otherwise create a new one
            Presentation presentation;
            if (File.Exists(inputPath))
            {
                presentation = new Presentation(inputPath);
            }
            else
            {
                presentation = new Presentation();
            }

            // Update built‑in document properties
            IDocumentProperties properties = presentation.DocumentProperties;
            properties.Author = "John Doe";
            properties.Title = "Sample Presentation";
            properties.Subject = "Demo of Document Properties";

            // Set default text language for the presentation
            presentation.DefaultTextStyle.DefaultParagraphFormat.DefaultPortionFormat.LanguageId = "en-US";

            // Save the presentation as PDF
            presentation.Save(outputPath, SaveFormat.Pdf);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception)
        {
            // Handle other exceptions (e.g., file I/O, Aspose.Slides errors)
        }
    }
}
