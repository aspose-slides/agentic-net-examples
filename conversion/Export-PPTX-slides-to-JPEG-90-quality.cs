// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX slides to JPEG 90 quality using C#

//

// Description:

// Demonstrates how to export each slide of a PPTX file to a JPEG image with

// 90% quality using C# and Aspose.Slides for .NET. The example loads a

// presentation, iterates through its slides, saves each slide as a JPEG file,

// and finally saves the (unchanged) presentation. This pattern can be used to

// automate slide‑to‑image conversion in .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, JPEG, Export, Slides, Jpeg,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Convert PPTX slides to high‑quality JPEG images for web or documentation.

// - Build C# utilities for batch processing of PowerPoint presentations.

// - Integrate slide image extraction into .NET workflows.

// - Validate slide rendering before publishing or further processing.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        string inputPath = "input.pptx";



        // Check if the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Load the presentation

            using (Presentation presentation = new Presentation(inputPath))

            {

                // Export each slide to JPEG with quality 90

                for (int index = 0; index < presentation.Slides.Count; index++)

                {

                    ISlide slide = presentation.Slides[index];

                    using (IImage slideImage = slide.GetImage(1f, 1f))

                    {

                        string outputFile = $"Slide_{index + 1}.jpg";

                        slideImage.Save(outputFile, Aspose.Slides.ImageFormat.Jpeg, 90);

                    }

                }



                // Save the presentation before exiting (no modifications made)

                presentation.Save("output.pptx", SaveFormat.Pptx);

            }

        }

        catch (NotSupportedException)

        {

            // Format not supported

            Console.WriteLine("The file format is not supported.");

        }

        catch (Exception ex)

        {

            // Handle other exceptions (e.g., external URLs or I/O errors)

            Console.WriteLine($"Error: {ex.Message}");

        }

    }

}

