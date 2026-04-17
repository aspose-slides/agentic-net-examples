using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "sample.pptx";
            string outputPath = "sample.odp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the source presentation
                Presentation srcPres = new Presentation(inputPath);

                // Save as ODP format
                srcPres.Save(outputPath, SaveFormat.Odp);

                // Load the saved ODP to verify master layouts
                Presentation destPres = new Presentation(outputPath);

                // Verify master slide count
                bool mastersMatch = srcPres.Masters.Count == destPres.Masters.Count;

                // Verify layout slide count for each master
                bool layoutsMatch = true;
                for (int i = 0; i < srcPres.Masters.Count && layoutsMatch; i++)
                {
                    int srcLayoutCount = srcPres.Masters[i].LayoutSlides.Count;
                    int destLayoutCount = destPres.Masters[i].LayoutSlides.Count;
                    if (srcLayoutCount != destLayoutCount)
                    {
                        layoutsMatch = false;
                    }
                }

                if (mastersMatch && layoutsMatch)
                {
                    Console.WriteLine("All master layouts were successfully transferred to ODP.");
                }
                else
                {
                    Console.WriteLine("Master layout verification failed.");
                }

                // Dispose presentations
                srcPres.Dispose();
                destPres.Dispose();
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
}