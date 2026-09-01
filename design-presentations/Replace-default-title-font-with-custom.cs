// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Replace default title font with custom using C#

//

// Description:

// Demonstrates how to replace the default title font in a PowerPoint presentation

// with a custom font using C# and Aspose.Slides for .NET. The example loads external

// fonts from a specified folder, replaces the source font (e.g., Arial) with the

// custom font throughout the presentation, saves the result, and clears the font

// cache.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Replace, Default, Title, Font,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate replacement of the default title font with a custom font.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        var inputPath = "input.pptx";

        var outputPath = "output.pptx";

        var fontsFolder = "CustomFonts";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Load custom fonts from the specified folder

            var fontFolders = new string[] { fontsFolder };

            Aspose.Slides.FontsLoader.LoadExternalFonts(fontFolders);



            // Load the presentation

            using (var pres = new Aspose.Slides.Presentation(inputPath))

            {

                // Define source (default) and destination (custom) fonts

                var sourceFont = new Aspose.Slides.FontData("Arial");

                var destFont = new Aspose.Slides.FontData("MyCustomFont");



                // Replace the default title font with the custom font across the entire presentation

                pres.FontsManager.ReplaceFont(sourceFont, destFont);



                // Save the modified presentation

                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            }



            // Clear the loaded custom fonts from cache

            Aspose.Slides.FontsLoader.ClearCache();

        }

        catch (NotSupportedException ex)

        {

            // Format not supported

            Console.WriteLine("Format not supported: " + ex.Message);

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

