using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            using (Presentation presentation = new Presentation(inputPath))
            {
                foreach (ISlide slide in presentation.Slides)
                {
                    foreach (IShape shape in slide.Shapes)
                    {
                        if (shape is Aspose.Slides.SmartArt.SmartArt)
                        {
                            Aspose.Slides.SmartArt.SmartArt smartArt = (Aspose.Slides.SmartArt.SmartArt)shape;
                            IterateSmartArtNodes(smartArt.AllNodes);
                        }
                    }
                }

                presentation.Save(outputPath, SaveFormat.Pptx);
            }
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

    static void IterateSmartArtNodes(ISmartArtNodeCollection nodes)
    {
        foreach (ISmartArtNode node in nodes)
        {
            if (node.TextFrame != null)
            {
                foreach (IParagraph paragraph in node.TextFrame.Paragraphs)
                {
                    foreach (IPortion portion in paragraph.Portions)
                    {
                        portion.PortionFormat.LatinFont = new FontData("Arial");
                    }
                }
            }

            if (node.ChildNodes != null && node.ChildNodes.Count > 0)
            {
                IterateSmartArtNodes(node.ChildNodes);
            }
        }
    }
}