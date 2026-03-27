using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        var inputPath = "input.pptx";
        var outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        var presentation = new Aspose.Slides.Presentation(inputPath);

        foreach (var slide in presentation.Slides)
        {
            foreach (var shape in slide.Shapes)
            {
                if (shape is Aspose.Slides.SmartArt.ISmartArt smartArt)
                {
                    foreach (var node in smartArt.AllNodes)
                    {
                        var textFrame = node.TextFrame;
                        if (textFrame != null && textFrame.Paragraphs.Count > 0)
                        {
                            var paragraph = textFrame.Paragraphs[0];
                            if (paragraph.Portions.Count > 0)
                            {
                                var portion = paragraph.Portions[0];
                                portion.PortionFormat.FontHeight += 2;
                            }
                        }
                    }
                }
            }
        }

        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}