using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;
using Aspose.Slides.Export;

namespace SmartArtExample
{
    class Program
    {
        static void Main()
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a SmartArt diagram to the slide
            Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(20, 20, 600, 500, Aspose.Slides.SmartArt.SmartArtLayoutType.OrganizationChart);

            // Get the first (parent) node of the SmartArt
            Aspose.Slides.SmartArt.ISmartArtNode parentNode = smartArt.AllNodes[0];

            // Add first child node at position 0
            Aspose.Slides.SmartArt.SmartArtNode childNode1 = (Aspose.Slides.SmartArt.SmartArtNode)((Aspose.Slides.SmartArt.SmartArtNodeCollection)parentNode.ChildNodes).AddNodeByPosition(0);
            childNode1.TextFrame.Text = "Child 1";
            childNode1.Position = 0; // Set position relative to siblings

            // Add second child node at position 1
            Aspose.Slides.SmartArt.SmartArtNode childNode2 = (Aspose.Slides.SmartArt.SmartArtNode)((Aspose.Slides.SmartArt.SmartArtNodeCollection)parentNode.ChildNodes).AddNodeByPosition(1);
            childNode2.TextFrame.Text = "Child 2";
            childNode2.Position = 1; // Set position relative to siblings

            // Add third child node at position 2
            Aspose.Slides.SmartArt.SmartArtNode childNode3 = (Aspose.Slides.SmartArt.SmartArtNode)((Aspose.Slides.SmartArt.SmartArtNodeCollection)parentNode.ChildNodes).AddNodeByPosition(2);
            childNode3.TextFrame.Text = "Child 3";
            childNode3.Position = 2; // Set position relative to siblings

            // Save the presentation
            presentation.Save("SmartArtWithChildren.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}