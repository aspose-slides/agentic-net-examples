using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace DetectDataTablesInCharts
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            if (args.Length > 0)
            {
                inputPath = args[0];
            }

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("File does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Presentation pres = new Presentation(inputPath))
                {
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        ISlide slide = pres.Slides[slideIndex];
                        foreach (IShape shape in slide.Shapes)
                        {
                            IChart chart = shape as IChart;
                            if (chart != null && chart.HasDataTable)
                            {
                                Console.WriteLine("Chart with visible data table found on slide index: " + slideIndex);
                            }
                        }
                    }

                    // Save the presentation (could be the same file or a new one)
                    string outputPath = "output.pptx";
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Comment: format not supported
            }
        }
    }
}