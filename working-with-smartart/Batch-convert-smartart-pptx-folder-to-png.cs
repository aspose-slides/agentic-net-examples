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
            // Input folder path (first argument or default "Input")
            string inputFolder;
            if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))
            {
                inputFolder = args[0];
            }
            else
            {
                inputFolder = "Input";
            }

            // Verify folder exists
            if (!Directory.Exists(inputFolder))
            {
                Console.WriteLine("Input folder does not exist: " + inputFolder);
                return;
            }

            // Get all PPTX files in the folder
            string[] pptxFiles = Directory.GetFiles(inputFolder, "*.pptx");

            foreach (string pptxPath in pptxFiles)
            {
                try
                {
                    // Load presentation
                    Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(pptxPath);

                    // Iterate through slides
                    foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                    {
                        int shapeIndex = 0;

                        // Iterate through shapes on the slide
                        foreach (Aspose.Slides.IShape shape in slide.Shapes)
                        {
                            // Check if the shape is a SmartArt diagram
                            if (shape is Aspose.Slides.SmartArt.ISmartArt)
                            {
                                // Define scaling factors (full size)
                                float scaleX = 1f;
                                float scaleY = 1f;

                                // Generate thumbnail image for the SmartArt shape
                                using (Aspose.Slides.IImage thumbnail = shape.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, scaleX, scaleY))
                                {
                                    // Build output file name
                                    string outputFileName = Path.Combine(
                                        inputFolder,
                                        String.Format("{0}_slide{1}_shape{2}.png",
                                            Path.GetFileNameWithoutExtension(pptxPath),
                                            slide.SlideNumber,
                                            shapeIndex));

                                    // Save thumbnail as PNG
                                    thumbnail.Save(outputFileName, Aspose.Slides.ImageFormat.Png);
                                }
                            }

                            shapeIndex++;
                        }
                    }

                    // Save presentation before exiting (no modifications made)
                    presentation.Save(pptxPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    presentation.Dispose();
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                    // Comment: format not supported
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error processing file " + pptxPath + ": " + ex.Message);
                }
            }
        }
    }
}