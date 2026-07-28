// -----------------------------------------------------------------------------
// Example: Extract title and author to XML manifest using C#
//
// Description:
// Demonstrates how to extract the Title and Author built‑in document properties
// from a PowerPoint presentation and write them to an XML manifest file using
// Aspose.Slides for .NET. The example loads a PPTX file, reads the properties,
// creates a simple XML document, and saves the manifest alongside the original
// presentation. This pattern can be used in automation scripts or utilities
// that need to catalog presentation metadata.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Extract, Title, Author, 
// Manifest, XML, Presentation Metadata, Automation
//
// Use Cases:
// - Generate XML manifests containing presentation metadata for indexing.
// - Build tools that validate or audit PowerPoint files before publishing.
// - Integrate metadata extraction into larger document management systems.
// - Automate reporting of presentation properties in .NET applications.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Xml;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DocumentManifestUtility
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output paths
            string inputPath = "input.pptx";
            string manifestPath = "manifest.xml";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Access built‑in document properties
                IDocumentProperties documentProperties = presentation.DocumentProperties;

                // Retrieve Title and Author
                string title = documentProperties.Title;
                string author = documentProperties.Author;

                // Write properties to XML manifest
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                using (XmlWriter writer = XmlWriter.Create(manifestPath, settings))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("PresentationManifest");
                    writer.WriteElementString("Title", title ?? string.Empty);
                    writer.WriteElementString("Author", author ?? string.Empty);
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }

                // Save the presentation before exit (no modifications made)
                presentation.Save(inputPath, SaveFormat.Pptx);
                presentation.Dispose();

                Console.WriteLine("Manifest created at: " + Path.GetFullPath(manifestPath));
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // The provided file format may not be supported by Aspose.Slides.
            }
        }
    }
}
