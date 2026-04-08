using System;
using System.IO;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationMetadataExport
{
    // Class to hold metadata information
    public class PresentationMetadata
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Subject { get; set; }
        public DateTime CreatedTime { get; set; }
        public int SlidesCount { get; set; }
        public int HiddenSlides { get; set; }
        public string PresentationFormat { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string jsonOutputPath = "metadata.json";
            string savedPresentationPath = "saved_output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Extract document properties
                    Aspose.Slides.IDocumentProperties docProps = presentation.DocumentProperties;

                    // Populate metadata object
                    PresentationMetadata metadata = new PresentationMetadata();
                    metadata.Title = docProps.Title;
                    metadata.Author = docProps.Author;
                    metadata.Subject = docProps.Subject;
                    metadata.CreatedTime = docProps.CreatedTime;
                    metadata.SlidesCount = presentation.Slides.Count;
                    metadata.HiddenSlides = docProps.HiddenSlides;
                    metadata.PresentationFormat = docProps.PresentationFormat;

                    // Serialize metadata to JSON
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(metadata, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });

                    // Write JSON to file
                    File.WriteAllText(jsonOutputPath, jsonString);
                    Console.WriteLine("Metadata exported to JSON file: " + jsonOutputPath);

                    // Save the presentation before exiting (as per requirement)
                    presentation.Save(savedPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported for this operation.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URLs or web services)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}