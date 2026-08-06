// -----------------------------------------------------------------------------
// Example: Generate smartart child node thumbnails 100x100 embed using C#
//
// Description:
// Demonstrates how to generate 100x100 pixel thumbnails for each SmartArt
// child node shape, embed those thumbnails into a summary slide, and save the
// resulting presentation using Aspose.Slides for .NET. The example loads an
// existing PPTX, extracts SmartArt node shapes, creates scaled thumbnails, and
// arranges them in a grid on a new slide.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Generate, SmartArt, Child,
// Node, Thumbnail, Embed, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate generation of SmartArt child node thumbnails and embed them in a
//   summary slide.
// - Build C# tools for PowerPoint presentation analysis and reporting.
// - Create visual overviews of SmartArt content in .NET applications.
// - Validate and transform PPTX files with embedded graphics.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ThumbnailSmartArtExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load presentation
                Presentation pres = new Presentation(inputPath);

                // Create a summary slide at the end
                ISlide summarySlide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.TitleOnly));

                // Positioning variables for thumbnails on the summary slide
                float startX = 20f;
                float startY = 100f;
                float offsetX = 110f; // thumbnail width + spacing
                float offsetY = 110f; // thumbnail height + spacing
                int columns = 5;
                int currentColumn = 0;
                int currentRow = 0;

                // Iterate through all slides to find SmartArt shapes
                foreach (ISlide slide in pres.Slides)
                {
                    foreach (IShape shape in slide.Shapes)
                    {
                        // Check if the shape is a SmartArt diagram
                        if (shape is Aspose.Slides.SmartArt.ISmartArt)
                        {
                            Aspose.Slides.SmartArt.ISmartArt smartArt = (Aspose.Slides.SmartArt.ISmartArt)shape;

                            // Iterate through all nodes of the SmartArt
                            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smartArt.AllNodes)
                            {
                                // Each node may contain multiple shapes; generate thumbnail for each
                                foreach (IShape nodeShape in node.Shapes)
                                {
                                    // Calculate scaling factors to obtain a 100x100 pixel thumbnail
                                    float scaleX = 100f / nodeShape.Width;
                                    float scaleY = 100f / nodeShape.Height;

                                    // Generate thumbnail image for the shape
                                    IImage shapeImage = nodeShape.GetImage(ShapeThumbnailBounds.Shape, scaleX, scaleY);

                                    // Save thumbnail to a memory stream in PNG format
                                    using (MemoryStream ms = new MemoryStream())
                                    {
                                        shapeImage.Save(ms, Aspose.Slides.ImageFormat.Png);
                                        ms.Position = 0;

                                        // Add the image to the presentation's image collection
                                        IPPImage ppImg = pres.Images.AddImage(ms);

                                        // Calculate placement on the summary slide
                                        float posX = startX + (currentColumn * offsetX);
                                        float posY = startY + (currentRow * offsetY);

                                        // Add picture frame with the thumbnail
                                        summarySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, posX, posY, 100f, 100f, ppImg);
                                    }

                                    // Update grid position
                                    currentColumn++;
                                    if (currentColumn >= columns)
                                    {
                                        currentColumn = 0;
                                        currentRow++;
                                    }
                                }
                            }
                        }
                    }
                }

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
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
