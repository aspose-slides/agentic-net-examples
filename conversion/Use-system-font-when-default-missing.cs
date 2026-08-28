// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Use system font when default missing using C#

//

// Description:

// Demonstrates how to load a PowerPoint presentation with a fallback system

// font when the default regular font is missing, optionally add a Unicode

// range font fallback rule, and save the modified presentation using

// Aspose.Slides for .NET. This console application shows the required steps

// for handling missing fonts during presentation processing.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, System Font, Default Regular Font,

// Font Fallback, Presentation Processing, Office Automation

//

// Use Cases:

// - Ensure presentations render correctly when the original font is unavailable.

// - Add custom font fallback rules for specific Unicode ranges.

// - Automate PowerPoint file processing in .NET applications.

// - Validate and transform PPTX files with font substitution logic.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Paths for input and output presentations

        string inputPath = "input.pptx";

        string outputPath = "output.pptx";



        // System font to use as fallback when the default regular font is missing

        string fallbackFont = "Arial";



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Load options with a fallback regular font

            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();

            loadOptions.DefaultRegularFont = fallbackFont;



            // Load the presentation using the specified load options

            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath, loadOptions);



            // Optional: add a font fallback rule for a specific Unicode range

            Aspose.Slides.IFontFallBackRule rule = new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, fallbackFont);

            Aspose.Slides.IFontFallBackRulesCollection rules = new Aspose.Slides.FontFallBackRulesCollection();

            rules.Add(rule);

            pres.FontsManager.FontFallBackRulesCollection = rules;



            // Save the presentation

            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            pres.Dispose();

        }

        catch (NotSupportedException)

        {

            // Handle unsupported file format

            Console.WriteLine("The file format is not supported.");

        }

        catch (Exception ex)

        {

            // General exception handling

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

