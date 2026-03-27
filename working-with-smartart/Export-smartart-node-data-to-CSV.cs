using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SmartArtCsvReport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a Closed Chevron Process SmartArt
            Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(
                10, 10, 800, 60, Aspose.Slides.SmartArt.SmartArtLayoutType.ClosedChevronProcess);

            // Add first node and set its text
            Aspose.Slides.SmartArt.ISmartArtNode node1 = smartArt.AllNodes.AddNode();
            node1.TextFrame.Text = "First Node";

            // Set fill color for shapes in the first node
            foreach (Aspose.Slides.SmartArt.ISmartArtShape shape in node1.Shapes)
            {
                shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                shape.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;
            }

            // Add second node and set its text
            Aspose.Slides.SmartArt.ISmartArtNode node2 = smartArt.AllNodes.AddNode();
            node2.TextFrame.Text = "Second Node";
            node2.IsAssistant = true; // Mark as assistant

            // Set fill color for shapes in the second node
            foreach (Aspose.Slides.SmartArt.ISmartArtShape shape in node2.Shapes)
            {
                shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                shape.FillFormat.SolidFillColor.Color = System.Drawing.Color.Blue;
            }

            // Generate CSV report
            string csvPath = "SmartArtReport.csv";
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(csvPath))
            {
                writer.WriteLine("Text,FillColor,IsAssistant");
                foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smartArt.AllNodes)
                {
                    string text = node.TextFrame.Text;
                    string fillColor = "None";

                    if (node.Shapes.Count > 0)
                    {
                        Aspose.Slides.SmartArt.ISmartArtShape shape = node.Shapes[0];
                        if (shape.FillFormat.FillType == Aspose.Slides.FillType.Solid)
                        {
                            fillColor = shape.FillFormat.SolidFillColor.Color.Name;
                        }
                    }

                    string isAssistant = node.IsAssistant.ToString();
                    writer.WriteLine($"{text},{fillColor},{isAssistant}");
                }
            }

            // Save the presentation
            presentation.Save("SmartArtOutput.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}