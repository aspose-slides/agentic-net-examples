// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert ODP to SWF and verify integrity using C#

//

// Description:

// Demonstrates how to convert an OpenDocument Presentation (ODP) file to

// Shockwave Flash (SWF) format and verify the conversion result using

// Aspose.Slides for .NET. The example loads the ODP file, saves it as SWF,

// checks that the output file exists and has a non‑zero size, and reports

// success or failure.

//

// Keywords:

// C#, Aspose.Slides, ODP, SWF, Convert, Verify, Integrity, Presentation,

// Office Automation, .NET

//

// Use Cases:

// - Automate conversion of ODP presentations to SWF for web preview.

// - Validate that the conversion produced a non‑empty SWF file.

// - Integrate ODP‑to‑SWF conversion into .NET batch processing tools.

// - Ensure file existence and size checks after conversion.

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

        string outputPath = "output.swf";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            Presentation pres = new Presentation(inputPath);

            pres.Save(outputPath, SaveFormat.Swf);

            if (File.Exists(outputPath))

            {

                FileInfo info = new FileInfo(outputPath);

                if (info.Length > 0)

                {

                    Console.WriteLine("Conversion successful. Output file size: " + info.Length);

                }

                else

                {

                    Console.WriteLine("Output file is empty.");

                }

            }

            else

            {

                Console.WriteLine("Output file was not created.");

            }

            pres.Dispose();

        }

        catch (NotSupportedException)

        {

            // format not supported

            Console.WriteLine("The format is not supported.");

        }

        catch (Exception ex)

        {

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

