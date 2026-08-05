// -----------------------------------------------------------------------------
// Example: Save thumbnail to UNC share permission error using C#
//
// Description:
// Demonstrates how to save slide thumbnails to a UNC network share and handle
// permission errors using C# and Aspose.Slides for .NET. The example also shows
// how to save the modified presentation back to the same UNC share. It includes
// necessary checks for file existence, directory accessibility, and proper
// disposal of resources, making it suitable for automating PowerPoint workflows
// that involve network storage.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Save, Thumbnail, UNC, Share,
// Permission, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate saving slide thumbnails to a UNC network share with permission handling.
// - Build C# utilities for PowerPoint presentation processing on shared storage.
// - Generate or transform PPTX files and store results on network locations.
// - Validate and troubleshoot permission-related issues in presentation workflows.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ThumbnailExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path (first argument or default)
            string inputPath = args.Length > 0 ? args[0] : "sample.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // UNC network share folder for thumbnails
            string uncFolder = @"\\Server\Share\Thumbnails";

            // Ensure the UNC folder exists and is accessible
            try
            {
                if (!Directory.Exists(uncFolder))
                {
                    Directory.CreateDirectory(uncFolder);
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Access denied to network share: " + uncFolder);
                return;
            }

            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Iterate through slides and save thumbnails
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                ISlide slide = presentation.Slides[i];
                IImage slideImage = slide.GetImage(1f, 1f);
                string thumbnailPath = Path.Combine(uncFolder, $"Slide_{i + 1}.png");

                try
                {
                    slideImage.Save(thumbnailPath, Aspose.Slides.ImageFormat.Png);
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("Access denied when saving thumbnail: " + thumbnailPath);
                }
                catch (NotSupportedException)
                {
                    // Format not supported comment
                    Console.WriteLine("Image format not supported for: " + thumbnailPath);
                }
                finally
                {
                    slideImage.Dispose();
                }
            }

            // Save the presentation back to the network share
            string presentationOutputPath = Path.Combine(uncFolder, "output.pptx");
            try
            {
                presentation.Save(presentationOutputPath, SaveFormat.Pptx);
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Access denied when saving presentation: " + presentationOutputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported comment
                Console.WriteLine("Presentation format not supported for: " + presentationOutputPath);
            }

            // Dispose the presentation before exit
            presentation.Dispose();
        }
    }
}
