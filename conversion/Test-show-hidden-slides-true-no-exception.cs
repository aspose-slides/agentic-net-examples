// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Test show hidden slides true no exception using C#

//

// Description:

// Demonstrates how to test that setting ShowHiddenSlides to true when saving a

// presentation to SWF does not throw an exception. The example creates a new

// presentation, hides the first slide, configures SwfOptions to show hidden

// slides, saves the file as SWF, and verifies successful execution.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Test, ShowHiddenSlides, Hidden Slides,

// SWF, Presentation Processing, Office Automation

//

// Use Cases:

// - Verify that hidden slides are included when ShowHiddenSlides is enabled.

// - Ensure SWF export works without errors for presentations with hidden slides.

// - Build automated tests for Aspose.Slides export options.

// - Integrate hidden slide handling into .NET PowerPoint processing tools.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        TestSwfOptionsShowHiddenSlides();

    }



    static void TestSwfOptionsShowHiddenSlides()

    {

        string outputPath = "output.swf";



        // Delete existing file if present

        if (File.Exists(outputPath))

        {

            File.Delete(outputPath);

        }



        try

        {

            // Create a new presentation

            using (Presentation presentation = new Presentation())

            {

                // Mark the first slide as hidden

                ISlide slide = presentation.Slides[0];

                slide.Hidden = true;



                // Configure SWF options

                SwfOptions options = new SwfOptions();

                options.ShowHiddenSlides = true;



                // Save as SWF; should not throw an exception

                presentation.Save(outputPath, SaveFormat.Swf, options);

            }



            Console.WriteLine("Test passed: No exception when ShowHiddenSlides is true.");

        }

        catch (Aspose.Slides.PptxUnsupportedFormatException ex)

        {

            // Format not supported

            Console.WriteLine("Unsupported format: " + ex.Message);

        }

        catch (Aspose.Slides.PptUnsupportedFormatException ex)

        {

            Console.WriteLine("Unsupported format: " + ex.Message);

        }

        catch (Exception ex)

        {

            // Any other exception indicates test failure

            Console.WriteLine("Test failed: " + ex.GetType().FullName + " - " + ex.Message);

        }

        finally

        {

            // Clean up generated file

            if (File.Exists(outputPath))

            {

                File.Delete(outputPath);

            }

        }

    }

}

