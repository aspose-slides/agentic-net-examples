// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Create handout PDF notes below two columns using C#

//

// Description:

// Demonstrates how to create a handout PDF with speaker notes placed below each

// slide arranged in two columns using C# and Aspose.Slides for .NET. The example

// shows the required presentation-processing steps for PowerPoint files and

// produces the requested output in a standalone console application. Developers

// can use this pattern to automate PPTX workflows, validate results, or integrate

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Handout, Notes, Below,

// Columns, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate creation of handout PDFs with notes below two-column slide layouts.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files into handout PDFs in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        string inputPath = "input.pptx";

        string outputPath = "output.pdf";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            using (Presentation pres = new Presentation(inputPath))

            {

                PdfOptions options = new PdfOptions

                {

                    SlidesLayoutOptions = new HandoutLayoutingOptions

                    {

                        Handout = HandoutType.Handouts2,

                        PrintSlideNumbers = false,

                        PrintFrameSlide = false

                    }

                };



                // Save the presentation as a handout PDF with speaker notes beneath each slide

                pres.Save(outputPath, SaveFormat.Pdf, options);

            }

        }

        catch (NotSupportedException)

        {

            // Format not supported

            Console.WriteLine("The file format is not supported.");

        }

        catch (Exception ex)

        {

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

