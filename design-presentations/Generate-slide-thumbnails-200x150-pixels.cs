// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Generate slide thumbnails 200x150 pixels using C#

//

// Description:

// Demonstrates how to generate 200x150 pixel JPEG thumbnails for each slide

// in a PowerPoint presentation using C# and Aspose.Slides for .NET. The

// example loads a PPTX file, creates a thumbnail image for every slide with

// the specified dimensions, saves the images to a folder, and finally saves

// the (unchanged) presentation. This pattern can be used to automate PPTX

// workflows, create preview images, or integrate slide rendering into .NET

// applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Generate, Slide, Thumbnails,

// 200X150, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate generation of slide thumbnails sized 200x150 pixels.

// - Build C# tools for PowerPoint presentation preview creation.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using System.Drawing;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Input presentation path

        string inputPath = "input.pptx";

        // Output folder for thumbnails

        string outputFolder = "Thumbnails";



        // Verify input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        // Ensure output directory exists

        if (!Directory.Exists(outputFolder))

        {

            Directory.CreateDirectory(outputFolder);

        }



        try

        {

            // Load the presentation

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



            // Desired thumbnail dimensions

            System.Drawing.Size thumbnailSize = new System.Drawing.Size(200, 150);



            // Generate thumbnail for each slide

            for (int index = 0; index < presentation.Slides.Count; index++)

            {

                Aspose.Slides.ISlide slide = presentation.Slides[index];

                using (Aspose.Slides.IImage image = slide.GetImage(thumbnailSize))

                {

                    string outputPath = Path.Combine(outputFolder, $"Slide_{index + 1}.jpg");

                    image.Save(outputPath, Aspose.Slides.ImageFormat.Jpeg);

                }

            }



            // Save presentation before exit (no modifications made)

            presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);

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

