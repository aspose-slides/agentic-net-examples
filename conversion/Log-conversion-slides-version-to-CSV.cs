// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Log Aspose.Slides version and convert slide to PDF using C#

//

// Description:

// Demonstrates how to log the Aspose.Slides library version to a CSV-formatted

// log file and convert selected slides from a PowerPoint presentation to PDF

// using Aspose.Slides for .NET. The example includes basic file existence

// checks, version retrieval, logging, selective slide export, and saving a copy

// of the original presentation.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Conversion, Slides, Version,

// Logging, CSV, PDF, Presentation Processing, Office Automation

//

// Use Cases:

// - Record Aspose.Slides version information for audit or troubleshooting.

// - Automate conversion of specific slides to PDF.

// - Generate CSV-compatible logs for integration with reporting tools.

// - Build .NET utilities for PowerPoint presentation workflow automation.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        string inputPath = "input.pptx";

        string outputPath = "output.pdf";

        string logPath = "conversion.log";



        try

        {

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist.");

                return;

            }



            Presentation presentation = new Presentation(inputPath);



            string version = Aspose.Slides.BuildVersionInfo.AssemblyVersion;

            string logEntry = DateTime.Now.ToString("s") + ",Aspose.Slides version," + version;

            File.AppendAllText(logPath, logEntry + Environment.NewLine);



            int[] slides = new int[] { 1 };

            presentation.Save(outputPath, slides, SaveFormat.Pdf);



            presentation.Save("saved.pptx", SaveFormat.Pptx);

            presentation.Dispose();

        }

        catch (NotSupportedException)

        {

            // Format not supported

            Console.WriteLine("The requested format is not supported.");

        }

        catch (Exception ex)

        {

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

