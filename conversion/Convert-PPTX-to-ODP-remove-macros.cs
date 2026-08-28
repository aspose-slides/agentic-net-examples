// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert PPTX to ODP remove macros using C#

//

// Description:

// Demonstrates how to convert a PPTX file to ODP format while removing any

// embedded VBA macros using C# and Aspose.Slides for .NET. The example loads a

// presentation with options to delete embedded binary objects, explicitly

// clears VBA modules if present, and saves the result as an ODP file. This

// pattern can be used in console applications to automate macro‑free conversion

// workflows for PowerPoint presentations.

//

// Keywords:

// C#, PowerPoint, PPTX, ODP, Aspose.Slides for .NET, Convert, Remove, Macros,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of PPTX files to ODP while stripping macros.

// - Build C# utilities for secure PowerPoint presentation handling.

// - Integrate macro‑removal steps into .NET document processing pipelines.

// - Prepare presentations for environments that require macro‑free files.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        var inputPath = args.Length > 0 ? args[0] : "input.pptx";

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        var outputPath = Path.ChangeExtension(inputPath, ".odp");



        try

        {

            var loadOptions = new Aspose.Slides.LoadOptions();

            loadOptions.DeleteEmbeddedBinaryObjects = true;



            using (var presentation = new Aspose.Slides.Presentation(inputPath, loadOptions))

            {

                // Remove any VBA macros if present

                if (presentation.VbaProject != null && presentation.VbaProject.Modules.Count > 0)

                {

                    while (presentation.VbaProject.Modules.Count > 0)

                    {

                        presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

                    }

                }



                // Save as ODP

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Odp);

            }

        }

        catch (NotSupportedException)

        {

            // Format not supported

            Console.WriteLine("The file format is not supported for conversion.");

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

