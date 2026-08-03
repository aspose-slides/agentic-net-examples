// -----------------------------------------------------------------------------
// Example: Export presentation custom data to JSON using C#
//
// Description:
// Demonstrates how to export all custom XML parts from a PowerPoint presentation
// to a JSON file using C# and Aspose.Slides for .NET. The example loads a PPTX,
// extracts each custom XML part's ID and XML content, serializes the collection
// to formatted JSON, and writes it to disk. It also shows basic error handling
// and re‑saving the presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, Presentation, Custom XML,
// Data, JSON, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of custom XML data from PPTX files.
// - Build tools that convert presentation metadata to JSON for downstream processing.
// - Integrate custom data export into .NET applications or CI pipelines.
// - Validate and audit custom data embedded in PowerPoint presentations.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportCustomData
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string presentationPath = "input.pptx";
            string jsonOutputPath = "customData.json";

            // Verify that the presentation file exists
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("Presentation file not found: " + presentationPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(presentationPath))
                {
                    // Prepare a list to hold custom XML part data
                    List<object> customXmlData = new List<object>();

                    // Iterate through all custom XML parts in the presentation
                    ICustomXmlPart[] customParts = presentation.AllCustomXmlParts;
                    foreach (ICustomXmlPart part in customParts)
                    {
                        // Use ItemId (GUID) and XmlAsString for each part
                        customXmlData.Add(new
                        {
                            Id = part.ItemId,
                            Xml = part.XmlAsString
                        });
                    }

                    // Serialize the collected data to JSON
                    string json = JsonSerializer.Serialize(customXmlData, new JsonSerializerOptions { WriteIndented = true });

                    // Write JSON to the output file
                    File.WriteAllText(jsonOutputPath, json);
                    Console.WriteLine("Custom data exported to: " + jsonOutputPath);

                    // Save the presentation before exiting (no changes made, just re‑save)
                    presentation.Save(presentationPath, SaveFormat.Pptx);
                }
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported for this operation.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., I/O errors, web service errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
