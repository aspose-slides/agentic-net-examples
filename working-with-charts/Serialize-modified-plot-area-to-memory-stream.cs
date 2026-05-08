using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        // Add a line chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Line, 50f, 50f, 450f, 300f);
        // Modify plot area size fractions
        chart.PlotArea.Width = 0.8f;   // 80% of chart width
        chart.PlotArea.Height = 0.6f;  // 60% of chart height
        // Validate layout to obtain actual dimensions
        chart.ValidateChartLayout();
        float actualWidth = chart.PlotArea.ActualWidth;
        float actualHeight = chart.PlotArea.ActualHeight;
        // Serialize presentation to a memory stream
        System.IO.MemoryStream memStream = new System.IO.MemoryStream();
        try
        {
            presentation.Save(memStream, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }
        // Reset stream position for reading
        memStream.Position = 0;
        // Reload presentation from memory stream
        Aspose.Slides.Presentation loadedPresentation = new Aspose.Slides.Presentation(memStream);
        Aspose.Slides.Charts.IChart loadedChart = loadedPresentation.Slides[0].Shapes[0] as Aspose.Slides.Charts.IChart;
        if (loadedChart != null)
        {
            loadedChart.ValidateChartLayout();
            float loadedActualWidth = loadedChart.PlotArea.ActualWidth;
            float loadedActualHeight = loadedChart.PlotArea.ActualHeight;
            // Dimensions can be verified here
        }
        // Save the modified presentation to a file
        string outputPath = "ModifiedChart.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        // Clean up resources
        presentation.Dispose();
        loadedPresentation.Dispose();
        memStream.Dispose();
    }
}