using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace SmartArtBorderIncrease
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Get the first slide
                    Aspose.Slides.ISlide slide = presentation.Slides[0];

                    // Locate the first SmartArt shape on the slide
                    Aspose.Slides.SmartArt.ISmartArt smartArt = null;
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        smartArt = shape as Aspose.Slides.SmartArt.SmartArt;
                        if (smartArt != null)
                        {
                            break;
                        }
                    }

                    if (smartArt != null)
                    {
                        // Iterate over all nodes and increase border thickness
                        foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smartArt.AllNodes)
                        {
                            foreach (Aspose.Slides.SmartArt.ISmartArtShape smartShape in node.Shapes)
                            {
                                // Increase the line (border) width by 1 point
                                smartShape.LineFormat.Width = smartShape.LineFormat.Width + 1f;
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (System.Net.WebException)
            {
                // Handle external URL or web service errors
            }
        }
    }
}