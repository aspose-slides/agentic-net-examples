// -----------------------------------------------------------------------------
// Example: Extract presentation tags for ML classification using C#
//
// Description:
// Demonstrates how to extract custom tag metadata from a PowerPoint presentation
// using Aspose.Slides for .NET. The example loads a PPTX file, reads all tags
// stored in the presentation's custom data, and prepares the tag names and
// values for downstream machine‑learning classification. The presentation is
// then saved unchanged. This pattern can be used to build automated pipelines
// that feed presentation metadata into ML models.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Extract, Presentation, Tags,
// Classification, Machine Learning, Custom Data, Office Automation
//
// Use Cases:
// - Automate extraction of presentation tags for ML classification.
// - Build C# tools that preprocess PowerPoint metadata for AI models.
// - Integrate tag extraction into .NET applications handling PPTX files.
// - Validate and log custom data before further processing or publishing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TagMetadataExtractor
{
    class Program
    {
        static void Main()
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation
            Presentation presentation = null;
            try
            {
                presentation = new Presentation(inputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
                return;
            }
            catch (Exception ex)
            {
                // Handle other loading errors (e.g., corrupted file)
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }

            // Extract tag metadata
            ITagCollection tagCollection = presentation.CustomData.Tags;
            string[] tagNames = new string[tagCollection.Count];
            string[] tagValues = new string[tagCollection.Count];

            for (int i = 0; i < tagCollection.Count; i++)
            {
                tagNames[i] = tagCollection.GetNameByIndex(i);
                tagValues[i] = tagCollection.GetValueByIndex(i);
            }

            // TODO: Feed tagNames and tagValues into a machine learning model for classification
            // Example placeholder:
            // var prediction = MyMachineLearningModel.Predict(tagNames, tagValues);
            // Console.WriteLine("Classification result: " + prediction);

            // Save the presentation before exiting (no modifications made)
            try
            {
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
            finally
            {
                presentation.Dispose();
            }
        }
    }
}
