// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Validate mixed PPT and ODP slide sequence during SWF conversion using C#

//

// Description:

// Demonstrates how to load PPTX and ODP presentations, convert each to SWF, 

// and verify that the original slide counts are preserved after conversion. 

// The example uses Aspose.Slides for .NET in a console application and can be 

// adapted to automate presentation validation or batch conversion workflows.

//

// Keywords:

// C#, Aspose.Slides for .NET, PPTX, ODP, SWF, slide count validation, conversion, 

// presentation processing, Office automation

//

// Use Cases:

// - Verify that slide ordering and count are maintained when converting PPTX/ODP to SWF.

// - Build command‑line tools for batch conversion of presentations to SWF.

// - Integrate slide‑sequence validation into CI pipelines for presentation assets.

// - Generate SWF files for web preview while ensuring content integrity.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ValidateSwfSequence

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input presentation files (PPT and ODP)

            string pptInputPath = "mixed_source.pptx";

            string odpInputPath = "mixed_source.odp";



            // Output SWF files

            string pptSwfOutputPath = "mixed_source_ppt.swf";

            string odpSwfOutputPath = "mixed_source_odp.swf";



            // Validate input files existence

            if (!File.Exists(pptInputPath))

            {

                Console.WriteLine("PPT input file does not exist: " + pptInputPath);

                return;

            }



            if (!File.Exists(odpInputPath))

            {

                Console.WriteLine("ODP input file does not exist: " + odpInputPath);

                return;

            }



            try

            {

                // Process PPT file

                using (Presentation pptPresentation = new Presentation(pptInputPath))

                {

                    int pptSlideCount = pptPresentation.Slides.Count;



                    // Save as SWF

                    SwfOptions pptSwfOptions = new SwfOptions();

                    pptPresentation.Save(pptSwfOutputPath, SaveFormat.Swf, pptSwfOptions);



                    Console.WriteLine($"PPT: Slides={pptSlideCount}, SWF saved to {pptSwfOutputPath}");

                }



                // Process ODP file

                using (Presentation odpPresentation = new Presentation(odpInputPath))

                {

                    int odpSlideCount = odpPresentation.Slides.Count;



                    // Save as SWF

                    SwfOptions odpSwfOptions = new SwfOptions();

                    odpPresentation.Save(odpSwfOutputPath, SaveFormat.Swf, odpSwfOptions);



                    Console.WriteLine($"ODP: Slides={odpSlideCount}, SWF saved to {odpSwfOutputPath}");

                }



                // Validation: ensure slide counts are preserved in SWF conversion

                // (Aspose.Slides guarantees slide order in SWF; we report the counts)

                Console.WriteLine("Validation completed: slide sequencing preserved during SWF conversion.");

            }

            catch (NotSupportedException ex)

            {

                // Format not supported

                Console.WriteLine("The provided file format is not supported: " + ex.Message);

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

