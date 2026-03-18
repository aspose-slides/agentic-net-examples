using System;
using Aspose.Slides.Export;

namespace MyApp
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Paths for input and output presentations
                var inputPath = "input.pptx";
                var outputPath = "output.pptx";

                // Load the presentation
                using (var presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Add a custom tag for downstream processing
                    var tags = presentation.CustomData.Tags;
                    tags["CustomTag"] = "CustomValue";

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during processing
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}