using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation
                Presentation presentation = new Presentation("input.pptx");

                // Create a new fallback rules collection
                IFontFallBackRulesCollection fallbackRules = new FontFallBackRulesCollection();

                // Add a fallback rule for Unicode range 0x400-0x4FF to use "Times New Roman"
                fallbackRules.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

                // Assign the fallback rules to the presentation's FontsManager
                presentation.FontsManager.FontFallBackRulesCollection = fallbackRules;

                // Render the first slide to an image
                IImage slideImage = presentation.Slides[0].GetImage(1f, 1f);
                slideImage.Save("slide0.png", ImageFormat.Png);

                // Save the modified presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}