using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace HideVerticalAxis
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (Presentation presentation = new Presentation("input.pptx"))
                {
                    foreach (ISlide slide in presentation.Slides)
                    {
                        foreach (IShape shape in slide.Shapes)
                        {
                            IChart chart = shape as IChart;
                            if (chart != null && chart.Type == ChartType.Line)
                            {
                                IAxis verticalAxis = chart.Axes.VerticalAxis;
                                verticalAxis.IsVisible = false;
                            }
                        }
                    }
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}