using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RetrieveSvgFromPictureFrames
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input PPTX path (first argument or default)
                string dataDir = args.Length > 0 ? args[0] : "Data";
                string inputPptxPath = Path.Combine(dataDir, "input.pptx");

                // Output directory for extracted SVGs and the saved presentation
                string outputDir = Path.Combine(dataDir, "output");
                Directory.CreateDirectory(outputDir);

                // Load the presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPptxPath);

                // Iterate through slides and shapes
                int slideIndex = 0;
                foreach (Aspose.Slides.ISlide slide in pres.Slides)
                {
                    int shapeIndex = 0;
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        // Check if the shape is a picture frame
                        Aspose.Slides.IPictureFrame pictureFrame = shape as Aspose.Slides.IPictureFrame;
                        if (pictureFrame != null)
                        {
                            // Get the image associated with the picture frame
                            Aspose.Slides.IPPImage ppImage = pictureFrame.PictureFormat.Picture.Image;
                            if (ppImage != null && ppImage.SvgImage != null)
                            {
                                // Retrieve SVG content
                                string svgContent = ppImage.SvgImage.SvgContent;

                                // Save SVG to a file
                                string svgFileName = $"slide{slideIndex}_shape{shapeIndex}.svg";
                                string svgFilePath = Path.Combine(outputDir, svgFileName);
                                File.WriteAllText(svgFilePath, svgContent);
                            }
                        }
                        shapeIndex++;
                    }
                    slideIndex++;
                }

                // Save the (potentially unchanged) presentation
                string outputPptxPath = Path.Combine(outputDir, "output.pptx");
                pres.Save(outputPptxPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}