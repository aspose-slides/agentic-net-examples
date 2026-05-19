using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputJson = "smartart.json";
        string outputPptx = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            List<object> nodesList = new List<object>();

            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                if (shape is Aspose.Slides.SmartArt.SmartArt)
                {
                    Aspose.Slides.SmartArt.SmartArt smartArt = (Aspose.Slides.SmartArt.SmartArt)shape;
                    foreach (Aspose.Slides.SmartArt.ISmartArtNode rootNode in smartArt.AllNodes)
                    {
                        nodesList.Add(ProcessNode(rootNode));
                    }
                }
            }

            string json = System.Text.Json.JsonSerializer.Serialize(nodesList, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(outputJson, json);

            presentation.Save(outputPptx, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static object ProcessNode(Aspose.Slides.SmartArt.ISmartArtNode node)
    {
        List<object> childList = new List<object>();
        foreach (Aspose.Slides.SmartArt.ISmartArtNode child in node.ChildNodes)
        {
            childList.Add(ProcessNode(child));
        }

        return new
        {
            Text = node.TextFrame != null ? node.TextFrame.Text : null,
            Level = node.Level,
            Position = node.Position,
            Children = childList
        };
    }
}