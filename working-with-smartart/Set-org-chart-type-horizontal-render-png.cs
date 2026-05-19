using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;
using Aspose.Slides.Export;

namespace SetOrgChartTypeHorizontalRenderPng
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Add a SmartArt diagram of type OrganizationChart
                ISmartArt smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.OrganizationChart);

                // Set the SmartArt layout to Horizontal Organization Chart
                smartArt.Layout = SmartArtLayoutType.HorizontalOrganizationChart;

                // Render the slide to a PNG image
                IImage slideImage = slide.GetImage(1f, 1f);
                slideImage.Save("Slide.png", ImageFormat.Png);

                // Save the presentation
                presentation.Save("Presentation.pptx", SaveFormat.Pptx);
            }
        }
    }
}