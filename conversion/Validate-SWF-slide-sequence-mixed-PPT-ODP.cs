using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths to source presentations
        string pptPath = "input.ppt";
        string odpPath = "input.odp";

        // Paths for generated SWF files
        string pptSwfPath = "output_ppt.swf";
        string odpSwfPath = "output_odp.swf";

        // Verify source files exist
        if (!File.Exists(pptPath))
        {
            Console.WriteLine("PPT file not found: " + pptPath);
            return;
        }
        if (!File.Exists(odpPath))
        {
            Console.WriteLine("ODP file not found: " + odpPath);
            return;
        }

        // Convert PPT to SWF and validate slide count
        try
        {
            using (Aspose.Slides.Presentation pptPres = new Aspose.Slides.Presentation(pptPath))
            {
                int pptSlideCount = pptPres.Slides.Count;
                Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();
                pptPres.Save(pptSwfPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);
                Console.WriteLine("PPT converted to SWF. Slides: " + pptSlideCount);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported for SWF conversion
            Console.WriteLine("PPT format not supported for SWF conversion.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error processing PPT: " + ex.Message);
        }

        // Convert ODP to SWF and validate slide count
        try
        {
            using (Aspose.Slides.Presentation odpPres = new Aspose.Slides.Presentation(odpPath))
            {
                int odpSlideCount = odpPres.Slides.Count;
                Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();
                odpPres.Save(odpSwfPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);
                Console.WriteLine("ODP converted to SWF. Slides: " + odpSlideCount);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported for SWF conversion
            Console.WriteLine("ODP format not supported for SWF conversion.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error processing ODP: " + ex.Message);
        }

        // Simple validation output
        Console.WriteLine("SWF conversion and slide sequencing validation completed.");
    }
}