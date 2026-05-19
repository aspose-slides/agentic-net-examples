using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        var inputPath = "input.pptx";
        var outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found.");
            return;
        }

        try
        {
            var presentation = new Aspose.Slides.Presentation(inputPath);

            foreach (var slide in presentation.Slides)
            {
                foreach (var shape in slide.Shapes)
                {
                    if (shape is Aspose.Slides.SmartArt.ISmartArt smartArt)
                    {
                        var nodes = smartArt.AllNodes;
                        foreach (var node in nodes)
                        {
                            foreach (var smartShape in node.Shapes)
                            {
                                if (smartShape.TextFrame != null)
                                {
                                    Console.WriteLine(smartShape.TextFrame.Text);
                                }
                            }
                        }
                    }
                }
            }

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The provided file format is not supported.");
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}