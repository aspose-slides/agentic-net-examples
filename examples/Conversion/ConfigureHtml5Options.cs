using System;

class Program
{
    static void Main()
    {
        // Load the PPTX presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx");

        // Create Html5Options and configure slide layout
        Aspose.Slides.Export.Html5Options options = new Aspose.Slides.Export.Html5Options();

        // Set the SlidesLayoutOptions to handout layout (4 horizontal slides per page)
        Aspose.Slides.Export.HandoutLayoutingOptions layoutOptions = new Aspose.Slides.Export.HandoutLayoutingOptions();
        layoutOptions.Handout = Aspose.Slides.Export.HandoutType.Handouts4Horizontal;
        options.SlidesLayoutOptions = layoutOptions;

        // Save the presentation as HTML5 using the configured options
        pres.Save("output.html", Aspose.Slides.Export.SaveFormat.Html5, options);

        // Clean up resources
        pres.Dispose();
    }
}