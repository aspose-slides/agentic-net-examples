// -----------------------------------------------------------------------------
// Example: Insert timestamp slide into presentations using C#
//
// Description:
// Demonstrates how to embed a VBA macro that inserts a timestamp slide into
// PowerPoint presentations using C# and Aspose.Slides for .NET. The example
// creates a VBA project, adds a module with the macro, sets required references,
// and saves the modified presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Insert, Timestamp, Slide, VBA,
// Macro, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate embedding a timestamp VBA macro into existing presentations.
// - Build C# tools for PowerPoint presentation processing with VBA support.
// - Generate or transform PPTX files that include a timestamp slide macro.
// - Validate VBA macro insertion before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

class Program
{
    static void Main(string[] args)
    {
        // List of presentation files to process
        string[] inputFiles = new string[] { "Presentation1.pptx", "Presentation2.pptx" };

        foreach (string inputPath in inputFiles)
        {
            // Check if the file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("File not found: " + inputPath);
                continue;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                // Create a new VBA project
                pres.VbaProject = new Aspose.Slides.Vba.VbaProject();

                // Add a VBA module with the macro that inserts a timestamp slide
                Aspose.Slides.Vba.IVbaModule module = pres.VbaProject.Modules.AddEmptyModule("TimestampModule");
                module.SourceCode = @"
Sub AddTimestampSlide()
    Dim sld As Slide
    Set sld = ActivePresentation.Slides.Add(ActivePresentation.Slides.Count + 1, ppLayoutBlank)
    Dim shp As Shape
    Set shp = sld.Shapes.AddTextbox(msoTextOrientationHorizontal, 100, 100, 400, 50)
    shp.TextFrame.TextRange.Text = Format(Now, ""yyyy-MM-dd HH:mm:ss"")
End Sub
";

                // Add required VBA references (stdole and Office)
                Aspose.Slides.Vba.VbaReferenceOleTypeLib stdoleRef = new Aspose.Slides.Vba.VbaReferenceOleTypeLib("stdole", "{00020430-0000-0000-C000-000000000046}");
                Aspose.Slides.Vba.VbaReferenceOleTypeLib officeRef = new Aspose.Slides.Vba.VbaReferenceOleTypeLib("Office", "{000C0300-0000-0000-C000-000000000046}");
                pres.VbaProject.References.Add(stdoleRef);
                pres.VbaProject.References.Add(officeRef);

                // Save the modified presentation
                string outputPath = Path.Combine(Path.GetDirectoryName(inputPath), Path.GetFileNameWithoutExtension(inputPath) + "_WithTimestamp.pptx");
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Dispose the presentation object
                pres.Dispose();

                Console.WriteLine("Processed and saved: " + outputPath);
            }
            catch (Exception ex)
            {
                // If the format is not supported, comment accordingly
                Console.WriteLine("Error processing file " + inputPath + ": " + ex.Message);
                // Format not supported
            }
        }
    }
}
