using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace SmartArtNodeInsertExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a SmartArt diagram to the slide
                Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(
                    10, 10, 400, 300, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

                // Add initial nodes
                Aspose.Slides.SmartArt.ISmartArtNode node1 = smartArt.AllNodes.AddNode();
                node1.TextFrame.Text = "Node 1";

                Aspose.Slides.SmartArt.ISmartArtNode node2 = smartArt.AllNodes.AddNode();
                node2.TextFrame.Text = "Node 2";

                Aspose.Slides.SmartArt.ISmartArtNode node3 = smartArt.AllNodes.AddNode();
                node3.TextFrame.Text = "Node 3";

                // Insert a new node at index 3 (zero‑based)
                Aspose.Slides.SmartArt.ISmartArtNode insertedNode = smartArt.AllNodes.AddNodeByPosition(3);
                insertedNode.TextFrame.Text = "Inserted Node";

                // Apply a custom fill color to the shapes of the inserted node
                foreach (Aspose.Slides.SmartArt.ISmartArtShape shape in insertedNode.Shapes)
                {
                    shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    shape.FillFormat.SolidFillColor.Color = Color.Green;
                }

                // Save the presentation
                string outputPath = "SmartArtNodeInsert.pptx";
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Dispose the presentation
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format, file I/O errors)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}