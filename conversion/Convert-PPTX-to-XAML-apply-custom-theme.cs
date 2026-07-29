// -----------------------------------------------------------------------------
// Example: Convert PPTX to XAML apply custom theme using C#
//
// Description:
// Demonstrates how to convert a PPTX presentation to XAML after applying a
// custom external theme using Aspose.Slides for .NET. The example loads a
// PowerPoint file, applies a .thmx theme to all master slides (and their
// dependent slides), and saves the result as XAML files. This pattern can be
// used in console applications to automate presentation processing, theme
// validation, or UI generation from PowerPoint content.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Convert, XAML, Apply, Custom Theme,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate conversion of PPTX to XAML with a custom theme applied.
// - Build C# tools for PowerPoint presentation processing and UI generation.
// - Generate XAML representations of slides for WPF or other XAML‑based UI frameworks.
// - Validate theme application before publishing or integrating presentations.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Export.Xaml;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input presentation, external theme file, and output XAML
        string inputPath = "input.pptx";
        string themePath = "custom.thmx";
        string outputPath = "output.xaml";

        // Verify that the input presentation exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input presentation file not found.");
            return;
        }

        // Verify that the external theme file exists
        if (!File.Exists(themePath))
        {
            Console.WriteLine("External theme file not found.");
            return;
        }

        try
        {
            // Load the presentation
            Presentation pres = new Presentation(inputPath);

            // Apply the external theme to each master slide and its dependent slides
            for (int i = 0; i < pres.Masters.Count; i++)
            {
                IMasterSlide master = pres.Masters[i];
                master.ApplyExternalThemeToDependingSlides(themePath);
            }

            // Save the presentation as XAML
            XamlOptions xamlOptions = new XamlOptions();
            pres.Save(outputPath, xamlOptions);
        }
        catch (PptxReadException ex)
        {
            // Handle errors related to applying the external theme
            Console.WriteLine("Failed to apply external theme: " + ex.Message);
        }
        catch (NotSupportedException ex)
        {
            // Format not supported
            Console.WriteLine("Operation not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
