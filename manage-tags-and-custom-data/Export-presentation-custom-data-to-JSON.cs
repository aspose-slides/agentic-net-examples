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