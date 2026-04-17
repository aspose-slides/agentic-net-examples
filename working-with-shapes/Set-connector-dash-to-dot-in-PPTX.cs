using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                    {
                        foreach (Aspose.Slides.IShape shape in slide.Shapes)
                        {
                            Aspose.Slides.IConnector connector = shape as Aspose.Slides.IConnector;
                            if (connector != null && connector.LineFormat != null)
                            {
                                connector.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.Dot;
                            }
                        }
                    }

                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}