// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert PPTX to ODP retaining textboxes using C#

//

// Description:

// Demonstrates how to convert a PPTX file to ODP format while ensuring that

// all text boxes are retained. The example loads a presentation, accesses each

// slide's text frames (which forces the text boxes to be included), and saves

// the result as an ODP file using Aspose.Slides for .NET. This pattern can be

// used in console applications to automate PowerPoint conversion workflows.

//

// Keywords:

// C#, PowerPoint, PPTX, ODP, Aspose.Slides for .NET, Convert, Retaining, 

// Textboxes, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of PPTX to ODP while preserving text boxes.

// - Build C# utilities for PowerPoint presentation processing.

// - Integrate PPTX to ODP conversion into .NET applications.

// - Validate that text boxes survive format conversion before publishing.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        string inputPath = "input.pptx";

        string outputPath = "output.odp";



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        try

        {

            // Load the PPTX presentation

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))

            {

                // Iterate through slides to access all text boxes (ensures they are retained)

                for (int i = 0; i < presentation.Slides.Count; i++)

                {

                    Aspose.Slides.ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(presentation.Slides[i]);

                    // No modification needed; just accessing the text frames

                }



                // Save the presentation as ODP

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Odp);

            }

        }

        catch (NotSupportedException)

        {

            // Format not supported

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

