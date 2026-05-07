using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.xps";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    Aspose.Slides.IBaseSlideHeaderFooterManager headerFooter = presentation.Slides[i].HeaderFooterManager;
                    if (!headerFooter.IsFooterVisible)
                    {
                        headerFooter.SetFooterVisibility(true);
                    }
                    headerFooter.SetFooterText("My Footer");
                }

                Aspose.Slides.Export.XpsOptions options = new Aspose.Slides.Export.XpsOptions();
                // Customize XpsOptions if needed, e.g., options.DrawSlidesFrame = true;

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Xps, options);
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException)
        {
            // Format not supported
            Console.WriteLine("The presentation format is not supported for XPS conversion.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}