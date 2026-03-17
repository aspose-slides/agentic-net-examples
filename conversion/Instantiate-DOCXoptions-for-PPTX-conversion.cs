using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the source PPTX presentation
            Presentation presentation = new Presentation("input.pptx");

            // Create PPTX save options using the factory
            SaveOptionsFactory optionsFactory = new SaveOptionsFactory();
            PptxOptions pptxOptions = (PptxOptions)optionsFactory.CreatePptxOptions();

            // Example configuration of the save options
            pptxOptions.RefreshThumbnail = true;

            // Save the presentation with the configured options
            presentation.Save("output.pptx", SaveFormat.Pptx, pptxOptions);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}