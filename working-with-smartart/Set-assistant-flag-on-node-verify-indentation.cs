using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        Aspose.Slides.Presentation pres = null;
        try
        {
            // Load the presentation
            pres = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            return;
        }

        try
        {
            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Iterate through shapes to find SmartArt
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                if (shape is Aspose.Slides.SmartArt.SmartArt)
                {
                    Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

                    // Ensure there is at least one node
                    if (smart.AllNodes.Count > 0)
                    {
                        // Get the first node
                        Aspose.Slides.SmartArt.ISmartArtNode node = smart.AllNodes[0];

                        // Set the node as an assistant
                        node.IsAssistant = true;

                        // Verify hierarchical indentation via Level property
                        int level = node.Level;
                        Console.WriteLine("Node Level after setting IsAssistant: " + level);
                    }
                }
            }

            // Save the modified presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error processing presentation: " + ex.Message);
        }
        finally
        {
            // Dispose the presentation
            if (pres != null)
                pres.Dispose();
        }
    }
}