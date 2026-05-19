using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace SmartArtExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a SmartArt diagram to the slide
            ISmartArt smartArt = slide.Shapes.AddSmartArt(10, 10, 800, 60, SmartArtLayoutType.BasicCycle);

            // Add a new node to the SmartArt
            ISmartArtNode node = smartArt.AllNodes.AddNode();

            // Set text for the new node
            node.TextFrame.Text = "New Node";

            // Apply solid fill using the theme's Accent1 color to each shape in the node
            foreach (ISmartArtShape shape in node.Shapes)
            {
                shape.FillFormat.FillType = FillType.Solid;
                shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent1;
            }

            // Save the presentation
            presentation.Save("output.pptx", SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}