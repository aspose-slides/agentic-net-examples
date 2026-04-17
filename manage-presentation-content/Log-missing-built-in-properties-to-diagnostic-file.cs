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