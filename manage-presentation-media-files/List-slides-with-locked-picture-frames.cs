// -----------------------------------------------------------------------------
// Example: List slides with locked picture frames using C#
//
// Description:
// Demonstrates how to enumerate slides in a PowerPoint presentation and
// identify those that contain picture frames with a locked aspect ratio using
// Aspose.Slides for .NET. The example loads a PPTX file, checks each shape on
// every slide, reports slides that meet the criteria, and saves the presentation.
// This pattern can be used to automate validation or processing of PPTX files
// where picture frame aspect ratios must be preserved.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, List Slides, Locked Aspect Ratio,
// Picture Frame, Presentation Processing, Office Automation
//
// Use Cases:
// - Detect slides containing picture frames with locked aspect ratios.
// - Build validation tools for PowerPoint presentations in .NET.
// - Automate reporting of specific shape properties across slides.
// - Integrate aspect‑ratio checks into larger PPTX processing pipelines.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DetectLockedAspectRatio
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Aspose.Slides.Presentation pres = null;
            try
            {
                // Load the presentation
                pres = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or loading errors
                // Format not supported
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            try
            {
                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = pres.Slides[slideIndex];
                    bool hasLockedAspectRatio = false;

                    // Examine each shape on the slide
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        // Check if the shape is a picture frame
                        if (shape is Aspose.Slides.IPictureFrame pictureFrame)
                        {
                            // Check if the picture frame's aspect ratio is locked
                            if (pictureFrame.ShapeLock != null && pictureFrame.ShapeLock.AspectRatioLocked)
                            {
                                hasLockedAspectRatio = true;
                                break; // No need to check further shapes on this slide
                            }
                        }
                    }

                    // Output slide number if it contains locked picture frames
                    if (hasLockedAspectRatio)
                    {
                        Console.WriteLine("Slide " + (slideIndex + 1) + " contains picture frame(s) with locked aspect ratio.");
                    }
                }

                // Save the (potentially unchanged) presentation before exiting
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            finally
            {
                // Ensure resources are released
                if (pres != null)
                {
                    pres.Dispose();
                }
            }
        }
    }
}
