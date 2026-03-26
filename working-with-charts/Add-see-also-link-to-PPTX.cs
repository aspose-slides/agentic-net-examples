using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InsertSeeAlsoReference
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            // Load existing presentation if it exists, otherwise create a new one
            Presentation presentation;
            if (File.Exists(inputPath))
            {
                presentation = new Presentation(inputPath);
            }
            else
            {
                presentation = new Presentation();
                // Ensure there is a second slide to link to
                presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            }

            // Get the first slide (where the "See also" reference will be placed)
            var slide = presentation.Slides[0];

            // Add a rectangle auto shape to hold the hyperlink text
            var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 50);
            shape.AddTextFrame("See also");

            // Access the first portion of the text frame
            var portion = shape.TextFrame.Paragraphs[0].Portions[0];

            // Obtain the hyperlink manager for the portion
            var hyperlinkManager = portion.PortionFormat.HyperlinkManager;

            // Define the target slide (second slide) for the internal hyperlink
            var targetSlide = presentation.Slides[1];

            // Set internal hyperlink on click to the target slide
            hyperlinkManager.SetInternalHyperlinkClick(targetSlide);

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Clean up resources
            presentation.Dispose();
        }
    }
}