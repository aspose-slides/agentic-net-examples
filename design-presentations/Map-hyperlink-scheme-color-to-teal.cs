// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Map hyperlink scheme color to teal using C#

//

// Description:

// Demonstrates how to map the Hyperlink scheme color to a custom teal color in a

// PowerPoint presentation using C# and Aspose.Slides for .NET. The example

// creates a new presentation, modifies the master theme's color scheme to set

// the Hyperlink and FollowedHyperlink colors, and saves the result as a PPTX file.

// This pattern can be used to customize hyperlink colors in automated PPTX

// generation or processing workflows.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Hyperlink, Scheme, Color, Teal,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Customize hyperlink colors in generated presentations.

// - Build C# tools for PowerPoint presentation processing with specific branding.

// - Automate PPTX workflows that require consistent hyperlink styling.

// - Integrate presentation color customization into .NET applications.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Theme;

using System.Drawing;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        try

        {

            // Create a new presentation

            using (Presentation pres = new Presentation())

            {

                // Access the master theme's color scheme

                IMasterTheme masterTheme = pres.MasterTheme;

                IColorScheme colorScheme = masterTheme.ColorScheme;



                // Map the Hyperlink scheme color to a custom teal color (RGB 0,128,128)

                colorScheme.Hyperlink.Color = Color.FromArgb(0, 128, 128);



                // Optionally set the FollowedHyperlink color as well

                colorScheme.FollowedHyperlink.Color = Color.FromArgb(0, 100, 100);



                // Save the presentation before exiting

                pres.Save("output.pptx", SaveFormat.Pptx);

            }

        }

        catch (FileNotFoundException ex)

        {

            Console.WriteLine("File not found: " + ex.Message);

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

