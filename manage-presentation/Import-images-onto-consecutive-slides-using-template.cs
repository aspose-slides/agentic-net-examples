using System;
using System.IO;
using System.Linq;
using Aspose.Slides.Export;

namespace ImageImportExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Directory containing source images
            string dataDir = "Images";
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            // Get supported image files
            string[] imageFiles = Directory.GetFiles(dataDir, "*.*", SearchOption.TopDirectoryOnly)
                .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                            f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                            f.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                .ToArray();

            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Use a blank layout slide as template
            Aspose.Slides.ILayoutSlide layout = pres.LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);
            if (layout == null && pres.LayoutSlides.Count > 0)
            {
                layout = pres.LayoutSlides[0];
            }

            // Add each image to a new slide
            foreach (string imgPath in imageFiles)
            {
                if (!File.Exists(imgPath))
                {
                    continue; // Skip missing files
                }

                try
                {
                    // Add a new empty slide based on the layout
                    Aspose.Slides.ISlide slide = pres.Slides.AddEmptySlide(layout);

                    // Load image into presentation's image collection
                    byte[] imgBytes = File.ReadAllBytes(imgPath);
                    Aspose.Slides.IPPImage img = pres.Images.AddImage(imgBytes);

                    // Add picture frame that fills the slide
                    float slideWidth = pres.SlideSize.Size.Width;
                    float slideHeight = pres.SlideSize.Size.Height;
                    slide.Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, 0, 0, slideWidth, slideHeight, img);
                }
                catch (Exception ex)
                {
                    // Handle unsupported format or other errors
                    // Format not supported: {ex.Message}
                }
            }

            // Save the presentation
            string outPath = Path.Combine(dataDir, "output.pptx");
            pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
    }
}