using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideTransitionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = "FadeTransition.pptx";

            // Create a new presentation
            Presentation pres = new Presentation();

            // Set transition type to Fade
            pres.Slides[0].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;

            // Set transition duration to 2000 milliseconds (2 seconds)
            pres.Slides[0].SlideShowTransition.Duration = 2000;

            try
            {
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle format not supported or other save errors
                // Format not supported
            }
            finally
            {
                pres.Dispose();
            }
        }
    }
}