using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a SmartArt diagram to the slide
            Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(10, 10, 800, 400, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

            // Add a few nodes to the SmartArt
            Aspose.Slides.SmartArt.ISmartArtNode node1 = smartArt.AllNodes.AddNode();
            node1.TextFrame.Text = "Node 1";
            Aspose.Slides.SmartArt.ISmartArtNode node2 = smartArt.AllNodes.AddNode();
            node2.TextFrame.Text = "Node 2";
            Aspose.Slides.SmartArt.ISmartArtNode node3 = smartArt.AllNodes.AddNode();
            node3.TextFrame.Text = "Node 3";

            // Apply radial gradient fill to each shape within each node
            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smartArt.AllNodes)
            {
                foreach (Aspose.Slides.SmartArt.ISmartArtShape shape in node.Shapes)
                {
                    shape.FillFormat.FillType = Aspose.Slides.FillType.Gradient;
                    shape.FillFormat.GradientFormat.GradientShape = Aspose.Slides.GradientShape.Radial;
                    // Add gradient stops (0% and 100%)
                    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, Aspose.Slides.PresetColor.Red);
                    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, Aspose.Slides.PresetColor.Blue);
                }
            }

            // Define output paths
            string outputDir = "Output";
            if (!System.IO.Directory.Exists(outputDir))
            {
                System.IO.Directory.CreateDirectory(outputDir);
            }
            string pptxPath = System.IO.Path.Combine(outputDir, "SmartArtRadialGradient.pptx");
            string jpegPath = System.IO.Path.Combine(outputDir, "SlideImage.jpg");

            // Save the presentation
            presentation.Save(pptxPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Export the first slide as JPEG with full scale
            float scaleX = 1.0f;
            float scaleY = 1.0f;
            using (Aspose.Slides.IImage slideImage = slide.GetImage(scaleX, scaleY))
            {
                slideImage.Save(jpegPath, Aspose.Slides.ImageFormat.Jpeg);
            }

            // Dispose the presentation
            presentation.Dispose();

            Console.WriteLine("Presentation and slide image have been saved to: " + outputDir);
        }
    }
}