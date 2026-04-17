using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ShapeThumbnailExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input directory containing presentations
            string inputDirectory = "InputPresentations";
            // Output directory for shape thumbnails and saved presentations
            string outputDirectory = "ShapeThumbnails";

            // Verify input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.WriteLine("Input directory does not exist: " + inputDirectory);
                return;
            }

            // Create output directory if it does not exist
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all files in the input directory
            string[] presentationFiles = Directory.GetFiles(inputDirectory, "*.*", SearchOption.TopDirectoryOnly);

            foreach (string presentationPath in presentationFiles)
            {
                try
                {
                    // Load the presentation
                    Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(presentationPath);

                    // Iterate through each slide
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        Aspose.Slides.ISlide slide = pres.Slides[slideIndex];

                        // Iterate through each shape on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                            // Generate thumbnail for the shape (full scale)
                            Aspose.Slides.IImage shapeImage = shape.GetImage(ShapeThumbnailBounds.Shape, 1f, 1f);

                            // Build output file name: {presentation}_slide{n}_shape{m}.png
                            string baseFileName = Path.GetFileNameWithoutExtension(presentationPath);
                            string shapeFileName = string.Format("{0}_slide{1}_shape{2}.png", baseFileName, slideIndex + 1, shapeIndex + 1);
                            string shapeOutputPath = Path.Combine(outputDirectory, shapeFileName);

                            // Save the shape thumbnail as PNG
                            shapeImage.Save(shapeOutputPath, Aspose.Slides.ImageFormat.Png);
                        }
                    }

                    // Save the (unchanged) presentation to the output folder (required by lifecycle rule)
                    string savedPresentationPath = Path.Combine(outputDirectory, Path.GetFileName(presentationPath));
                    pres.Save(savedPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                    Console.WriteLine("File format not supported: " + presentationPath);
                }
                catch (Exception ex)
                {
                    // Handle other exceptions (e.g., file access issues, external resources)
                    Console.WriteLine("Error processing file: " + presentationPath);
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}