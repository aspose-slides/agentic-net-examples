// -----------------------------------------------------------------------------
// Example: Clone Presentation In-Memory for MathML Export
//
// Description:
// This console application loads an existing PowerPoint PPTX file, creates an
// in‑memory clone of the presentation using Aspose.Slides, and demonstrates how
// to prepare the clone for MathML export without modifying the original file.
// The clone is saved as a separate PPTX file; replace the placeholder with
// actual MathML export logic as needed.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, presentation clone, MathML export
//
// Use Cases:
// - Generate MathML from slides while preserving the source presentation.
// - Perform analysis or transformations on a temporary copy of a PPTX.
// - Automate batch processing of presentations for mathematical content extraction.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace AsposeSlidesCloneMathML
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "source.pptx";
            string outputPath = "cloned_for_mathml.pptx";

            // Verify that the source file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file does not exist: " + inputPath);
                return;
            }

            // Load the original presentation
            Aspose.Slides.Presentation srcPres = null;
            Aspose.Slides.Presentation tempPres = null;
            try
            {
                srcPres = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading source presentation: " + ex.Message);
                return;
            }

            try
            {
                // Create an empty temporary presentation
                tempPres = new Aspose.Slides.Presentation();

                // Clone each slide from the source into the temporary presentation
                Aspose.Slides.ISlideCollection srcSlides = srcPres.Slides;
                for (int i = 0; i < srcSlides.Count; i++)
                {
                    Aspose.Slides.ISlide sourceSlide = srcSlides[i];
                    // AddClone clones the slide together with its layout/master
                    tempPres.Slides.AddClone(sourceSlide);
                }

                // -------------------------------------------------------------
                // Placeholder for MathML export logic.
                // Aspose.Slides provides MathML export via the MathMlExportOptions
                // class (if available). Replace the following comment with actual
                // export code, for example:
                // Aspose.Slides.Export.MathMlExportOptions options = new Aspose.Slides.Export.MathMlExportOptions();
                // tempPres.Save("output.mathml", Aspose.Slides.Export.SaveFormat.MathMl, options);
                // -------------------------------------------------------------

                // For demonstration, save the cloned presentation as PPTX
                tempPres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Cloned presentation saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during cloning or saving: " + ex.Message);
            }
            finally
            {
                // Dispose presentations to release resources
                if (srcPres != null)
                {
                    srcPres.Dispose();
                }
                if (tempPres != null)
                {
                    tempPres.Dispose();
                }
            }
        }
    }
}
