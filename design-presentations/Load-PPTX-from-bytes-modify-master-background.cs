using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Expect input and output file paths as arguments
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: Program <input.pptx> <output.pptx>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        // Check if input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Read presentation bytes from file
            byte[] inputBytes = File.ReadAllBytes(inputPath);

            // Load presentation from byte array
            PresentationFactory factory = new PresentationFactory();
            IPresentation pres = factory.ReadPresentation(inputBytes);

            // Update master slide background
            pres.Masters[0].Background.Type = BackgroundType.OwnBackground;
            pres.Masters[0].Background.FillFormat.FillType = FillType.Solid;
            pres.Masters[0].Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

            // Save modified presentation to a memory stream
            using (MemoryStream ms = new MemoryStream())
            {
                pres.Save(ms, SaveFormat.Pptx);
                byte[] outputBytes = ms.ToArray();

                // Write the modified bytes to the output file
                File.WriteAllBytes(outputPath, outputBytes);
            }

            // Dispose presentation
            pres.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}