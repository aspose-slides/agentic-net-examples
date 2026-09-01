// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Set PPTX theme accent1 to bright orange using C#

//

// Description:

// Demonstrates how to set the Accent1 color of a PPTX theme to a bright orange

// shade using C# and Aspose.Slides for .NET. The example creates a new presentation,

// modifies the master theme's Accent1 color, and saves the result as a PPTX file.

// This pattern can be used to automate theme color adjustments in PowerPoint

// presentations within .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Pptx, Theme, Accent1, Bright, Orange,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate setting PPTX theme Accent1 to bright orange.

// - Build C# tools for PowerPoint theme color customization.

// - Generate or transform PPTX files with specific theme colors in .NET apps.

// - Validate and standardize presentation theme colors before publishing.

// -----------------------------------------------------------------------------



using System;

using System.Drawing;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SetThemeAccent

{

    class Program

    {

        static void Main()

        {

            // Create a new presentation

            using (Presentation presentation = new Presentation())

            {

                // Access the first accent color in the master theme's color scheme

                IColorFormat accent1 = presentation.MasterTheme.ColorScheme.Accent1;

                // Assign a bright orange color to Accent1

                accent1.Color = Color.OrangeRed;



                // Save the modified presentation

                presentation.Save("Accent1_BrightOrange.pptx", SaveFormat.Pptx);

            }

        }

    }

}

