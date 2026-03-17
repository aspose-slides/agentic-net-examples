using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to save the generated presentation
            string outputPath = "DefaultFontPresentation.pptx";

            try
            {
                // Configure load options with the desired default regular font
                Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
                loadOptions.DefaultRegularFont = "Arial";

                // Create a new presentation using the load options
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(loadOptions);

                // Add a new empty slide (using the layout of the first slide)
                presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

                // Save the presentation before exiting
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}