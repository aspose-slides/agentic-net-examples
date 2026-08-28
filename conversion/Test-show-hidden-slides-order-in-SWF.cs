// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Test show hidden slides order in SWF using C#

//

// Description:

// Demonstrates how to generate SWF files from a PowerPoint presentation

// with and without hidden slides using Aspose.Slides for .NET. The example

// loads a PPTX file, saves two SWF outputs (one excluding hidden slides and

// one including them), and handles common errors such as missing input files

// or unsupported formats.

//

// Keywords:

// C#, PowerPoint, PPTX, SWF, Aspose.Slides for .NET, Hidden Slides, 

// Presentation Conversion, Office Automation

//

// Use Cases:

// - Verify the effect of the ShowHiddenSlides option when converting PPTX to SWF.

// - Create automated tools that produce SWF presentations with specific slide visibility.

// - Test and validate presentation conversion workflows in .NET applications.

// - Generate SWF assets for web publishing while controlling hidden slide inclusion.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace TestShowHiddenSlidesInSwf

{

    class Program

    {

        static void Main(string[] args)

        {

            string inputPath = "input.pptx";

            string outputPathHiddenFalse = "output_showhidden_false.swf";

            string outputPathHiddenTrue = "output_showhidden_true.swf";



            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                Presentation presentation = new Presentation(inputPath);



                // Save without hidden slides

                SwfOptions optionsFalse = new SwfOptions();

                optionsFalse.ShowHiddenSlides = false;

                presentation.Save(outputPathHiddenFalse, SaveFormat.Swf, optionsFalse);



                // Save with hidden slides

                SwfOptions optionsTrue = new SwfOptions();

                optionsTrue.ShowHiddenSlides = true;

                presentation.Save(outputPathHiddenTrue, SaveFormat.Swf, optionsTrue);



                // Dispose the presentation

                presentation.Dispose();



                Console.WriteLine("SWF files generated successfully.");

            }

            catch (Aspose.Slides.PptxUnsupportedFormatException)

            {

                // Format not supported

                Console.WriteLine("The provided file format is not supported for conversion to SWF.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

