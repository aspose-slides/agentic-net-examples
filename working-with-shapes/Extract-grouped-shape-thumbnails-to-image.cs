using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace GroupShapeThumbnailExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PowerPoint file path
            string inputPath = "input.pptx";
            // Output folder for thumbnails
            string outputFolder = "Thumbnails";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                // Load presentation
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
                return;
            }
            catch (Exception ex)
            {
                // Other loading errors
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }

            // Iterate through slides
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                // Iterate through shapes to find group shapes
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[shapeIndex] as Aspose.Slides.IShape;
                    Aspose.Slides.IGroupShape groupShape = shape as Aspose.Slides.IGroupShape;
                    if (groupShape != null)
                    {
                        // Get thumbnail of the group shape
                        Aspose.Slides.IImage groupImage = groupShape.GetImage();

                        // Build output file name preserving hierarchy cues
                        string imageFileName = Path.Combine(outputFolder,
                            $"Slide{slide.SlideNumber}_Group{shapeIndex + 1}.png");

                        // Save thumbnail as PNG
                        groupImage.Save(imageFileName, Aspose.Slides.ImageFormat.Png);
                    }
                }
            }

            // Save the presentation (even if unchanged) before exiting
            string savedPath = Path.Combine(outputFolder, "ProcessedPresentation.pptx");
            presentation.Save(savedPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}