using System;
using System.IO;
using System.IO.Compression;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchShapeThumbnails
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputDirectory = "InputPpts";
            string outputZipPath = "ShapeThumbnails.zip";

            if (!Directory.Exists(inputDirectory))
            {
                Console.WriteLine("Input directory does not exist.");
                return;
            }

            using (FileStream zipToOpen = new FileStream(outputZipPath, FileMode.Create))
            using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
            {
                string[] pptFiles = Directory.GetFiles(inputDirectory);
                foreach (string pptPath in pptFiles)
                {
                    try
                    {
                        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(pptPath);
                        int slideNumber = 1;
                        foreach (Aspose.Slides.ISlide slide in pres.Slides)
                        {
                            int shapeIndex = 0;
                            foreach (Aspose.Slides.IShape shape in slide.Shapes)
                            {
                                Aspose.Slides.IImage shapeImage = shape.GetImage();
                                if (shapeImage != null)
                                {
                                    string entryName = $"{Path.GetFileNameWithoutExtension(pptPath)}_slide{slideNumber}_shape{shapeIndex}.png";
                                    ZipArchiveEntry entry = archive.CreateEntry(entryName);
                                    using (Stream entryStream = entry.Open())
                                    {
                                        shapeImage.Save(entryStream, Aspose.Slides.ImageFormat.Png);
                                    }
                                    shapeImage.Dispose();
                                }
                                shapeIndex++;
                            }
                            slideNumber++;
                        }
                        // Save presentation before exit (no modifications)
                        pres.Save(pptPath, Aspose.Slides.Export.SaveFormat.Pptx);
                        pres.Dispose();
                    }
                    catch (NotSupportedException)
                    {
                        // Format not supported
                    }
                    catch (Exception)
                    {
                        // Handle other exceptions if needed
                    }
                }
            }
        }
    }
}