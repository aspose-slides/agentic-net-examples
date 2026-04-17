using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddImageHyperlinkExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input image file path
            string inputImagePath = "image.png";
            // Output presentation file path
            string outputPresentationPath = "output.pptx";
            // Hyperlink URL to assign to the image
            string hyperlinkUrl = "https://www.aspose.com/";

            try
            {
                // Verify that the input image file exists
                if (!File.Exists(inputImagePath))
                {
                    Console.WriteLine("Input image file does not exist: " + inputImagePath);
                    return;
                }

                // Read image data into a byte array
                byte[] imageData = File.ReadAllBytes(inputImagePath);

                // Create a new presentation
                Presentation pres = new Presentation();

                // Add the image to the presentation's media collection
                IPPImage img = pres.Images.AddImage(imageData);

                // Get the first slide (or create one if none exist)
                ISlide slide;
                if (pres.Slides.Count > 0)
                {
                    slide = pres.Slides[0];
                }
                else
                {
                    slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
                }

                // Add a picture frame that uses the added image
                Aspose.Slides.IShape pictureShape = slide.Shapes.AddPictureFrame(
                    ShapeType.Rectangle,
                    0,
                    0,
                    pres.SlideSize.Size.Width,
                    pres.SlideSize.Size.Height,
                    img);

                // Cast to picture frame to set hyperlink
                Aspose.Slides.IPictureFrame pictureFrame = pictureShape as Aspose.Slides.IPictureFrame;
                if (pictureFrame != null)
                {
                    pictureFrame.HyperlinkClick = new Hyperlink(hyperlinkUrl);
                    pictureFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";
                }

                // Save the presentation
                pres.Save(outputPresentationPath, SaveFormat.Pptx);

                // Dispose the presentation
                pres.Dispose();

                Console.WriteLine("Presentation created successfully: " + outputPresentationPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URL issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}