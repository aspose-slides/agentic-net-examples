using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output file path
            string outputPath = "OrganizationChart.pptx";

            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add an Organization Chart SmartArt diagram (horizontal layout by default)
            ISmartArt smartArt = slide.Shapes.AddSmartArt(50, 50, 600, 400, SmartArtLayoutType.OrganizationChart);

            // Change the layout of the first root node to a vertical left hanging layout
            smartArt.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle any errors (e.g., unsupported format, file I/O issues)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}