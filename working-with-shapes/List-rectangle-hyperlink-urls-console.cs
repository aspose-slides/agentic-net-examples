using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main()
        {
            string inputPath = "input.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    foreach (ISlide slide in presentation.Slides)
                    {
                        foreach (IShape shape in slide.Shapes)
                        {
                            IAutoShape autoShape = shape as IAutoShape;
                            if (autoShape != null && autoShape.ShapeType == ShapeType.Rectangle)
                            {
                                IHyperlink hyperlink = autoShape.HyperlinkClick;
                                if (hyperlink != null && !string.IsNullOrEmpty(hyperlink.ExternalUrl))
                                {
                                    Console.WriteLine(hyperlink.ExternalUrl);
                                }
                            }
                        }
                    }

                    // Save the presentation before exiting
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}