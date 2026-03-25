using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output_with_overview.pptx");

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Insert an overview slide at the beginning using a suitable layout
        Aspose.Slides.IMasterLayoutSlideCollection layoutSlides = pres.Masters[0].LayoutSlides;
        Aspose.Slides.ILayoutSlide layoutSlide = layoutSlides.GetByType(Aspose.Slides.SlideLayoutType.TitleAndObject) ??
                                                layoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Title);
        if (layoutSlide == null)
        {
            layoutSlide = layoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);
        }
        Aspose.Slides.ISlide overviewSlide = pres.Slides.InsertEmptySlide(0, layoutSlide);

        // Desired thumbnail dimensions
        int desiredX = 200;
        int desiredY = 150;

        // Calculate scaling factors based on presentation size
        float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
        float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

        // Layout parameters for thumbnails
        int columns = 5;
        int spacing = 10;
        int thumbIndex = 0;

        // Generate thumbnails for each existing slide (skip the newly added overview slide)
        for (int i = 1; i < pres.Slides.Count; i++)
        {
            Aspose.Slides.ISlide srcSlide = pres.Slides[i];
            Aspose.Slides.IImage thumbImage = srcSlide.GetImage(scaleX, scaleY);

            // Save thumbnail to a memory stream as JPEG
            using (MemoryStream ms = new MemoryStream())
            {
                thumbImage.Save(ms, Aspose.Slides.ImageFormat.Jpeg);
                byte[] imgBytes = ms.ToArray();

                // Add image to presentation's image collection
                Aspose.Slides.IPPImage img = pres.Images.AddImage(imgBytes);

                // Calculate position in a grid
                int col = thumbIndex % columns;
                int row = thumbIndex / columns;
                float posX = col * (desiredX + spacing);
                float posY = row * (desiredY + spacing);

                // Add the thumbnail picture frame to the overview slide
                overviewSlide.Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, posX, posY, desiredX, desiredY, img);
            }

            thumbIndex++;
        }

        // Save the modified presentation
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}