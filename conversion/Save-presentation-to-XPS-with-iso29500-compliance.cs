// -----------------------------------------------------------------------------
// Example: Save presentation to XPS with iso29500 compliance using C#
//
// Description:
// Demonstrates how to save a PowerPoint presentation to XPS format with ISO29500
// compliance using C# and Aspose.Slides for .NET. The example loads an existing
// PPTX file, configures XPS export options to meet ISO29500 standards, and
// saves the result as an XPS document. This pattern can be used to automate
// presentation conversion workflows, ensure compliance, or integrate XPS
// generation into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, XPS, Aspose.Slides for .NET, Save, Presentation, ISO29500,
// Compliance, XpsOptions, Office Automation
//
// Use Cases:
// - Convert PPTX files to XPS with ISO29500 compliance.
// - Build C# utilities for compliant presentation export.
// - Integrate XPS generation into .NET applications handling PowerPoint files.
// - Ensure exported XPS documents meet ISO29500 standards for distribution.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlidesXpsExport
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.xps";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Presentation pres = new Presentation(inputPath))
                {
                    XpsOptions xpsOptions = new XpsOptions();
                    // Set compliance to ISO29500 for XPS export.
                    xpsOptions.Compliance = XpsCompliance.ISO29500;
                    xpsOptions.SaveMetafilesAsPng = true;

                    pres.Save(outputPath, SaveFormat.Xps, xpsOptions);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
