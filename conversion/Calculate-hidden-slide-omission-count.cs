// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Calculate hidden slide omission count using C#

//

// Description:

// Demonstrates how to calculate the number of hidden slides that would be omitted

// when a presentation is saved with default settings using Aspose.Slides for .NET.

// The example loads a PPTX file, retrieves the hidden slide count, outputs the

// result, and saves a copy of the presentation. This pattern can be used to

// automate slide visibility checks or to prepare presentations for publishing.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Calculate, Hidden Slides, Omission,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Determine how many hidden slides will be omitted during export.

// - Build tools that validate slide visibility before publishing.

// - Automate PowerPoint processing workflows in .NET applications.

// - Integrate hidden slide analysis into custom presentation pipelines.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");

        string outputPath = Path.Combine(Environment.CurrentDirectory, "output.pptx");



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        int omittedHiddenSlides = GetOmittedHiddenSlides(inputPath);

        Console.WriteLine("Number of hidden slides omitted: " + omittedHiddenSlides);



        try

        {

            using (Presentation pres = new Presentation(inputPath))

            {

                // Save presentation before exit

                pres.Save(outputPath, SaveFormat.Pptx);

            }

        }

        catch (Exception ex)

        {

            // Handle unsupported format or other errors

            Console.WriteLine("Error processing presentation: " + ex.Message);

        }

    }



    static int GetOmittedHiddenSlides(string filePath)

    {

        try

        {

            using (Presentation pres = new Presentation(filePath))

            {

                // When ShowHiddenSlides is false (default), omitted slides equal HiddenSlides count

                return pres.DocumentProperties.HiddenSlides;

            }

        }

        catch (Exception)

        {

            // format not supported

            return 0;

        }

    }

}

