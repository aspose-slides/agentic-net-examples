using System;
using System.IO;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        Aspose.Slides.SmartArt.ISmartArt chevron = slide.Shapes.AddSmartArt(10, 10, 800, 60, Aspose.Slides.SmartArt.SmartArtLayoutType.ClosedChevronProcess);

        // Add first node
        Aspose.Slides.SmartArt.ISmartArtNode node1 = chevron.AllNodes.AddNode();
        node1.TextFrame.Text = "Node 1";
        foreach (Aspose.Slides.SmartArt.ISmartArtShape shape in node1.Shapes)
        {
            shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            shape.FillFormat.SolidFillColor.Color = Color.Red;
        }

        // Add second node (assistant)
        Aspose.Slides.SmartArt.ISmartArtNode node2 = chevron.AllNodes.AddNode();
        node2.TextFrame.Text = "Node 2";
        node2.IsAssistant = true;
        foreach (Aspose.Slides.SmartArt.ISmartArtShape shape in node2.Shapes)
        {
            shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            shape.FillFormat.SolidFillColor.Color = Color.Green;
        }

        // Add third node
        Aspose.Slides.SmartArt.ISmartArtNode node3 = chevron.AllNodes.AddNode();
        node3.TextFrame.Text = "Node 3";
        foreach (Aspose.Slides.SmartArt.ISmartArtShape shape in node3.Shapes)
        {
            shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            shape.FillFormat.SolidFillColor.Color = Color.Blue;
        }

        // Generate CSV report
        string csvPath = "SmartArtReport.csv";
        using (StreamWriter writer = new StreamWriter(csvPath))
        {
            writer.WriteLine("Text,FillColor,IsAssistant");
            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in chevron.AllNodes)
            {
                string text = node.TextFrame.Text;
                bool isAssistant = node.IsAssistant;
                string fillColor = "Unknown";

                foreach (Aspose.Slides.SmartArt.ISmartArtShape shape in node.Shapes)
                {
                    if (shape.FillFormat.FillType == Aspose.Slides.FillType.Solid)
                    {
                        Color color = shape.FillFormat.SolidFillColor.Color;
                        fillColor = color.Name;
                    }
                    break; // only first shape
                }

                writer.WriteLine(string.Format("{0},{1},{2}", text, fillColor, isAssistant));
            }
        }

        // Save the presentation
        presentation.Save("SmartArtPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}