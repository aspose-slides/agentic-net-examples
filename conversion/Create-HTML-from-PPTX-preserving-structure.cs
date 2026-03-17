using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationToHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.pptx";
                string outputPath = "output.html";

                using (Presentation pres = new Presentation(inputPath))
                {
                    HtmlOptions options = new HtmlOptions();
                    // Uncomment the following lines to customize slide layout in the HTML output
                    // HandoutLayoutingOptions layoutOptions = new HandoutLayoutingOptions
                    // {
                    //     Handout = HandoutType.Handouts4Horizontal
                    // };
                    // options.SlidesLayoutOptions = layoutOptions;

                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html, options);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}