using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Folder containing PPTX files
        string inputFolder = "InputPptx";
        if (!Directory.Exists(inputFolder))
        {
            Console.WriteLine("Input folder does not exist.");
            return;
        }

        // Get all PPTX files in the folder
        string[] pptxFiles = Directory.GetFiles(inputFolder, "*.pptx");
        foreach (string pptxPath in pptxFiles)
        {
            try
            {
                // Load presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(pptxPath);

                // Iterate through slides
                for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = pres.Slides[slideIndex];

                    // Iterate through shapes on the slide
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        // Check if the shape is a SmartArt diagram
                        if (shape is Aspose.Slides.SmartArt.SmartArt)
                        {
                            Aspose.Slides.SmartArt.SmartArt smartArt = (Aspose.Slides.SmartArt.SmartArt)shape;

                            // Define scaling factors (full size)
                            float scaleX = 1f;
                            float scaleY = 1f;

                            // Generate thumbnail image for the SmartArt shape
                            using (Aspose.Slides.IImage thumbnail = smartArt.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, scaleX, scaleY))
                            {
                                // Build output file name
                                string outputFileName = Path.Combine(
                                    inputFolder,
                                    Path.GetFileNameWithoutExtension(pptxPath) +
                                    "_slide" + (slideIndex + 1) +
                                    "_smartart.png");

                                // Save thumbnail as PNG
                                thumbnail.Save(outputFileName, Aspose.Slides.ImageFormat.Png);
                            }
                        }
                    }
                }

                // Save presentation before exiting (no modifications made)
                pres.Save(pptxPath, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (NotSupportedException)
            {
                // Handle unsupported file format
                Console.WriteLine("File format not supported: " + pptxPath);
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("Error processing file: " + pptxPath);
                Console.WriteLine(ex.Message);
            }
        }
    }
}