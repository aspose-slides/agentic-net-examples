// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert PPTX with password to PDF unencrypted using C#

//

// Description:

// Demonstrates how to convert a password‑protected PPTX file to an unencrypted PDF

// using Aspose.Slides for .NET. The example loads the presentation with the

// supplied password and saves it as PDF without applying any password to the

// output file. This pattern can be used in console utilities or automated

// workflows that need to remove protection from PowerPoint files.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Convert, Password, Unencrypted,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Remove password protection from PPTX files while converting to PDF.

// - Build command‑line tools for batch conversion of secured presentations.

// - Integrate PPTX de‑protection into .NET applications or CI pipelines.

// - Generate PDF reports from protected PowerPoint decks.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "protected.pptx");

        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

        string password = "myPassword";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            LoadOptions loadOptions = new LoadOptions();

            loadOptions.Password = password;

            var presentation = new Presentation(inputPath, loadOptions);

            presentation.Save(outputPath, SaveFormat.Pdf);

            presentation.Dispose();

        }

        catch (NotSupportedException)

        {

            // Format not supported

        }

        catch (Exception)

        {

            // Handle other exceptions (e.g., web service errors)

        }

    }

}

