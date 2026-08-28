// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Create printable PDF handout booklet from PPTX using C#

//

// Description:

// Demonstrates how to generate a printable PDF booklet from a PPTX file using

// C# and Aspose.Slides for .NET. The example loads a presentation, configures

// PDF export options for a handout layout with two slides per page, and saves

// the result as a PDF file. This pattern can be used to automate the creation

// of printable handouts or booklets from PowerPoint presentations.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Handout, Booklet, Export,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate creation of printable PDF handouts from PPTX files.

// - Build C# tools for PowerPoint presentation export.

// - Generate PDF booklets with specific slide layouts in .NET applications.

// - Integrate presentation conversion into automated workflows.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        // Define input and output file paths

        string inputPath = "input.pptx";

        string outputPath = "output.pdf";



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Load the presentation from the input file

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))

            {

                // Configure PDF export options for a handout with two slides per page

                Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions

                {

                    SlidesLayoutOptions = new Aspose.Slides.Export.HandoutLayoutingOptions

                    {

                        Handout = Aspose.Slides.Export.HandoutType.Handouts2

                    }

                };



                // Save the presentation as a PDF booklet

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

            }

        }

        catch (NotSupportedException)

        {

            // The file format is not supported

            Console.WriteLine("The file format is not supported.");

        }

        catch (Exception ex)

        {

            // General error handling

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

