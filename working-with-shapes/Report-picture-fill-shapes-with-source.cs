using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ShapePictureFillReport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                // Iterate through all slides
                foreach (Aspose.Slides.ISlide slide in pres.Slides)
                {
                    // Iterate through all shapes on the slide
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        // Check if the shape has a picture fill
                        if (shape.FillFormat != null && shape.FillFormat.FillType == Aspose.Slides.FillType.Picture)
                        {
                            Aspose.Slides.IPictureFillFormat picFill = shape.FillFormat.PictureFillFormat;
                            if (picFill != null && picFill.Picture != null && picFill.Picture.Image != null)
                            {
                                // Attempt to locate the image index in the presentation's image collection
                                int imageIndex = -1;
                                for (int i = 0; i < pres.Images.Count; i++)
                                {
                                    if (pres.Images[i] == picFill.Picture.Image)
                                    {
                                        imageIndex = i;
                                        break;
                                    }
                                }

                                // Output the report line
                                Console.WriteLine(
                                    "Slide " + slide.SlideNumber +
                                    ", Shape \"" + shape.Name + "\" uses picture fill. " +
                                    "Image index in collection: " + imageIndex);
                            }
                        }
                    }
                }

                // Save the presentation before exiting
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Handle unsupported file format
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}