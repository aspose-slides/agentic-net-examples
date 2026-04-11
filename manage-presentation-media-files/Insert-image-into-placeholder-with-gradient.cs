using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Input image path and output presentation path
        string inputPath = "image.jpg";
        string outputPath = "output.pptx";

        // Verify that the input image file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input image file does not exist.");
            return;
        }

        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Get a blank layout slide from the presentation
            Aspose.Slides.ILayoutSlide layout = pres.LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);

            // Add a picture placeholder to the layout slide
            Aspose.Slides.IAutoShape placeholder = layout.PlaceholderManager.AddPicturePlaceholder(50f, 50f, 400f, 300f);

            // Apply a gradient fill to the placeholder background
            placeholder.FillFormat.FillType = Aspose.Slides.FillType.Gradient;
            placeholder.FillFormat.GradientFormat.TileFlip = Aspose.Slides.TileFlip.FlipBoth;

            // Load the image and add it to the presentation's image collection
            Aspose.Slides.IImage img = Aspose.Slides.Images.FromFile(inputPath);
            Aspose.Slides.IPPImage ppImg = pres.Images.AddImage(img);

            // Set the placeholder's picture fill to the loaded image
            Aspose.Slides.IPictureFillFormat picFill = placeholder.FillFormat.PictureFillFormat;
            picFill.Picture.Image = ppImg;

            // Save the presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}