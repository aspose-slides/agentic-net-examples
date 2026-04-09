using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReplaceLowResImages
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";
            // Directory containing higher‑resolution images
            string highResImageDir = "highres";

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                    // Collect picture frames to process
                    List<Aspose.Slides.IShape> pictureFrames = new List<Aspose.Slides.IShape>();
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        if (shape is Aspose.Slides.IPictureFrame)
                        {
                            pictureFrames.Add(shape);
                        }
                    }

                    // Replace each picture frame with a higher‑resolution image
                    foreach (Aspose.Slides.IShape shape in pictureFrames)
                    {
                        Aspose.Slides.IPictureFrame oldPic = (Aspose.Slides.IPictureFrame)shape;
                        float x = oldPic.X;
                        float y = oldPic.Y;
                        float width = oldPic.Width;
                        float height = oldPic.Height;

                        // Determine high‑resolution image path (example uses a generic file)
                        string highResImagePath = Path.Combine(highResImageDir, "highres.jpg");
                        if (!File.Exists(highResImagePath))
                        {
                            // Skip if the high‑resolution image is not found
                            continue;
                        }

                        // Add the high‑resolution image and create a picture frame (add‑relative‑scale‑height‑picture‑frame rule)
                        Aspose.Slides.IImage img = Aspose.Slides.Images.FromFile(highResImagePath);
                        Aspose.Slides.IPPImage imgx = presentation.Images.AddImage(img);
                        Aspose.Slides.IPictureFrame pf = presentation.Slides[slideIndex].Shapes.AddPictureFrame(
                            Aspose.Slides.ShapeType.Rectangle, x, y, width, height, imgx);
                        pf.RelativeScaleHeight = 1.0f;
                        pf.RelativeScaleWidth = 1.0f;
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                // format not supported
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}