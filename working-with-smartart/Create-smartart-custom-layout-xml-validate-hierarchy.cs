using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SmartArtCustomLayoutExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output path
            string outputPath = "CustomSmartArt.pptx";

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a SmartArt diagram with OrganizationChart layout
            Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(
                20f, 20f, 600f, 500f,
                Aspose.Slides.SmartArt.SmartArtLayoutType.OrganizationChart);

            // Build custom hierarchy:
            // Root node (already exists)
            Aspose.Slides.SmartArt.ISmartArtNode rootNode = smartArt.Nodes[0];

            // Add first child to root
            Aspose.Slides.SmartArt.ISmartArtNode childNode1 = rootNode.ChildNodes.AddNode();
            childNode1.Position = 0;
            childNode1.OrganizationChartLayout = Aspose.Slides.SmartArt.OrganizationChartLayoutType.LeftHanging;

            // Add second child to root
            Aspose.Slides.SmartArt.ISmartArtNode childNode2 = rootNode.ChildNodes.AddNode();
            childNode2.Position = 1;
            childNode2.OrganizationChartLayout = Aspose.Slides.SmartArt.OrganizationChartLayoutType.LeftHanging;

            // Add a sub‑child to the first child
            Aspose.Slides.SmartArt.ISmartArtNode subChildNode = childNode1.ChildNodes.AddNode();
            subChildNode.Position = 0;
            subChildNode.OrganizationChartLayout = Aspose.Slides.SmartArt.OrganizationChartLayoutType.LeftHanging;

            // Validate hierarchy: each child level should be parent level + 1
            bool hierarchyValid = true;
            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smartArt.AllNodes)
            {
                if (node.ChildNodes.Count > 0)
                {
                    foreach (Aspose.Slides.SmartArt.ISmartArtNode child in node.ChildNodes)
                    {
                        if (child.Level != node.Level + 1)
                        {
                            hierarchyValid = false;
                            break;
                        }
                    }
                }
                if (!hierarchyValid) break;
            }

            Console.WriteLine("Hierarchy valid: " + hierarchyValid);

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}