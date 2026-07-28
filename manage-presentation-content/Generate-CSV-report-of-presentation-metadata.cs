// -----------------------------------------------------------------------------
// Example: Generate CSV report of presentation metadata using C#
//
// Description:
// Demonstrates how to scan a folder of PowerPoint presentations, extract
// metadata such as Title, Author, and the count of custom document properties,
// and generate a CSV report. The example also shows how to preserve the
// original file format by re‑saving each presentation after processing using
// Aspose.Slides for .NET.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, CSV, Report, Presentation,
// Metadata, DocumentProperties, Office Automation
//
// Use Cases:
// - Automate creation of CSV inventories of presentation metadata.
// - Build .NET tools for batch processing and validation of PowerPoint files.
// - Integrate presentation metadata extraction into CI/CD pipelines.
// - Preserve original presentation formats while performing analysis.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesCsvReport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect a folder path as the first argument
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide the folder path containing presentations.");
                return;
            }

            string folderPath = args[0];
            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine("The specified folder does not exist: " + folderPath);
                return;
            }

            // Prepare CSV output
            StringBuilder csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("Title,Author,CustomPropertiesCount");

            // Supported extensions
            string[] extensions = new string[] { ".pptx", ".ppt", ".odp", ".pptm", ".ppsx", ".ppsm", ".potx", ".potm", ".pps", ".pot", ".otp", ".fodp", ".xml" };

            foreach (string filePath in Directory.GetFiles(folderPath))
            {
                if (Array.IndexOf(extensions, Path.GetExtension(filePath).ToLower()) < 0)
                {
                    // Skip unsupported file extensions
                    continue;
                }

                try
                {
                    // Load presentation
                    using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(filePath))
                    {
                        // Access document properties
                        Aspose.Slides.IDocumentProperties docProps = presentation.DocumentProperties;

                        string title = docProps.Title ?? string.Empty;
                        string author = docProps.Author ?? string.Empty;
                        int customCount = docProps.CountOfCustomProperties;

                        // Append CSV line (escape commas if needed)
                        csvBuilder.AppendLine(string.Format("{0},{1},{2}", title.Replace(",", "&#44;"), author.Replace(",", "&#44;"), customCount));

                        // Save presentation before exiting (preserve original format)
                        try
                        {
                            // Determine appropriate SaveFormat based on source format
                            Aspose.Slides.Export.SaveFormat saveFormat = Aspose.Slides.Export.SaveFormat.Pptx; // default
                            switch (presentation.SourceFormat)
                            {
                                case Aspose.Slides.SourceFormat.Ppt:
                                    saveFormat = Aspose.Slides.Export.SaveFormat.Ppt;
                                    break;
                                case Aspose.Slides.SourceFormat.Pptx:
                                    saveFormat = Aspose.Slides.Export.SaveFormat.Pptx;
                                    break;
                                case Aspose.Slides.SourceFormat.Odp:
                                    saveFormat = Aspose.Slides.Export.SaveFormat.Odp;
                                    break;
                                case Aspose.Slides.SourceFormat.Pptm:
                                    saveFormat = Aspose.Slides.Export.SaveFormat.Pptm;
                                    break;
                                case Aspose.Slides.SourceFormat.Ppsx:
                                    saveFormat = Aspose.Slides.Export.SaveFormat.Ppsx;
                                    break;
                                case Aspose.Slides.SourceFormat.Ppsm:
                                    saveFormat = Aspose.Slides.Export.SaveFormat.Ppsm;
                                    break;
                                case Aspose.Slides.SourceFormat.Potx:
                                    saveFormat = Aspose.Slides.Export.SaveFormat.Potx;
                                    break;
                                case Aspose.Slides.SourceFormat.Potm:
                                    saveFormat = Aspose.Slides.Export.SaveFormat.Potm;
                                    break;
                                case Aspose.Slides.SourceFormat.Pps:
                                    saveFormat = Aspose.Slides.Export.SaveFormat.Pps;
                                    break;
                                case Aspose.Slides.SourceFormat.Pot:
                                    saveFormat = Aspose.Slides.Export.SaveFormat.Pot;
                                    break;
                                case Aspose.Slides.SourceFormat.Otp:
                                    saveFormat = Aspose.Slides.Export.SaveFormat.Otp;
                                    break;
                                case Aspose.Slides.SourceFormat.Fodp:
                                    saveFormat = Aspose.Slides.Export.SaveFormat.Fodp;
                                    break;
                                case Aspose.Slides.SourceFormat.Xml:
                                    saveFormat = Aspose.Slides.Export.SaveFormat.Xml;
                                    break;
                                default:
                                    // Keep default
                                    break;
                            }

                            presentation.Save(filePath, saveFormat);
                        }
                        catch (NotSupportedException)
                        {
                            // Format not supported for saving; comment and continue
                            // Format not supported.
                        }
                    }
                }
                catch (Aspose.Slides.PptxUnsupportedFormatException)
                {
                    // Handle unsupported PPTX format
                    // Format not supported.
                }
                catch (Aspose.Slides.PptUnsupportedFormatException)
                {
                    // Handle unsupported PPT format
                    // Format not supported.
                }
                catch (Exception ex)
                {
                    // General exception handling (e.g., file corrupted)
                    Console.WriteLine("Error processing file: " + filePath);
                    Console.WriteLine("Exception: " + ex.Message);
                }
            }

            // Write CSV report to the same folder
            string csvPath = Path.Combine(folderPath, "PresentationReport.csv");
            try
            {
                File.WriteAllText(csvPath, csvBuilder.ToString(), Encoding.UTF8);
                Console.WriteLine("CSV report generated at: " + csvPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to write CSV report: " + ex.Message);
            }
        }
    }
}
