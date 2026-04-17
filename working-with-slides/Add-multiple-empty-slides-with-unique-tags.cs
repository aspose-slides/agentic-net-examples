using System;
using System.IO;
using Aspose.Slides.Export;

namespace BatchAddSlides
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output directory
            string outputDir = Path.Combine(Environment.CurrentDirectory, "Output");
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Use the first layout slide as a template
            Aspose.Slides.ILayoutSlide layout = pres.LayoutSlides[0];

            // Add multiple empty slides and assign unique tags
            for (int i = 0; i < 5; i++)
            {
                Aspose.Slides.ISlide slide = pres.Slides.AddEmptySlide(layout);
                slide.CustomData.Tags["SlideTag" + i] = "TagValue" + i;
            }

            // Save the presentation
            string outPath = Path.Combine(outputDir, "BatchSlides.pptx");
            try
            {
                pres.Save(outPath, SaveFormat.Pptx);
            }
            catch (Exception)
            {
                // Format not supported
            }

            // Dispose the presentation
            pres.Dispose();
        }
    }
}