using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a SmartArt shape with an initial layout
        Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

        // Count nodes before cloning
        int beforeCount = smartArt.AllNodes.Count;

        // Clone the SmartArt shape within the same slide
        Aspose.Slides.IShapeCollection shapes = slide.Shapes;
        shapes.AddClone(shapes[0], 500, 50);

        // Retrieve the cloned SmartArt (assumed to be the last shape)
        Aspose.Slides.IShape clonedShape = shapes[shapes.Count - 1];
        Aspose.Slides.SmartArt.ISmartArt clonedSmartArt = (Aspose.Slides.SmartArt.ISmartArt)clonedShape;

        // Change layout of the cloned SmartArt to RadialCycle
        clonedSmartArt.Layout = Aspose.Slides.SmartArt.SmartArtLayoutType.RadialCycle;

        // Count nodes after layout change
        int afterCount = clonedSmartArt.AllNodes.Count;

        // Output the node counts
        Console.WriteLine("Node count before cloning: " + beforeCount);
        Console.WriteLine("Node count after cloning and layout change: " + afterCount);

        // Save the presentation
        string outPath = "SmartArtClone.pptx";
        presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation
        presentation.Dispose();
    }
}