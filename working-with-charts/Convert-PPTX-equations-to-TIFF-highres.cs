using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Export;

namespace MathToTiff
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input presentation path
                string inputPath = "input.pptx";
                // Output directory for TIFF images
                string outputDir = "output";

                // Ensure output directory exists
                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                // Load presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Iterate through slides
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        ISlide slide = presentation.Slides[slideIndex];

                        // Check for math shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            IShape shape = slide.Shapes[shapeIndex];
                            IAutoShape autoShape = shape as IAutoShape;
                            if (autoShape != null && autoShape.TextFrame != null && autoShape.TextFrame.Paragraphs.Count > 0 && autoShape.TextFrame.Paragraphs[0].Portions.Count > 0)
                            {
                                MathPortion mathPortion = autoShape.TextFrame.Paragraphs[0].Portions[0] as MathPortion;
                                if (mathPortion != null)
                                {
                                    // Render the slide at higher resolution (scale factor 2.0)
                                    IImage slideImage = slide.GetImage(2.0f, 2.0f);
                                    string tiffPath = Path.Combine(outputDir, $"slide_{slideIndex + 1}_shape_{shapeIndex + 1}.tiff");
                                    slideImage.Save(tiffPath, ImageFormat.Tiff);
                                }
                            }
                        }

                        // Additionally, render the whole slide as high‑resolution TIFF
                        IImage fullSlideImage = slide.GetImage(2.0f, 2.0f);
                        string fullTiffPath = Path.Combine(outputDir, $"slide_{slideIndex + 1}.tiff");
                        fullSlideImage.Save(fullTiffPath, ImageFormat.Tiff);
                    }

                    // Save the (potentially unchanged) presentation before exiting
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}