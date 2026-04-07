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
        // Path to the configuration file
        string configPath = "config.json";

        // Verify that the configuration file exists
        if (!File.Exists(configPath))
        {
            Console.WriteLine("Configuration file not found: " + configPath);
            return;
        }

        // Read and deserialize the configuration
        string json = File.ReadAllText(configPath);
        List<ConversionBatch> batches = JsonSerializer.Deserialize<List<ConversionBatch>>(json);
        if (batches == null)
        {
            Console.WriteLine("Failed to parse configuration.");
            return;
        }

        // Process each conversion batch
        foreach (ConversionBatch batch in batches)
        {
            // Verify that the source presentation exists
            if (!File.Exists(batch.SourcePath))
            {
                Console.WriteLine("Source file not found: " + batch.SourcePath);
                continue;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(batch.SourcePath))
                {
                    // Create and configure SWF options
                    SwfOptions options = new SwfOptions();
                    options.Compressed = batch.Compressed;
                    options.ShowHiddenSlides = batch.ShowHiddenSlides;
                    options.EnableContextMenu = batch.EnableContextMenu;
                    options.ShowBottomPane = batch.ShowBottomPane;
                    options.ShowFullScreen = batch.ShowFullScreen;
                    options.ShowLeftPane = batch.ShowLeftPane;
                    options.ShowPageBorder = batch.ShowPageBorder;
                    options.ShowPageStepper = batch.ShowPageStepper;
                    options.ShowSearch = batch.ShowSearch;
                    options.ShowTopPane = batch.ShowTopPane;
                    options.StartOpenLeftPane = batch.StartOpenLeftPane;
                    options.ViewerIncluded = batch.ViewerIncluded;

                    // Save the presentation as SWF using the configured options
                    presentation.Save(batch.OutputPath, SaveFormat.Swf, options);
                }
            }
            catch (PptxUnsupportedFormatException)
            {
                // Handle unsupported file format
                Console.WriteLine("Unsupported file format for: " + batch.SourcePath);
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("Error processing file: " + batch.SourcePath);
                Console.WriteLine(ex.Message);
            }
        }
    }

    // Class representing a conversion batch configuration
    public class ConversionBatch
    {
        public string SourcePath { get; set; }
        public string OutputPath { get; set; }
        public bool Compressed { get; set; } = true;
        public bool ShowHiddenSlides { get; set; } = false;
        public bool EnableContextMenu { get; set; } = true;
        public bool ShowBottomPane { get; set; } = true;
        public bool ShowFullScreen { get; set; } = true;
        public bool ShowLeftPane { get; set; } = true;
        public bool ShowPageBorder { get; set; } = true;
        public bool ShowPageStepper { get; set; } = true;
        public bool ShowSearch { get; set; } = true;
        public bool ShowTopPane { get; set; } = true;
        public bool StartOpenLeftPane { get; set; } = false;
        public bool ViewerIncluded { get; set; } = true;
    }
}