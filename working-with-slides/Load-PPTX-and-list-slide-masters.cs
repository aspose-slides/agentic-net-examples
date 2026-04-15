using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideMasterEnumerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath;
            if (args.Length > 0)
            {
                inputPath = args[0];
            }
            else
            {
                inputPath = "sample.pptx";
            }

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                Presentation presentation = new Presentation(inputPath);

                Console.WriteLine("Enumerating master slides:");
                foreach (IMasterSlide masterSlide in presentation.Masters)
                {
                    Console.WriteLine("Master Name: " + masterSlide.Name);
                }

                string outputPath = Path.Combine(Path.GetDirectoryName(inputPath), "output.pptx");
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();

                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other loading errors
                Console.WriteLine("Error processing presentation: " + ex.Message);
            }
        }
    }
}