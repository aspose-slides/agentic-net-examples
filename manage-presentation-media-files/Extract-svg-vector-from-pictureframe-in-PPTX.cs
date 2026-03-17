using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExtractSvgFromPictureFrame
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

                // Iterate through slides to find a picture frame
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                        // Check if the shape is a PictureFrame
                        Aspose.Slides.PictureFrame pictureFrame = shape as Aspose.Slides.PictureFrame;
                        if (pictureFrame != null)
                        {
                            // Export the picture frame as SVG
                            using (FileStream svgStream = new FileStream("pictureframe.svg", FileMode.Create, FileAccess.Write))
                            {
                                pictureFrame.WriteAsSvg(svgStream);
                            }

                            // Exit after processing the first picture frame
                            slideIndex = presentation.Slides.Count; // break outer loop
                            break;
                        }
                    }
                }

                // Save the presentation before exiting
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}