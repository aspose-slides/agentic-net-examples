using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.SmartArt;
using Aspose.Slides.Export;

namespace RemoveAssistantsFromOrgChart
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "OrgChart.pptx");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "OrgChart_Updated.pptx");

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Presentation pres = new Presentation(inputPath);
            ISlide slide = pres.Slides[0];

            // Assume the first shape is the organization chart SmartArt
            Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes[0] as Aspose.Slides.SmartArt.ISmartArt;
            if (smartArt == null)
            {
                Console.WriteLine("No SmartArt shape found on the first slide.");
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                return;
            }

            // Remove assistant nodes recursively
            for (int i = 0; i < smartArt.Nodes.Count; i++)
            {
                RemoveAssistantNodes(smartArt.Nodes[i]);
            }

            // Save the updated presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }

        private static void RemoveAssistantNodes(Aspose.Slides.SmartArt.ISmartArtNode node)
        {
            // Process child nodes from last to first to avoid index issues when removing
            for (int i = node.ChildNodes.Count - 1; i >= 0; i--)
            {
                Aspose.Slides.SmartArt.ISmartArtNode child = node.ChildNodes[i];
                if (child.IsAssistant)
                {
                    child.Remove();
                }
                else
                {
                    // Recursively process non‑assistant children
                    RemoveAssistantNodes(child);
                }
            }
        }
    }
}