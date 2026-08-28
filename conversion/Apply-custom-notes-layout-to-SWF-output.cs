// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Apply custom notes layout to SWF output using C#

//

// Description:

// Demonstrates how to apply a custom notes layout when converting a PowerPoint

// presentation to SWF using Aspose.Slides for .NET. The example loads a PPTX

// file, configures the notes position for the generated SWF, and saves the

// output. This pattern can be used to automate PPTX‑to‑SWF conversion with

// specific notes formatting in .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, SWF, Aspose.Slides for .NET, Apply, Custom, Notes, Layout,

// Conversion, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of PPTX files to SWF with a custom notes layout.

// - Build C# utilities for PowerPoint presentation processing and publishing.

// - Generate SWF output with speaker annotations positioned at the bottom.

// - Validate presentation conversion workflows before integration.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Input and output file paths

        var inputPath = "input.pptx";

        var outputPath = "output.swf";



        // Verify input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Load presentation

            using (Presentation pres = new Presentation(inputPath))

            {

                // Configure SWF options with custom notes layout

                var swfOptions = new SwfOptions();

                var notesOptions = new NotesCommentsLayoutingOptions

                {

                    NotesPosition = NotesPositions.BottomFull // speaker annotations

                };

                swfOptions.SlidesLayoutOptions = notesOptions;



                // Save as SWF

                pres.Save(outputPath, SaveFormat.Swf, swfOptions);

            }

        }

        catch (NotSupportedException)

        {

            // Format not supported

        }

        catch (System.Net.WebException)

        {

            // Handle external URL or web service exception

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

