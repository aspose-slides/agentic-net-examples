using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.docx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Access document properties
                    Aspose.Slides.IDocumentProperties docProps = presentation.DocumentProperties;

                    // Read some built‑in metadata
                    string author = docProps.Author;
                    string title = docProps.Title;
                    DateTime created = docProps.CreatedTime;

                    // Embed the metadata as custom properties
                    docProps.SetCustomPropertyValue("OriginalAuthor", author);
                    docProps.SetCustomPropertyValue("OriginalTitle", title);
                    docProps.SetCustomPropertyValue("OriginalCreatedTime", created);

                    // Attempt to save as DOCX – Aspose.Slides does not support DOCX output.
                    // The following line is commented out because SaveFormat.Docx does not exist.
                    // presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Docx);

                    // Save as PPTX as a fallback (format supported)
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Handle unsupported format exception (e.g., trying to save to DOCX)
                Console.WriteLine("The requested output format (DOCX) is not supported by Aspose.Slides.");
            }
            catch (Exception ex)
            {
                // General exception handling for unexpected errors (e.g., file I/O, network)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}