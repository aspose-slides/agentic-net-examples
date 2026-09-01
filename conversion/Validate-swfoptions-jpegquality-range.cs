// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Validate swfoptions jpegquality range using C#

//

// Description:

// Demonstrates how to validate SwfOptions.JpegQuality property range using C# and 

// Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Validate, SwfOptions, 

// JpegQuality, Range, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate validation of SwfOptions.JpegQuality range.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides.Export;



namespace SwfOptionsJpegQualityTest

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define paths

            string presentationPath = "test.pptx";

            string outputSwfPath = "output.swf";



            // Ensure presentation file exists

            if (!File.Exists(presentationPath))

            {

                // Create a new presentation and save it

                Aspose.Slides.Presentation newPresentation = new Aspose.Slides.Presentation();

                newPresentation.Save(presentationPath, Aspose.Slides.Export.SaveFormat.Pptx);

                newPresentation.Dispose();

            }



            // Load the presentation

            Aspose.Slides.Presentation presentation = null;

            try

            {

                presentation = new Aspose.Slides.Presentation(presentationPath);

            }

            catch (Exception ex)

            {

                // Handle loading errors (e.g., unsupported format)

                Console.WriteLine("Error loading presentation: " + ex.Message);

                // format not supported

                return;

            }



            // Create SwfOptions and test JpegQuality property

            Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();



            // Test valid value

            try

            {

                swfOptions.JpegQuality = 50; // within 0-100

                Console.WriteLine("Set JpegQuality to 50 successfully.");

            }

            catch (Exception ex)

            {

                Console.WriteLine("Failed to set valid JpegQuality: " + ex.Message);

            }



            // Test value below range

            try

            {

                swfOptions.JpegQuality = -10;

                Console.WriteLine("Set JpegQuality to -10 (should not happen).");

            }

            catch (Exception ex)

            {

                Console.WriteLine("Caught exception for JpegQuality -10: " + ex.Message);

            }



            // Test value above range

            try

            {

                swfOptions.JpegQuality = 150;

                Console.WriteLine("Set JpegQuality to 150 (should not happen).");

            }

            catch (Exception ex)

            {

                Console.WriteLine("Caught exception for JpegQuality 150: " + ex.Message);

            }



            // Save the presentation as SWF using the options

            try

            {

                presentation.Save(outputSwfPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

                Console.WriteLine("Presentation saved as SWF successfully.");

            }

            catch (Exception ex)

            {

                Console.WriteLine("Error saving SWF: " + ex.Message);

            }



            // Clean up

            presentation.Dispose();

        }

    }

}

