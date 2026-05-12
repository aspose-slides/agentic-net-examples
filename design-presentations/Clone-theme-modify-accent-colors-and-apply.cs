using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Presentation pres = new Presentation(inputPath);

            // Modify accent colors of the master theme
            pres.MasterTheme.ColorScheme.Accent1.Color = Color.Red;
            pres.MasterTheme.ColorScheme.Accent2.Color = Color.Green;
            pres.MasterTheme.ColorScheme.Accent3.Color = Color.Blue;

            // Save the modified presentation
            pres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Aspose.Slides.PptxReadException ex)
        {
            Console.WriteLine("Failed to read the presentation: " + ex.Message);
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("File format not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}