using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PowerPointToHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.html";

            try
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    Aspose.Slides.Export.HtmlOptions options = new Aspose.Slides.Export.HtmlOptions
                    {
                        SlidesLayoutOptions = new Aspose.Slides.Export.HandoutLayoutingOptions
                        {
                            Handout = Aspose.Slides.Export.HandoutType.Handouts4Horizontal
                        }
                    };

                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html, options);
                }

                Console.WriteLine("Presentation successfully converted to HTML.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}