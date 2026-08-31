// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX slides as high resolution PNG using C#

//

// Description:

// Demonstrates how to export each slide of a PPTX file to high‑resolution PNG

// images using Aspose.Slides for .NET. The example loads a presentation,

// renders every slide with a 3× scaling factor to increase image quality,

// saves the PNG files to a specified folder, and optionally saves a copy of

// the presentation. This pattern can be used to automate slide image extraction

// or integrate high‑resolution export into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Export, High Resolution,

// Slides, Image, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate export of PPTX slides as high‑resolution PNG images.

// - Build C# utilities for PowerPoint slide image extraction.

// - Generate visual assets for web, documentation, or e‑learning platforms.

// - Integrate slide rendering into .NET workflows or services.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ExportSlidesToPng

{

    class Program

    {

        static void Main(string[] args)

        {

            string inputPath = "input.pptx";

            string outputDir = "output_images";

            string outputPresentation = "output.pptx";



            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist.");

                return;

            }



            if (!Directory.Exists(outputDir))

            {

                Directory.CreateDirectory(outputDir);

            }



            try

            {

                using (Presentation presentation = new Presentation(inputPath))

                {

                    int slideCount = presentation.Slides.Count;

                    for (int i = 0; i < slideCount; i++)

                    {

                        ISlide slide = presentation.Slides[i];

                        float scaleX = 3f;

                        float scaleY = 3f;

                        using (IImage image = slide.GetImage(scaleX, scaleY))

                        {

                            string imagePath = Path.Combine(outputDir, $"slide_{i + 1}.png");

                            image.Save(imagePath, Aspose.Slides.ImageFormat.Png);

                        }

                    }



                    // Save presentation before exit

                    presentation.Save(outputPresentation, Aspose.Slides.Export.SaveFormat.Pptx);

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The file format is not supported.");

            }

            catch (Exception ex)

            {

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

