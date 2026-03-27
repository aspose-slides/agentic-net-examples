using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        // Path to the folder containing images
        string inputFolder = "Images";
        // Output presentation file
        string outputPath = "PictureOrgChart.pptx";

        // Verify that the input folder exists
        if (!Directory.Exists(inputFolder))
        {
            Console.WriteLine("Input folder does not exist.");
            return;
        }

        // Create a new presentation
        Presentation presentation = new Presentation();

        // Add a blank slide to the presentation
        ISlide slide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

        // Add a Picture Organization Chart SmartArt diagram
        ISmartArt smartArt = slide.Shapes.AddSmartArt(50, 50, 600, 400, SmartArtLayoutType.PictureOrganizationChart);

        // Get all image files from the specified folder
        string[] imageFiles = Directory.GetFiles(inputFolder);
        int nodeIndex = 0;

        // Assign each image to a SmartArt node (if available)
        foreach (string imageFile in imageFiles)
        {
            if (nodeIndex >= smartArt.Nodes.Count)
                break;

            // Add the image to the presentation's image collection
            IPPImage img = presentation.Images.AddImage(File.ReadAllBytes(imageFile));

            // Retrieve the shape associated with the current node
            IShape nodeShape = smartArt.Nodes[nodeIndex].Shapes[0];

            // Set the shape's fill to the image
            nodeShape.FillFormat.FillType = FillType.Picture;
            nodeShape.FillFormat.PictureFillFormat.Picture.Image = img;

            nodeIndex++;
        }

        // Save the presentation
        presentation.Save(outputPath, SaveFormat.Pptx);
    }
}