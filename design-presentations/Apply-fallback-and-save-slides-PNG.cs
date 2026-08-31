// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export slides to PNG using C#

//

// Description:

// Demonstrates how to load a PowerPoint presentation and export each slide

// as a PNG image using Aspose.Slides for .NET. The example includes basic

// validation of the input file and error handling, and shows how to save the

// (unchanged) presentation back to disk.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Export, Slides, Presentation Processing, Office Automation

//

// Use Cases:

// - Convert PowerPoint slides to PNG images for web or documentation.

// - Automate slide image generation in .NET applications.

// - Integrate slide export functionality into custom tools.

// - Validate slide rendering before publishing.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Path to the source presentation

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

            using (Presentation pres = new Presentation(inputPath))

            {

                // Iterate through each slide and export as PNG

                for (int index = 0; index < pres.Slides.Count; index++)

                {

                    ISlide slide = pres.Slides[index];

                    using (IImage slideImage = slide.GetImage())

                    {

                        string outputFile = $"slide_{index + 1}.png";

                        slideImage.Save(outputFile, Aspose.Slides.ImageFormat.Png);

                    }

                }



                // Save the presentation before exiting (if any modifications were made)

                pres.Save("output.pptx", SaveFormat.Pptx);

            }

        }

        catch (NotSupportedException)

        {

            // Format not supported

        }

        catch (Exception ex)

        {

            // Handle other exceptions (e.g., file access issues)

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

