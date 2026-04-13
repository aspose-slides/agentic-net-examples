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