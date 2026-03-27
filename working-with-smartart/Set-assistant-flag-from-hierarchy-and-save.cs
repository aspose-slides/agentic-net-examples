using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";
        string hierarchyPath = "hierarchy.txt";

        // Verify input presentation exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // Verify hierarchy data file exists
        if (!File.Exists(hierarchyPath))
        {
            Console.WriteLine("Hierarchy data file does not exist: " + hierarchyPath);
            return;
        }

        // Load hierarchy data into a dictionary (node index -> IsAssistant flag)
        System.Collections.Generic.Dictionary<int, bool> assistantMap = new System.Collections.Generic.Dictionary<int, bool>();
        string[] lines = File.ReadAllLines(hierarchyPath);
        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            string[] parts = line.Split(',');
            if (parts.Length != 2)
                continue;

            int nodeIndex;
            bool isAssistant;
            if (int.TryParse(parts[0].Trim(), out nodeIndex) && bool.TryParse(parts[1].Trim(), out isAssistant))
            {
                assistantMap[nodeIndex] = isAssistant;
            }
        }

        // Load presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
        try
        {
            // Assume we work with the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Iterate through shapes to find SmartArt diagrams
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                if (shape is Aspose.Slides.SmartArt.ISmartArt)
                {
                    Aspose.Slides.SmartArt.ISmartArt smartArt = (Aspose.Slides.SmartArt.ISmartArt)shape;

                    // Iterate over all nodes and set IsAssistant based on hierarchy data
                    for (int i = 0; i < smartArt.AllNodes.Count; i++)
                    {
                        Aspose.Slides.SmartArt.ISmartArtNode node = smartArt.AllNodes[i];
                        bool flag;
                        if (assistantMap.TryGetValue(i, out flag))
                        {
                            node.IsAssistant = flag;
                        }
                    }
                }
            }

            // Save the modified presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        finally
        {
            // Ensure resources are released
            pres.Dispose();
        }
    }
}