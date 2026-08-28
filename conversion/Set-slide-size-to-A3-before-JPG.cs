// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Set slide size to A3 before JPG using C#

//

// Description:

// Demonstrates how to set the slide size of a PowerPoint presentation to A3

// before exporting each slide as a JPG image using C# and Aspose.Slides for .NET.

// The example loads a PPTX file, changes the slide dimensions, saves the

// modified presentation, and then renders each slide to a JPEG file.

// This pattern can be used to automate slide‑size adjustments and image

// extraction in .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, JPG, Slide, Size, A3, Before,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Adjust slide size to A3 before image export.

// - Build C# utilities for converting PPTX slides to JPEG with specific dimensions.

// - Integrate slide‑size manipulation and image rendering into .NET workflows.

// - Validate and preprocess presentations prior to publishing or further processing.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        var inputPath = "input.pptx";

        var outputPresPath = "output_A3.pptx";

        var outputImgFolder = "Images";



        try

        {

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist.");

                return;

            }



            // Load presentation

            var presentation = new Presentation(inputPath);



            // Set slide size to A3 with EnsureFit scaling

            presentation.SlideSize.SetSize(SlideSizeType.A3Paper, SlideSizeScaleType.EnsureFit);



            // Save modified presentation

            presentation.Save(outputPresPath, SaveFormat.Pptx);



            // Ensure output folder exists

            Directory.CreateDirectory(outputImgFolder);



            // Export each slide to JPG

            foreach (var slide in presentation.Slides)

            {

                using (var image = slide.GetImage(1f, 1f))

                {

                    var imagePath = Path.Combine(outputImgFolder, $"Slide_{slide.SlideNumber}.jpg");

                    image.Save(imagePath, ImageFormat.Jpeg);

                }

            }



            // Dispose presentation

            presentation.Dispose();

        }

        catch (NotSupportedException)

        {

            // Format not supported

        }

        catch (Exception)

        {

            // Handle other exceptions (e.g., external URLs)

        }

    }

}

