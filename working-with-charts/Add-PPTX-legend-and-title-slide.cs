using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // ----- Title Slide -----
            ISlide titleSlide = presentation.Slides[0];
            IAutoShape titleShape = titleSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 100, 600, 100);
            titleShape.AddTextFrame("Presentation Title");
            titleShape.TextFrame.TextFrameFormat.CenterText = NullableBool.True;
            titleShape.TextFrame.Paragraphs[0].ParagraphFormat.Alignment = TextAlignment.Center;

            // ----- Chart Slide -----
            // Add an empty slide based on the first layout
            ISlide chartSlide = presentation.Slides.AddEmptySlide(presentation.Masters[0].LayoutSlides[0]);

            // Add a clustered column chart
            IChart chart = chartSlide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 150, 500, 300);

            // Set chart title
            chart.HasTitle = true;
            chart.ChartTitle.AddTextFrameForOverriding("Sales Data");
            chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;

            // Position the legend on the right
            chart.Legend.Position = LegendPositionType.Right;

            // Consistent legend formatting
            chart.Legend.TextFormat.PortionFormat.FontHeight = 14f;
            chart.Legend.TextFormat.PortionFormat.FontBold = NullableBool.True;

            // Save the presentation
            presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}