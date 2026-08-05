// -----------------------------------------------------------------------------
// Example: Set first slide number from JSON config using C#
//
// Description:
// Demonstrates how to set the first slide number of a PowerPoint presentation
// based on a value read from a JSON configuration file using C# and Aspose.Slides
// for .NET. The example creates a new presentation, applies the slide number,
// and saves the result as a PPTX file in a standalone console application.
// Developers can adapt this pattern to automate PPTX workflows, validate
// configuration-driven settings, or integrate presentation logic into .NET
// applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, First Slide Number, JSON,
// Configuration, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting the first slide number from external JSON configuration.
// - Build C# utilities for PowerPoint presentation customization.
// - Generate or modify PPTX files programmatically in .NET applications.
// - Validate presentation settings before publishing or further processing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SetFirstSlideNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the JSON configuration file
            string configPath = "config.json";

            // Verify that the configuration file exists
            if (!File.Exists(configPath))
            {
                Console.WriteLine("Configuration file not found: " + configPath);
                return;
            }

            // Read and parse the JSON configuration
            int firstSlideNumber;
            try
            {
                string jsonContent = File.ReadAllText(configPath);
                JsonDocument jsonDoc = JsonDocument.Parse(jsonContent);
                firstSlideNumber = jsonDoc.RootElement.GetProperty("FirstSlideNumber").GetInt32();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading configuration: " + ex.Message);
                return;
            }

            // Create a new presentation
            Presentation pres = new Presentation();

            // Set the first slide number using the rule "set-slide-number"
            pres.FirstSlideNumber = firstSlideNumber;

            // Define output file path
            string outputPath = "output.pptx";

            // Save the presentation (handle unsupported format exception)
            try
            {
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Format not supported or other save error
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }

            // Dispose the presentation object
            pres.Dispose();
        }
    }
}
