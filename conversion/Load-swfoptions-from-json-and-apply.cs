// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Load swfoptions from json and apply using C#

//

// Description:

// Demonstrates how to load SwfOptions from a JSON configuration file and

// apply them to convert a PowerPoint presentation (PPTX) to SWF format using

// Aspose.Slides for .NET. The example includes argument validation, JSON

// deserialization, option mapping, and saving the output file.

//

// Keywords:

// C#, PowerPoint, PPTX, SWF, Aspose.Slides for .NET, Load, SwfOptions, Json,

// Convert, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate PPTX to SWF conversion with customizable options.

// - Build command‑line utilities for batch processing of presentations.

// - Integrate configurable SWF export into .NET applications.

// - Validate and test presentation conversion workflows.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using System.Text.Json;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SwfConversionUtility

{

    // Class representing the JSON configuration for SwfOptions

    public class SwfConfig

    {

        public bool? Compressed { get; set; }

        public string DefaultRegularFont { get; set; }

        public bool? EnableContextMenu { get; set; }

        public int? JpegQuality { get; set; }

        public bool? ShowBottomPane { get; set; }

        public bool? ShowFullScreen { get; set; }

        public bool? ShowHiddenSlides { get; set; }

        public bool? ShowLeftPane { get; set; }

        public bool? ShowPageBorder { get; set; }

        public bool? ShowPageStepper { get; set; }

        public bool? ShowSearch { get; set; }

        public bool? ShowTopPane { get; set; }

        public bool? ViewerIncluded { get; set; }

        // Add other properties as needed

    }



    class Program

    {

        static void Main(string[] args)

        {

            // Expecting three arguments: configJsonPath, inputPptxPath, outputSwfPath

            if (args.Length < 3)

            {

                Console.WriteLine("Usage: SwfConversionUtility <configJsonPath> <inputPptxPath> <outputSwfPath>");

                return;

            }



            string configJsonPath = args[0];

            string inputPptxPath = args[1];

            string outputSwfPath = args[2];



            // Verify that the JSON configuration file exists

            if (!File.Exists(configJsonPath))

            {

                Console.WriteLine($"Configuration file not found: {configJsonPath}");

                return;

            }



            // Verify that the input presentation file exists

            if (!File.Exists(inputPptxPath))

            {

                Console.WriteLine($"Input presentation file not found: {inputPptxPath}");

                return;

            }



            SwfConfig config;

            try

            {

                string jsonContent = File.ReadAllText(configJsonPath);

                config = JsonSerializer.Deserialize<SwfConfig>(jsonContent);

            }

            catch (Exception ex)

            {

                Console.WriteLine($"Failed to read or parse configuration file: {ex.Message}");

                return;

            }



            try

            {

                using (Presentation pres = new Presentation(inputPptxPath))

                {

                    // Create SwfOptions and apply settings from config

                    SwfOptions swfOptions = new SwfOptions();



                    if (config.Compressed.HasValue)

                        swfOptions.Compressed = config.Compressed.Value;



                    if (!string.IsNullOrEmpty(config.DefaultRegularFont))

                        swfOptions.DefaultRegularFont = config.DefaultRegularFont;



                    if (config.EnableContextMenu.HasValue)

                        swfOptions.EnableContextMenu = config.EnableContextMenu.Value;



                    if (config.JpegQuality.HasValue)

                        swfOptions.JpegQuality = config.JpegQuality.Value;



                    if (config.ShowBottomPane.HasValue)

                        swfOptions.ShowBottomPane = config.ShowBottomPane.Value;



                    if (config.ShowFullScreen.HasValue)

                        swfOptions.ShowFullScreen = config.ShowFullScreen.Value;



                    if (config.ShowHiddenSlides.HasValue)

                        swfOptions.ShowHiddenSlides = config.ShowHiddenSlides.Value;



                    if (config.ShowLeftPane.HasValue)

                        swfOptions.ShowLeftPane = config.ShowLeftPane.Value;



                    if (config.ShowPageBorder.HasValue)

                        swfOptions.ShowPageBorder = config.ShowPageBorder.Value;



                    if (config.ShowPageStepper.HasValue)

                        swfOptions.ShowPageStepper = config.ShowPageStepper.Value;



                    if (config.ShowSearch.HasValue)

                        swfOptions.ShowSearch = config.ShowSearch.Value;



                    if (config.ShowTopPane.HasValue)

                        swfOptions.ShowTopPane = config.ShowTopPane.Value;



                    if (config.ViewerIncluded.HasValue)

                        swfOptions.ViewerIncluded = config.ViewerIncluded.Value;



                    // Save the presentation as SWF using the configured options

                    pres.Save(outputSwfPath, SaveFormat.Swf, swfOptions);

                }



                // Ensure the presentation is saved before exiting (handled by using block)

                Console.WriteLine($"Conversion completed successfully. Output saved to {outputSwfPath}");

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The specified format is not supported for conversion.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine($"An error occurred during conversion: {ex.Message}");

            }

        }

    }

}

