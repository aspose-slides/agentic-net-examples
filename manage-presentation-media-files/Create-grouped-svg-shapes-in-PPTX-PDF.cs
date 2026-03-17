using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Paths
                string dataDir = @"C:\Data";
                string svgPath = Path.Combine(dataDir, "input.svg");
                string pptxPath = Path.Combine(dataDir, "output.pptx");
                string pdfPath = Path.Combine(dataDir, "output.pdf");

                // Load SVG content
                string svgContent = File.ReadAllText(svgPath);

                // Create a new presentation
                using (Presentation pres = new Presentation())
                {
                    // Create SVG image object
                    ISvgImage svgImage = new SvgImage(svgContent);

                    // Add SVG image to the presentation's image collection
                    IPPImage ppImage = pres.Images.AddImage(svgImage);

                    // Add picture frame containing the SVG image
                    Aspose.Slides.PictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(
                        ShapeType.Rectangle,
                        0,
                        0,
                        ppImage.Width,
                        ppImage.Height,
                        ppImage) as Aspose.Slides.PictureFrame;

                    // Convert the SVG picture frame into a group shape
                    if (pictureFrame != null && pictureFrame.PictureFormat.Picture.Image.SvgImage != null)
                    {
                        ISvgImage innerSvg = pictureFrame.PictureFormat.Picture.Image.SvgImage;
                        IGroupShape groupShape = pres.Slides[0].Shapes.AddGroupShape(
                            innerSvg,
                            pictureFrame.Frame.X,
                            pictureFrame.Frame.Y,
                            pictureFrame.Frame.Width,
                            pictureFrame.Frame.Height);

                        // Remove the original picture frame
                        pres.Slides[0].Shapes.Remove(pictureFrame);

                        // Edit group shape properties
                        groupShape.Name = "MySvgGroup";
                        groupShape.AlternativeText = "Converted SVG Group";
                        groupShape.Rotation = 45f; // Rotate 45 degrees
                        groupShape.Width = groupShape.Width * 1.2f; // Scale width
                        groupShape.Height = groupShape.Height * 1.2f; // Scale height
                    }

                    // Save as PPTX
                    pres.Save(pptxPath, SaveFormat.Pptx);

                    // Save as PDF
                    pres.Save(pdfPath, SaveFormat.Pdf);
                }

                Console.WriteLine("Presentation and PDF files have been created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}