using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SetFirstSlideNumberExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = "CustomFirstSlideNumber.pptx";

            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Set the first slide number to a custom start value (e.g., 5)
                presentation.FirstSlideNumber = 5;

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format)
                // Format not supported
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}