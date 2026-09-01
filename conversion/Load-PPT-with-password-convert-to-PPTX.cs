// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Load PPT with password convert to PPTX using C#

//

// Description:

// Demonstrates how to load a password‑protected PPT file and convert it to PPTX 

// using C# and Aspose.Slides for .NET. The example shows loading options with a 

// password, converting the presentation format, and saving the result to an 

// output folder in a standalone console application. Developers can use this 

// pattern to automate PPT conversion workflows, handle protected files, or 

// integrate presentation processing into .NET solutions.

//

// Keywords:

// C#, PowerPoint, PPT, PPTX, Aspose.Slides for .NET, Load, Password, Convert, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of password‑protected PPT files to PPTX.

// - Build C# utilities for PowerPoint presentation handling.

// - Integrate secure PPT processing into .NET applications.

// - Validate and transform legacy PowerPoint presentations before publishing.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Define input file path

        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "protected.ppt");

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        // Password for the protected presentation

        string password = "myPassword";



        try

        {

            // Load the password‑protected presentation

            LoadOptions loadOptions = new LoadOptions();

            loadOptions.Password = password;

            Presentation presentation = new Presentation(inputPath, loadOptions);



            // Prepare output directory

            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");

            if (!Directory.Exists(outputDir))

                Directory.CreateDirectory(outputDir);



            // Save as PPTX

            string outputPath = Path.Combine(outputDir, "converted.pptx");

            presentation.Save(outputPath, SaveFormat.Pptx);



            // Dispose the presentation

            presentation.Dispose();



            Console.WriteLine("Presentation converted successfully.");

        }

        catch (NotSupportedException)

        {

            // Format not supported

            Console.WriteLine("The file format is not supported.");

        }

        catch (Exception ex)

        {

            // Handle other exceptions (e.g., web service errors)

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

