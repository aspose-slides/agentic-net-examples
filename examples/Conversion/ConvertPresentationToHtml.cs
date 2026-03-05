using System;

namespace AsposeSlidesHtmlConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PowerPoint file
            string inputPath = "input.pptx";

            // Output HTML files
            string outputHtmlOriginal = "output_original.html";
            string outputHtmlEmbedded = "output_embedded.html";

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Save with original fonts (no embedding)
                Aspose.Slides.Export.HtmlOptions htmlOptionsOriginal = new Aspose.Slides.Export.HtmlOptions();
                presentation.Save(outputHtmlOriginal, Aspose.Slides.Export.SaveFormat.Html, htmlOptionsOriginal);

                // Save with embedded fonts
                Aspose.Slides.Export.HtmlOptions htmlOptionsEmbedded = new Aspose.Slides.Export.HtmlOptions();
                Aspose.Slides.Export.HtmlFormatter customFormatter = Aspose.Slides.Export.HtmlFormatter.CreateCustomFormatter(new Aspose.Slides.Export.EmbedAllFontsHtmlController());
                htmlOptionsEmbedded.HtmlFormatter = customFormatter;
                presentation.Save(outputHtmlEmbedded, Aspose.Slides.Export.SaveFormat.Html, htmlOptionsEmbedded);

                // Save the (possibly unchanged) presentation before exiting
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}