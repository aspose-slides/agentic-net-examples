using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartCalculationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

                // Access the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Add a clustered column chart
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 150, 500, 400);

                // Set chart title
                chart.HasTitle = true;
                chart.ChartTitle.AddTextFrameForOverriding("Sales Data");
                chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;

                // Get the chart data workbook
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Remove default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add series
                chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Q1"), chart.Type);
                chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Q2"), chart.Type);

                // Add categories
                chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Product A"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Product B"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Product C"));

                // Populate first series data
                Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series[0];
                series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 120));
                series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 150));
                series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 1, 180));

                // Populate second series data
                Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series[1];
                series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 80));
                series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, 130));
                series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 2, 170));

                // Add a formula cell to calculate total of Q1
                Aspose.Slides.Charts.IChartDataCell totalCell = workbook.GetCell(0, 1, 3, null);
                totalCell.Formula = "SUM(B2:C2)";

                // Calculate all formulas in the workbook
                workbook.CalculateFormulas();

                // Add a textbox explaining chart calculation
                Aspose.Slides.IAutoShape txtShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 20, 500, 100);
                txtShape.AddTextFrame("Chart calculation uses an embedded workbook. The total for Q1 is calculated via a formula.");
                txtShape.TextFrame.Paragraphs[0].ParagraphFormat.Alignment = TextAlignment.Center;

                // Validate chart layout to compute actual element positions
                chart.ValidateChartLayout();

                // Save the presentation
                pres.Save("ChartCalculationDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}