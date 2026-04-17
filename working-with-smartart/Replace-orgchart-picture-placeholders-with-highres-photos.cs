using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReplaceOrgChartPictures
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for input presentation and output presentation
            string inputPath = "OrgChart.pptx";
            string outputPath = "OrgChart_Updated.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input presentation file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Iterate through all slides
                    foreach (ISlide slide in pres.Slides)
                    {
                        // Iterate through all shapes on the slide
                        foreach (IShape shape in slide.Shapes)
                        {
                            // Check if the shape has a picture placeholder
                            IPlaceholder placeholder = shape.Placeholder;
                            if (placeholder != null && placeholder.Type == PlaceholderType.Picture)
                            {
                                // Simulate retrieving a high‑resolution image from a database
                                // (Here we simply load an image file from disk)
                                string highResImagePath = "highres.jpg";

                                if (!File.Exists(highResImagePath))
                                {
                                    Console.WriteLine("High‑resolution image not found: " + highResImagePath);
                                    continue;
                                }

                                // Add the image to the presentation's image collection
                                byte[] imageBytes = File.ReadAllBytes(highResImagePath);
                                IPPImage highResImage = pres.Images.AddImage(imageBytes);

                                // Cast the shape to a picture frame to replace its image
                                IPictureFrame pictureFrame = shape as IPictureFrame;
                                if (pictureFrame != null)
                                {
                                    // Replace the picture in the placeholder with the high‑resolution image
                                    pictureFrame.PictureFormat.Picture.Image = highResImage;
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported by Aspose.Slides.
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}