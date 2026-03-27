using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // Load the presentation from the input file
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Iterate through all slides in the presentation
        for (int i = 0; i < pres.Slides.Count; i++)
        {
            Aspose.Slides.ISlide slide = pres.Slides[i];

            // Iterate through all shapes on the slide
            for (int j = 0; j < slide.Shapes.Count; j++)
            {
                Aspose.Slides.IShape shape = slide.Shapes[j];

                // Check if the shape is a SmartArt diagram
                Aspose.Slides.SmartArt.ISmartArt smartArt = shape as Aspose.Slides.SmartArt.ISmartArt;
                if (smartArt != null && smartArt.Layout == Aspose.Slides.SmartArt.SmartArtLayoutType.OrganizationChart)
                {
                    // Loop through all nodes in the organization chart
                    foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smartArt.AllNodes)
                    {
                        // If the node is marked as an assistant, clear the flag
                        if (node.IsAssistant)
                        {
                            node.IsAssistant = false;
                        }
                    }
                }
            }
        }

        // Save the modified presentation
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}