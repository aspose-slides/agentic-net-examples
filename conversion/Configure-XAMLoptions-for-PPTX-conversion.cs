using System;
using Aspose.Slides.Export;
using Aspose.Slides.Export.Xaml;

class Program
{
    static void Main()
    {
        try
        {
            // Load the PPTX presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Configure XAML conversion options
            Aspose.Slides.Export.Xaml.XamlOptions options = new Aspose.Slides.Export.Xaml.XamlOptions();
            options.ExportHiddenSlides = true; // Export hidden slides as well

            // Convert and save the presentation to XAML files
            presentation.Save(options);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}