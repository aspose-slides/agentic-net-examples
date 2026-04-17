using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input file path
        string inputFile = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        if (!File.Exists(inputFile))
        {
            Console.WriteLine("Input file does not exist: " + inputFile);
            return;
        }

        try
        {
            // Load presentation
            using (Presentation pres = new Presentation(inputFile))
            {
                // Check for digital signatures
                if (pres.DigitalSignatures.Count == 0)
                {
                    Console.WriteLine("Presentation is unsigned. Flagging for review.");
                }
                else
                {
                    Console.WriteLine("Presentation has digital signatures.");
                }

                // Save presentation before exit
                string outputFile = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");
                pres.Save(outputFile, SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}