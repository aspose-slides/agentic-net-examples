using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AddLegendAndTitleSlide
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path (if it exists it will be loaded, otherwise a new one is created)
            string inputPath = "input.pptx";
            Aspose.Slides.Presentation presentation;

            if (File.Exists(inputPath))
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            else
            {
                presentation = new Aspose.Slides.Presentation();
            }

            // -------------------------------------------------
            // Add a Title slide
            // -------------------------------------------------
            ILayoutSlide titleLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Title);
            ISlide titleSlide = presentation.Slides.AddEmptySlide(titleLayout);

            // Set title text and center align it
            IAutoShape titleShape = (IAutoShape)titleSlide.Shapes[0];
            titleShape.TextFrame.Text = "Presentation Title";
            IParagraph titleParagraph = titleShape.TextFrame.Paragraphs[0];
            titleParagraph.ParagraphFormat.Alignment = TextAlignment.Center;

            // -------------------------------------------------
            // Add a new slide with a chart and a legend
            // -------------------------------------------------
            ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
            ISlide chartSlide = presentation.Slides.AddEmptySlide(blankLayout);

            // Add a clustered column chart
            IChart chart = chartSlide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 100, 500, 400);

            // Enable legend and set its position
            chart.HasLegend = true;
            chart.Legend.Position = LegendPositionType.Right;

            // Add a chart title
            chart.HasTitle = true;
            chart.ChartTitle.AddTextFrameForOverriding("Sales Data");

            // -------------------------------------------------
            // Save the presentation
            // -------------------------------------------------
            string outputPath = "output.pptx";
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}