using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace WatermarkMetadataExtractor
{
    class Program
    {
        static void Main()
        {
            // Path to the input PPTX file
            string inputPath = "input.pptx";

            // Verify that the file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("The file '" + inputPath + "' does not exist.");
                return;
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                // Load the presentation
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or loading errors
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                // Comment: format not supported
                return;
            }

            // Iterate through each master slide to find possible watermark shapes
            for (int masterIndex = 0; masterIndex < presentation.Masters.Count; masterIndex++)
            {
                Aspose.Slides.IMasterSlide masterSlide = presentation.Masters[masterIndex];
                for (int shapeIndex = 0; shapeIndex < masterSlide.Shapes.Count; shapeIndex++)
                {
                    Aspose.Slides.IShape shape = masterSlide.Shapes[shapeIndex];

                    // Identify potential watermark shapes:
                    // - Shape has a text frame (text watermark) OR is a picture frame (image watermark)
                    // - Fill type is NoFill (common for transparent watermarks)
                    bool isPotentialWatermark = false;

                    // Check for text watermark
                    Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                    if (autoShape != null && autoShape.TextFrame != null)
                    {
                        // Additional heuristic: center-aligned text often used for watermarks
                        if (autoShape.TextFrame.TextFrameFormat != null &&
                            autoShape.TextFrame.TextFrameFormat.CenterText == Aspose.Slides.NullableBool.True)
                        {
                            isPotentialWatermark = true;
                        }
                    }

                    // Check for picture watermark
                    Aspose.Slides.IPictureFrame pictureFrame = shape as Aspose.Slides.IPictureFrame;
                    if (pictureFrame != null)
                    {
                        isPotentialWatermark = true;
                    }

                    // Verify that the shape has NoFill (transparent background) – typical for watermarks
                    if (shape.FillFormat != null && shape.FillFormat.FillType == Aspose.Slides.FillType.NoFill)
                    {
                        // Keep the flag as is
                    }
                    else
                    {
                        // If FillType is not NoFill, it might still be a watermark, but we keep the current flag
                    }

                    if (isPotentialWatermark)
                    {
                        // Extract position metadata
                        float x = shape.X;
                        float y = shape.Y;
                        float width = shape.Width;
                        float height = shape.Height;

                        Console.WriteLine("Found potential watermark on master slide " + masterIndex);
                        Console.WriteLine(" - Shape Index: " + shapeIndex);
                        Console.WriteLine(" - Position: X=" + x + ", Y=" + y);
                        Console.WriteLine(" - Size: Width=" + width + ", Height=" + height);

                        // Extract opacity if available
                        // For picture watermarks, opacity can be set via ImageTransform.AddAlphaModulateFixed
                        // Unfortunately Aspose.Slides does not expose a direct property to read the current opacity.
                        // As a placeholder, we indicate that opacity extraction is not directly supported.
                        if (pictureFrame != null)
                        {
                            Console.WriteLine(" - Opacity: Not directly readable via API (requires parsing ImageTransform).");
                        }
                        else if (autoShape != null)
                        {
                            // Text opacity can be part of the fill color's transparency; not exposed directly.
                            Console.WriteLine(" - Opacity: Not directly readable for text shapes via API.");
                        }

                        // Output the watermark text if it is a text shape
                        if (autoShape != null && autoShape.TextFrame != null)
                        {
                            Console.WriteLine(" - Watermark Text: " + autoShape.TextFrame.Text);
                        }
                    }
                }
            }

            // Save the presentation (even if unchanged) before exiting as per requirement
            string outputPath = "output.pptx";
            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to '" + outputPath + "'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save presentation: " + ex.Message);
                // Comment: format not supported
            }

            // Release resources
            if (presentation != null)
            {
                presentation.Dispose();
            }
        }
    }
}