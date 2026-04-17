using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ReplaceChartsWithTreemap
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Presentation pres = new Presentation(inputPath))
                {
                    foreach (ISlide slide in pres.Slides)
                    {
                        for (int i = slide.Shapes.Count - 1; i >= 0; i--)
                        {
                            IShape shape = slide.Shapes[i];
                            if (shape is IChart)
                            {
                                IChart oldChart = (IChart)shape;
                                float x = oldChart.X;
                                float y = oldChart.Y;
                                float width = oldChart.Width;
                                float height = oldChart.Height;

                                // Remove the existing chart
                                slide.Shapes.RemoveAt(i);

                                // Add a new Treemap chart at the same position and size
                                IChart newChart = slide.Shapes.AddChart(ChartType.Treemap, x, y, width, height);
                                // Optional: set a title for the new chart
                                newChart.HasTitle = true;
                                newChart.ChartTitle.AddTextFrameForOverriding("Treemap Chart");
                            }
                        }
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException ex)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}