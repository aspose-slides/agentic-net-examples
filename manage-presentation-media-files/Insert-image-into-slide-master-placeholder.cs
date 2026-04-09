using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths for input presentation, image, and output presentation
        string inputPath = "template.pptx";
        string imagePath = "image.jpg";
        string outputPath = "output.pptx";

        // Verify that input files exist
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input presentation not found.");
            return;
        }
        if (!File.Exists(imagePath))
        {
            Console.WriteLine("Image file not found.");
            return;
        }

        try
        {
            // Load the source presentation
            Presentation pres = new Presentation(inputPath);

            // Get the first master slide
            IMasterSlide master = pres.Masters[0];

            // Get a blank layout slide from the master
            ILayoutSlide layout = master.LayoutSlides.GetByType(SlideLayoutType.Blank);

            // Add a picture placeholder to the layout slide
            IAutoShape placeholder = layout.PlaceholderManager.AddPicturePlaceholder(50, 50, 400, 300);

            // Load image data and add it to the presentation's image collection
            byte[] imageData = File.ReadAllBytes(imagePath);
            IPPImage img = pres.Images.AddImage(imageData);

            // Set the placeholder's fill to the image (updates all linked slides)
            placeholder.FillFormat.PictureFillFormat.Picture.Image = img;

            // Save the updated presentation
            pres.Save(outputPath, SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}