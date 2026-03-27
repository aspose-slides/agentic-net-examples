using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Load existing presentation if it exists; otherwise create a new one
        Aspose.Slides.Presentation presentation;
        if (File.Exists(inputPath))
        {
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        else
        {
            presentation = new Aspose.Slides.Presentation();
        }

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Locate the first SmartArt object on the slide
        Aspose.Slides.SmartArt.ISmartArt smartArt = null;
        for (int i = 0; i < slide.Shapes.Count; i++)
        {
            Aspose.Slides.IShape shape = slide.Shapes[i];
            smartArt = shape as Aspose.Slides.SmartArt.ISmartArt;
            if (smartArt != null)
            {
                break;
            }
        }

        // If a SmartArt diagram is found, clear the IsAssistant flag on the first assistant node
        if (smartArt != null)
        {
            Aspose.Slides.SmartArt.ISmartArtNodeCollection allNodes = smartArt.AllNodes;
            for (int i = 0; i < allNodes.Count; i++)
            {
                Aspose.Slides.SmartArt.ISmartArtNode node = allNodes[i];
                if (node.IsAssistant)
                {
                    node.IsAssistant = false;
                    break; // Assuming only one assistant node needs to be cleared
                }
            }
        }

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}