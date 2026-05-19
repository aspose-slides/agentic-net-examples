using System;
using System.IO;
using System.IO.Compression;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPptx = "output.pptx";
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
                if (shape is Aspose.Slides.SmartArt.SmartArt)
                {
                    smartArt = (Aspose.Slides.SmartArt.SmartArt)shape;
                    break;
                }
            }

            if (smartArt == null)
            {
                Console.WriteLine("No SmartArt found.");
                presentation.Save(outputPptx, Aspose.Slides.Export.SaveFormat.Pptx);
                return;
            }

            using (FileStream zipToOpen = new FileStream(zipPath, FileMode.Create))
            {
                using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                {
                    int nodeIndex = 0;
                    foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smartArt.AllNodes)
                    {
                        int shapeIndex = 0;
                        foreach (Aspose.Slides.SmartArt.ISmartArtShape shape in node.Shapes)
                        {
                            Aspose.Slides.IImage image = shape.GetImage();
                            string entryName = $"node_{nodeIndex}_shape_{shapeIndex}.png";
                            ZipArchiveEntry entry = archive.CreateEntry(entryName);
                            using (Stream entryStream = entry.Open())
                            {
                                image.Save(entryStream, Aspose.Slides.ImageFormat.Png);
                            }
                            shapeIndex++;
                        }
                        nodeIndex++;
                    }
                }
            }

            presentation.Save(outputPptx, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}