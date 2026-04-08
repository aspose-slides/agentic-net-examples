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