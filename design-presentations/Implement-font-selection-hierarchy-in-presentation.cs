using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Add a clustered column chart
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

                // Set chart title
                chart.ChartTitle.AddTextFrameForOverriding("Sales Overview");
                chart.HasTitle = true;

                // Set font height for chart title via TextFormat
                chart.TextFormat.PortionFormat.FontHeight = 24f;

                // Show values for the first series data labels
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

                // Example of font hierarchy: replace a missing font with a fallback
                // Load a source font (e.g., Arial) and a substitute font (e.g., Calibri)
                IFontData sourceFont = new FontData("Arial");
                IFontData substituteFont = new FontData("Calibri");
                presentation.FontsManager.ReplaceFont(sourceFont, substituteFont);

                // Save the presentation
                presentation.Save("FontHierarchyExample.pptx", SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}