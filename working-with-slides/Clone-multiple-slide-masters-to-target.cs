// -----------------------------------------------------------------------------
// Example: Clone Multiple Slide Masters to Target Presentation
//
// Description:
// Demonstrates how to clone all slide masters from a source PPTX into a new
// destination presentation using Aspose.Slides for .NET. The program also adds
// a slide that utilizes one of the cloned masters, useful for consolidating
// master libraries or building multi‑master templates.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, clone slide masters, master slide
//
// Use Cases:
// - Transfer all slide masters from an existing template to a new presentation.
// - Create a composite master library for reusable design assets.
// - Automate preparation of presentations that require multiple master slides.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------

using System;
using System.IO;

class Program
{
    static void Main()
    {
        string sourcePath = "Template.pptx";
        string destinationPath = "ClonedMasters.pptx";

        // Ensure source presentation exists; create a simple one if missing
        if (!File.Exists(sourcePath))
        {
            try
            {
                using (Aspose.Slides.Presentation tempPres = new Aspose.Slides.Presentation())
                {
                    // Clone the default master to have at least two masters
                    Aspose.Slides.IMasterSlide newMaster = tempPres.Masters.AddClone(tempPres.Masters[0]);
                    tempPres.Save(sourcePath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to create source presentation: " + ex.Message);
                Environment.Exit(1);
            }
        }

        try
        {
            using (Aspose.Slides.Presentation srcPres = new Aspose.Slides.Presentation(sourcePath))
            {
                using (Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation())
                {
                    // Clone all master slides from source to destination
                    for (int i = 0; i < srcPres.Masters.Count; i++)
                    {
                        Aspose.Slides.IMasterSlide sourceMaster = srcPres.Masters[i];
                        destPres.Masters.AddClone(sourceMaster);
                    }

                    // Add a slide that uses the first cloned master
                    if (srcPres.Slides.Count > 0 && destPres.Masters.Count > 0)
                    {
                        Aspose.Slides.ISlide sourceSlide = srcPres.Slides[0];
                        Aspose.Slides.IMasterSlide destMaster = destPres.Masters[0];
                        destPres.Slides.AddClone(sourceSlide, destMaster, true);
                    }

                    // Save the destination presentation
                    destPres.Save(destinationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
            Environment.Exit(1);
        }
    }
}
