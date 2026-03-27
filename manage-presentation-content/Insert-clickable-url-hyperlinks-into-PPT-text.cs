using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace HyperlinkDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Add a rectangle auto shape to the first slide
                Aspose.Slides.IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle,
                    50,   // X position
                    50,   // Y position
                    400,  // Width
                    50,   // Height
                    false // isGrouped
                );

                // Add a text frame with placeholder text
                shape.AddTextFrame("Click here to visit example.com");

                // Set an external hyperlink on the first portion of the first paragraph
                shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Aspose.Slides.Hyperlink("https://www.example.com");
                shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "Visit Example.com";
                shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 20;

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }

            Console.WriteLine("Presentation saved to: " + outputPath);
        }
    }
}