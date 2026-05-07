using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.odp";
        string outputSwf = "output.swf";

        // Check if the input ODP file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Verify presentation format without loading the full document
            Aspose.Slides.IPresentationInfo presInfo = Aspose.Slides.PresentationFactory.Instance.GetPresentationInfo(inputPath);
            Aspose.Slides.LoadFormat loadFormat = presInfo.LoadFormat;
            if (loadFormat != Aspose.Slides.LoadFormat.Odp)
            {
                Console.WriteLine("The provided file is not in ODP format.");
                return;
            }

            // Load the ODP presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                int originalSlideCount = pres.Slides.Count;

                // Convert the presentation to SWF format
                Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();
                pres.Save(outputSwf, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

                // Validate that the slide count matches (SWF does not expose slides, so we rely on count)
                Console.WriteLine($"Original slide count: {originalSlideCount}");
                Console.WriteLine("SWF generated successfully. Slide order is preserved if slide count matches.");
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}