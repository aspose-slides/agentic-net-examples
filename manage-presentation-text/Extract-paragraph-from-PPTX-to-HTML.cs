using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: program <input.pptx> <output.html>");
                return;
            }

            var inputPath = args[0];
            var outputPath = args[1];

            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Get all text frames from the presentation (excluding masters)
                var textFrames = SlideUtil.GetAllTextFrames(presentation, false);

                var htmlBuilder = new StringBuilder();
                var options = new TextToHtmlConversionOptions();

                foreach (var textFrame in textFrames)
                {
                    var paragraphs = textFrame.Paragraphs;
                    // Convert all paragraphs in the text frame to HTML
                    var html = paragraphs.ExportToHtml(0, paragraphs.Count, options);
                    htmlBuilder.AppendLine(html);
                }

                // Write the combined HTML to the output file
                File.WriteAllText(outputPath, htmlBuilder.ToString());

                // Save the presentation before exiting
                presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}