// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert PPTX to PDF 70percent quality fontsubstitution using C#

//

// Description:

// Demonstrates how to convert a PPTX file to a PDF with 70 percent JPEG image

// quality while substituting missing fonts using Aspose.Slides for .NET. The

// example loads a presentation, defines a font substitution rule, configures

// PDF export options, and saves the result as a PDF document. This pattern can

// be used in console utilities or automated workflows that require consistent

// visual output despite missing fonts.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Convert, 70Percent, Quality,

// FontSubstitution, Presentation Processing, Office Automation

//

// Use Cases:

// - Convert PowerPoint presentations to PDF with reduced image size.

// - Apply font substitution to ensure correct rendering when source fonts are unavailable.

// - Build .NET tools for batch processing of PPTX files into PDF format.

// - Integrate PDF conversion with custom quality settings into larger automation pipelines.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        string inputPath = "input.pptx";

        string outputPath = "output.pdf";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        try

        {

            using (Presentation presentation = new Presentation(inputPath))

            {

                // Enable font substitution for missing fonts

                FontData sourceFont = new FontData("MissingFont");

                FontData destFont = new FontData("Arial");

                FontSubstRule substRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

                presentation.FontsManager.FontSubstRuleList.Add(substRule);



                // Set PDF options with image quality at 70%

                PdfOptions pdfOptions = new PdfOptions

                {

                    JpegQuality = 70

                };



                // Save the presentation as PDF

                presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);

            }

        }

        catch (NotSupportedException)

        {

            // Format not supported

            Console.WriteLine("The provided file format is not supported.");

        }

        catch (Exception ex)

        {

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

