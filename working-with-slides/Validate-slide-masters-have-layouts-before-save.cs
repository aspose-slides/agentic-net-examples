using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
        string outputPath = Path.Combine(Environment.CurrentDirectory, "output.pptx");

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Presentation pres = new Presentation(inputPath))
            {
                // Validate that each master slide contains at least one layout slide
                foreach (IMasterSlide master in pres.Masters)
                {
                    if (master.LayoutSlides.Count == 0)
                    {
                        Console.WriteLine("A master slide has no layout slides.");
                        // Optionally, you could add a default layout here
                    }
                }

                // Save the presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // If the file format is not supported, handle accordingly
            // format not supported
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}