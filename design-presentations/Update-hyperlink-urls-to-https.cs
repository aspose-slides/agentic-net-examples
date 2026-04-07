using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace UpdateHyperlinks
{
    class Program
    {
        static void Main()
        {
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                using (var presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    foreach (var slide in presentation.Slides)
                    {
                        foreach (var shape in slide.Shapes)
                        {
                            if (shape is Aspose.Slides.IAutoShape autoShape && autoShape.TextFrame != null)
                            {
                                var paragraphs = autoShape.TextFrame.Paragraphs;
                                for (int p = 0; p < paragraphs.Count; p++)
                                {
                                    var portions = paragraphs[p].Portions;
                                    for (int po = 0; po < portions.Count; po++)
                                    {
                                        var hyperlink = portions[po].PortionFormat.HyperlinkClick;
                                        if (hyperlink != null)
                                        {
                                            var url = (hyperlink as Aspose.Slides.Hyperlink)?.ExternalUrl;
                                            if (!string.IsNullOrEmpty(url) && url.StartsWith("http://"))
                                            {
                                                var newUrl = "https://" + url.Substring(7);
                                                portions[po].PortionFormat.HyperlinkClick = new Aspose.Slides.Hyperlink(newUrl);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("File format not supported.");
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}