using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
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
            try
            {
                ISlide slide = pres.Slides[0];
                foreach (IShape shape in slide.Shapes)
                {
                    if (shape is ISmartArt)
                    {
                        ISmartArt smart = (ISmartArt)shape;
                        if (smart.AllNodes.Count > 0)
                        {
                            ISmartArtNode node = smart.AllNodes[0];
                            // Set the node as assistant
                            node.IsAssistant = true;
                            // Verify hierarchical indentation via Level property
                            int level = node.Level;
                            Console.WriteLine($"Node level after setting IsAssistant: {level}");
                        }
                    }
                }
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            finally
            {
                pres.Dispose();
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}