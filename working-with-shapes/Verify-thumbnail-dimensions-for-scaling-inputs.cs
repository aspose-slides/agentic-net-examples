using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ThumbnailUnitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the input presentation
            string inputPath = "sample.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation inside a using block to ensure disposal
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Get the first slide for testing
                ISlide slide = presentation.Slides[0];

                // Retrieve original slide dimensions (in points)
                ISlideSize slideSize = presentation.SlideSize;
                SizeF originalSize = slideSize.Size; // SizeF is from System.Drawing

                // Define test scaling factors
                float[] scaleFactorsX = new float[] { 1f, 2f, 0.5f };
                float[] scaleFactorsY = new float[] { 1f, 2f, 0.5f };

                // Iterate over scaling inputs and verify thumbnail dimensions
                for (int i = 0; i < scaleFactorsX.Length; i++)
                {
                    float scaleX = scaleFactorsX[i];
                    float scaleY = scaleFactorsY[i];

                    // Generate thumbnail image with custom scaling
                    using (IImage thumbnail = slide.GetImage(scaleX, scaleY))
                    {
                        // Expected dimensions (rounded to nearest integer)
                        int expectedWidth = (int)Math.Round(originalSize.Width * scaleX);
                        int expectedHeight = (int)Math.Round(originalSize.Height * scaleY);

                        // Actual dimensions from the generated image
                        int actualWidth = thumbnail.Width;
                        int actualHeight = thumbnail.Height;

                        // Simple assertions
                        if (actualWidth != expectedWidth || actualHeight != expectedHeight)
                        {
                            Console.WriteLine($"Test failed for scaleX={scaleX}, scaleY={scaleY}: Expected ({expectedWidth}x{expectedHeight}), Got ({actualWidth}x{actualHeight})");
                        }
                        else
                        {
                            Console.WriteLine($"Test passed for scaleX={scaleX}, scaleY={scaleY}: Dimensions ({actualWidth}x{actualHeight})");
                        }
                    }
                }

                // Save the presentation before exiting (no modifications made)
                try
                {
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                    // Comment: format not supported
                }
                catch (Exception ex)
                {
                    // Handle unexpected exceptions (e.g., external resources)
                    Console.WriteLine("An error occurred while saving: " + ex.Message);
                }
            }
        }
    }
}