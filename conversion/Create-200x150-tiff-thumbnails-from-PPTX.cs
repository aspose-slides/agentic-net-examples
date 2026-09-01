// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Create 200x150 tiff thumbnails from PPTX using C#

//

// Description:

// Demonstrates how to create 200x150 tiff thumbnails from PPTX using C# and 

// Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, 200X150, Tiff, Thumbnails, 

// Pptx, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate create 200x150 tiff thumbnails from PPTX.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Input PPTX file path

        string inputPath = "input.pptx";

        // Output directory for thumbnails

        string outputDir = "Thumbnails";



        // Verify input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        // Ensure output directory exists

        Directory.CreateDirectory(outputDir);



        try

        {

            // Load presentation

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



            // Iterate through slides and generate 200x150 TIFF thumbnails

            for (int index = 0; index < presentation.Slides.Count; index++)

            {

                Aspose.Slides.ISlide slide = presentation.Slides[index];

                System.Drawing.Size thumbnailSize = new System.Drawing.Size(200, 150);

                using (Aspose.Slides.IImage image = slide.GetImage(thumbnailSize))

                {

                    string outputPath = Path.Combine(outputDir, $"Slide_{index + 1}.tiff");

                    image.Save(outputPath, Aspose.Slides.ImageFormat.Tiff);

                }

            }



            // Save presentation before exit (no modifications made)

            presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);

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

