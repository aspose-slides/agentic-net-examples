using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Presentation pres = new Presentation(inputPath);

            // Iterate through slides to find SmartArt organization chart
            for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
            {
                ISlide slide = pres.Slides[slideIndex];
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    ISmartArt smartArt = slide.Shapes[shapeIndex] as ISmartArt;
                    if (smartArt != null)
                    {
                        // Remove assistant nodes recursively
                        RemoveAssistantNodes(smartArt.Nodes);
                    }
                }
            }

            pres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }

    static void RemoveAssistantNodes(ISmartArtNodeCollection nodes)
    {
        for (int i = nodes.Count - 1; i >= 0; i--)
        {
            ISmartArtNode node = nodes[i];
            if (node.IsAssistant)
            {
                node.Remove();
            }
            else
            {
                // Process child nodes
                RemoveAssistantNodes(node.ChildNodes);
            }
        }
    }
}