using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.html";

            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Set HTML5 export options to preserve animations
            Aspose.Slides.Export.Html5Options options = new Aspose.Slides.Export.Html5Options();
            options.AnimateShapes = true;
            options.AnimateTransitions = true;

            // Save as HTML5
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html5, options);

            // Clean up
            pres.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}