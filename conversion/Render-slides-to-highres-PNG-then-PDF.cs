using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideToPdfConverter
{
    class Program
    {
        static void Main()
        {
            // Input and output paths
            string inputPath = "input.pptx";
            string outputPdfPath = "output.pdf";
            string imageDir = "SlideImages";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            // Ensure image directory exists
            if (!Directory.Exists(imageDir))
            {
                Directory.CreateDirectory(imageDir);
            }

            // Load the source presentation
            Presentation sourcePresentation = new Presentation(inputPath);

            // High‑resolution scale factor
            float scaleX = 3f;
            float scaleY = 3f;

            // Export each slide as PNG
            for (int i = 0; i < sourcePresentation.Slides.Count; i++)
            {
                ISlide slide = sourcePresentation.Slides[i];
                using (IImage image = slide.GetImage(scaleX, scaleY))
                {
                    string imagePath = Path.Combine(imageDir, $"slide_{i + 1}.png");
                    image.Save(imagePath, Aspose.Slides.ImageFormat.Png);
                }
            }

            // Create a new presentation to hold PNG images
            Presentation pdfPresentation = new Presentation();

            // Add each PNG as a picture on a separate slide
            for (int i = 0; i < sourcePresentation.Slides.Count; i++)
            {
                string imagePath = Path.Combine(imageDir, $"slide_{i + 1}.png");
                if (!File.Exists(imagePath))
                {
                    continue;
                }

                // Add a new slide for all but the first image
                ISlide targetSlide = i == 0 ? pdfPresentation.Slides[0] : pdfPresentation.Slides.AddEmptySlide(pdfPresentation.Slides[0].LayoutSlide);

                // Load image into presentation
                IPPImage pptImage = pdfPresentation.Images.AddImage(Images.FromFile(imagePath));

                // Add picture frame covering the whole slide
                targetSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pdfPresentation.SlideSize.Size.Width, pdfPresentation.SlideSize.Size.Height, pptImage);
            }

            // Save the combined presentation as PDF
            try
            {
                pdfPresentation.Save(outputPdfPath, SaveFormat.Pdf);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified format is not supported for saving.");
            }

            // Clean up
            sourcePresentation.Dispose();
            pdfPresentation.Dispose();
        }
    }
}