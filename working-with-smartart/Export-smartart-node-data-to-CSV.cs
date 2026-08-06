// -----------------------------------------------------------------------------
// Example: Export smartart node data to CSV using C#
//
// Description:
// Demonstrates how to create a presentation, add a SmartArt diagram, populate
// nodes with text, fill color and assistant status, and export the node data
// (text, fill color, assistant flag) to a CSV file using Aspose.Slides for .NET.
// The example also saves the generated presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, SmartArt, Node, CSV,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of SmartArt node information to CSV for reporting.
// - Build .NET tools that process PowerPoint presentations and generate data
//   extracts.
// - Integrate SmartArt analysis into document management or analytics pipelines.
// - Validate SmartArt content programmatically before publishing.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace SmartArtCsvReport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a SmartArt diagram
            ISmartArt smartArt = slide.Shapes.AddSmartArt(10, 10, 800, 200, SmartArtLayoutType.ClosedChevronProcess);

            // Add sample nodes with text, fill color, and assistant status
            for (int i = 0; i < 3; i++)
            {
                ISmartArtNode node = smartArt.AllNodes.AddNode();
                node.TextFrame.Text = "Node " + i;

                // Set fill color for the first shape of the node
                foreach (ISmartArtShape shape in node.Shapes)
                {
                    shape.FillFormat.FillType = FillType.Solid;
                    shape.FillFormat.SolidFillColor.Color = Color.FromArgb(255, i * 80, 0);
                    break; // Only need to set one shape
                }

                // Mark the second node as an assistant
                node.IsAssistant = (i == 1);
            }

            // Generate CSV report
            string csvPath = "SmartArtReport.csv";
            using (StreamWriter writer = new StreamWriter(csvPath))
            {
                writer.WriteLine("Text,FillColor,IsAssistant");
                foreach (ISmartArtNode node in smartArt.AllNodes)
                {
                    string text = node.TextFrame.Text;
                    Color fillColor = Color.Empty;

                    // Retrieve fill color from the first shape of the node
                    foreach (ISmartArtShape shape in node.Shapes)
                    {
                        if (shape.FillFormat != null && shape.FillFormat.FillType == FillType.Solid)
                        {
                            fillColor = shape.FillFormat.SolidFillColor.Color;
                            break;
                        }
                    }

                    bool isAssistant = node.IsAssistant;
                    writer.WriteLine($"{text},{fillColor.Name},{isAssistant}");
                }
            }

            // Save the presentation
            try
            {
                presentation.Save("SmartArtOutput.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Format not supported
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}
