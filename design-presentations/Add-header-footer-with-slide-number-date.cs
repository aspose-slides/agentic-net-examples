using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string dataDir = "Data";
        string inputPath = Path.Combine(dataDir, "input.pptx");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            Presentation presentation = new Presentation(inputPath);

            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                IBaseSlideHeaderFooterManager manager = presentation.Slides[i].HeaderFooterManager;

                if (!manager.IsFooterVisible)
                {
                    manager.SetFooterVisibility(true);
                }
                if (!manager.IsSlideNumberVisible)
                {
                    manager.SetSlideNumberVisibility(true);
                }
                if (!manager.IsDateTimeVisible)
                {
                    manager.SetDateTimeVisibility(true);
                }

                manager.SetFooterText("Custom Footer Text");
                manager.SetDateTimeText(DateTime.Now.ToString("yyyy-MM-dd"));
            }

            // Ensure slide numbers are visible for the whole presentation
            presentation.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}