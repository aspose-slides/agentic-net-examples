using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        if (!File.Exists(inputPath))
        {
            // Input file does not exist
            return;
        }

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.Export.SVGOptions svgOptions = new Aspose.Slides.Export.SVGOptions();
            // Preserve theme colors and embed fonts
            svgOptions.ExternalFontsHandling = Aspose.Slides.Export.SvgExternalFontsHandling.Embed;

            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                string outputSvg = $"slide_{i + 1}.svg";
                using (FileStream fileStream = File.Create(outputSvg))
                {
                    presentation.Slides[i].WriteAsSvg(fileStream, svgOptions);
                }
            }

            // Save presentation before exit
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (System.Net.WebException)
        {
            // Handle external URL or web service exception
        }
    }
}