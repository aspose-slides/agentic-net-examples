using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "output.pptx";
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add original SmartArt (Organization Chart)
            Aspose.Slides.SmartArt.ISmartArt originalSmartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, Aspose.Slides.SmartArt.SmartArtLayoutType.OrganizationChart);
            // Set original root node layout to Left Hanging
            originalSmartArt.Nodes[0].OrganizationChartLayout = Aspose.Slides.SmartArt.OrganizationChartLayoutType.LeftHanging;

            // Clone the SmartArt shape
            Aspose.Slides.IShapeCollection shapes = slide.Shapes;
            Aspose.Slides.IShape clonedShape = shapes.AddClone(originalSmartArt, 500, 50);
            Aspose.Slides.SmartArt.ISmartArt clonedSmartArt = (Aspose.Slides.SmartArt.ISmartArt)clonedShape;

            // Change cloned SmartArt node layout to Standard (horizontal)
            clonedSmartArt.Nodes[0].OrganizationChartLayout = Aspose.Slides.SmartArt.OrganizationChartLayoutType.Standart;

            // Compare node arrangements
            Console.WriteLine("Original node layout: " + originalSmartArt.Nodes[0].OrganizationChartLayout);
            Console.WriteLine("Cloned node layout: " + clonedSmartArt.Nodes[0].OrganizationChartLayout);

            // Save presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., format not supported)
        }
    }
}