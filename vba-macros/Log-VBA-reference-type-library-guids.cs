// -----------------------------------------------------------------------------
// Example: Log VBA reference type library guids using C#
//
// Description:
// Demonstrates how to enumerate VBA references in a PowerPoint macro-enabled
// presentation and log the type library GUIDs (LibID) using C# and Aspose.Slides
// for .NET. The example loads a .pptm file, accesses its VBA project, iterates
// through the references, and prints each reference name and LibID (or notes
// non‑OLE references). It also saves the presentation unchanged.
//
// Keywords:
// C#, PowerPoint, PPTM, Aspose.Slides for .NET, VBA, Reference, Type Library,
// Guids, Presentation Processing, Office Automation
//
// Use Cases:
// - Extract and log VBA reference type library GUIDs from macro‑enabled PPTX/PPTM files.
// - Build diagnostic tools for PowerPoint VBA projects.
// - Verify VBA dependencies before deployment or migration.
// - Automate presentation analysis in .NET applications.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Vba;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string presentationPath = "input.pptm";
        if (args.Length > 0)
        {
            presentationPath = args[0];
        }

        if (!File.Exists(presentationPath))
        {
            Console.WriteLine("File does not exist: " + presentationPath);
            return;
        }

        try
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(presentationPath))
            {
                Aspose.Slides.Vba.IVbaProject vbaProject = presentation.VbaProject;
                if (vbaProject != null)
                {
                    Aspose.Slides.Vba.IVbaReferenceCollection references = vbaProject.References;
                    foreach (Aspose.Slides.Vba.IVbaReference reference in references)
                    {
                        Aspose.Slides.Vba.IVbaReferenceOleTypeLib oleRef = reference as Aspose.Slides.Vba.IVbaReferenceOleTypeLib;
                        if (oleRef != null)
                        {
                            Console.WriteLine("Reference Name: " + oleRef.Name + ", LibID: " + oleRef.Libid);
                        }
                        else
                        {
                            Console.WriteLine("Reference Name: " + reference.Name + " (non-OLE type library)");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No VBA project found in the presentation.");
                }

                // Save the presentation before exiting
                presentation.Save(presentationPath, Aspose.Slides.Export.SaveFormat.Pptm);
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
