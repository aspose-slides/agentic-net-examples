using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MergePresentations
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string sourceFile1 = "Presentation1.pptx";
            string sourceFile2 = "Presentation2.pptx";
            string outputFile = "MergedPresentation.pptx";

            // Verify source files exist
            if (!File.Exists(sourceFile1))
            {
                Console.WriteLine("Source file not found: " + sourceFile1);
                return;
            }
            if (!File.Exists(sourceFile2))
            {
                Console.WriteLine("Source file not found: " + sourceFile2);
                return;
            }

            try
            {
                // Load first source presentation
                Aspose.Slides.Presentation srcPres1 = new Aspose.Slides.Presentation(sourceFile1);
                // Load second source presentation
                Aspose.Slides.Presentation srcPres2 = new Aspose.Slides.Presentation(sourceFile2);
                // Create destination presentation
                Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation();

                // Helper method to clone slides from a source presentation
                void CloneSlides(Aspose.Slides.Presentation srcPres)
                {
                    Aspose.Slides.ISlideCollection srcSlides = srcPres.Slides;
                    for (int i = 0; i < srcSlides.Count; i++)
                    {
                        // Clone slide with its master to preserve animations
                        Aspose.Slides.ISlide sourceSlide = srcSlides[i];
                        Aspose.Slides.IMasterSlide sourceMaster = sourceSlide.LayoutSlide.MasterSlide;
                        Aspose.Slides.IMasterSlide destMaster = destPres.Masters.AddClone(sourceMaster);
                        destPres.Slides.AddClone(sourceSlide, destMaster, true);
                    }
                }

                // Clone slides from both presentations
                CloneSlides(srcPres1);
                CloneSlides(srcPres2);

                // Save merged presentation
                destPres.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);

                // Dispose resources
                srcPres1.Dispose();
                srcPres2.Dispose();
                destPres.Dispose();

                Console.WriteLine("Merged presentation saved to: " + outputFile);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("One of the input files has an unsupported format.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}