using System;

class Program
{
    static void Main(string[] args)
    {
        // Load the PPTX presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx");

        // Create XAML options and configure them
        Aspose.Slides.Export.Xaml.XamlOptions options = new Aspose.Slides.Export.Xaml.XamlOptions();
        options.ExportHiddenSlides = true;

        // Save the presentation as XAML using the specified options
        pres.Save(options);

        // Clean up resources
        pres.Dispose();
    }
}