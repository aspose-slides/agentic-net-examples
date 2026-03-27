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
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a SmartArt diagram to the slide
            Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(
                10, 10, 400, 300, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicCycle);

            // Add a new node to the SmartArt diagram
            Aspose.Slides.SmartArt.ISmartArtNode node = smartArt.Nodes.AddNode();

            // Set a long paragraph as the node's text
            node.TextFrame.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                                 "Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. " +
                                 "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris " +
                                 "nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in " +
                                 "reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.";

            // Enable text wrapping within the node
            node.TextFrame.TextFrameFormat.WrapText = Aspose.Slides.NullableBool.True;

            // Save the presentation
            presentation.Save("SmartArtWithWrappedText.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up
            presentation.Dispose();
        }
    }
}