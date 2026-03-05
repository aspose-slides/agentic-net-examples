using System;

namespace PresentationToHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source PowerPoint file
            string inputPath = "input.pptx";
            // Path to the output HTML file
            string outputPath = "output.html";

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Optional: configure HTML export options
                Aspose.Slides.Export.HtmlOptions htmlOptions = new Aspose.Slides.Export.HtmlOptions();

                // Save the presentation as HTML
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html, htmlOptions);
            }

            // Indicate completion
            Console.WriteLine("Presentation converted to HTML successfully.");
        }
    }
}