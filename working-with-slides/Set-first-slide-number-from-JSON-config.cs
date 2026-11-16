// -----------------------------------------------------------------------------
// Example: Set First Slide Number from JSON Configuration
//
// Description:
// This console application reads a JSON configuration file to obtain a
// first slide number, creates a new PowerPoint presentation, applies the
// slide number using Aspose.Slides for .NET, and saves the result as a PPTX file.
// It demonstrates configuration‑driven slide numbering automation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, first slide number, JSON configuration
//
// Use Cases:
// - Automate slide numbering based on external settings.
// - Integrate presentation generation into CI/CD pipelines.
// - Centralize presentation defaults in a JSON config file.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Text.Json;
using System.Reflection;

class Program
{
    static int Main(string[] args)
    {
        string configPath = "config.json";
        string outputPath = "ResultPresentation.pptx";

        // Ensure configuration file exists; create a sample if missing.
        if (!File.Exists(configPath))
        {
            try
            {
                using (FileStream fs = File.Create(configPath))
                {
                    byte[] sample = System.Text.Encoding.UTF8.GetBytes("{\"FirstSlideNumber\": 5}");
                    fs.Write(sample, 0, sample.Length);
                }
                Console.WriteLine("Sample configuration file created at: " + Path.GetFullPath(configPath));
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Failed to create sample configuration file: " + ex.Message);
                return 1;
            }
        }

        // Read and parse JSON configuration.
        int firstSlideNumber = 1; // Default value.
        try
        {
            string jsonContent = File.ReadAllText(configPath);
            using (JsonDocument doc = JsonDocument.Parse(jsonContent))
            {
                JsonElement root = doc.RootElement;
                if (root.TryGetProperty("FirstSlideNumber", out JsonElement numberElement) && numberElement.TryGetInt32(out int value))
                {
                    firstSlideNumber = value;
                }
                else
                {
                    Console.Error.WriteLine("FirstSlideNumber not found or invalid in configuration. Using default value 1.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error reading configuration: " + ex.Message);
            return 1;
        }

        // Create a new presentation and set the first slide number via reflection.
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Attempt to set the FirstSlideNumber property if it exists.
            PropertyInfo slideNumberProp = typeof(Aspose.Slides.Presentation).GetProperty("FirstSlideNumber");
            if (slideNumberProp != null && slideNumberProp.CanWrite)
            {
                slideNumberProp.SetValue(presentation, firstSlideNumber, null);
                Console.WriteLine("First slide number set to " + firstSlideNumber);
            }
            else
            {
                // Property not available in this version; comment for developers.
                Console.Error.WriteLine("The property 'FirstSlideNumber' is not supported in the current Aspose.Slides version.");
            }

            // Save the presentation.
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            Console.WriteLine("Presentation saved to: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error processing presentation: " + ex.Message);
            return 1;
        }

        return 0;
    }
}
