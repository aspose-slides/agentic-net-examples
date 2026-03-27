using System;
using System.IO;
using Aspose.Slides;
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

        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        foreach (Aspose.Slides.IShape shape in pres.Slides[0].Shapes)
        {
            if (shape is Aspose.Slides.SmartArt.SmartArt)
            {
                Aspose.Slides.SmartArt.SmartArt smartArt = (Aspose.Slides.SmartArt.SmartArt)shape;

                if (smartArt.AllNodes.Count > 0)
                {
                    Aspose.Slides.SmartArt.ISmartArtNode nodeToRemove = smartArt.AllNodes[0];

                    if (nodeToRemove.ChildNodes.Count > 0)
                    {
                        Aspose.Slides.SmartArt.ISmartArtNode firstChild = nodeToRemove.ChildNodes[0];
                        int nodePosition = nodeToRemove.Position;

                        // Remove the original node
                        nodeToRemove.Remove();

                        // Remove the first child from its original collection
                        ((Aspose.Slides.SmartArt.SmartArtNodeCollection)nodeToRemove.ChildNodes).RemoveNode(firstChild);

                        // Add a new node at the original position in the root collection
                        Aspose.Slides.SmartArt.ISmartArtNode promotedNode = ((Aspose.Slides.SmartArt.SmartArtNodeCollection)smartArt.AllNodes).AddNodeByPosition(nodePosition);
                        promotedNode.TextFrame.Text = firstChild.TextFrame.Text;
                    }
                }

                break;
            }
        }

        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}