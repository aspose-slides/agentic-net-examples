// -----------------------------------------------------------------------------
// Example: Verify thumbnail dimensions for scaling inputs using C#
//
// Description:
// Demonstrates how to verify thumbnail dimensions for scaling inputs using C# 
// and Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Verify, Thumbnail, Dimensions, 
// Scaling, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate verify thumbnail dimensions for scaling inputs.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ThumbnailDimensionTests
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Path to the input presentation
            string inputPath = "Sample.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Ensure there is at least one slide
                    if (presentation.Slides.Count == 0)
                    {
                        Console.WriteLine("Presentation contains no slides.");
                        return;
                    }

                    // Access the first slide
                    ISlide slide = presentation.Slides[0];

                    // Original slide dimensions (in points)
                    float originalWidth = presentation.SlideSize.Size.Width;
                    float originalHeight = presentation.SlideSize.Size.Height;

                    // Define scaling factors to test
                    float[] scaleFactors = new float[] { 0.5f, 1.0f, 2.0f };

                    foreach (float scaleX in scaleFactors)
                    {
                        foreach (float scaleY in scaleFactors)
                        {
                            // Generate thumbnail with custom scaling
                            using (IImage thumbnail = slide.GetImage(scaleX, scaleY))
                            {
                                // Expected dimensions
                                int expectedWidth = (int)(originalWidth * scaleX);
                                int expectedHeight = (int)(originalHeight * scaleY);

                                // Actual dimensions
                                int actualWidth = thumbnail.Width;
                                int actualHeight = thumbnail.Height;

                                // Verify dimensions
                                if (actualWidth == expectedWidth && actualHeight == expectedHeight)
                                {
                                    Console.WriteLine($"PASS: ScaleX={scaleX}, ScaleY={scaleY} => Width={actualWidth}, Height={actualHeight}");
                                }
                                else
                                {
                                    Console.WriteLine($"FAIL: ScaleX={scaleX}, ScaleY={scaleY} => Expected ({expectedWidth}x{expectedHeight}), Got ({actualWidth}x{actualHeight})");
                                }

                                // Optionally save the thumbnail for manual inspection
                                string outputImagePath = $"Thumbnail_{scaleX}_{scaleY}.png";
                                thumbnail.Save(outputImagePath, Aspose.Slides.ImageFormat.Png);
                            }
                        }
                    }

                    // Save the presentation before exiting (as per lifecycle rule)
                    string outputPresentationPath = "ModifiedSample.pptx";
                    presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported by Aspose.Slides.
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., external URL or other I/O issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
