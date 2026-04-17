using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputFolder;
        if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))
        {
            inputFolder = args[0];
        }
        else
        {
            inputFolder = "InputSlides";
        }

        if (!Directory.Exists(inputFolder))
        {
            Console.WriteLine("Input folder does not exist: " + inputFolder);
            return;
        }

        string[] pptxFiles = Directory.GetFiles(inputFolder, "*.pptx");
        foreach (string pptxPath in pptxFiles)
        {
            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(pptxPath);

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(pptxPath);
                string outputDir = Path.Combine(inputFolder, fileNameWithoutExt + "_SmartArtThumbnails");
                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                {
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        if (shape is Aspose.Slides.SmartArt.ISmartArt)
                        {
                            using (Aspose.Slides.IImage smartArtImage = shape.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, 1f, 1f))
                            {
                                string imagePath = Path.Combine(outputDir, $"Slide_{slide.SlideNumber}_SmartArt_{shape.Name}.png");
                                smartArtImage.Save(imagePath, Aspose.Slides.ImageFormat.Png);
                            }
                        }
                    }
                }

                // Save presentation before exit (no modifications made)
                presentation.Save(pptxPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("File format not supported: " + pptxPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing file " + pptxPath + ": " + ex.Message);
            }
        }
    }
}