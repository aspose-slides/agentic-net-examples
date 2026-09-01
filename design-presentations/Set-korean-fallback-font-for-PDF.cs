// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Set Korean fallback font for PDF using C#

//

// Description:

// Demonstrates how to configure a Korean (Hangul) fallback font for PDF

// export using Aspose.Slides for .NET. The example loads a PPTX file, adds a

// font fallback rule that maps the Hangul Unicode range to "Malgun Gothic",

// saves an intermediate PPTX (required by the fallback rule lifecycle), and

// then exports the presentation to PDF with the specified fallback font.

// This pattern can be used in console utilities or automated workflows that

// need proper Korean text rendering in PDF output.

//

// Keywords:

// C#, Aspose.Slides, PDF, Korean, Hangul, Fallback Font, FontFallBackRule,

// Presentation Processing, PowerPoint, .NET

//

// Use Cases:

// - Ensure Korean characters render correctly when converting PPTX to PDF.

// - Build command‑line tools for batch processing of presentations with

//   language‑specific fallback fonts.

// - Integrate Korean font fallback handling into .NET applications that

//   generate PDFs from PowerPoint files.

// - Automate validation of PDF output for multilingual presentations.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        string inputPath = "input.pptx";

        string outputPdfPath = "output.pdf";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            Presentation pres = new Presentation(inputPath);



            // Create a fallback rule for Hangul Unicode range using "Malgun Gothic"

            IFontFallBackRule hangulRule = new FontFallBackRule(0xAC00u, 0xD7AFu, "Malgun Gothic");

            IFontFallBackRulesCollection rules = new FontFallBackRulesCollection();

            rules.Add(hangulRule);

            pres.FontsManager.FontFallBackRulesCollection = rules;



            // Optionally save the presentation (required by lifecycle rule)

            pres.Save("intermediate.pptx", SaveFormat.Pptx);



            // Export to PDF

            pres.Save(outputPdfPath, SaveFormat.Pdf);



            pres.Dispose();

        }

        catch (Exception ex)

        {

            // Handle unsupported format or other errors

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

