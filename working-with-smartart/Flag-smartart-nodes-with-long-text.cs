using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace SmartArtTextTruncate
{
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

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                int slideCount = presentation.Slides.Count;
                for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        if (shape is Aspose.Slides.SmartArt.ISmartArt)
                        {
                            Aspose.Slides.SmartArt.ISmartArt smartArt = (Aspose.Slides.SmartArt.ISmartArt)shape;
                            ProcessSmartArtNodes(smartArt.AllNodes);
                        }
                    }
                }

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }

        private static void ProcessSmartArtNodes(Aspose.Slides.SmartArt.ISmartArtNodeCollection nodes)
        {
            int nodeCount = nodes.Count;
            for (int i = 0; i < nodeCount; i++)
            {
                Aspose.Slides.SmartArt.ISmartArtNode node = nodes[i];

                // Truncate text in the node itself
                if (node.TextFrame != null && node.TextFrame.Text != null)
                {
                    string text = node.TextFrame.Text;
                    if (text.Length > 50)
                    {
                        node.TextFrame.Text = text.Substring(0, 50);
                    }
                }

                // Truncate text in each shape of the node
                foreach (Aspose.Slides.SmartArt.ISmartArtShape shape in node.Shapes)
                {
                    if (shape.TextFrame != null && shape.TextFrame.Text != null)
                    {
                        string shapeText = shape.TextFrame.Text;
                        if (shapeText.Length > 50)
                        {
                            shape.TextFrame.Text = shapeText.Substring(0, 50);
                        }
                    }
                }

                // Recursively process child nodes
                if (node.ChildNodes != null && node.ChildNodes.Count > 0)
                {
                    ProcessSmartArtNodes(node.ChildNodes);
                }
            }
        }
    }
}