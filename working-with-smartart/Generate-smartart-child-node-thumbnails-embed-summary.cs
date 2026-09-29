// -----------------------------------------------------------------------------
// Example: Generate SmartArt Child Node Thumbnails and Summary Slide
//
// Description:
// This console application creates a PowerPoint presentation using Aspose.Slides for .NET,
// adds a SmartArt diagram, extracts thumbnails of each SmartArt child node's primary shape,
// and places those 100x100 thumbnails on a separate summary slide. The resulting PPTX file
// is saved to disk. The example demonstrates shape thumbnail generation, image handling,
// and dynamic slide composition.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SmartArt, shape thumbnail, summary slide
//
// Use Cases:
// - Automatically generate overview slides with visual thumbnails of diagram elements.
// - Create presentation assets for reporting tools that need compact visual summaries.
// - Build custom PowerPoint reports that include extracted SmartArt node images.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace AsposeSlidesSmartArtThumbnailExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = "SmartArtSummary.pptx";

            try
            {
                // Ensure the output directory exists
                string outputDirectory = Path.GetDirectoryName(Path.GetFullPath(outputPath));
                if (!Directory.Exists(outputDirectory))
                {
                    Directory.CreateDirectory(outputDirectory);
                }

                // Create a new presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

                // Add SmartArt to the first slide
                Aspose.Slides.ISlide smartArtSlide = pres.Slides[0];
                Aspose.Slides.SmartArt.ISmartArt smartArt = smartArtSlide.Shapes.AddSmartArt(
                    20, 20, 600, 400,
                    Aspose.Slides.SmartArt.SmartArtLayoutType.OrganizationChart);

                // Add a summary slide
                Aspose.Slides.ISlide summarySlide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

                // Layout variables for thumbnails
                int columns = 5;
                int currentColumn = 0;
                int currentRow = 0;
                float thumbnailWidth = 100f;
                float thumbnailHeight = 100f;
                float startX = 20f;
                float startY = 20f;
                float spacingX = 110f; // width + 10px gap
                float spacingY = 110f; // height + 10px gap

                // Iterate through all SmartArt nodes
                foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smartArt.AllNodes)
                {
                    // Get the primary shape of the node (first shape)
                    if (node.Shapes.Count == 0)
                    {
                        continue; // Skip nodes without shapes
                    }

                    Aspose.Slides.SmartArt.ISmartArtShape nodeShape = node.Shapes[0];

                    // Generate a thumbnail image of the shape
                    Aspose.Slides.IImage shapeImage = nodeShape.GetImage(
                        Aspose.Slides.ShapeThumbnailBounds.Shape,
                        1f, // scaleX
                        1f  // scaleY
                    );

                    // Add the image to the presentation's image collection
                    Aspose.Slides.IPPImage ippImage = pres.Images.AddImage(shapeImage);

                    // Calculate position for the thumbnail on the summary slide
                    float posX = startX + currentColumn * spacingX;
                    float posY = startY + currentRow * spacingY;

                    // Add the thumbnail as a picture frame
                    Aspose.Slides.IPictureFrame pictureFrame = summarySlide.Shapes.AddPictureFrame(
                        Aspose.Slides.ShapeType.Rectangle,
                        posX,
                        posY,
                        thumbnailWidth,
                        thumbnailHeight,
                        ippImage
                    );

                    // Update column/row counters
                    currentColumn++;
                    if (currentColumn >= columns)
                    {
                        currentColumn = 0;
                        currentRow++;
                    }
                }

                // Save the presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + Path.GetFullPath(outputPath));
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
