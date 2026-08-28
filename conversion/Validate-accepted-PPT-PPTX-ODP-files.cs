// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Validate accepted PPT PPTX ODP files using C#

//

// Description:

// Demonstrates how to validate that an input file is a supported PowerPoint

// format (PPT, PPTX, ODP) using Aspose.Slides for .NET, and then convert the

// presentation to PPTX. The example shows how to obtain presentation info

// without fully loading the file, perform format validation, and save the

// result as a new PPTX file in a console application.

//

// Keywords:

// C#, PowerPoint, PPTX, PPT, ODP, Aspose.Slides for .NET, Validate, Convert,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Validate that a file is a supported PowerPoint format before processing.

// - Convert PPT or ODP files to PPTX programmatically.

// - Build .NET tools for batch conversion of presentations.

// - Integrate format validation and conversion into automated workflows.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        // Determine input file path

        string inputPath;

        if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))

        {

            inputPath = args[0];

        }

        else

        {

            inputPath = "input.pptx"; // default placeholder

        }



        // Verify that the file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Get presentation info without loading the full presentation

            IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(inputPath);

            LoadFormat loadFormat = info.LoadFormat;



            // Validate supported formats: PPT, PPTX, ODP

            bool supported = loadFormat == LoadFormat.Ppt ||

                             loadFormat == LoadFormat.Pptx ||

                             loadFormat == LoadFormat.Odp;



            if (!supported)

            {

                // format not supported

                Console.WriteLine("File format not supported for conversion.");

                return;

            }



            // Load the presentation

            using (Presentation pres = new Presentation(inputPath))

            {

                // Define output path (convert to PPTX as an example)

                string outputPath = Path.Combine(

                    Path.GetDirectoryName(inputPath) ?? string.Empty,

                    Path.GetFileNameWithoutExtension(inputPath) + "_converted.pptx");



                // Save the presentation

                pres.Save(outputPath, SaveFormat.Pptx);

                Console.WriteLine("Conversion completed: " + outputPath);

            }

        }

        catch (Exception ex)

        {

            // Handle any unexpected errors

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

