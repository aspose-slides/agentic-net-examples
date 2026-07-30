// -----------------------------------------------------------------------------
// Example: Resize picture frame images to max 800px using C#
//
// Description:
// Demonstrates how to resize picture frame images in a PowerPoint presentation
// so that their width does not exceed 800 pixels. The example loads a PPTX file,
// iterates through all slides and picture frames, scales down any image whose
// width is larger than 800px while preserving the aspect ratio, and saves the
// modified presentation. This pattern can be used to enforce size limits on
// embedded images during automated PPTX processing with Aspose.Slides for .NET.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Resize, Picture Frame, Images, 
// Presentation Processing, Office Automation, Image Scaling
//
// Use Cases:
// - Ensure embedded images in presentations meet size constraints for
//   performance or layout consistency.
// - Build automated tools that preprocess PPTX files before publishing.
// - Integrate image‑size validation into CI pipelines for presentation assets.
// - Create batch scripts that adjust image dimensions across multiple slides.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ImageResizeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Iterate through all slides and shapes
                foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                {
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        // Process only picture frames (embedded images)
                        if (shape is Aspose.Slides.IPictureFrame)
                        {
                            Aspose.Slides.IPictureFrame picture = (Aspose.Slides.IPictureFrame)shape;
                            float originalWidth = picture.Width;

                            // Resize if width exceeds 800 pixels
                            if (originalWidth > 800f)
                            {
                                float scaleFactor = 800f / originalWidth;
                                picture.Width = 800f;
                                picture.Height = picture.Height * scaleFactor;
                            }
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported for this operation.
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
