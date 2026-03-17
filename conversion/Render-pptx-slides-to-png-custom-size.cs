using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RenderSlidesToPng
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input PowerPoint file path
                string inputPath = "input.pptx";

                // Output folder for PNG images
                string outputFolder = "SlideImages";
                Directory.CreateDirectory(outputFolder);

                // Ask user for desired image width and height
                Console.Write("Enter desired image width (pixels): ");
                string widthInput = Console.ReadLine();
                Console.Write("Enter desired image height (pixels): ");
                string heightInput = Console.ReadLine();

                int desiredWidth = int.Parse(widthInput);
                int desiredHeight = int.Parse(heightInput);

                // Open the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Calculate scaling factors based on original slide size (points)
                    float originalWidth = pres.SlideSize.Size.Width;
                    float originalHeight = pres.SlideSize.Size.Height;

                    float scaleX = (float)desiredWidth / originalWidth;
                    float scaleY = (float)desiredHeight / originalHeight;

                    // Iterate through all slides and export each as PNG
                    for (int i = 0; i < pres.Slides.Count; i++)
                    {
                        ISlide slide = pres.Slides[i];
                        IImage slideImage = slide.GetImage(scaleX, scaleY);
                        string outputPath = Path.Combine(outputFolder, $"slide_{i + 1}.png");
                        slideImage.Save(outputPath, ImageFormat.Png);
                    }

                    // Save the presentation (even if unchanged) before exiting
                    string savedPresentationPath = "output.pptx";
                    pres.Save(savedPresentationPath, SaveFormat.Pptx);
                }

                Console.WriteLine("All slides have been rendered to PNG successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}