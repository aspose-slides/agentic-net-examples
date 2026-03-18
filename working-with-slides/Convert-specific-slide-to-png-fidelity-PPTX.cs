using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertSlideToImage
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Path to the source presentation
                string sourcePath = "input.pptx";
                // Path for the exported slide image
                string imagePath = "slide1.png";
                // Path for the saved presentation (optional, demonstrates saving before exit)
                string savedPresentationPath = "output.pptx";

                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
                {
                    // Get the first slide (index 0)
                    Aspose.Slides.ISlide slide = presentation.Slides[0];

                    // Render the slide to a raster image with full fidelity
                    Aspose.Slides.IImage slideImage = slide.GetImage();

                    // Save the image as PNG using the correct ImageFormat namespace
                    slideImage.Save(imagePath, Aspose.Slides.ImageFormat.Png);

                    // Save the (potentially unchanged) presentation before exiting
                    presentation.Save(savedPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during processing
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}