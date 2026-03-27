using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace NormalViewDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect input and output file paths as arguments
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: NormalViewDemo <input.pptx> <output.pptx>");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation
            Presentation pres = new Presentation(inputPath);

            // Configure normal view properties
            pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
            pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;
            pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
            pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80f;
            pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

            // Save the modified presentation
            pres.Save(outputPath, SaveFormat.Pptx);
        }
    }
}