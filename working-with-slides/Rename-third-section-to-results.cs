using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string dataDir = Path.Combine(Environment.CurrentDirectory, "Data");
        string inputPath = Path.Combine(dataDir, "input.pptx");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            var presentation = new Presentation(inputPath);

            if (presentation.Sections.Count > 2)
            {
                var thirdSection = presentation.Sections[2];
                thirdSection.Name = "Results";
            }
            else
            {
                Console.WriteLine("Presentation does not contain a third section.");
            }

            Console.WriteLine("Sections after rename:");
            for (int i = 0; i < presentation.Sections.Count; i++)
            {
                Console.WriteLine($"{i}: {presentation.Sections[i].Name}");
            }

            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}