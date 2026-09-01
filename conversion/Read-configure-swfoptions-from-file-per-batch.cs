// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Read and apply SWF conversion options from a configuration file per batch using C#

//

// Description:

// Demonstrates how to read a configuration file containing SWF conversion options

// and apply them to convert a PowerPoint presentation to SWF using Aspose.Slides for .NET.

// The example shows the required presentation-processing steps for PowerPoint files

// and produces the requested output in a standalone console application. Developers can

// use this pattern to automate PPTX to SWF workflows, customize conversion settings,

// or integrate presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Read, Configure, SwfOptions,

// File, Presentation Processing, Batch Conversion, Office Automation

//

// Use Cases:

// - Batch convert PPTX files to SWF with custom conversion options.

// - Automate PowerPoint to SWF conversion using external configuration files.

// - Build C# tools for PowerPoint presentation processing and SWF output customization.

// - Validate and fine‑tune SWF conversion settings before publishing or integration.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using System.Collections.Generic;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SwfConversionUtility

{

    class Program

    {

        static void Main(string[] args)

        {

            // Expect configuration file path as first argument

            if (args.Length == 0)

            {

                Console.WriteLine("Please provide the path to the configuration file.");

                return;

            }



            string configPath = args[0];

            if (!File.Exists(configPath))

            {

                Console.WriteLine($"Configuration file not found: {configPath}");

                return;

            }



            // Read all lines from the configuration file

            string[] lines = File.ReadAllLines(configPath);

            // Simple key-value parsing

            Dictionary<string, string> config = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            foreach (string line in lines)

            {

                if (string.IsNullOrWhiteSpace(line) || line.TrimStart().StartsWith("#"))

                    continue; // Skip empty lines and comments



                int separatorIndex = line.IndexOf('=');

                if (separatorIndex > 0)

                {

                    string key = line.Substring(0, separatorIndex).Trim();

                    string value = line.Substring(separatorIndex + 1).Trim();

                    config[key] = value;

                }

            }



            // Required keys: InputFile, OutputFile

            if (!config.ContainsKey("InputFile") || !config.ContainsKey("OutputFile"))

            {

                Console.WriteLine("Configuration must contain InputFile and OutputFile entries.");

                return;

            }



            string inputFile = config["InputFile"];

            string outputFile = config["OutputFile"];



            if (!File.Exists(inputFile))

            {

                Console.WriteLine($"Input presentation file not found: {inputFile}");

                return;

            }



            try

            {

                using (Presentation presentation = new Presentation(inputFile))

                {

                    // Create default SwfOptions

                    SwfOptions swfOptions = new SwfOptions();



                    // Apply optional settings from config

                    if (config.ContainsKey("Compressed"))

                    {

                        if (bool.TryParse(config["Compressed"], out bool compressed))

                            swfOptions.Compressed = compressed;

                    }



                    if (config.ContainsKey("ViewerIncluded"))

                    {

                        if (bool.TryParse(config["ViewerIncluded"], out bool viewerIncluded))

                            swfOptions.ViewerIncluded = viewerIncluded;

                    }



                    if (config.ContainsKey("ShowHiddenSlides"))

                    {

                        if (bool.TryParse(config["ShowHiddenSlides"], out bool showHidden))

                            swfOptions.ShowHiddenSlides = showHidden;

                    }



                    if (config.ContainsKey("JpegQuality"))

                    {

                        if (int.TryParse(config["JpegQuality"], out int jpegQuality))

                            swfOptions.JpegQuality = jpegQuality;

                    }



                    // Additional properties can be set similarly...



                    // Save the presentation as SWF using the configured options

                    presentation.Save(outputFile, SaveFormat.Swf, swfOptions);

                }

            }

            catch (Aspose.Slides.PptxUnsupportedFormatException ex)

            {

                // Handle unsupported file format

                Console.WriteLine($"Unsupported file format: {ex.Message}");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine($"An error occurred: {ex.Message}");

            }

        }

    }

}

