using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SetDefaultFontExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Set default regular font for the presentation when saving
                Aspose.Slides.Export.PptxOptions saveOptions = new Aspose.Slides.Export.PptxOptions();
                saveOptions.DefaultRegularFont = "Arial";

                // Save the presentation with the specified options
                presentation.Save("DefaultFontPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx, saveOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}