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
                Console.WriteLine("Input file does not exist.");
                return;
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or loading errors
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            List<string> reportLines = new List<string>();

            foreach (Aspose.Slides.ISlide slide in presentation.Slides)
            {
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    if (shape is Aspose.Slides.SmartArt.ISmartArt)
                    {
                        Aspose.Slides.SmartArt.ISmartArt smartArt = (Aspose.Slides.SmartArt.ISmartArt)shape;
                        Aspose.Slides.SmartArt.ISmartArtNodeCollection allNodes = smartArt.AllNodes;
                        foreach (Aspose.Slides.SmartArt.ISmartArtNode node in allNodes)
                        {
                            ProcessNode(node, reportLines);
                        }
                    }
                }
            }

            Console.WriteLine("Assistant Nodes Report:");
            foreach (string line in reportLines)
            {
                Console.WriteLine(line);
            }

            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle save errors (e.g., unsupported format)
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }
            finally
            {
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }

        private static void ProcessNode(Aspose.Slides.SmartArt.ISmartArtNode parentNode, List<string> report)
        {
            Aspose.Slides.SmartArt.ISmartArtNodeCollection childNodes = parentNode.ChildNodes;
            foreach (Aspose.Slides.SmartArt.ISmartArtNode child in childNodes)
            {
                if (child.IsAssistant)
                {
                    string parentText = parentNode.TextFrame != null ? parentNode.TextFrame.Text : "(no text)";
                    string assistantText = child.TextFrame != null ? child.TextFrame.Text : "(no text)";
                    report.Add($"Parent: \"{parentText}\" -> Assistant: \"{assistantText}\"");
                }
                // Recursively process deeper levels
                ProcessNode(child, report);
            }
        }
    }
}