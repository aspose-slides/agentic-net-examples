using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the PPTX presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Create and configure Markdown save options
        Aspose.Slides.Export.MarkdownSaveOptions markdownOptions = new Aspose.Slides.Export.MarkdownSaveOptions();
        markdownOptions.ShowHiddenSlides = true;
        markdownOptions.ShowSlideNumber = true;
        markdownOptions.Flavor = Aspose.Slides.Export.Flavor.Github;
        markdownOptions.ExportType = Aspose.Slides.Export.MarkdownExportType.Sequential;
        markdownOptions.NewLineType = Aspose.Slides.Export.NewLineType.Windows;

        // Save the presentation as a Markdown file
        presentation.Save("output.md", Aspose.Slides.Export.SaveFormat.Md, markdownOptions);
    }
}