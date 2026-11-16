// -----------------------------------------------------------------------------
// Example: Insert cloned slide master at position three using C#
// 
// Description:
// Demonstrates how to insert a cloned slide master at position three in a
// PowerPoint presentation using C# and Aspose.Slides for .NET. The program
// creates a sample PPTX if none exists, ensures at least three masters are
// present, clones the first master, inserts the clone at index three, and saves
// the modified file.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Insert cloned slide master, Master slide manipulation
// 
// Use Cases:
// - Automate insertion of a cloned slide master at a specific position.
// - Build .NET tools for PowerPoint presentation manipulation.
// - Validate slide master workflows before publishing.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputPath = "source.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            try
            {
                Aspose.Slides.Presentation createPres = new Aspose.Slides.Presentation();
                // Ensure there are at least three master slides
                Aspose.Slides.IMasterSlide baseMaster = createPres.Masters[0];
                createPres.Masters.AddClone(baseMaster);
                createPres.Masters.AddClone(baseMaster);
                // Add a slide using the first master to have content
                createPres.Slides.AddEmptySlide(createPres.Masters[0].LayoutSlides[0]);
                createPres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                createPres.Dispose();
            }
            catch (Exception exCreate)
            {
                Console.WriteLine("Failed to create sample input file: " + exCreate.Message);
                Environment.Exit(1);
            }
        }

        try
        {
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
            // Ensure there are at least three masters before inserting at index 3
            while (pres.Masters.Count < 3)
            {
                Aspose.Slides.IMasterSlide baseMaster = pres.Masters[0];
                pres.Masters.AddClone(baseMaster);
            }

            Aspose.Slides.IMasterSlide sourceMaster = pres.Masters[0];
            // Insert the cloned master at position three (zero‑based index)
            pres.Masters.InsertClone(3, sourceMaster);
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            Environment.Exit(1);
        }
    }
}
