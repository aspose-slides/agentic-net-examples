using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load an existing presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Create PPTX save options using the factory
            Aspose.Slides.Export.SaveOptionsFactory optionsFactory = new Aspose.Slides.Export.SaveOptionsFactory();
            Aspose.Slides.Export.IPptxOptions pptxOptions = optionsFactory.CreatePptxOptions();

            // Set compression/ZIP64 mode to control output size
            pptxOptions.Zip64Mode = Aspose.Slides.Export.Zip64Mode.Always;

            // Save the presentation as PPTX with the specified options
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx, pptxOptions);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}