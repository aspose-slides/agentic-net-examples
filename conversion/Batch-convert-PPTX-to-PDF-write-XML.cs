using System;
using System.IO;
using System.Diagnostics;
using System.Xml.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine input, output, and XML result paths
            string inputDirectory = args.Length > 0 ? args[0] : "Input";
            string outputDirectory = args.Length > 1 ? args[1] : "Output";
            string xmlResultPath = args.Length > 2 ? args[2] : "results.xml";

            // Verify input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.WriteLine("Input directory does not exist: " + inputDirectory);
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Prepare XML root element
            XElement rootElement = new XElement("Conversions");

            // Get all PPTX files in the input directory
            string[] pptxFiles = Directory.GetFiles(inputDirectory, "*.pptx", SearchOption.TopDirectoryOnly);

            foreach (string pptxFilePath in pptxFiles)
            {
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(pptxFilePath);
                string pdfOutputPath = Path.Combine(outputDirectory, fileNameWithoutExtension + ".pdf");
                Stopwatch stopwatch = new Stopwatch();

                try
                {
                    using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(pptxFilePath))
                    {
                        stopwatch.Start();
                        presentation.Save(pdfOutputPath, Aspose.Slides.Export.SaveFormat.Pdf);
                        stopwatch.Stop();
                    }

                    // Record successful conversion with duration
                    XElement fileElement = new XElement("File",
                        new XAttribute("Name", fileNameWithoutExtension),
                        new XAttribute("DurationMs", stopwatch.ElapsedMilliseconds));
                    rootElement.Add(fileElement);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                    XElement errorElement = new XElement("File",
                        new XAttribute("Name", fileNameWithoutExtension),
                        new XAttribute("Error", "Format not supported"));
                    rootElement.Add(errorElement);
                }
                catch (Exception ex)
                {
                    // General error handling
                    XElement errorElement = new XElement("File",
                        new XAttribute("Name", fileNameWithoutExtension),
                        new XAttribute("Error", ex.Message));
                    rootElement.Add(errorElement);
                }
            }

            // Ensure directory for XML result exists
            string xmlDirectory = Path.GetDirectoryName(xmlResultPath);
            if (!string.IsNullOrEmpty(xmlDirectory) && !Directory.Exists(xmlDirectory))
            {
                Directory.CreateDirectory(xmlDirectory);
            }

            // Save XML results
            XDocument resultDocument = new XDocument(rootElement);
            resultDocument.Save(xmlResultPath);
        }
    }
}