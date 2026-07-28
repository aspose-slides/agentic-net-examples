// -----------------------------------------------------------------------------
// Example: Log missing built in properties to diagnostic file using C#
//
// Description:
// Demonstrates how to iterate over one or more PowerPoint presentations,
// read their built‑in document properties using Aspose.Slides for .NET, and
// write entries to a diagnostic text file for any properties that are empty
// or missing. The example also shows how to create an unchanged copy of each
// processed presentation. This pattern can be used in automated validation
// or migration scenarios where presentation metadata must be verified.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Built‑in properties, Missing
// properties, Diagnostic file, Presentation metadata, Automation
//
// Use Cases:
// - Validate that required built‑in properties (Author, Title, etc.) are set
//   before publishing or archiving presentations.
// - Generate a report of missing metadata across a batch of PPTX files.
// - Integrate property‑checking logic into CI pipelines or document‑management
//   systems.
// - Create unchanged copies of source presentations while performing analysis.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input presentation files (use command‑line arguments if provided)
        string[] presentationFiles = args.Length > 0 ? args : new string[] { "presentation1.pptx", "presentation2.pptx" };
        string diagnosticPath = "diagnostic.txt";

        using (StreamWriter writer = new StreamWriter(diagnosticPath, false))
        {
            foreach (string inputPath in presentationFiles)
            {
                // Check if the file exists
                if (!File.Exists(inputPath))
                {
                    writer.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                try
                {
                    // Get presentation info and read its built‑in properties
                    Aspose.Slides.IPresentationInfo info = Aspose.Slides.PresentationFactory.Instance.GetPresentationInfo(inputPath);
                    Aspose.Slides.IDocumentProperties props = info.ReadDocumentProperties();

                    // Log missing built‑in properties
                    LogIfMissing(props.Author, "Author", writer, inputPath);
                    LogIfMissing(props.Title, "Title", writer, inputPath);
                    LogIfMissing(props.Subject, "Subject", writer, inputPath);
                    LogIfMissing(props.Category, "Category", writer, inputPath);
                    LogIfMissing(props.Comments, "Comments", writer, inputPath);
                    LogIfMissing(props.Company, "Company", writer, inputPath);
                    LogIfMissing(props.ContentStatus, "ContentStatus", writer, inputPath);
                    LogIfMissing(props.ContentType, "ContentType", writer, inputPath);
                    LogIfMissing(props.Keywords, "Keywords", writer, inputPath);
                    LogIfMissing(props.Manager, "Manager", writer, inputPath);
                    LogIfMissing(props.HyperlinkBase, "HyperlinkBase", writer, inputPath);

                    // Save a copy of the presentation (unchanged) before exiting
                    string outputPath = Path.Combine(Path.GetDirectoryName(inputPath) ?? "", Path.GetFileNameWithoutExtension(inputPath) + "_copy.pptx");
                    Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    presentation.Dispose();
                }
                catch (Exception ex)
                {
                    // Handle unsupported format or other errors
                    writer.WriteLine($"Error processing {inputPath}: {ex.Message} // format not supported");
                }
            }
        }
    }

    static void LogIfMissing(string value, string propertyName, StreamWriter writer, string filePath)
    {
        if (string.IsNullOrEmpty(value))
        {
            writer.WriteLine($"{filePath}: Missing built‑in property '{propertyName}'");
        }
    }
}
