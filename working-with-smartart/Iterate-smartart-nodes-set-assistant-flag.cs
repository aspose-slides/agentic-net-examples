using System;
using System.IO;
using Aspose.Slides.Export;

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

        Aspose.Slides.Presentation pres = null;
        try
        {
            pres = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.ISlide slide = pres.Slides[0];
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                if (shape is Aspose.Slides.SmartArt.ISmartArt)
                {
                    Aspose.Slides.SmartArt.ISmartArt smart = (Aspose.Slides.SmartArt.ISmartArt)shape;
                    foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smart.AllNodes)
                    {
                        // Example hierarchy logic: set assistant flag based on external data
                        // Here we simply clear the assistant flag for demonstration
                        if (node.IsAssistant)
                        {
                            node.IsAssistant = false;
                        }
                    }
                }
            }
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            // Format not supported
        }
        finally
        {
            if (pres != null)
            {
                pres.Dispose();
            }
        }
    }
}