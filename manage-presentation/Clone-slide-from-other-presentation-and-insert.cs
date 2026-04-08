using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string sourceFile = "SourcePresentation.pptx";
        string destinationFile = "DestinationPresentation.pptx";
        string outputFile = "ClonedPresentation.pptx";
        int insertPosition = 2; // zero‑based index where the slide will be inserted

        // Verify that the source file exists
        if (!File.Exists(sourceFile))
        {
            Console.WriteLine("Source file not found: " + sourceFile);
            return;
        }

        // Verify that the destination file exists
        if (!File.Exists(destinationFile))
        {
            Console.WriteLine("Destination file not found: " + destinationFile);
            return;
        }

        try
        {
            // Load the source presentation
            using (Presentation sourcePres = new Presentation(sourceFile))
            {
                // Load the destination presentation
                using (Presentation destPres = new Presentation(destinationFile))
                {
                    // Get the first slide from the source presentation
                    ISlide sourceSlide = sourcePres.Slides[0];

                    // Insert a clone of the source slide into the destination at the specified index
                    destPres.Slides.InsertClone(insertPosition, sourceSlide);

                    // Save the modified destination presentation
                    destPres.Save(outputFile, SaveFormat.Pptx);
                }
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException)
        {
            // The file format is not supported
            Console.WriteLine("One of the files has an unsupported PPTX format.");
        }
        catch (Aspose.Slides.PptUnsupportedFormatException)
        {
            // The file format is not supported
            Console.WriteLine("One of the files has an unsupported PPT format.");
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}