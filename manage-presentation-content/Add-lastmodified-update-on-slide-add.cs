using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationMacro
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "data/input.pptx";
            string outputPath = "data/output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Add a new slide by cloning the first slide
                ISlide newSlide = presentation.Slides.AddClone(presentation.Slides[0]);

                // Save the presentation before updating properties
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();

                // Update the LastSavedTime property using PresentationInfo
                IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(outputPath);
                IDocumentProperties props = info.ReadDocumentProperties();
                props.LastSavedTime = DateTime.UtcNow;
                info.UpdateDocumentProperties(props);
                info.WriteBindedPresentation(outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file access issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}