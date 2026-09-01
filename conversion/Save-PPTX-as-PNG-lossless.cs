// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Save PPTX as PNG lossless using C#

//

// Description:

// Demonstrates how to load a PPTX file and export each slide as a lossless PNG

// image using Aspose.Slides for .NET. The example also shows the required

// presentation lifecycle handling by saving the (unchanged) presentation back

// to disk. This pattern can be used to automate slide‑to‑image conversion in

// .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Save, Lossless, Slide Export,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of PPTX slides to high‑quality PNG images.

// - Build C# utilities for extracting slide graphics for web or documentation.

// - Generate image assets from presentations in .NET workflows.

// - Validate slide rendering before publishing or integration.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SlideToPngConverter

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input PPTX file path

            string inputPath = "input.pptx";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                using (Presentation presentation = new Presentation(inputPath))

                {

                    // Iterate through all slides

                    for (int index = 0; index < presentation.Slides.Count; index++)

                    {

                        ISlide slide = presentation.Slides[index];

                        // Export each slide as a PNG image using lossless compression

                        using (IImage image = slide.GetImage())

                        {

                            string outputPath = $"slide_{index}.png";

                            image.Save(outputPath, Aspose.Slides.ImageFormat.Png);

                        }

                    }



                    // Save the presentation (no modifications, but required by lifecycle rule)

                    presentation.Save("output.pptx", SaveFormat.Pptx);

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The provided file format is not supported.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

