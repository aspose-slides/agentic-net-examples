// -----------------------------------------------------------------------------
// Example: Extract built in properties to JSON config using C#
//
// Description:
// Demonstrates how to extract built‑in document properties from a PowerPoint
// presentation and serialize them to a JSON configuration file using C# and
// Aspose.Slides for .NET. The example loads a PPTX file, reads the built‑in
// properties, writes them to a formatted JSON file, and saves the presentation
// (required by the API) as a temporary file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Extract, Built‑in Properties,
// JSON, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of PowerPoint built‑in properties to JSON for reporting.
// - Build C# utilities that analyze or audit PPTX metadata.
// - Integrate presentation metadata handling into .NET applications.
// - Validate and log presentation properties before publishing or further processing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExtractProperties
{
    // Class representing the built‑in properties to be serialized to JSON
    public class BuiltInProperties
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Subject { get; set; }
        public string Category { get; set; }
        public string Comments { get; set; }
        public string Company { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastSavedBy { get; set; }
        public DateTime LastSavedTime { get; set; }
        public string Keywords { get; set; }
        public string Manager { get; set; }
        public string PresentationFormat { get; set; }
        public int RevisionNumber { get; set; }
        public bool ScaleCrop { get; set; }
        public bool SharedDoc { get; set; }
        public int Slides { get; set; }
        public int Words { get; set; }
        public TimeSpan TotalEditingTime { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "properties.json";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    IDocumentProperties docProps = presentation.DocumentProperties;

                    // Populate the built‑in properties object
                    BuiltInProperties builtIn = new BuiltInProperties
                    {
                        Title = docProps.Title,
                        Author = docProps.Author,
                        Subject = docProps.Subject,
                        Category = docProps.Category,
                        Comments = docProps.Comments,
                        Company = docProps.Company,
                        CreatedTime = docProps.CreatedTime,
                        LastSavedBy = docProps.LastSavedBy,
                        LastSavedTime = docProps.LastSavedTime,
                        Keywords = docProps.Keywords,
                        Manager = docProps.Manager,
                        PresentationFormat = docProps.PresentationFormat,
                        RevisionNumber = docProps.RevisionNumber,
                        ScaleCrop = docProps.ScaleCrop,
                        SharedDoc = docProps.SharedDoc,
                        Slides = docProps.Slides,
                        Words = docProps.Words,
                        TotalEditingTime = docProps.TotalEditingTime
                    };

                    // Serialize to JSON and write to file
                    JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
                    string json = JsonSerializer.Serialize(builtIn, options);
                    File.WriteAllText(outputPath, json);
                    Console.WriteLine("Built‑in properties written to: " + outputPath);

                    // Save the presentation before exiting as required
                    presentation.Save("temp_saved.pptx", SaveFormat.Pptx);
                }
            }
            // Handle unsupported format exceptions
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                Console.WriteLine("Unsupported PPTX format: " + ex.Message);
            }
            catch (Aspose.Slides.PptUnsupportedFormatException ex)
            {
                Console.WriteLine("Unsupported PPT format: " + ex.Message);
            }
            // General exception handling
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
