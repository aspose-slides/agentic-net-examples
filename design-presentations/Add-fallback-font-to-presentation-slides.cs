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

                // Add a blank slide (optional, just to have content)
                ISlide slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

                // Define save options with a fallback font
                PptxOptions saveOptions = new PptxOptions();
                saveOptions.DefaultRegularFont = "Arial";

                // Save the presentation as PPTX using the specified options
                presentation.Save("FallbackFontPresentation.pptx", SaveFormat.Pptx, saveOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}