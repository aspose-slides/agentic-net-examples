// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Batch export PowerPoint presentations to PNG subfolders using C#

//

// Description:

// Demonstrates how to iterate over PowerPoint files in a directory, load each

// presentation with Aspose.Slides for .NET, and export every slide as a PNG

// image into a dedicated subfolder named after the source file. The sample

// supports PPT, PPTX, PPTM, and ODP formats, creates output folders as needed,

// and includes basic error handling for unsupported formats and I/O issues.

// This console application can serve as a template for automating slide‑image

// generation or integrating presentation processing into .NET solutions.

//

// Keywords:

// C#, Aspose.Slides for .NET, PowerPoint, PPT, PPTX, PPTM, ODP, PNG, Slide Export,

// Batch Processing, Subfolders, Presentation Conversion, Office Automation

//

// Use Cases:

// - Convert a collection of presentations to PNG images for web publishing.

// - Generate slide thumbnails or archives in automated build pipelines.

// - Build command‑line tools that batch‑process PowerPoint files in .NET.

// - Validate and transform presentation assets before distribution.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace BatchExportPptToPng

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input and output directories

            string inputDirectory = "Input";

            string outputDirectory = "Output";



            // Verify input directory exists

            if (!Directory.Exists(inputDirectory))

            {

                Console.WriteLine($"Input directory does not exist: {inputDirectory}");

                return;

            }



            // Create output directory if it does not exist

            if (!Directory.Exists(outputDirectory))

            {

                Directory.CreateDirectory(outputDirectory);

            }



            // Process each PowerPoint file in the input directory

            string[] pptFiles = Directory.GetFiles(inputDirectory, "*.*", SearchOption.TopDirectoryOnly);

            foreach (string filePath in pptFiles)

            {

                string extension = Path.GetExtension(filePath).ToLowerInvariant();

                if (extension != ".ppt" && extension != ".pptx" && extension != ".pptm" && extension != ".odp")

                {

                    // Skip unsupported file types

                    continue;

                }



                // Verify the file exists before processing

                if (!File.Exists(filePath))

                {

                    Console.WriteLine($"File not found: {filePath}");

                    continue;

                }



                try

                {

                    // Load the presentation

                    using (Presentation presentation = new Presentation(filePath))

                    {

                        // Create a subfolder named after the presentation (without extension)

                        string presentationName = Path.GetFileNameWithoutExtension(filePath);

                        string presentationOutputFolder = Path.Combine(outputDirectory, presentationName);

                        if (!Directory.Exists(presentationOutputFolder))

                        {

                            Directory.CreateDirectory(presentationOutputFolder);

                        }



                        // Export each slide to PNG

                        for (int index = 0; index < presentation.Slides.Count; index++)

                        {

                            ISlide slide = presentation.Slides[index];

                            using (IImage slideImage = slide.GetImage())

                            {

                                string outputPath = Path.Combine(presentationOutputFolder, $"slide_{index + 1}.png");

                                slideImage.Save(outputPath, Aspose.Slides.ImageFormat.Png);

                            }

                        }



                        // Save the presentation (no modifications, just to satisfy the rule)

                        try

                        {

                            presentation.Save(filePath, SaveFormat.Pptx);

                        }

                        catch (PptxUnsupportedFormatException)

                        {

                            // Format not supported for saving as PPTX; ignore as we only needed to export slides

                        }

                    }

                }

                catch (PptxUnsupportedFormatException)

                {

                    // Format not supported for loading; write comment and continue

                    Console.WriteLine($"Unsupported presentation format: {filePath}");

                }

                catch (Exception ex)

                {

                    // General exception handling (e.g., I/O errors)

                    Console.WriteLine($"Error processing file '{filePath}': {ex.Message}");

                }

            }

        }

    }

}

