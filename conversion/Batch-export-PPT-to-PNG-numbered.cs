// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Batch export PPT to PNG numbered using C#

//

// Description:

// Demonstrates how to batch export PowerPoint presentations (PPT, PPTX, ODP, PPTM)

// to numbered PNG images using C# and Aspose.Slides for .NET. The example iterates

// through all supported presentation files in an input folder, converts each slide

// to a PNG file prefixed with the slide number, and saves the images to an output

// folder. This pattern can be used to automate slide extraction, create image

// assets for web publishing, or integrate presentation processing into .NET

// applications.

//

// Keywords:

// C#, PowerPoint, PPTX, PPT, ODP, PPTM, Aspose.Slides for .NET, PNG, Batch Export,

// Numbered Slides, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate batch conversion of PowerPoint slides to numbered PNG images.

// - Build C# utilities for extracting slide images from presentations.

// - Generate image assets for documentation, e‑learning, or web content.

// - Validate and preview presentation content programmatically before publishing.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace BatchExport

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input and output directories

            string inputDir = Path.Combine(Environment.CurrentDirectory, "InputPpts");

            string outputDir = Path.Combine(Environment.CurrentDirectory, "OutputImages");



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



            // Get all files in the input directory

            string[] pptFiles = Directory.GetFiles(inputDir, "*.*", SearchOption.TopDirectoryOnly);

            foreach (string filePath in pptFiles)

            {

                // Process only supported PowerPoint formats

                string extension = Path.GetExtension(filePath).ToLowerInvariant();

                if (extension != ".ppt" && extension != ".pptx" && extension != ".odp" && extension != ".pptm")

                {

                    continue; // Skip unsupported formats

                }



                // Check file existence (important)

                if (!File.Exists(filePath))

                {

                    Console.WriteLine("File not found: " + filePath);

                    continue;

                }



                try

                {

                    // Load the presentation

                    Presentation pres = new Presentation(filePath);



                    // Prepare output file name format (slide number prefix)

                    string formatString = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(filePath) + "_slide_{0}.png");



                    // Export each slide to PNG (using provided rule structure)

                    for (int index = 0; index < pres.Slides.Count; index++)

                    {

                        ISlide slide = pres.Slides[index];

                        using (IImage image = slide.GetImage())

                        {

                            string outputPath = string.Format(formatString, index + 1);

                            image.Save(outputPath, ImageFormat.Png);

                        }

                    }



                    // Save presentation before exit (no modifications made)

                    try

                    {

                        pres.Save(filePath, SaveFormat.Pptx);

                    }

                    catch (NotSupportedException)

                    {

                        // Format not supported for saving as PPTX

                    }



                    pres.Dispose();

                }

                catch (Exception ex)

                {

                    // Handle any processing errors

                    Console.WriteLine("Error processing file " + filePath + ": " + ex.Message);

                }

            }

        }

    }

}

