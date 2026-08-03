// -----------------------------------------------------------------------------
// Example: Extract presentation tags output JSON using C#
//
// Description:
// Demonstrates how to extract custom data tags from a PowerPoint presentation
// and output them as JSON using Aspose.Slides for .NET. The example loads a
// PPTX file, reads all tags stored in the presentation's CustomData, serializes
// them to a JSON string, prints the result, and saves the presentation.
// This pattern can be used to automate tag extraction, validation, or
// integration of PowerPoint metadata in .NET applications.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, CustomData, Tags, JSON, Extraction,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of presentation custom tags to JSON.
// - Build tools for PowerPoint metadata analysis in .NET.
// - Integrate tag data into downstream systems or reporting pipelines.
// - Validate and audit presentation custom data before publishing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "input.pptx";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found.");
            return;
        }

        try
        {
            using (Presentation presentation = new Presentation(filePath))
            {
                var tags = presentation.CustomData.Tags;
                var tagDictionary = new Dictionary<string, string>();

                for (int i = 0; i < tags.Count; i++)
                {
                    string name = tags.GetNameByIndex(i);
                    string value = tags.GetValueByIndex(i);
                    tagDictionary[name] = value;
                }

                string json = JsonSerializer.Serialize(tagDictionary);
                Console.WriteLine(json);

                // Save the presentation before exiting
                presentation.Save(filePath, SaveFormat.Pptx);
            }
        }
        catch (PptxUnsupportedFormatException)
        {
            // Format not supported
        }
        catch (PptUnsupportedFormatException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
