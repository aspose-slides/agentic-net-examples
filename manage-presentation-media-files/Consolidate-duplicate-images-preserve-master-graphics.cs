using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the source presentation
                using (Presentation pres = new Presentation("input.pptx"))
                {
                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        ISlide slide = pres.Slides[slideIndex];
                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            IShape shape = slide.Shapes[shapeIndex];
                            IPictureFrame pictureFrame = shape as IPictureFrame;
                            if (pictureFrame != null)
                            {
                                // Compress each picture to a medium resolution and delete cropped areas
                                pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);
                            }
                        }
                    }

                    // Configure PDF export options
                    PdfOptions pdfOptions = new PdfOptions();
                    pdfOptions.BestImagesCompressionRatio = true; // optimal image compression
                    pdfOptions.SaveMetafilesAsPng = true; // preserve master‑slide graphics

                    // Save the presentation as PDF
                    pres.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}