using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SmartArtPatternPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output directory
            string outputDir = "output";
            if (!System.IO.Directory.Exists(outputDir))
                System.IO.Directory.CreateDirectory(outputDir);

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a SmartArt diagram
            Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(50, 50, 600, 400, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

            // Add three nodes and set pattern fill for each shape in the node
            for (int i = 0; i < 3; i++)
            {
                Aspose.Slides.SmartArt.ISmartArtNode node = smartArt.AllNodes.AddNode();
                node.TextFrame.Text = "Node " + (i + 1).ToString();

                foreach (Aspose.Slides.SmartArt.ISmartArtShape shape in node.Shapes)
                {
                    // Set fill type to pattern
                    shape.FillFormat.FillType = Aspose.Slides.FillType.Pattern;

                    // Configure pattern style and colors
                    shape.FillFormat.PatternFormat.PatternStyle = Aspose.Slides.PatternStyle.DiagonalCross;
                    shape.FillFormat.PatternFormat.ForeColor.Color = System.Drawing.Color.Blue;
                    shape.FillFormat.PatternFormat.BackColor.Color = System.Drawing.Color.Yellow;
                }
            }

            // Save the presentation as PDF with default options
            try
            {
                Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
                presentation.Save(System.IO.Path.Combine(outputDir, "SmartArtPattern.pdf"), Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }

            // Save the presentation before exit (optional PPTX output)
            presentation.Save(System.IO.Path.Combine(outputDir, "SmartArtPattern.pptx"), Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up
            presentation.Dispose();
        }
    }
}