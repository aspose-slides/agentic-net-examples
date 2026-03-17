using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InsertLocalImage
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for the input image and the output presentation
            string inputImagePath = "image1.jpg";
            string outputPresentationPath = "output.pptx";

            // Ensure the input image file exists
            if (!File.Exists(inputImagePath))
            {
                Console.WriteLine("Input image file not found: " + inputImagePath);
                return;
            }

            // Create a new presentation inside a try-catch block
            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation();

                // Load the image using Aspose.Slides to obtain its original dimensions
                Aspose.Slides.IImage slideImage = Aspose.Slides.Images.FromFile(inputImagePath);

                // Add the image to the presentation's image collection
                Aspose.Slides.IPPImage presentationImage = presentation.Images.AddImage(slideImage);

                // Get the first slide (a new presentation always contains one empty slide)
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Preserve original image dimensions and position at (0,0)
                float pictureX = 0f;
                float pictureY = 0f;
                float pictureWidth = (float)slideImage.Width;
                float pictureHeight = (float)slideImage.Height;

                // Insert the picture frame with the original size
                slide.Shapes.AddPictureFrame(
                    Aspose.Slides.ShapeType.Rectangle,
                    pictureX,
                    pictureY,
                    pictureWidth,
                    pictureHeight,
                    presentationImage);
                
                // Save the presentation
                presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved successfully to: " + outputPresentationPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                // Ensure the presentation object is disposed to release resources
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}