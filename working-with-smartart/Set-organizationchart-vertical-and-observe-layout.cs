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

        // Add a SmartArt diagram with a horizontal organization chart layout
        Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 400, Aspose.Slides.SmartArt.SmartArtLayoutType.HorizontalOrganizationChart);

        // Change the SmartArt layout to a vertical organization chart
        smartArt.Layout = Aspose.Slides.SmartArt.SmartArtLayoutType.OrganizationChart;

        // Adjust the layout of the root node to left hanging to observe the layout shift
        if (smartArt.Nodes.Count > 0)
        {
            smartArt.Nodes[0].OrganizationChartLayout = Aspose.Slides.SmartArt.OrganizationChartLayoutType.LeftHanging;
        }

        // Save the presentation
        presentation.Save("OrganizationChartShift.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}