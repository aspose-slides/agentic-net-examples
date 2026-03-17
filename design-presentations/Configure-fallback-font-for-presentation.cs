using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Configure fallback font using save options
                PptOptions saveOptions = new PptOptions();
                saveOptions.DefaultRegularFont = "Arial";

                // Save the presentation with the fallback font setting
                presentation.Save("FallbackFontPresentation.pptx", SaveFormat.Pptx, saveOptions);
            }
            catch (Exception ex)
            {
                // Output any errors
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}