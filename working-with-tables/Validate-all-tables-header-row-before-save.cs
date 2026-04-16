using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TableHeaderValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output paths
            string dataDir = "Data";
            string inputFile = "input.pptx";
            string outputFile = "output.pptx";

            string inputPath = Path.Combine(dataDir, inputFile);
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            // Load the presentation
            Presentation pres = null;
            try
            {
                pres = new Presentation(inputPath);
            }
            catch (Exception)
            {
                // Format not supported
                return;
            }

            // Iterate through all slides and tables
            for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
            {
                ISlide slide = pres.Slides[slideIndex];
                foreach (IShape shape in slide.Shapes)
                {
                    if (shape is ITable)
                    {
                        ITable table = (ITable)shape;
                        // Ensure the first row is marked as header
                        if (!table.FirstRow)
                        {
                            table.FirstRow = true;
                        }
                    }
                }
            }

            // Save the updated presentation
            string outputPath = Path.Combine(dataDir, outputFile);
            pres.Save(outputPath, SaveFormat.Pptx);
            pres.Dispose();
        }
    }
}