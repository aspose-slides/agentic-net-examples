using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string thumbnailPath = "node_thumbnail.jpg";
            string reportPath = "ReportPresentation.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the source presentation
                using (Presentation sourcePres = new Presentation(inputPath))
                {
                    // Access the first slide
                    ISlide sourceSlide = sourcePres.Slides[0];

                    // Add a SmartArt diagram to the slide
                    ISmartArt smartArt = sourceSlide.Shapes.AddSmartArt(50f, 50f, 400f, 300f, SmartArtLayoutType.BasicBlockList);

                    // Ensure there is at least one root node
                    if (smartArt.Nodes.Count > 0)
                    {
                        // Get the first root node
                        ISmartArtNode rootNode = smartArt.Nodes[0];

                        // Ensure the root node has at least one child node
                        ISmartArtNode targetNode = rootNode;
                        if (rootNode.ChildNodes.Count > 0)
                        {
                            targetNode = rootNode.ChildNodes[0];
                        }

                        // Ensure the target node has at least one associated shape
                        if (targetNode.Shapes.Count > 0)
                        {
                            // Get the first shape of the node
                            IShape nodeShape = targetNode.Shapes[0];

                            // Generate a thumbnail image of the shape
                            IImage nodeImage = nodeShape.GetImage();

                            // Save the thumbnail to disk
                            nodeImage.Save(thumbnailPath, ImageFormat.Jpeg);
                        }
                    }

                    // Save the source presentation (required before exit)
                    sourcePres.Save("SourcePresentation_saved.pptx", SaveFormat.Pptx);
                }

                // Create a new presentation to act as the report document
                using (Presentation reportPres = new Presentation())
                {
                    // Access the first slide of the report
                    ISlide reportSlide = reportPres.Slides[0];

                    // Load the previously saved thumbnail image
                    using (FileStream imgStream = new FileStream(thumbnailPath, FileMode.Open, FileAccess.Read))
                    {
                        // Add the image as a picture frame to the report slide
                        reportSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 100f, 100f, 300f, 200f, reportPres.Images.AddImage(imgStream));
                    }

                    // Save the report presentation
                    reportPres.Save(reportPath, SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                // Format not supported
                Console.WriteLine("Unsupported file format: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}