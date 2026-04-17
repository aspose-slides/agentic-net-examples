using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportPresentationToHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output paths
            string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            string outputDir = Path.Combine(Environment.CurrentDirectory, "output");
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            string outputHtml = Path.Combine(outputDir, "presentation.html");

            // Configure HTML export options
            Aspose.Slides.Export.HtmlOptions htmlOptions = new Aspose.Slides.Export.HtmlOptions();
            htmlOptions.SvgResponsiveLayout = true;
            // Use a slide-show formatter; CSS file can be generated per slide as needed
            htmlOptions.HtmlFormatter = Aspose.Slides.Export.HtmlFormatter.CreateSlideShowFormatter("style.css", true);

            // Load the presentation
            Aspose.Slides.Presentation pres = null;
            try
            {
                pres = new Aspose.Slides.Presentation(inputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("File format not supported.");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }

            // Save as HTML
            try
            {
                pres.Save(outputHtml, Aspose.Slides.Export.SaveFormat.Html, htmlOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
            finally
            {
                // Ensure the presentation is disposed
                if (pres != null)
                    pres.Dispose();
            }

            Console.WriteLine("Export completed.");
        }
    }
}