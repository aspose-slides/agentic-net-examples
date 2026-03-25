using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // ----- Title Slide -----
            Aspose.Slides.ISlide titleSlide = pres.Slides[0];
            Aspose.Slides.IAutoShape titleShape = (Aspose.Slides.IAutoShape)titleSlide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50f, 50f, 600f, 100f);
            titleShape.AddTextFrame("Presentation Title");
            titleShape.TextFrame.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;

            // ----- Chart Slide -----
            Aspose.Slides.ISlide chartSlide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
            Aspose.Slides.Charts.Chart chart = (Aspose.Slides.Charts.Chart)chartSlide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 150f, 500f, 300f);
            chart.ValidateChartLayout();

            // Chart Title
            Aspose.Slides.Charts.ChartTitle chartTitle = (Aspose.Slides.Charts.ChartTitle)chart.ChartTitle;
            chartTitle.AddTextFrameForOverriding("Sales Chart");
            chartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;
            chartTitle.Height = 20f;
            chart.HasTitle = true;

            // Legend positioning
            Aspose.Slides.Charts.Legend legend = (Aspose.Slides.Charts.Legend)chart.Legend;
            legend.X = 0.8f;   // 80% from left
            legend.Y = 0.1f;   // 10% from top
            legend.Width = 0.2f;
            legend.Height = 0.2f;

            // Save the presentation
            pres.Save("OutputPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.IO.FileNotFoundException ex)
        {
            Console.WriteLine("Input file not found: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}