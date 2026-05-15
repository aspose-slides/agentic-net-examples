using System;
using System.IO;
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
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputFile))
            {
                // Check for digital signatures
                if (presentation.DigitalSignatures.Count == 0)
                {
                    Console.WriteLine("Presentation is unsigned. Flagging for review.");
                }
                else
                {
                    Console.WriteLine("Presentation is signed.");
                }

                // Save presentation before exit
                string outputFile = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");
                presentation.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (System.Net.WebException)
        {
            // External URL or web service error
            Console.WriteLine("Failed to access external resource.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}