// -----------------------------------------------------------------------------
// Example: Generate SmartArt child node thumbnails and embed summary slide using C#
//
// Description:
// Demonstrates how to iterate through SmartArt child nodes, create 100x100
// thumbnail images for each node's primary shape, and place those thumbnails
// on a separate summary slide. The example uses Aspose.Slides for .NET to
// create a presentation, add SmartArt, generate shape thumbnails, and save the
// result as a PPTX file.
//
// Keywords:
// C#, Aspose.Slides, SmartArt, Thumbnail, Summary Slide, Presentation Automation,
// PowerPoint, PPTX, Image Generation, .NET
//
// Use Cases:
// - Automate creation of summary slides with visual thumbnails of SmartArt nodes.
// - Build tools that extract and display SmartArt content as images.
// - Generate compact visual overviews of complex SmartArt diagrams.
// - Integrate SmartArt thumbnail generation into .NET PowerPoint processing pipelines.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Add SmartArt to the first slide
            Aspose.Slides.ISlide slide0 = pres.Slides[0];
            Aspose.Slides.SmartArt.ISmartArt smartArt = slide0.Shapes.AddSmartArt(
                20f, 20f, 400f, 300f, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

            // Ensure there is a second (summary) slide
            if (pres.Slides.Count == 1)
            {
                pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank));
            }
            Aspose.Slides.ISlide summarySlide = pres.Slides[1];

            int nodeIndex = 0;
            int cols = 5;
            int spacing = 10;

            // Iterate through SmartArt child nodes
            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smartArt.AllNodes)
            {
                if (node.Shapes.Count > 0)
                {
                    // Get the first shape of the node
                    Aspose.Slides.IShape shape = node.Shapes[0];

                    // Calculate scaling factors to obtain a 100x100 thumbnail
                    float scaleX = 100f / shape.Width;
                    float scaleY = 100f / shape.Height;

                    // Generate thumbnail image for the shape
                    Aspose.Slides.IImage shapeImage = shape.GetImage(
                        Aspose.Slides.ShapeThumbnailBounds.Shape, scaleX, scaleY);

                    // Add the thumbnail image to the presentation's image collection
                    Aspose.Slides.IPPImage ppImg = pres.Images.AddImage(shapeImage);

                    // Position the thumbnail on the summary slide
                    int x = (nodeIndex % cols) * (100 + spacing);
                    int y = (nodeIndex / cols) * (100 + spacing);
                    summarySlide.Shapes.AddPictureFrame(
                        Aspose.Slides.ShapeType.Rectangle, x, y, 100f, 100f, ppImg);

                    nodeIndex++;
                }
            }

            // Save the presentation
            string outputPath = "SmartArtThumbnails.pptx";
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle any errors (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
