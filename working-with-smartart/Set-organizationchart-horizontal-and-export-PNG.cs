using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace OrgChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output directory
            string outputDir = "Output";
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add an Organization Chart SmartArt diagram
            Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(
                50,    // X position
                50,    // Y position
                400,   // Width
                300,   // Height
                Aspose.Slides.SmartArt.SmartArtLayoutType.OrganizationChart);

            // Set the organization chart layout type to Horizontal (Standart)
            if (smartArt.Nodes.Count > 0)
            {
                smartArt.Nodes[0].OrganizationChartLayout = Aspose.Slides.SmartArt.OrganizationChartLayoutType.Standart;
            }

            // Save the presentation
            string presentationPath = Path.Combine(outputDir, "OrgChart.pptx");
            presentation.Save(presentationPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Render the slide as PNG
            Aspose.Slides.IImage slideImage = slide.GetImage();
            string pngPath = Path.Combine(outputDir, "OrgChart.png");
            slideImage.Save(pngPath, Aspose.Slides.ImageFormat.Png);

            // Dispose resources
            presentation.Dispose();
        }
    }
}