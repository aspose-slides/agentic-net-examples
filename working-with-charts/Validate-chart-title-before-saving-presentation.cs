using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];
                // Add a clustered column chart
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 100f, 100f, 500f, 350f);
                // Set chart title properties
                chart.HasTitle = true;
                chart.ChartTitle.AddTextFrameForOverriding("Sales Data");
                chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;
                chart.ChartTitle.Height = 20;
                chart.ChartTitle.Width = 400;
                chart.ChartTitle.Y = 0;
                chart.ChartTitle.X = 0;
                // Validate chart layout
                chart.ValidateChartLayout();
                // Ensure the title is non‑empty before saving
                if (chart.HasTitle && chart.ChartTitle.TextFrameForOverriding != null && !string.IsNullOrEmpty(chart.ChartTitle.TextFrameForOverriding.Text))
                {
                    presentation.Save("ChartTitleExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
                else
                {
                    Console.WriteLine("Chart title is empty. Presentation not saved.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}