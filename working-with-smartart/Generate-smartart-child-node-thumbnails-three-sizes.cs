using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                if (shape is Aspose.Slides.SmartArt.SmartArt)
                {
                    Aspose.Slides.SmartArt.SmartArt smartArt = (Aspose.Slides.SmartArt.SmartArt)shape;

                    for (int i = 0; i < smartArt.AllNodes.Count; i++)
                    {
                        Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)smartArt.AllNodes[i];

                        foreach (Aspose.Slides.SmartArt.ISmartArtShape nodeShape in node.Shapes)
                        {
                            // Generate thumbnails at three different scales
                            GenerateThumbnail(nodeShape, i, 0.5f, "Small");
                            GenerateThumbnail(nodeShape, i, 1.0f, "Medium");
                            GenerateThumbnail(nodeShape, i, 2.0f, "Large");
                        }
                    }
                }
            }

            // Save the presentation before exiting
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void GenerateThumbnail(Aspose.Slides.SmartArt.ISmartArtShape shape, int nodeIndex, float scale, string sizeFolder)
    {
        string baseDir = Path.Combine("Thumbnails", sizeFolder);
        if (!Directory.Exists(baseDir))
        {
            Directory.CreateDirectory(baseDir);
        }

        string fileName = Path.Combine(baseDir, $"Node_{nodeIndex}_Scale_{scale}.png");

        using (Aspose.Slides.IImage image = shape.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, scale, scale))
        {
            image.Save(fileName, Aspose.Slides.ImageFormat.Png);
        }
    }
}