using System;
using System.IO;
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input presentation path, output path, and placeholder image path
        string inputPath = args.Length > 0 ? args[0] : "input.pptx";
        string outputPath = args.Length > 1 ? args[1] : "output.pptx";
        string placeholderPath = args.Length > 2 ? args[2] : "placeholder.png";

        // Validate input files
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }
        if (!File.Exists(placeholderPath))
        {
            Console.WriteLine("Placeholder image does not exist.");
            return;
        }

        try
        {
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                HttpClient httpClient = new HttpClient();

                // Iterate through all slides and shapes
                foreach (Aspose.Slides.ISlide slide in pres.Slides)
                {
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        Aspose.Slides.ISlidesPicture picture = shape as Aspose.Slides.ISlidesPicture;
                        if (picture != null && !string.IsNullOrEmpty(picture.LinkPathLong))
                        {
                            try
                            {
                                // Try to access the external image URL
                                HttpResponseMessage response = httpClient.GetAsync(picture.LinkPathLong).Result;
                                if (!response.IsSuccessStatusCode)
                                {
                                    throw new Exception("Image not reachable");
                                }
                                // Image is accessible; no action needed
                            }
                            catch
                            {
                                // Replace broken link with placeholder image
                                byte[] placeholderData = File.ReadAllBytes(placeholderPath);
                                Aspose.Slides.IPPImage placeholderImage = pres.Images.AddImage(placeholderData);
                                picture.Image = placeholderImage;
                                picture.LinkPathLong = null;
                            }
                        }
                    }
                }

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}