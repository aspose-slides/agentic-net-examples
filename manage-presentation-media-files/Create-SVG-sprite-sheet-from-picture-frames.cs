using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SvgSpriteGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPresentationPath = "output.pptx";
            string spriteSheetPath = "sprite.svg";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    StringBuilder spriteBuilder = new StringBuilder();
                    spriteBuilder.AppendLine("<svg xmlns=\"http://www.w3.org/2000/svg\" style=\"display:none\">");

                    int svgIndex = 0;

                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        ISlide slide = presentation.Slides[slideIndex];
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            IShape shape = slide.Shapes[shapeIndex];
                            IPictureFrame pictureFrame = shape as IPictureFrame;
                            if (pictureFrame != null)
                            {
                                // Retrieve the embedded image (IPPImage)
                                IPPImage embeddedImage = pictureFrame.PictureFormat.Picture.Image;
                                if (embeddedImage != null && embeddedImage.SvgImage != null)
                                {
                                    // Get SVG content
                                    string svgContent = embeddedImage.SvgImage.SvgContent;
                                    if (!string.IsNullOrEmpty(svgContent))
                                    {
                                        svgIndex++;
                                        spriteBuilder.AppendLine($"<symbol id=\"svg{svgIndex}\">");
                                        spriteBuilder.AppendLine(svgContent);
                                        spriteBuilder.AppendLine("</symbol>");
                                    }
                                }
                            }
                        }
                    }

                    spriteBuilder.AppendLine("</svg>");

                    // Write the combined SVG sprite sheet to file
                    File.WriteAllText(spriteSheetPath, spriteBuilder.ToString());

                    // Save the (potentially unchanged) presentation
                    presentation.Save(outputPresentationPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external resources)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}