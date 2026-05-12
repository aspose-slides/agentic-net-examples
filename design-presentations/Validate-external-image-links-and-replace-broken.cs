using System;
using System.IO;
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ValidateExternalImages
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPath = args.Length > 1 ? args[1] : "output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Placeholder image path (must exist)
            string placeholderPath = "placeholder.png";
            if (!File.Exists(placeholderPath))
            {
                Console.WriteLine("Placeholder image not found: " + placeholderPath);
                return;
            }

            // Load presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                HttpClient httpClient = new HttpClient();

                // Iterate through all slides and shapes
                foreach (ISlide slide in pres.Slides)
                {
                    foreach (IShape shape in slide.Shapes)
                    {
                        // Process only picture shapes
                        if (shape is ISlidesPicture picture)
                        {
                            string link = picture.LinkPathLong;
                            if (!string.IsNullOrEmpty(link))
                            {
                                try
                                {
                                    // Attempt to download the external image
                                    HttpResponseMessage response = httpClient.GetAsync(link).Result;
                                    if (response.IsSuccessStatusCode)
                                    {
                                        byte[] imageData = response.Content.ReadAsByteArrayAsync().Result;
                                        IPPImage img = pres.Images.AddImage(imageData);
                                        picture.Image = img;
                                        picture.LinkPathLong = string.Empty; // Clear broken link
                                    }
                                    else
                                    {
                                        // Replace with placeholder on failed download
                                        byte[] placeholderData = File.ReadAllBytes(placeholderPath);
                                        IPPImage placeholderImg = pres.Images.AddImage(placeholderData);
                                        picture.Image = placeholderImg;
                                        picture.LinkPathLong = string.Empty;
                                    }
                                }
                                catch (HttpRequestException)
                                {
                                    // Network error – replace with placeholder
                                    byte[] placeholderData = File.ReadAllBytes(placeholderPath);
                                    IPPImage placeholderImg = pres.Images.AddImage(placeholderData);
                                    picture.Image = placeholderImg;
                                    picture.LinkPathLong = string.Empty;
                                }
                            }
                        }
                    }
                }

                // Save the modified presentation
                try
                {
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
                catch (Exception ex)
                {
                    // Format not supported or other save error
                    // Comment: format not supported
                    Console.WriteLine("Error saving presentation: " + ex.Message);
                }
            }
        }
    }
}