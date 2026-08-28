// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Merge presentations preserve all animations using C#

//

// Description:

// Demonstrates how to merge two PowerPoint presentations while preserving all

// animations using C# and Aspose.Slides for .NET. The example loads two source

// PPTX files, clones their slides (including animation timelines) into a new

// presentation, and saves the merged result. This pattern can be used to

// automate PPTX workflows, validate results, or integrate presentation logic

// into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Merge, Presentations, Preserve,

// Animations, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate merging of presentations while keeping existing animations.

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

            string sourcePath1 = "Presentation1.pptx";

            string sourcePath2 = "Presentation2.pptx";

            string outputPath = "MergedPresentation.pptx";



            if (!File.Exists(sourcePath1))

            {

                Console.WriteLine("Source file 1 does not exist.");

                return;

            }

            if (!File.Exists(sourcePath2))

            {

                Console.WriteLine("Source file 2 does not exist.");

                return;

            }



            try

            {

                Aspose.Slides.Presentation sourcePres1 = new Aspose.Slides.Presentation(sourcePath1);

                Aspose.Slides.Presentation sourcePres2 = new Aspose.Slides.Presentation(sourcePath2);

                Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation();



                // Clone slides from first source presentation

                for (int i = 0; i < sourcePres1.Slides.Count; i++)

                {

                    Aspose.Slides.ISlide sourceSlide = sourcePres1.Slides[i];

                    Aspose.Slides.IMasterSlide sourceMaster = sourceSlide.LayoutSlide.MasterSlide;

                    Aspose.Slides.IMasterSlide destMaster = destPres.Masters.AddClone(sourceMaster);

                    destPres.Slides.AddClone(sourceSlide, destMaster, true);

                }



                // Clone slides from second source presentation

                for (int i = 0; i < sourcePres2.Slides.Count; i++)

                {

                    Aspose.Slides.ISlide sourceSlide = sourcePres2.Slides[i];

                    Aspose.Slides.IMasterSlide sourceMaster = sourceSlide.LayoutSlide.MasterSlide;

                    Aspose.Slides.IMasterSlide destMaster = destPres.Masters.AddClone(sourceMaster);

                    destPres.Slides.AddClone(sourceSlide, destMaster, true);

                }



                destPres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);



                sourcePres1.Dispose();

                sourcePres2.Dispose();

                destPres.Dispose();

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

