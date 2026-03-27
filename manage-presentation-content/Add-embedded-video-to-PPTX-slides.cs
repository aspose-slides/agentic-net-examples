using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "sample.pptx";
            string outputPath = "sample_modified.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Get presentation information without loading the full presentation
            IPresentationInfo presentationInfo = PresentationFactory.Instance.GetPresentationInfo(inputPath);
            LoadFormat loadFormat = presentationInfo.LoadFormat;
            Console.WriteLine("Load format: " + loadFormat);

            // Check if the format is PPTX
            bool isPptx = loadFormat == LoadFormat.Pptx;
            Console.WriteLine("Is PPTX format: " + isPptx);

            // Load the presentation for further processing
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Access built‑in document properties
                IDocumentProperties docProps = presentation.DocumentProperties;
                Console.WriteLine("Original Title: " + docProps.Title);

                // Modify a property (allowed because it is not read‑only)
                docProps.Title = "Modified Presentation Title";

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
        }
    }
}