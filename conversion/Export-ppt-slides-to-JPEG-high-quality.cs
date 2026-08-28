// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPT slides to high‑quality JPEG images using C#

//

// Description:

// Demonstrates how to export each slide of a PowerPoint presentation to a

// high‑resolution JPEG image using C# and Aspose.Slides for .NET. The example

// loads a PPTX file, creates an output folder, renders each slide at double

// scale for improved image quality, and saves the results as JPEG files.

// This pattern can be used to automate PPTX workflows, generate image assets,

// or integrate presentation processing into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, JPEG, Export, Slides, High‑Quality,

// Image, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate export of PPT slides to high‑quality JPEG images.

// - Build C# tools for PowerPoint presentation image extraction.

// - Generate or transform PPTX files into image assets in .NET applications.

// - Validate presentation rendering before publishing or integration.

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

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            Presentation presentation = new Presentation(inputPath);

            string outputDir = "output_images";

            if (!Directory.Exists(outputDir))

            {

                Directory.CreateDirectory(outputDir);

            }



            // Export each slide at double scale (200%) for higher JPEG quality

            for (int i = 0; i < presentation.Slides.Count; i++)

            {

                ISlide slide = presentation.Slides[i];

                IImage image = slide.GetImage(2f, 2f);

                string outPath = Path.Combine(outputDir, $"Slide_{i + 1}.jpg");

                image.Save(outPath, ImageFormat.Jpeg);

                image.Dispose();

            }



            // Save presentation before exit (no modifications made)

            presentation.Save(inputPath, SaveFormat.Pptx);

            presentation.Dispose();

        }

        catch (NotSupportedException)

        {

            // Format not supported

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

