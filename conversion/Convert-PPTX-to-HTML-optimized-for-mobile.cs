using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationToHtml
{
    class Program
    {
        static void Main()
        {
            try
            {
                var sourceFile = "input.pptx";
                var htmlFile = "output.html";

                using (var presentation = new Aspose.Slides.Presentation(sourceFile))
                {
                    var htmlOptions = new Aspose.Slides.Export.HtmlOptions();
                    // Preserve slide layouts and assets using default options
                    presentation.Save(htmlFile, Aspose.Slides.Export.SaveFormat.Html, htmlOptions);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}