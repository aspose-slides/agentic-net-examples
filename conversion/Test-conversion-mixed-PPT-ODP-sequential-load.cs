using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input file paths
        string pptPath = "input.ppt";
        string odpPath = "input.odp";

        // Output file paths
        string outputPptxFromPpt = "output_from_ppt.pptx";
        string outputPptxFromOdp = "output_from_odp.pptx";

        // Verify input files exist
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

        // Load PPT, convert to PPTX
        try
        {
            Aspose.Slides.Presentation presPpt = new Aspose.Slides.Presentation(pptPath);
            // Save using convert-without-xps-options rule
            presPpt.Save(outputPptxFromPpt, Aspose.Slides.Export.SaveFormat.Pptx);
            presPpt.Dispose();
        }
        catch (NotSupportedException)
        {
            // format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error processing PPT file: " + ex.Message);
        }

        // Load ODP, convert to PPTX
        try
        {
            Aspose.Slides.Presentation presOdp = new Aspose.Slides.Presentation(odpPath);
            // Save using convert-without-xps-options rule
            presOdp.Save(outputPptxFromOdp, Aspose.Slides.Export.SaveFormat.Pptx);
            presOdp.Dispose();
        }
        catch (NotSupportedException)
        {
            // format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error processing ODP file: " + ex.Message);
        }
    }
}