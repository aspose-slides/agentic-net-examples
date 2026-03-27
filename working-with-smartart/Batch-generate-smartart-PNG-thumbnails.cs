using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SmartArtBatchThumbnail
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input folder path (first argument or current directory)
            string inputFolder;
            if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))
            {
                inputFolder = args[0];
            }
            else
            {
                inputFolder = Directory.GetCurrentDirectory();
            }

            // Verify folder exists
            if (!Directory.Exists(inputFolder))
            {
                Console.WriteLine("Folder does not exist: " + inputFolder);
                return;
            }

            // Output folder for thumbnails
            string outputFolder = Path.Combine(inputFolder, "SmartArtThumbnails");
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            // Process each PPTX file in the folder
            string[] pptxFiles = Directory.GetFiles(inputFolder, "*.pptx");
            foreach (string pptxPath in pptxFiles)
            {
                // Load presentation
                Presentation presentation = new Presentation(pptxPath);

                // Iterate through slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    ISlide slide = presentation.Slides[slideIndex];

                    // Iterate through shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        IShape shape = slide.Shapes[shapeIndex];

                        // Check if the shape is a SmartArt diagram
                        if (shape is Aspose.Slides.SmartArt.ISmartArt)
                        {
                            // Generate thumbnail image for the SmartArt shape
                            using (IImage thumbnail = shape.GetImage())
                            {
                                // Build output file name: originalFile_slideShape.png
                                string fileName = String.Format("{0}_slide{1}_shape{2}.png",
                                    Path.GetFileNameWithoutExtension(pptxPath),
                                    slide.SlideNumber,
                                    shapeIndex + 1);
                                string outputPath = Path.Combine(outputFolder, fileName);

                                // Save thumbnail as PNG
                                thumbnail.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                            }
                        }
                    }
                }

                // Save presentation (no modifications, but required by rule)
                presentation.Save(pptxPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }

            Console.WriteLine("Processing completed. Thumbnails saved to: " + outputFolder);
        }
    }
}