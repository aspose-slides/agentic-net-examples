using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchSmartArtToPng
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input folder containing PPTX files
            string inputFolder = args.Length > 0 ? args[0] : "InputPresentations";
            // Output folder for generated PNG thumbnails
            string outputFolder = args.Length > 1 ? args[1] : "SmartArtThumbnails";

            // Verify input folder exists
            if (!Directory.Exists(inputFolder))
            {
                Console.WriteLine("Input folder does not exist: " + inputFolder);
                return;
            }

            // Create output folder if it does not exist
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            // Process each PPTX file in the input folder
            string[] presentationFiles = Directory.GetFiles(inputFolder, "*.pptx");
            foreach (string presentationPath in presentationFiles)
            {
                // Load presentation
                using (Presentation presentation = new Presentation(presentationPath))
                {
                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        ISlide slide = presentation.Slides[slideIndex];

                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            // Attempt to cast shape to SmartArt
                            Aspose.Slides.SmartArt.SmartArt smartArtShape = slide.Shapes[shapeIndex] as Aspose.Slides.SmartArt.SmartArt;
                            if (smartArtShape != null)
                            {
                                // Generate thumbnail image for the SmartArt shape
                                using (IImage smartArtImage = smartArtShape.GetImage())
                                {
                                    string outputFileName = string.Format("{0}_slide{1}_smartart{2}.png",
                                        Path.GetFileNameWithoutExtension(presentationPath),
                                        slideIndex + 1,
                                        shapeIndex + 1);
                                    string outputPath = Path.Combine(outputFolder, outputFileName);

                                    // Save image as PNG using fully qualified ImageFormat
                                    smartArtImage.Save(outputPath, ImageFormat.Png);
                                    Console.WriteLine("Saved SmartArt thumbnail: " + outputPath);
                                }
                            }
                        }
                    }

                    // Save presentation before exiting (no modifications made, but required by lifecycle rule)
                    string savedPresentationPath = Path.Combine(outputFolder,
                        Path.GetFileNameWithoutExtension(presentationPath) + "_processed.pptx");
                    presentation.Save(savedPresentationPath, SaveFormat.Pptx);
                }
            }

            Console.WriteLine("Batch conversion completed.");
        }
    }
}