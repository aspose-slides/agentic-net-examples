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
            // Paths for configuration, input, and output files
            string configPath = "config.json";
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the configuration file exists
            if (!File.Exists(configPath))
            {
                Console.WriteLine("Configuration file not found: " + configPath);
                return;
            }

            // Verify that the input presentation exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input presentation not found: " + inputPath);
                return;
            }

            try
            {
                // Read and parse the JSON configuration
                string jsonContent = File.ReadAllText(configPath);
                using (JsonDocument document = JsonDocument.Parse(jsonContent))
                {
                    JsonElement root = document.RootElement;
                    int firstSlideNumber = root.GetProperty("FirstSlideNumber").GetInt32();

                    // Load the presentation
                    Presentation pres = new Presentation(inputPath);

                    // Set the first slide number based on configuration
                    pres.FirstSlideNumber = firstSlideNumber;

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);

                    // Clean up resources
                    pres.Dispose();

                    Console.WriteLine("Presentation saved successfully with first slide number set to " + firstSlideNumber);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
                Console.WriteLine("The specified file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}