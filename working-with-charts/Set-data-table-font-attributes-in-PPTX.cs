using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace SetDataTableFontAttributes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect the input PPTX file path as the first argument
            if (args.Length == 0)
            {
                Console.WriteLine("Error: No input file specified.");
                return;
            }

            string inputPath = args[0];
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: File not found - " + inputPath);
                return;
            }

            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Find the first chart on the slide
                IChart chart = null;
                foreach (IShape shape in slide.Shapes)
                {
                    if (shape is IChart)
                    {
                        chart = (IChart)shape;
                        break;
                    }
                }

                if (chart == null)
                {
                    Console.WriteLine("Error: No chart found on the first slide.");
                    return;
                }

                // Ensure the chart has a data table
                chart.HasDataTable = true;

                // Access the data table
                IDataTable dataTable = chart.ChartDataTable;

                // Configure font attributes for the data table
                // Set typeface
                dataTable.TextFormat.PortionFormat.LatinFont = new FontData("Arial");
                // Set font size (points)
                dataTable.TextFormat.PortionFormat.FontHeight = 12f;
                // Set bold style
                dataTable.TextFormat.PortionFormat.FontBold = NullableBool.True;

                // Save the modified presentation
                string outputPath = "SetDataTableFontAttributes_out.pptx";
                presentation.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to " + outputPath);
            }
        }
    }
}