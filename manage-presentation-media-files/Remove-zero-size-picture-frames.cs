// -----------------------------------------------------------------------------
// Example: Remove zero size picture frames using C#
//
// Description:
// Demonstrates how to remove picture frames that have zero width or height 
// from a PowerPoint presentation using C# and Aspose.Slides for .NET. The 
// example loads a PPTX file, scans each slide for picture frames, removes any 
// with zero dimensions, and saves the cleaned presentation. This pattern can 
// be used to clean up malformed presentations before further processing.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Remove, Zero, Size, Picture, 
// Frame, Presentation Processing, Office Automation
//
// Use Cases:
// - Clean up presentations by removing invalid picture frames.
// - Prepare PPTX files for publishing or conversion.
// - Automate validation of slide content in .NET applications.
// - Integrate presentation sanitization into CI pipelines.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveZeroSizePictureFrames
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (var presentation = new Presentation(inputPath))
                {
                    // Iterate through each slide
                    foreach (var slide in presentation.Slides)
                    {
                        // Iterate backwards through shapes to allow removal
                        for (int i = slide.Shapes.Count - 1; i >= 0; i--)
                        {
                            var shape = slide.Shapes[i];
                            // Check if the shape is a picture frame
                            if (shape is IPictureFrame pictureFrame)
                            {
                                // Remove picture frames with zero width or height
                                if (pictureFrame.Width == 0 || pictureFrame.Height == 0)
                                {
                                    slide.Shapes.RemoveAt(i);
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported
                // (Add specific handling if needed)
            }
        }
    }
}
