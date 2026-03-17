using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the PPTX presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Create XpsOptions and set custom settings
            Aspose.Slides.Export.XpsOptions options = new Aspose.Slides.Export.XpsOptions();
            options.SaveMetafilesAsPng = true;

            // Save the presentation as XPS using the configured options
            presentation.Save("output.xps", Aspose.Slides.Export.SaveFormat.Xps, options);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}