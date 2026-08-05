// -----------------------------------------------------------------------------
// Example: Log thumbnail generation start and end using C#
//
// Description:
// Demonstrates how to generate JPEG thumbnails for each slide in a PowerPoint
// presentation while logging the processing time for each slide and the total
// operation using C# and Aspose.Slides for .NET. The example loads a PPTX file,
// creates scaled images of slides, saves them, and records timing information
// to the console.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Thumbnail, Generation, Start, End, Logging, Slide Processing, Presentation Automation
//
// Use Cases:
// - Measure and log performance of slide thumbnail generation.
// - Automate creation of slide preview images in .NET applications.
// - Integrate timing diagnostics into PowerPoint processing workflows.
// - Validate and benchmark presentation processing before deployment.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using System.Diagnostics;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output paths
        string inputPath = "input.pptx";
        string outputPresentationPath = "output.pptx";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Define scaling factors
            int scaleX = 1;
            int scaleY = scaleX;

            // Define output file name format for thumbnails
            string fileNameFormat = "Slide_{0}.jpg";

            // Start total processing timer
            Stopwatch totalTimer = new Stopwatch();
            totalTimer.Start();

            // Iterate through each slide and generate thumbnail
            foreach (Aspose.Slides.ISlide slide in presentation.Slides)
            {
                // Start timer for individual slide
                Stopwatch slideTimer = new Stopwatch();
                slideTimer.Start();

                using (Aspose.Slides.IImage thumbnail = slide.GetImage(scaleX, scaleY))
                {
                    string imageFileName = string.Format(fileNameFormat, slide.SlideNumber);
                    thumbnail.Save(imageFileName, Aspose.Slides.ImageFormat.Jpeg);
                }

                // Stop timer and log duration
                slideTimer.Stop();
                Console.WriteLine($"Slide {slide.SlideNumber} processed in {slideTimer.ElapsedMilliseconds} ms.");
            }

            // Stop total timer and log overall duration
            totalTimer.Stop();
            Console.WriteLine($"Total thumbnail generation time: {totalTimer.ElapsedMilliseconds} ms.");

            // Save the (unchanged) presentation before exit
            presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
