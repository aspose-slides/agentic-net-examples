using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input PPTX file path
                string inputPath = "input.pptx";
                // Output HTML file path
                string outputPath = "output.html";

                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Configure HTML5 export options
                    Aspose.Slides.Export.Html5Options options = new Aspose.Slides.Export.Html5Options();
                    options.AnimateShapes = true;
                    options.AnimateTransitions = true;

                    // Save the presentation as HTML5
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html5, options);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during conversion
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}