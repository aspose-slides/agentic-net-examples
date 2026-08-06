// -----------------------------------------------------------------------------
// Example: Create thumbnail with index watermark PNG using C#
//
// Description:
// Demonstrates how to generate PNG thumbnails for each SmartArt node in a
// presentation, overlaying an index watermark on the node shape using
// Aspose.Slides for .NET. The example loads a PPTX, finds the first SmartArt,
// adds a transparent rectangle with the node index as text, creates a thumbnail
// image of the node, and saves the images as PNG files while preserving the
// modified presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SmartArt, PNG, Thumbnail,
// Index, Watermark, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate creation of indexed thumbnails for SmartArt nodes.
// - Build C# tools for PowerPoint SmartArt processing and visualization.
// - Generate PNG assets from PPTX presentations for documentation or web use.
// - Validate and enhance SmartArt layouts programmatically.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPresentationPath = "output.pptx";

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found.");
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                // Find the first SmartArt shape on the first slide
                Aspose.Slides.SmartArt.SmartArt smartArt = null;
                foreach (Aspose.Slides.IShape shape in pres.Slides[0].Shapes)
                {
                    if (shape is Aspose.Slides.SmartArt.SmartArt)
                    {
                        smartArt = (Aspose.Slides.SmartArt.SmartArt)shape;
                        break;
                    }
                }

                if (smartArt == null)
                {
                    Console.WriteLine("No SmartArt found in the presentation.");
                }
                else
                {
                    int nodeIndex = 0;
                    // Iterate through all child nodes of the SmartArt
                    foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smartArt.AllNodes)
                    {
                        // Ensure the node has at least one associated shape
                        if (node.Shapes.Count > 0)
                        {
                            // Get the first shape of the node
                            Aspose.Slides.SmartArt.ISmartArtShape nodeShape = node.Shapes[0];

                            // Add a rectangle shape as a watermark overlay
                            Aspose.Slides.IAutoShape watermark = pres.Slides[0].Shapes.AddAutoShape(
                                Aspose.Slides.ShapeType.Rectangle,
                                nodeShape.X,
                                nodeShape.Y,
                                nodeShape.Width,
                                nodeShape.Height);

                            // Add the node index as text
                            watermark.AddTextFrame(nodeIndex.ToString());

                            // Center the text
                            watermark.TextFrame.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;

                            // Make the watermark shape transparent
                            watermark.FillFormat.FillType = Aspose.Slides.FillType.NoFill;
                            watermark.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.NoFill;

                            // Generate thumbnail of the node shape
                            Aspose.Slides.IImage nodeImage = nodeShape.GetImage(
                                Aspose.Slides.ShapeThumbnailBounds.Shape,
                                1f,
                                1f);

                            // Save the thumbnail as PNG
                            string pngPath = $"Node_{nodeIndex}.png";
                            nodeImage.Save(pngPath, Aspose.Slides.ImageFormat.Png);
                        }

                        nodeIndex++;
                    }
                }

                // Save the modified presentation
                pres.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
