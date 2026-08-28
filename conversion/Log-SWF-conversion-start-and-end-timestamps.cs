// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Log SWF conversion start and end timestamps using C#

//

// Description:

// Demonstrates how to log the start and end timestamps of converting PowerPoint

// presentations to SWF format using C# and Aspose.Slides for .NET. The example

// iterates over a list of PPTX files, performs the conversion, and writes the

// timing information to the console. This pattern helps developers monitor

// conversion performance and integrate logging into batch processing tools.

//

// Keywords:

// C#, PowerPoint, PPTX, SWF, Aspose.Slides for .NET, Conversion, Timestamps,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Log SWF conversion start and end timestamps for batch processing.

// - Build C# utilities for PowerPoint to SWF conversion with performance tracking.

// - Integrate conversion timing into automated workflows or CI pipelines.

// - Diagnose and optimize presentation conversion performance.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        var inputFiles = new string[] { "sample1.pptx", "sample2.pptx" };



        foreach (var inputPath in inputFiles)

        {

            if (!File.Exists(inputPath))

            {

                Console.WriteLine($"Input file not found: {inputPath}");

                continue;

            }



            try

            {

                var startTime = DateTime.Now;

                Console.WriteLine($"Starting SWF conversion for '{inputPath}' at {startTime}");



                var presentation = new Aspose.Slides.Presentation(inputPath);

                var swfOptions = new Aspose.Slides.Export.SwfOptions();



                var outputPath = Path.ChangeExtension(inputPath, ".swf");

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

                presentation.Dispose();



                var endTime = DateTime.Now;

                Console.WriteLine($"Finished SWF conversion for '{inputPath}' at {endTime} (Duration: {(endTime - startTime).TotalSeconds} seconds)");

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine($"Format not supported for file: {inputPath}");

            }

            catch (Exception ex)

            {

                Console.WriteLine($"Error processing file '{inputPath}': {ex.Message}");

            }

        }

    }

}

