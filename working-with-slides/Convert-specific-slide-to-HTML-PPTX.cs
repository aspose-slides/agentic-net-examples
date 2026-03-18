using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideToHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.pptx";
                string outputPath = "slide1.html";
                int slideNumber = 1; // 1‑based index of the slide to convert

                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
                int[] slides = new int[] { slideNumber };
                presentation.Save(outputPath, slides, Aspose.Slides.Export.SaveFormat.Html);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}