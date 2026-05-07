using System;
using System.IO;
using Aspose.Slides.Export;

namespace AsposeSlidesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPath = args.Length > 1 ? args[1] : "output.odp";
            string intermediatePath = Path.Combine(Path.GetDirectoryName(outputPath), "temp_intermediate.pptx");

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Aspose.Slides.Presentation srcPres = null;
            Aspose.Slides.Presentation destPres = null;

            try
            {
                // Load source presentation
                srcPres = new Aspose.Slides.Presentation(inputPath);

                // Save to intermediate PPTX format
                srcPres.Save(intermediatePath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Load intermediate presentation (which will be used as destination)
                destPres = new Aspose.Slides.Presentation(intermediatePath);

                // Verify that all master slides and their layouts are transferred
                if (srcPres.Masters.Count != destPres.Masters.Count)
                {
                    Console.WriteLine("Master slide count mismatch after conversion.");
                }
                else
                {
                    for (int i = 0; i < srcPres.Masters.Count; i++)
                    {
                        Aspose.Slides.IMasterSlide srcMaster = srcPres.Masters[i];
                        Aspose.Slides.IMasterSlide destMaster = destPres.Masters[i];

                        if (srcMaster.LayoutSlides.Count != destMaster.LayoutSlides.Count)
                        {
                            Console.WriteLine($"Layout slide count mismatch in master index {i}.");
                        }
                    }
                }

                // Save final ODP file
                destPres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Odp);
                Console.WriteLine("Conversion completed successfully.");
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
            finally
            {
                // Dispose presentations and clean up intermediate file
                if (srcPres != null)
                {
                    srcPres.Dispose();
                }
                if (destPres != null)
                {
                    destPres.Dispose();
                }
                if (File.Exists(intermediatePath))
                {
                    try
                    {
                        File.Delete(intermediatePath);
                    }
                    catch
                    {
                        // Ignore cleanup errors
                    }
                }
            }
        }
    }
}