using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Check if input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Load presentation with exception handling for unsupported formats
        Presentation presentation = null;
        try
        {
            presentation = new Presentation(inputPath);
        }
        catch (Exception ex)
        {
            // Format not supported or other loading error
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            return;
        }

        // Iterate through slides and shapes to find SmartArt diagrams
        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
        {
            ISlide slide = presentation.Slides[slideIndex];
            foreach (IShape shape in slide.Shapes)
            {
                if (shape is Aspose.Slides.SmartArt.ISmartArt)
                {
                    Aspose.Slides.SmartArt.ISmartArt smartArt = (Aspose.Slides.SmartArt.ISmartArt)shape;
                    Aspose.Slides.SmartArt.ISmartArtNodeCollection allNodes = smartArt.AllNodes;
                    int nodeIndex = 0;
                    foreach (Aspose.Slides.SmartArt.ISmartArtNode node in allNodes)
                    {
                        if (node.IsHidden)
                        {
                            Console.WriteLine($"Hidden node found at slide {slideIndex}, node index {nodeIndex}");
                        }
                        nodeIndex++;
                    }
                }
            }
        }

        // Save presentation before exit
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}