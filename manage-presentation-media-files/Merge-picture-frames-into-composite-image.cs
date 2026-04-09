using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MergePictureFrames
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Get the first slide
                    ISlide slide = pres.Slides[0];

                    // Find the first two picture frames on the slide
                    IPictureFrame pictureFrame1 = null;
                    IPictureFrame pictureFrame2 = null;
                    foreach (IShape shape in slide.Shapes)
                    {
                        IPictureFrame pf = shape as IPictureFrame;
                        if (pf != null)
                        {
                            if (pictureFrame1 == null)
                            {
                                pictureFrame1 = pf;
                            }
                            else if (pictureFrame2 == null)
                            {
                                pictureFrame2 = pf;
                                break;
                            }
                        }
                    }

                    // Ensure both picture frames were found
                    if (pictureFrame1 == null || pictureFrame2 == null)
                    {
                        Console.WriteLine("The slide does not contain two picture frames.");
                        return;
                    }

                    // Extract images from the picture frames
                    IPPImage ippImage1 = pictureFrame1.PictureFormat.Picture.Image;
                    IPPImage ippImage2 = pictureFrame2.PictureFormat.Picture.Image;

                    // Load images into System.Drawing.Image objects
                    System.Drawing.Image img1;
                    System.Drawing.Image img2;
                    using (MemoryStream ms1 = new MemoryStream(ippImage1.BinaryData))
                    {
                        img1 = System.Drawing.Image.FromStream(ms1);
                    }
                    using (MemoryStream ms2 = new MemoryStream(ippImage2.BinaryData))
                    {
                        img2 = System.Drawing.Image.FromStream(ms2);
                    }

                    // Determine size of the composite image (side‑by‑side)
                    int compositeWidth = img1.Width + img2.Width;
                    int compositeHeight = Math.Max(img1.Height, img2.Height);

                    // Create the composite bitmap
                    System.Drawing.Bitmap compositeBitmap = new System.Drawing.Bitmap(compositeWidth, compositeHeight);
                    using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(compositeBitmap))
                    {
                        graphics.Clear(System.Drawing.Color.Transparent);
                        graphics.DrawImage(img1, 0, 0, img1.Width, img1.Height);
                        graphics.DrawImage(img2, img1.Width, 0, img2.Width, img2.Height);
                    }

                    // Save the composite bitmap to a memory stream in PNG format
                    MemoryStream compositeStream = new MemoryStream();
                    compositeBitmap.Save(compositeStream, System.Drawing.Imaging.ImageFormat.Png);
                    compositeStream.Position = 0;

                    // Add the composite image to the presentation
                    IPPImage compositeIppImage = pres.Images.AddImage(compositeStream);

                    // Insert a new picture frame with the composite image
                    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, compositeIppImage.Width, compositeIppImage.Height, compositeIppImage);

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., external URL or web service errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}