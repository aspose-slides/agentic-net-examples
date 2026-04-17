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