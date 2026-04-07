using System;
using System.IO;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SwfConversionUtility
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect three arguments: input presentation, output SWF, JSON config
            if (args.Length < 3)
            {
                Console.WriteLine("Usage: SwfConversionUtility <input.pptx> <output.swf> <config.json>");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];
            string configPath = args[2];

            // Verify input files exist
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input presentation file not found: {inputPath}");
                return;
            }

            if (!File.Exists(configPath))
            {
                Console.WriteLine($"Configuration JSON file not found: {configPath}");
                return;
            }

            // Load SwfOptions settings from JSON
            SwfOptions swfOptions = new SwfOptions();
            try
            {
                string jsonContent = File.ReadAllText(configPath);
                JsonDocument document = JsonDocument.Parse(jsonContent);
                JsonElement root = document.RootElement;

                if (root.TryGetProperty("Compressed", out JsonElement compressed))
                    swfOptions.Compressed = compressed.GetBoolean();

                if (root.TryGetProperty("DefaultRegularFont", out JsonElement defaultFont))
                    swfOptions.DefaultRegularFont = defaultFont.GetString();

                if (root.TryGetProperty("EnableContextMenu", out JsonElement contextMenu))
                    swfOptions.EnableContextMenu = contextMenu.GetBoolean();

                if (root.TryGetProperty("JpegQuality", out JsonElement jpegQuality))
                    swfOptions.JpegQuality = jpegQuality.GetInt32();

                if (root.TryGetProperty("ShowBottomPane", out JsonElement bottomPane))
                    swfOptions.ShowBottomPane = bottomPane.GetBoolean();

                if (root.TryGetProperty("ShowFullScreen", out JsonElement fullScreen))
                    swfOptions.ShowFullScreen = fullScreen.GetBoolean();

                if (root.TryGetProperty("ShowHiddenSlides", out JsonElement hiddenSlides))
                    swfOptions.ShowHiddenSlides = hiddenSlides.GetBoolean();

                if (root.TryGetProperty("ShowLeftPane", out JsonElement leftPane))
                    swfOptions.ShowLeftPane = leftPane.GetBoolean();

                if (root.TryGetProperty("ShowPageBorder", out JsonElement pageBorder))
                    swfOptions.ShowPageBorder = pageBorder.GetBoolean();

                if (root.TryGetProperty("ShowPageStepper", out JsonElement pageStepper))
                    swfOptions.ShowPageStepper = pageStepper.GetBoolean();

                if (root.TryGetProperty("ShowSearch", out JsonElement search))
                    swfOptions.ShowSearch = search.GetBoolean();

                if (root.TryGetProperty("ShowTopPane", out JsonElement topPane))
                    swfOptions.ShowTopPane = topPane.GetBoolean();

                if (root.TryGetProperty("SkipJavaScriptLinks", out JsonElement skipJs))
                    swfOptions.SkipJavaScriptLinks = skipJs.GetBoolean();

                if (root.TryGetProperty("ViewerIncluded", out JsonElement viewerIncluded))
                    swfOptions.ViewerIncluded = viewerIncluded.GetBoolean();

                // Additional properties like LogoImageBytes, LogoLink, etc., can be added similarly.
            }
            catch (JsonException)
            {
                Console.WriteLine("Failed to parse JSON configuration.");
                return;
            }
            catch (Exception ex)
            {
                // Handle any other unexpected errors (e.g., I/O errors)
                Console.WriteLine($"Error reading configuration: {ex.Message}");
                return;
            }

            // Perform conversion
            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    presentation.Save(outputPath, SaveFormat.Swf, swfOptions);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file access issues)
                Console.WriteLine($"Conversion failed: {ex.Message}");
            }
        }
    }
}