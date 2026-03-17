using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertPptxToHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input and output paths
                string inputPath = "input.pptx";
                string outputPath = "output.html";

                // Create a Presentation instance
                Presentation presentation = new Presentation(inputPath);

                // Configure HTML export options with high‑quality images at 150 DPI
                HtmlOptions htmlOptions = new HtmlOptions();
                htmlOptions.SlideImageFormat = SlideImageFormat.Bitmap(150f, Aspose.Slides.ImageFormat.Jpeg);

                // Save the presentation as HTML
                presentation.Save(outputPath, SaveFormat.Html, htmlOptions);

                // Dispose the presentation
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}