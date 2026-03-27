using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace OrganizationChartLayoutDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add an Organization Chart SmartArt diagram (horizontal layout by default)
            ISmartArt smartArt = slide.Shapes.AddSmartArt(50f, 50f, 400f, 300f, SmartArtLayoutType.OrganizationChart);

            // Change the layout of the root node to a vertical hanging layout (Left Hanging)
            // This shifts the organization chart from horizontal to vertical
            smartArt.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

            // Define output file path
            string outputPath = "OrganizationChartLayoutShift.pptx";

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}