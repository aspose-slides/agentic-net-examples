// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Validate slide title placeholder per slide using C#

//

// Description:

// Demonstrates how to iterate through all slides in a PowerPoint presentation,

// check that each slide contains at least one centered title placeholder, and

// report any missing titles. The example also saves the (potentially unchanged)

// presentation to a new file. This pattern helps automate validation of PPTX

// files using Aspose.Slides for .NET.

//

// Keywords:

// C#, Aspose.Slides, PowerPoint, PPTX, Validate, Slide Title, Placeholder, 

// Presentation Validation, Office Automation

//

// Use Cases:

// - Verify that every slide in a presentation has a title placeholder before publishing.

// - Integrate slide title validation into CI/CD pipelines for presentation assets.

// - Build command‑line tools that audit PPTX files for required placeholders.

// - Ensure consistency of slide layouts in automated PowerPoint generation workflows.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        // Input and output file paths

        string inputPath = "input.pptx";

        string outputPath = "validated_output.pptx";



        // Check if input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        Presentation presentation = null;

        try

        {

            // Load the presentation

            presentation = new Presentation(inputPath);

        }

        catch (Exception ex)

        {

            // Handle unsupported format or loading errors

            Console.WriteLine("Failed to load presentation. Possible unsupported format.");

            Console.WriteLine(ex.Message);

            return;

        }



        // Validate each slide contains at least one title placeholder

        bool allSlidesValid = true;

        for (int i = 0; i < presentation.Slides.Count; i++)

        {

            ISlide slide = presentation.Slides[i];

            bool hasTitlePlaceholder = false;



            foreach (IShape shape in slide.Shapes)

            {

                if (shape.Placeholder != null && shape.Placeholder.Type == PlaceholderType.CenteredTitle)

                {

                    hasTitlePlaceholder = true;

                    break;

                }

            }



            if (!hasTitlePlaceholder)

            {

                allSlidesValid = false;

                Console.WriteLine($"Slide {i + 1} does not contain a title placeholder.");

            }

        }



        if (allSlidesValid)

        {

            Console.WriteLine("All slides contain a title placeholder.");

        }



        // Save the presentation before exit

        try

        {

            presentation.Save(outputPath, SaveFormat.Pptx);

            Console.WriteLine("Presentation saved to: " + outputPath);

        }

        catch (Exception ex)

        {

            Console.WriteLine("Failed to save presentation.");

            Console.WriteLine(ex.Message);

        }

        finally

        {

            if (presentation != null)

            {

                presentation.Dispose();

            }

        }

    }

}

