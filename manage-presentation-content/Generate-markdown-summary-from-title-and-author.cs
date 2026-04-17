using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationUtility
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output paths
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPath = args.Length > 1 ? args[1] : "summary.md";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Presentation presentation = null;
            try
            {
                // Load presentation
                presentation = new Presentation(inputPath);

                // Access built‑in properties
                IDocumentProperties docProps = presentation.DocumentProperties;
                string title = docProps.Title;
                string author = docProps.Author;

                // Create markdown summary
                string markdown = "# Presentation Summary\r\n\r\n" +
                                  "**Title:** " + (title ?? "N/A") + "\r\n\r\n" +
                                  "**Author:** " + (author ?? "N/A") + "\r\n";

                // Write markdown file
                File.WriteAllText(outputPath, markdown);
                Console.WriteLine("Markdown summary written to: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("Error processing presentation: " + ex.Message);
                // Format not supported comment
                // The file format may not be supported by Aspose.Slides.
            }
            finally
            {
                // Save presentation before exit (if loaded)
                if (presentation != null)
                {
                    try
                    {
                        // Attempt to save in PPTX format
                        presentation.Save(inputPath, SaveFormat.Pptx);
                    }
                    catch
                    {
                        // Save format not supported; ignore
                    }
                    presentation.Dispose();
                }
            }
        }
    }
}