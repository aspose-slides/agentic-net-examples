using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace EmbedMetadata
{
    class Program
    {
        static void Main()
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx"; // DOCX format is not supported by Aspose.Slides; using PPTX instead

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Access built‑in document properties
                IDocumentProperties properties = presentation.DocumentProperties;

                // Embed built‑in properties as custom properties
                properties.SetCustomPropertyValue("Author", properties.Author);
                properties.SetCustomPropertyValue("Title", properties.Title);
                properties.SetCustomPropertyValue("Subject", properties.Subject);
                properties.SetCustomPropertyValue("Category", properties.Category);
                properties.SetCustomPropertyValue("Comments", properties.Comments);
                properties.SetCustomPropertyValue("Company", properties.Company);
                properties.SetCustomPropertyValue("CreatedTime", properties.CreatedTime);
                properties.SetCustomPropertyValue("LastSavedTime", properties.LastSavedTime);
                properties.SetCustomPropertyValue("Manager", properties.Manager);
                properties.SetCustomPropertyValue("PresentationFormat", properties.PresentationFormat);

                // Attempt to save as DOCX (unsupported) – fallback to PPTX
                try
                {
                    // The following line would be the intended DOCX save if supported:
                    // presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Docx);
                    // Since DOCX is not a supported SaveFormat, we save as PPTX instead.
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
                catch (Aspose.Slides.PptxUnsupportedFormatException ex)
                {
                    // Handle format not supported exception
                    Console.WriteLine("The requested format is not supported: " + ex.Message);
                }
                catch (Exception ex)
                {
                    // General exception handling for unexpected errors (e.g., file I/O, web services)
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

            // Ensure the presentation is saved before exiting
            Console.WriteLine("Processing completed.");
        }
    }
}