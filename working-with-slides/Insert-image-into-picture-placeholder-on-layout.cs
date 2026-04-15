using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define paths
        string dataDir = "Data";
        string imagePath = Path.Combine(dataDir, "image.jpg");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        // Ensure data directory exists
        if (!Directory.Exists(dataDir))
        {
            Directory.CreateDirectory(dataDir);
        }

        // Check if the image file exists
        if (!File.Exists(imagePath))
        {
            Console.WriteLine("Image file not found: " + imagePath);
            return;
        }

        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Get a blank layout slide
            Aspose.Slides.ILayoutSlide layout = pres.LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);

            // Add a picture placeholder to the layout slide
            Aspose.Slides.IAutoShape placeholder = layout.PlaceholderManager.AddPicturePlaceholder(20, 20, 300, 200);

            // Load the external image and add it to the presentation's image collection
            Aspose.Slides.IImage img = Aspose.Slides.Images.FromFile(imagePath);
            Aspose.Slides.IPPImage imgx = pres.Images.AddImage(img);

            // Set the placeholder's fill to the image
            placeholder.FillFormat.FillType = Aspose.Slides.FillType.Picture;
            placeholder.FillFormat.PictureFillFormat.Picture.Image = imgx;

            // Save the presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The provided file format is not supported.");
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}