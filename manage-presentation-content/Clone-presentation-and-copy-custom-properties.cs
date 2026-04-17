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