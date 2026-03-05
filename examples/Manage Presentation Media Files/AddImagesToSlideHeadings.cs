using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddImagesToSlideHeadings
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define the data directory where images are stored and output will be saved
            string dataDir = "Data";
            if (!Directory.Exists(dataDir))
                Directory.CreateDirectory(dataDir);

            // Path to the local image file
            string imagePath = Path.Combine(dataDir, "image.jpg");

            // Create a new presentation
            Presentation pres = new Presentation();

            // Get the first slide (slide index 0)
            ISlide slide = pres.Slides[0];

            // Load the image from file and add it to the presentation's image collection
            IImage image = Images.FromFile(imagePath);
            IPPImage imgx = pres.Images.AddImage(image);

            // Add a picture frame at the top-left corner of the slide (acting as a heading image)
            // Width and height are taken from the added image to preserve its original size
            IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
                ShapeType.Rectangle,
                0f,               // X position
                0f,               // Y position
                imgx.Width,       // Width of the picture frame
                imgx.Height,      // Height of the picture frame
                imgx);

            // Optional: add a border around the picture frame
            pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
            pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Blue;
            pictureFrame.LineFormat.Width = 2f;

            // Save the presentation to the output file
            string outPath = Path.Combine(dataDir, "output.pptx");
            pres.Save(outPath, SaveFormat.Pptx);

            // Release resources
            pres.Dispose();
        }
    }
}