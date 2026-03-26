using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        using (Presentation pres = new Presentation(inputPath))
        {
            // Get the first slide
            ISlide slide = pres.Slides[0];

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
                Console.WriteLine("No chart found on the first slide.");
                return;
            }

            // Initialize override theme to inherit current theme components
            chart.ThemeManager.OverrideTheme.InitColorSchemeFromInherited();
            chart.ThemeManager.OverrideTheme.InitFontSchemeFromInherited();
            chart.ThemeManager.OverrideTheme.InitFormatSchemeFromInherited();

            // Example modification: change an accent color in the overridden color scheme
            chart.ThemeManager.OverrideTheme.ColorScheme.Accent1.Color = System.Drawing.Color.DarkBlue;

            // Save the modified presentation
            pres.Save(outputPath, SaveFormat.Pptx);
        }

        Console.WriteLine("Presentation saved to " + outputPath);
    }
}