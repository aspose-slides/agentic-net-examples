// -----------------------------------------------------------------------------
// Example: Convert SVG picture frames to PNG using C#
//
// Description:
// Demonstrates how to locate SVG picture frames in a PowerPoint presentation,
// convert each SVG to a raster PNG image (via EMF intermediate) using 
// Aspose.Slides for .NET, and save the updated presentation. The example shows 
// the required presentation‑processing steps for PPTX files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SVG, PNG, Convert, Picture, 
// Frames, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate conversion of SVG picture frames to PNG in presentations.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertSvgPictureFramesToPng
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Override with command‑line arguments if provided
            if (args.Length >= 2)
            {
                inputPath = args[0];
                outputPath = args[1];
            }

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        ISlide slide = pres.Slides[slideIndex];

                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            IShape shape = slide.Shapes[shapeIndex];

                            // Process only picture frames
                            IPictureFrame pictureFrame = shape as IPictureFrame;
                            if (pictureFrame == null)
                            {
                                continue;
                            }

                            // Get the embedded image via the correct property chain
                            IPPImage embeddedImage = pictureFrame.PictureFormat.Picture.Image;

                            // Check if the image is an SVG
                            if (embeddedImage.SvgImage != null)
                            {
                                // Convert the SVG to EMF (vector metafile)
                                using (MemoryStream emfStream = new MemoryStream())
                                {
                                    embeddedImage.SvgImage.WriteAsEmf(emfStream);
                                    emfStream.Position = 0;

                                    // Add the EMF image to the presentation; this will rasterize it to PNG internally
                                    IPPImage rasterImage = pres.Images.AddImage(emfStream);

                                    // Replace the original SVG image with the rasterized PNG image
                                    pictureFrame.PictureFormat.Picture.Image = rasterImage;
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
