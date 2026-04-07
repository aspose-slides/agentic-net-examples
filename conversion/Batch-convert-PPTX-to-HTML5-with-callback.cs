using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchConvertToHtml5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output directories
            string inputDir = Path.Combine(Directory.GetCurrentDirectory(), "InputPresentations");
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Html5Output");

            // Verify input directory exists
            if (!Directory.Exists(inputDir))
            {
                Console.WriteLine("Input directory does not exist: " + inputDir);
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Get all PPTX files in the input directory
            string[] presentationFiles = Directory.GetFiles(inputDir, "*.pptx", SearchOption.TopDirectoryOnly);

            foreach (string presPath in presentationFiles)
            {
                // Verify the file exists before loading
                if (!File.Exists(presPath))
                {
                    Console.WriteLine("File not found: " + presPath);
                    continue;
                }

                try
                {
                    // Load the presentation
                    using (Presentation presentation = new Presentation(presPath))
                    {
                        // Prepare HTML5 export options
                        Html5Options options = new Html5Options
                        {
                            // Example: embed images (set to true or false as needed)
                            EmbedImages = true,
                            // Example: enable shape and transition animations
                            AnimateShapes = true,
                            AnimateTransitions = true,
                            // Set the output path for external resources (e.g., images)
                            OutputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(presPath) + "_resources")
                        };

                        // Ensure the resources output directory exists
                        if (!Directory.Exists(options.OutputPath))
                        {
                            Directory.CreateDirectory(options.OutputPath);
                        }

                        // OPTIONAL: Custom JavaScript callback after each slide loads.
                        // Aspose.Slides does not expose a direct hook for this in Html5Options,
                        // but you can embed a custom script by using a custom HTML formatter.
                        // Below is a placeholder for such implementation.
                        // HtmlFormatter customFormatter = HtmlFormatter.CreateSlideShowFormatter("", true);
                        // options.HtmlFormatter = customFormatter; // Assuming Html5Options supports this property.

                        // Define output HTML file path
                        string outputHtmlPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(presPath) + ".html");

                        // Save the presentation as HTML5
                        presentation.Save(outputHtmlPath, SaveFormat.Html5, options);
                        Console.WriteLine("Converted: " + presPath + " -> " + outputHtmlPath);
                    }
                }
                catch (DirectoryNotFoundException dirEx)
                {
                    // Handle missing directories during save operation
                    Console.WriteLine("Directory not found: " + dirEx.Message);
                }
                catch (NotSupportedException nsEx)
                {
                    // Handle unsupported format exception
                    Console.WriteLine("Format not supported for file: " + presPath + " - " + nsEx.Message);
                }
                catch (Exception ex)
                {
                    // General exception handling (e.g., web service errors)
                    Console.WriteLine("Error processing file: " + presPath + " - " + ex.Message);
                }
            }

            // Ensure all resources are released before exiting
            Console.WriteLine("Batch conversion completed.");
        }
    }
}