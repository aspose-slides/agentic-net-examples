using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SmartArtThumbnailGenerator
{
    class Program
    {
        static void Main()
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                // Load the presentation
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
                Console.WriteLine("The presentation format is not supported.");
                return;
            }
            catch (Exception ex)
            {
                // Handle other loading exceptions
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }

            // Create a summary slide (empty slide based on the first slide's layout)
            Aspose.Slides.ISlide summarySlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

            // Positioning variables for placing thumbnails on the summary slide
            float startX = 20f;
            float startY = 20f;
            float offsetX = 110f; // 100px thumbnail + 10px gap
            float offsetY = 110f;
            int columns = 5; // Number of thumbnails per row
            int currentColumn = 0;
            int currentRow = 0;

            // Iterate through all slides to find SmartArt shapes
            foreach (Aspose.Slides.ISlide slide in presentation.Slides)
            {
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    // Identify SmartArt shapes
                    Aspose.Slides.SmartArt.ISmartArt smartArt = shape as Aspose.Slides.SmartArt.ISmartArt;
                    if (smartArt == null)
                    {
                        continue;
                    }

                    // Iterate through all nodes of the SmartArt
                    foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smartArt.AllNodes)
                    {
                        // Iterate through all shapes associated with the node (child shapes)
                        foreach (Aspose.Slides.SmartArt.ISmartArtShape smartShape in node.Shapes)
                        {
                            // Ensure the shape has valid dimensions
                            if (smartShape.Width <= 0 || smartShape.Height <= 0)
                            {
                                continue;
                            }

                            // Calculate scaling factors to obtain a 100x100 pixel thumbnail
                            float scaleX = 100f / smartShape.Width;
                            float scaleY = 100f / smartShape.Height;

                            // Generate the thumbnail image using the required overload
                            Aspose.Slides.IImage thumbnailImage = smartShape.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, scaleX, scaleY);

                            // Add the image to the presentation's image collection
                            Aspose.Slides.IPPImage pptxImage = presentation.Images.AddImage(thumbnailImage);

                            // Calculate position for the picture frame on the summary slide
                            float pictureX = startX + (currentColumn * offsetX);
                            float pictureY = startY + (currentRow * offsetY);

                            // Add a picture frame containing the thumbnail
                            Aspose.Slides.IPictureFrame pictureFrame = summarySlide.Shapes.AddPictureFrame(
                                Aspose.Slides.ShapeType.Rectangle,
                                pictureX,
                                pictureY,
                                pptxImage.Width,
                                pptxImage.Height,
                                pptxImage);

                            // Update column/row counters
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

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}