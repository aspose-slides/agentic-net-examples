using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "output.pptx";
        try
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Set transition duration to 2000 milliseconds (2 seconds) for each slide
            foreach (ISlide slide in pres.Slides)
            {
                slide.SlideShowTransition.Duration = 2000;
            }

            // Save the presentation
            pres.Save(outputPath, SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}