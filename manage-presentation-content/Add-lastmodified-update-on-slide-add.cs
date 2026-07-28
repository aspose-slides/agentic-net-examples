// -----------------------------------------------------------------------------
// Example: Add lastmodified update on slide add using C#
//
// Description:
// Demonstrates how to add a new slide to a presentation and then update the
// LastSavedTime document property using Aspose.Slides for .NET. The example
// loads an existing PPTX file, clones the first slide, saves the modified
// presentation, and finally writes the updated LastSavedTime metadata.
// This pattern can be used to keep presentation metadata in sync after
// programmatic modifications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, LastSavedTime, Slide Add, 
// Presentation Processing, Document Properties, Office Automation
//
// Use Cases:
// - Add a slide to a PPTX file and automatically refresh the last-modified
//   timestamp.
// - Build .NET utilities that modify presentations while preserving accurate
//   metadata.
// - Integrate slide insertion and metadata updates into automated PPTX
//   workflows.
// - Ensure compliance with document management policies that require
//   correct LastSavedTime values.
// -----------------------------------------------------------------------------
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
