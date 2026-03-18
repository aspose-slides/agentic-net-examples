using System;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                var dataDir = "path/to/presentation/";
                var inputPath = System.IO.Path.Combine(dataDir, "input.pptx");
                var outputPath = System.IO.Path.Combine(dataDir, "output.pptx");

                using (var presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    var tableFound = false;
                    foreach (var slide in presentation.Slides)
                    {
                        foreach (var shape in slide.Shapes)
                        {
                            var table = shape as Aspose.Slides.Table;
                            if (table != null)
                            {
                                Console.WriteLine($"Table found on slide {slide.SlideNumber}");
                                tableFound = true;
                                break;
                            }
                        }
                        if (tableFound) break;
                    }

                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}