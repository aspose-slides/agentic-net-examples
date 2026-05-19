using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add an organization chart SmartArt with the default horizontal layout
        Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 400, Aspose.Slides.SmartArt.SmartArtLayoutType.OrganizationChart);

        // Change the layout of the root node to a vertical (left hanging) layout
        smartArt.Nodes[0].OrganizationChartLayout = Aspose.Slides.SmartArt.OrganizationChartLayoutType.LeftHanging;

        // Save the presentation
        presentation.Save("OrganizationChartLayoutShift.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}