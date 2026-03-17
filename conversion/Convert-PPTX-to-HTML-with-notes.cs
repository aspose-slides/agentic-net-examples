using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PowerPointToHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

                // Configure HTML export options to include speaker notes
                Aspose.Slides.Export.HtmlOptions htmlOptions = new Aspose.Slides.Export.HtmlOptions();
                htmlOptions.ShowHiddenSlides = true; // Ensures hidden content such as notes are included

                // Save as HTML
                presentation.Save("output.html", Aspose.Slides.Export.SaveFormat.Html, htmlOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}