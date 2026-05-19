using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add an Organization Chart SmartArt (horizontal layout by default)
        Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(50, 50, 600, 400, Aspose.Slides.SmartArt.SmartArtLayoutType.OrganizationChart);

        // Change the layout of the root node to a vertical left‑hanging layout
        smartArt.Nodes[0].OrganizationChartLayout = Aspose.Slides.SmartArt.OrganizationChartLayoutType.LeftHanging;

        // Save the presentation
        presentation.Save("OrganizationChartVertical.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}