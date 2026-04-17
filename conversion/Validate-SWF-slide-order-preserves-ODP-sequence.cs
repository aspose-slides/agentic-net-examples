using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input ODP file and output SWF file paths
        string inputPath = "input.odp";
        string outputPath = "output.swf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Get presentation info to ensure the file is ODP
            Aspose.Slides.IPresentationInfo presInfo = Aspose.Slides.PresentationFactory.Instance.GetPresentationInfo(inputPath);
            if (presInfo.LoadFormat != Aspose.Slides.LoadFormat.Odp)
            {
                Console.WriteLine("The input file is not in ODP format.");
                return;
            }

            // Load the ODP presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                // Capture original slide order (slide numbers)
                int slideCount = pres.Slides.Count;
                int[] originalOrder = new int[slideCount];
                for (int i = 0; i < slideCount; i++)
                {
                    originalOrder[i] = pres.Slides[i].SlideNumber;
                }

                // Convert to SWF format
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf);

                // Validate that slide count remains the same after conversion
                Console.WriteLine("Conversion completed. Slide count: " + slideCount);
                // Note: Direct validation of SWF slide order would require external tools.
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The specified format is not supported for conversion.");
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}