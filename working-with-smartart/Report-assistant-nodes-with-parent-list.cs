using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace SmartArtAssistantReport
{
    class Program
    {
        static void Main()
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Presentation presentation = null;
            try
            {
                presentation = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            List<string> reportLines = new List<string>();

            ISlide slide = presentation.Slides[0];
            foreach (IShape shape in slide.Shapes)
            {
                if (shape is ISmartArt)
                {
                    ISmartArt smartArt = (ISmartArt)shape;
                    foreach (ISmartArtNode node in smartArt.AllNodes)
                    {
                        if (node.IsAssistant)
                        {
                            ISmartArtNode parentNode = FindParent(smartArt, node);
                            string parentText = (parentNode != null && parentNode.TextFrame != null) ? parentNode.TextFrame.Text : "None";
                            string nodeText = (node.TextFrame != null) ? node.TextFrame.Text : "No Text";
                            reportLines.Add($"Assistant Node: '{nodeText}' Parent: '{parentText}'");
                        }
                    }
                }
            }

            foreach (string line in reportLines)
            {
                Console.WriteLine(line);
            }

            try
            {
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }
            finally
            {
                presentation.Dispose();
            }
        }

        private static ISmartArtNode FindParent(ISmartArt smartArt, ISmartArtNode targetNode)
        {
            foreach (ISmartArtNode node in smartArt.AllNodes)
            {
                foreach (ISmartArtNode child in node.ChildNodes)
                {
                    if (object.ReferenceEquals(child, targetNode))
                    {
                        return node;
                    }
                }
            }
            return null;
        }
    }
}