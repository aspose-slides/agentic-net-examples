// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Merge PPTX slides into single presentation using C#

//

// Description:

// Demonstrates how to merge slides from multiple PPTX files into a single

// presentation using C# and Aspose.Slides for .NET. The example shows the

// required presentation-processing steps for PowerPoint files and produces the

// combined output in a standalone console application. Developers can use this

// pattern to automate PPTX workflows, validate results, or integrate presentation

// logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Merge, Slides, Single,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate merging slides from multiple PPTX files into one presentation.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

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

            string sourcePath1 = "source1.pptx";

            string sourcePath2 = "source2.pptx";

            string outputPath = "merged.pptx";



            // Verify that input files exist

            if (!File.Exists(sourcePath1) || !File.Exists(sourcePath2))

            {

                Console.WriteLine("One or both input files were not found.");

                return;

            }



            try

            {

                // Load source presentations

                Presentation srcPres1 = new Presentation(sourcePath1);

                Presentation srcPres2 = new Presentation(sourcePath2);



                // Create destination presentation

                Presentation destPres = new Presentation();



                // Get slide collection of destination

                ISlideCollection destSlides = destPres.Slides;



                // Clone slides from the first presentation preserving order

                for (int i = 0; i < srcPres1.Slides.Count; i++)

                {

                    destSlides.AddClone(srcPres1.Slides[i]);

                }



                // Clone slides from the second presentation preserving order

                for (int i = 0; i < srcPres2.Slides.Count; i++)

                {

                    destSlides.AddClone(srcPres2.Slides[i]);

                }



                // Save the merged presentation

                destPres.Save(outputPath, SaveFormat.Pptx);



                // Dispose presentations

                srcPres1.Dispose();

                srcPres2.Dispose();

                destPres.Dispose();

            }

            catch (Exception ex)

            {

                // Handle unsupported format or other errors

                // Format not supported comment

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

