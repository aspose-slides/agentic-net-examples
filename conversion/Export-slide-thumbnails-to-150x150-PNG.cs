// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export slide thumbnails to 150x150 PNG using C#

//

// Description:

// Demonstrates how to export each slide of a PowerPoint presentation as a

// 150x150 PNG thumbnail using Aspose.Slides for .NET. The example loads a PPTX

// file, iterates through its slides, creates a thumbnail image of the specified

// size, and saves each thumbnail as a separate PNG file. It also includes basic

// error handling for missing input files and unsupported formats.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Export, Slide, Thumbnails,

// 150x150, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate generation of slide preview images for web galleries.

// - Build tools that create low‑resolution thumbnails for quick browsing.

// - Integrate slide thumbnail extraction into .NET applications.

// - Validate presentation content by visual inspection of generated images.

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

        // Path to the input presentation

        string inputPath = "input.pptx";



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Load the presentation

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



            // Iterate through each slide and export a 150x150 PNG thumbnail

            foreach (Aspose.Slides.ISlide slide in presentation.Slides)

            {

                // Create a thumbnail with the desired size

                using (Aspose.Slides.IImage thumbnail = slide.GetImage(new Size(150, 150)))

                {

                    // Build the output file name

                    string imageFileName = string.Format("Slide_{0}.png", slide.SlideNumber);



                    // Save the thumbnail as PNG

                    thumbnail.Save(imageFileName, Aspose.Slides.ImageFormat.Png);

                }

            }



            // Optionally, save the presentation (no changes made)

            // presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

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

