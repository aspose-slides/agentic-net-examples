using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        Presentation pres = null;
        try
        {
            pres = new Presentation(inputPath);
            ISlide slide = pres.Slides[0];
            foreach (IShape shape in slide.Shapes)
            {
                if (shape is ISmartArt)
                {
                    ISmartArt smart = (ISmartArt)shape;
                    foreach (ISmartArtNode node in smart.AllNodes)
                    {
                        // Example external hierarchy logic: set assistant flag based on node position
                        if (node.Position % 2 == 0)
                        {
                            node.IsAssistant = true;
                        }
                        else
                        {
                            node.IsAssistant = false;
                        }
                    }
                }
            }
            pres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            // Format not supported comment
        }
        finally
        {
            if (pres != null)
                pres.Dispose();
        }
    }
}