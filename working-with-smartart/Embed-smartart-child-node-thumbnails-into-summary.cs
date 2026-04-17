using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

public class Program
{
    public static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify input file existence
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Load the presentation
        Presentation pres = null;
        try
        {
            pres = new Presentation(inputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            return;
        }

        // Assume the first slide contains the SmartArt diagram
        ISlide sourceSlide = pres.Slides[0];
        ISmartArt smartArt = null;
        foreach (IShape shape in sourceSlide.Shapes)
        {
            if (shape is ISmartArt)
            {
                smartArt = (ISmartArt)shape;
                break;
            }
        }

        if (smartArt == null)
        {
            Console.WriteLine("No SmartArt diagram found on the first slide.");
            // Save the (unchanged) presentation before exit
            try
            {
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }
            return;
        }

        // Create a summary slide to hold thumbnails
        ISlide summarySlide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.TitleOnly));

        // Positioning variables for thumbnails
        float posX = 50f;
        float posY = 50f;
        float offsetX = 120f; // horizontal spacing between thumbnails

        // Iterate through all SmartArt nodes
        foreach (ISmartArtNode node in smartArt.AllNodes)
        {
            if (node.Shapes.Count == 0)
                continue;

            // Use the first shape of the node for thumbnail generation
            ISmartArtShape nodeShape = node.Shapes[0];

            // Calculate scaling factors to obtain a 100x100 pixel thumbnail
            float scaleX = 100f / nodeShape.Width;
            float scaleY = 100f / nodeShape.Height;

            // Generate the thumbnail image
            IImage thumb = null;
            try
            {
                thumb = nodeShape.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, scaleX, scaleY);
            }
            catch (Exception ex)
            {
                // Handle cases where thumbnail generation fails (e.g., unsupported format)
                Console.WriteLine("Thumbnail generation failed: " + ex.Message);
                continue;
            }

            // Add the thumbnail as a picture frame on the summary slide
            IPPImage ppImg = pres.Images.AddImage(thumb);
            summarySlide.Shapes.AddPictureFrame(
                ShapeType.Rectangle,
                posX,
                posY,
                ppImg.Width,
                ppImg.Height,
                ppImg);

            // Update position for the next thumbnail
            posX += offsetX;
        }

        // Save the modified presentation
        try
        {
            pres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to save presentation: " + ex.Message);
        }
    }
}