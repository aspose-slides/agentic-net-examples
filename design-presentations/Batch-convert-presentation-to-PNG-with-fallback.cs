// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Batch convert presentation to PNG with fallback using C#

//

// Description:

// Demonstrates how to batch convert PowerPoint presentations to PNG images

// using Aspose.Slides for .NET with a fallback font. The example processes

// all supported presentation files in an input directory, generates a PNG

// image for each slide, and saves the images to an output directory. It also

// saves a copy of the original presentation to the output folder, illustrating

// how to work with presentations in a console application.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Batch, Convert, 

// Presentation, Fallback Font, Image Export, Office Automation

//

// Use Cases:

// - Automate batch conversion of presentations to PNG images with font fallback.

// - Build .NET tools for processing PowerPoint files in bulk.

// - Generate slide images for web previews or documentation.

// - Ensure consistent rendering when original fonts are unavailable.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace BatchConvertToPng

{

    class Program

    {

        static void Main(string[] args)

        {

            string inputFolder = "InputPresentations";

            string outputFolder = "OutputImages";



            if (!Directory.Exists(inputFolder))

            {

                Console.WriteLine("Input folder does not exist.");

                return;

            }



            if (!Directory.Exists(outputFolder))

            {

                Directory.CreateDirectory(outputFolder);

            }



            string[] supportedExtensions = new string[] { ".ppt", ".pptx", ".odp", ".pptm", ".potx", ".potm" };

            string[] presentationFiles = Directory.GetFiles(inputFolder);



            foreach (string filePath in presentationFiles)

            {

                try

                {

                    if (!File.Exists(filePath))

                    {

                        Console.WriteLine($"File not found: {filePath}");

                        continue;

                    }



                    string extension = Path.GetExtension(filePath).ToLowerInvariant();

                    bool isSupported = false;

                    foreach (string ext in supportedExtensions)

                    {

                        if (extension == ext)

                        {

                            isSupported = true;

                            break;

                        }

                    }



                    if (!isSupported)

                    {

                        // format not supported

                        Console.WriteLine($"Unsupported format: {filePath}");

                        continue;

                    }



                    // Load with fallback font (DefaultRegularFont)

                    LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);

                    loadOptions.DefaultRegularFont = "Arial";



                    using (Presentation presentation = new Presentation(filePath, loadOptions))

                    {

                        for (int i = 0; i < presentation.Slides.Count; i++)

                        {

                            ISlide slide = presentation.Slides[i];

                            // Generate full‑scale image

                            IImage image = slide.GetImage(1f, 1f);

                            string outputFileName = Path.GetFileNameWithoutExtension(filePath) + $"_slide_{i + 1}.png";

                            string outputPath = Path.Combine(outputFolder, outputFileName);

                            image.Save(outputPath, Aspose.Slides.ImageFormat.Png);

                        }



                        // Save presentation before exit (no changes made, but fulfills requirement)

                        string tempSavePath = Path.Combine(outputFolder, Path.GetFileName(filePath));

                        presentation.Save(tempSavePath, SaveFormat.Pptx);

                    }

                }

                catch (PptxUnsupportedFormatException)

                {

                    // format not supported

                    Console.WriteLine($"Unsupported format exception for file: {filePath}");

                }

                catch (Exception ex)

                {

                    Console.WriteLine($"Error processing file {filePath}: {ex.Message}");

                }

            }

        }

    }

}

