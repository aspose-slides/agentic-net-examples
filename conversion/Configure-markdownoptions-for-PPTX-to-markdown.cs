using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var inputPath = "input.pptx";
            var outputPath = "output.md";

            using var presentation = new Aspose.Slides.Presentation(inputPath);

            var markdownOptions = new Aspose.Slides.Export.MarkdownSaveOptions
            {
                ShowHiddenSlides = true,
                ShowSlideNumber = true,
                Flavor = Aspose.Slides.Export.Flavor.Github,
                ExportType = Aspose.Slides.Export.MarkdownExportType.Sequential,
                NewLineType = Aspose.Slides.Export.NewLineType.Windows,
                SlideNumberFormat = "# Slide {0}",
                RemoveEmptyLines = true
            };

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Md, markdownOptions);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}