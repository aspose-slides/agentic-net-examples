using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FallbackFontExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Set fallback font using save options
                PptxOptions saveOptions = new PptxOptions();
                saveOptions.DefaultRegularFont = "Arial";

                // Save the presentation with the specified fallback font
                presentation.Save("FallbackFontPresentation.pptx", SaveFormat.Pptx, saveOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}