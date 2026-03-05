using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation (contains one empty slide)
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Create a factory for save options
        Aspose.Slides.Export.SaveOptionsFactory optionsFactory = new Aspose.Slides.Export.SaveOptionsFactory();

        // Obtain PPTX-specific save options
        Aspose.Slides.Export.IPptxOptions pptxOptions = optionsFactory.CreatePptxOptions();

        // Example: modify an option (optional)
        pptxOptions.RefreshThumbnail = false;

        // Save the presentation in PPTX format using the specified options
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx, pptxOptions);
    }
}