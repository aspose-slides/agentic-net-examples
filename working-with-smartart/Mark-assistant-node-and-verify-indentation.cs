using System;
using System.IO;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
            try
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Iterate through shapes to find a SmartArt diagram
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    if (shape is Aspose.Slides.SmartArt.ISmartArt)
                    {
                        Aspose.Slides.SmartArt.ISmartArt smartArt = (Aspose.Slides.SmartArt.ISmartArt)shape;

                        // Iterate through all nodes
                        foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smartArt.AllNodes)
                        {
                            // Set the node as an assistant
                            node.IsAssistant = true;

                            // Verify hierarchical indentation via the Level property
                            Console.WriteLine("Node Text: " + node.TextFrame.Text);
                            Console.WriteLine("Level: " + node.Level);
                            Console.WriteLine("IsAssistant: " + node.IsAssistant);
                            
                            // Demonstrate that assistant status may affect indentation (Level remains unchanged)
                            // Break after processing the first node for brevity
                            break;
                        }
                    }
                }

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            finally
            {
                // Dispose the presentation object
                pres.Dispose();
            }
        }
    }
}