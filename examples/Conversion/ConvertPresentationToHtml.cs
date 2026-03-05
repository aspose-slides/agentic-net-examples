using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PowerPointToHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source PowerPoint file
            string sourcePath = "input.pptx";

            // Path to the output HTML file
            string outputPath = "output.html";

            // Load the presentation
            using (Presentation presentation = new Presentation(sourcePath))
            {
                // Create HTML export options (default does not embed fonts)
                HtmlOptions htmlOptions = new HtmlOptions();

                // Save the presentation as HTML without embedding fonts
                presentation.Save(outputPath, SaveFormat.Html, htmlOptions);
            }
        }
    }
}