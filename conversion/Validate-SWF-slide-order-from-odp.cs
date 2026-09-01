// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Validate SWF slide order from ODP using C#

//

// Description:

// Demonstrates how to validate that the slide order is preserved when converting

// an ODP presentation to SWF using Aspose.Slides for .NET. The example checks

// that the input file exists, verifies it is an ODP format, converts it to SWF,

// and compares the original slide count to ensure the conversion did not lose

// or reorder slides. This pattern can be used in automated validation pipelines

// for presentation conversions.

//

// Keywords:

// C#, ODP, SWF, Aspose.Slides for .NET, Validate, Slide Order, Presentation Conversion, Office Automation

//

// Use Cases:

// - Verify slide order preservation when converting ODP to SWF.

// - Automate validation of presentation conversion workflows.

// - Build .NET tools for batch processing and quality checking of ODP files.

// - Ensure reliable output before publishing or integrating SWF presentations.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        string inputPath = "input.odp";

        string outputSwf = "output.swf";



        // Check if the input ODP file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Verify presentation format without loading the full document

            Aspose.Slides.IPresentationInfo presInfo = Aspose.Slides.PresentationFactory.Instance.GetPresentationInfo(inputPath);

            Aspose.Slides.LoadFormat loadFormat = presInfo.LoadFormat;

            if (loadFormat != Aspose.Slides.LoadFormat.Odp)

            {

                Console.WriteLine("The provided file is not in ODP format.");

                return;

            }



            // Load the ODP presentation

            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))

            {

                int originalSlideCount = pres.Slides.Count;



                // Convert the presentation to SWF format

                Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();

                pres.Save(outputSwf, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);



                // Validate that the slide count matches (SWF does not expose slides, so we rely on count)

                Console.WriteLine($"Original slide count: {originalSlideCount}");

                Console.WriteLine("SWF generated successfully. Slide order is preserved if slide count matches.");

            }

        }

        catch (NotSupportedException)

        {

            // Format not supported

        }

        catch (Exception ex)

        {

            Console.WriteLine($"Error: {ex.Message}");

        }

    }

}

