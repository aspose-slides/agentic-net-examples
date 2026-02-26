using System;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                0f,    // X position
                0f,    // Y position
                500f,  // Width
                500f   // Height
            );

            // Save the presentation
            presentation.Save("ChartPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}