using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideNumberExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Set the first slide number to start numbering at five
            presentation.FirstSlideNumber = 5;

            // Define output file path
            string outputPath = "CustomSlideDeck_out.pptx";

            try
            {
                // Save the presentation in PPTX format
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle cases where the format is not supported
                // Format not supported
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
        }
    }
}