// -----------------------------------------------------------------------------
// Example: Export slides to XAML for WPF integration using C#
//
// Description:
// Demonstrates how to export slides from a PowerPoint presentation to XAML
// for WPF integration using C# and Aspose.Slides for .NET. The example loads a
// PPTX file, configures XAML export options (including hidden slides), and
// saves the result as a standalone XAML file. This pattern can be used to
// automate PPTX workflows, validate results, or integrate presentation logic
// into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, Slides, XAML,
// Integration, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate export of slides to XAML for WPF integration.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
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
        string inputPath = "input.pptx";
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            using (Presentation presentation = new Presentation(inputPath))
            {
                XamlOptions options = new XamlOptions
                {
                    ExportHiddenSlides = true
                };

                // Export the presentation to XAML
                presentation.Save("output.xaml", options);
            }
        }
        catch (NotSupportedException ex)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
