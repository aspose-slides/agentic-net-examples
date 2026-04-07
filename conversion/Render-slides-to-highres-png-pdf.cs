using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define file paths
        var inputPath = "input.pptx";
        var outputPdfPath = "output.pdf";
        var imageFolder = "SlideImages";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Ensure image output folder exists
        Directory.CreateDirectory(imageFolder);

        try
        {
            // Load the source presentation
            var sourcePres = new Aspose.Slides.Presentation(inputPath);

            // High‑resolution scaling factors
            var scaleX = 3f;
            var scaleY = 3f;

            // Export each slide as a PNG image
            var slideIndex = 0;
            foreach (Aspose.Slides.ISlide slide in sourcePres.Slides)
            {
                using (Aspose.Slides.IImage image = slide.GetImage(scaleX, scaleY))
                {
                    var imagePath = Path.Combine(imageFolder, $"slide_{slideIndex}.png");
                    image.Save(imagePath, Aspose.Slides.ImageFormat.Png);
                }
                slideIndex++;
            }

            // Create a new presentation to hold images for PDF conversion
            var pdfPres = new Aspose.Slides.Presentation();

            // Get slide dimensions
            var slideWidth = pdfPres.SlideSize.Size.Width;
            var slideHeight = pdfPres.SlideSize.Size.Height;

            // Add each PNG as a full‑size picture frame on a new slide
            var imageFiles = Directory.GetFiles(imageFolder, "*.png");
            foreach (var imgFile in imageFiles)
            {
                // Add a new empty slide
                var newSlide = pdfPres.Slides.AddEmptySlide(pdfPres.Slides[0].LayoutSlide);

                // Load image and add to presentation's image collection
                using (Aspose.Slides.IImage img = Aspose.Slides.Images.FromFile(imgFile))
                {
                    var imgIndex = pdfPres.Images.AddImage(img);
                    // Insert picture frame covering the whole slide
                    newSlide.Shapes.AddPictureFrame(
                        Aspose.Slides.ShapeType.Rectangle,
                        0,
                        0,
                        slideWidth,
                        slideHeight,
                        imgIndex);
                }
            }

            // Save the combined presentation as a PDF
            pdfPres.Save(outputPdfPath, Aspose.Slides.Export.SaveFormat.Pdf);

            // Dispose presentations
            sourcePres.Dispose();
            pdfPres.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            // Handle other exceptions as needed
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}