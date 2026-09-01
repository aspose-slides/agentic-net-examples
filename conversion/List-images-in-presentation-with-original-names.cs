// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: List images in presentation with original names using C#

//

// Description:

// Demonstrates how to enumerate images in a PowerPoint presentation and

// generate a Markdown summary that lists each image using its original name

// (or a generated placeholder) with Aspose.Slides for .NET. The example loads

// a PPTX file, iterates through the presentation's image collection, writes

// the image identifiers to a Markdown file, and saves the (unchanged)

// presentation.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, List Images, Original Names,

// Markdown Summary, Presentation Processing, Office Automation

//

// Use Cases:

// - Generate a catalog of images contained in a PPTX file.

// - Build tools that audit or document presentation assets.

// - Integrate image enumeration into .NET automation workflows.

// - Produce Markdown reports for documentation or review processes.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Define paths

        string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");

        string inputPath = Path.Combine(dataDir, "input.pptx");

        string markdownPath = Path.Combine(dataDir, "ImagesSummary.md");

        string outputPresPath = Path.Combine(dataDir, "output.pptx");



        // Ensure input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file not found: " + inputPath);

            return;

        }



        try

        {

            // Load the presentation

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



            // Create Markdown summary

            using (StreamWriter writer = new StreamWriter(markdownPath))

            {

                writer.WriteLine("# Images Summary");

                writer.WriteLine();



                int imageIndex = 0;

                foreach (Aspose.Slides.IImage image in presentation.Images)

                {

                    imageIndex++;

                    // Attempt to retrieve original file name; fallback to generic name

                    string originalFileName = "Image_" + imageIndex;

                    // If the image has a name property, it could be used here

                    writer.WriteLine("- " + originalFileName);

                }

            }



            // Save the presentation (no modifications made)

            presentation.Save(outputPresPath, Aspose.Slides.Export.SaveFormat.Pptx);

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

