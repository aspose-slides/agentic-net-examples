// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Assign default background to unfilled slides using C#

//

// Description:

// Demonstrates how to assign a default solid background color to slides that

// do not already have a solid fill using C# and Aspose.Slides for .NET. The

// example loads an existing PPTX file, checks each slide's effective background

// fill type, and applies a generated solid color to any slide whose background

// is not solid. The modified presentation is then saved as a new PPTX file.

// This pattern can be used to ensure visual consistency across presentations

// by automatically providing a fallback background for unfilled slides.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Assign, Default, Background,

// Unfilled, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate assignment of default background colors to slides lacking a solid fill.

// - Build C# tools for PowerPoint presentation processing and cleanup.

// - Generate or transform PPTX files in .NET applications with consistent styling.

// - Validate and enforce presentation design guidelines before publishing.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;

using System.Drawing;



class Program

{

    static void Main(string[] args)

    {

        string inputPath = "input.pptx";

        string outputPath = "output.pptx";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            Presentation presentation = new Presentation(inputPath);

            int slideCount = presentation.Slides.Count;

            for (int i = 0; i < slideCount; i++)

            {

                IBackgroundEffectiveData bgEffective = presentation.Slides[i].Background.GetEffective();

                if (bgEffective.FillFormat.FillType != FillType.Solid)

                {

                    presentation.Slides[i].Background.Type = BackgroundType.OwnBackground;

                    presentation.Slides[i].Background.FillFormat.FillType = FillType.Solid;

                    int red = (i * 50) % 256;

                    int green = (i * 80) % 256;

                    int blue = (i * 110) % 256;

                    presentation.Slides[i].Background.FillFormat.SolidFillColor.Color = Color.FromArgb(red, green, blue);

                }

            }

            presentation.Save(outputPath, SaveFormat.Pptx);

            presentation.Dispose();

        }

        catch (Exception ex)

        {

            // Handle unsupported format or other errors

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

