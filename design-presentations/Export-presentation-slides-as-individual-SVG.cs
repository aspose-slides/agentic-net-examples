// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export presentation slides as individual SVG using C#

//

// Description:

// Demonstrates how to export each slide of a PowerPoint presentation to a

// separate SVG file using Aspose.Slides for .NET. The example loads a PPTX,

// iterates through all slides, writes each slide as an SVG image to a target

// directory, and optionally saves the original presentation.

//

// Keywords:

// C#, Aspose.Slides, PowerPoint, PPTX, SVG, Export, Slides, Presentation,

// Office Automation, .NET

//

// Use Cases:

// - Convert PowerPoint slides to scalable vector graphics for web or print.

// - Automate batch processing of presentations to SVG format.

// - Integrate slide‑to‑SVG conversion into .NET tools or services.

// - Prepare assets for responsive design or further graphic manipulation.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        // Define input presentation path and output directory for SVG files

        string inputPath = "input.pptx";

        string outputDir = "output_svgs";



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        // Ensure the output directory exists

        Directory.CreateDirectory(outputDir);



        try

        {

            // Load the presentation

            Presentation presentation = new Presentation(inputPath);



            // Convert each slide to an individual SVG file

            for (int i = 0; i < presentation.Slides.Count; i++)

            {

                string svgFilePath = Path.Combine(outputDir, $"slide_{i + 1}.svg");

                using (FileStream fileStream = File.Create(svgFilePath))

                {

                    presentation.Slides[i].WriteAsSvg(fileStream);

                }

            }



            // Save the presentation before exiting (no modifications made)

            presentation.Save(inputPath, SaveFormat.Pptx);

            presentation.Dispose();

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

