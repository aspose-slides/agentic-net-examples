// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX slides to PNG with alpha channel using C#

//

// Description:

// Demonstrates how to load a PPTX file, iterate through its slides, and export

// each slide as a PNG image preserving the alpha channel using Aspose.Slides for .NET.

// The example includes basic file existence checks and exception handling in a

// console application.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Alpha channel, Export, Slides, Presentation processing

//

// Use Cases:

// - Convert PowerPoint slides to PNG images with transparency.

// - Automate batch export of slide images in .NET tools.

// - Integrate slide-to-image conversion into reporting or publishing pipelines.

// - Validate slide rendering with alpha channel support.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        // Path to the source presentation

        string inputPath = "input.pptx";



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file not found: " + inputPath);

            return;

        }



        try

        {

            // Load the presentation

            using (Presentation pres = new Presentation(inputPath))

            {

                // Iterate through all slides

                for (int i = 0; i < pres.Slides.Count; i++)

                {

                    ISlide slide = pres.Slides[i];



                    // Export each slide as PNG with alpha channel preserved

                    using (IImage image = slide.GetImage(1f, 1f))

                    {

                        string outputPath = $"slide_{i}.png";

                        image.Save(outputPath, Aspose.Slides.ImageFormat.Png);

                    }

                }



                // Save the presentation (required before exit)

                pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            }

        }

        catch (NotSupportedException)

        {

            // Format not supported

            // Comment: The provided file format is not supported by Aspose.Slides.

        }

        catch (Exception ex)

        {

            // Handle other exceptions (e.g., I/O errors, network issues)

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

