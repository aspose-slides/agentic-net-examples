using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ShapePictureFillReport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string inputPath = Path.Combine(dataDir, "input.pptx");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Ensure data directory exists
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                // Build report
                StringBuilder reportBuilder = new StringBuilder();
                reportBuilder.AppendLine("Shapes using picture fill:");
                reportBuilder.AppendLine("-----------------------------------");

                // Iterate through slides
                for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = pres.Slides[slideIndex];
                    // Iterate through shapes
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                        // Check if shape has a FillFormat
                        if (shape.FillFormat != null && shape.FillFormat.FillType == Aspose.Slides.FillType.Picture)
                        {
                            Aspose.Slides.IPictureFillFormat picFill = shape.FillFormat.PictureFillFormat;
                            Aspose.Slides.IPPImage img = picFill.Picture.Image;
                            // Attempt to retrieve image index (as a proxy for source file name)
                            int imageIndex = -1;
                            for (int i = 0; i < pres.Images.Count; i++)
                            {
                                if (pres.Images[i] == img)
                                {
                                    imageIndex = i;
                                    break;
                                }
                            }
                            string imageInfo = imageIndex >= 0 ? $"Image Index: {imageIndex}" : "Image not found in collection";
                            reportBuilder.AppendLine($"Slide {slideIndex + 1}, Shape {shapeIndex + 1} ('{shape.Name}'): {imageInfo}");
                        }
                    }
                }

                // Output report
                Console.WriteLine(reportBuilder.ToString());

                // Save presentation (no modifications made, but required by rule)
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}