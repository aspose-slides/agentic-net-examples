using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace SmartArtPatternFillPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output directory and ensure it exists
            string outputDir = "Output";
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a SmartArt diagram to the slide
            Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(
                10,          // X position
                10,          // Y position
                600,         // Width
                400,         // Height
                Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

            // Add a few nodes with sample text
            Aspose.Slides.SmartArt.ISmartArtNode node1 = smartArt.AllNodes.AddNode();
            node1.TextFrame.Text = "First Node";

            Aspose.Slides.SmartArt.ISmartArtNode node2 = smartArt.AllNodes.AddNode();
            node2.TextFrame.Text = "Second Node";

            // Apply pattern fill to each shape within each node
            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smartArt.AllNodes)
            {
                foreach (Aspose.Slides.SmartArt.ISmartArtShape shape in node.Shapes)
                {
                    // Set fill type to Pattern
                    shape.FillFormat.FillType = Aspose.Slides.FillType.Pattern;

                    // Choose a pattern style
                    shape.FillFormat.PatternFormat.PatternStyle = Aspose.Slides.PatternStyle.DarkHorizontal;

                    // Set foreground and background colors for the pattern
                    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Red;
                    shape.FillFormat.PatternFormat.BackColor.Color = Color.Yellow;
                }
            }

            // Save the presentation as PDF
            string outputPath = Path.Combine(outputDir, "SmartArtPattern.pdf");
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}