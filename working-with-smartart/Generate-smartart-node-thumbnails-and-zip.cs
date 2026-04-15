using System;
using System.IO;
using System.IO.Compression;
using Aspose.Slides.Export;

namespace SmartArtThumbnails
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";
            string zipPath = "thumbnails.zip";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
                Aspose.Slides.ISlide slide = presentation.Slides[0];
                Aspose.Slides.SmartArt.ISmartArt smartArt = null;

                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    if (shape is Aspose.Slides.SmartArt.ISmartArt)
                    {
                        smartArt = (Aspose.Slides.SmartArt.ISmartArt)shape;
                        break;
                    }
                }

                if (smartArt != null)
                {
                    using (FileStream zipFileStream = new FileStream(zipPath, FileMode.Create))
                    {
                        using (ZipArchive zipArchive = new ZipArchive(zipFileStream, ZipArchiveMode.Create))
                        {
                            int nodeIndex = 0;
                            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smartArt.AllNodes)
                            {
                                if (node.Shapes.Count > 0)
                                {
                                    Aspose.Slides.SmartArt.ISmartArtShape nodeShape = node.Shapes[0];
                                    Aspose.Slides.IImage image = nodeShape.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, 1f, 1f);
                                    using (MemoryStream imageStream = new MemoryStream())
                                    {
                                        image.Save(imageStream, Aspose.Slides.ImageFormat.Png);
                                        imageStream.Position = 0;
                                        string entryName = $"node_{nodeIndex}.png";
                                        ZipArchiveEntry entry = zipArchive.CreateEntry(entryName);
                                        using (Stream entryStream = entry.Open())
                                        {
                                            imageStream.CopyTo(entryStream);
                                        }
                                    }
                                }
                                nodeIndex++;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No SmartArt found on the first slide.");
                }

                // Save the presentation before exiting
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}