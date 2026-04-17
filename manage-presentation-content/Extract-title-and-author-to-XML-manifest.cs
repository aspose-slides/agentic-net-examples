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