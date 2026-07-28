// -----------------------------------------------------------------------------
// Example: Clone presentation and copy custom document properties using C#
//
// Description:
// Demonstrates how to clone all slides from a source presentation and copy its
// custom document properties to a new presentation using Aspose.Slides for .NET.
// The example loads a PPTX file, creates a new presentation, clones slides,
// transfers custom properties, and saves the result as a separate PPTX file.
// This pattern can be used in console applications or integrated into larger
// .NET solutions for PowerPoint automation.
//
// Keywords:
// C#, .NET, PowerPoint, PPTX, Aspose.Slides, Clone Presentation, Copy Custom Properties,
// DocumentProperties, Slide Cloning, Office Automation
//
// Use Cases:
// - Automate cloning of a presentation while preserving custom metadata.
// - Build utilities that migrate or duplicate PPTX files with their custom properties.
// - Integrate slide cloning and property copying into document management workflows.
// - Validate and test presentation transformations in automated pipelines.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ClonePresentationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string dataDir = @"Data\";
            string inputFile = Path.Combine(dataDir, "source.pptx");
            string outputFile = Path.Combine(dataDir, "cloned.pptx");

            // Verify that the source file exists
            if (!File.Exists(inputFile))
            {
                Console.WriteLine("Source file does not exist: " + inputFile);
                return;
            }

            try
            {
                // Load the source presentation
                Aspose.Slides.Presentation srcPres = new Aspose.Slides.Presentation(inputFile);

                // Create a new empty presentation for the clone
                Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation();

                // Clone all slides from source to destination
                Aspose.Slides.ISlideCollection srcSlides = srcPres.Slides;
                Aspose.Slides.ISlideCollection destSlides = destPres.Slides;
                for (int i = 0; i < srcSlides.Count; i++)
                {
                    destSlides.AddClone(srcSlides[i]);
                }

                // Copy all custom document properties
                Aspose.Slides.IDocumentProperties srcProps = srcPres.DocumentProperties;
                Aspose.Slides.IDocumentProperties destProps = destPres.DocumentProperties;
                int customCount = srcProps.CountOfCustomProperties;
                for (int i = 0; i < customCount; i++)
                {
                    string propName = srcProps.GetCustomPropertyName(i);
                    object propValue = srcProps[propName];
                    destProps[propName] = propValue;
                }

                // Save the cloned presentation
                destPres.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);

                // Dispose presentations
                srcPres.Dispose();
                destPres.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., I/O errors, Aspose.Slides specific errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
