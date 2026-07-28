// -----------------------------------------------------------------------------
// Example: Sync custom property values between PPTX presentations using C#
//
// Description:
// Demonstrates how to read custom document properties from a source PPTX file
// and copy them to a target PPTX file using Aspose.Slides for .NET. The example
// loads presentation information, accesses document properties, synchronizes
// all custom properties, and saves the updated target presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Sync, Custom, Property, Values,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Synchronize custom metadata between multiple PowerPoint presentations.
// - Automate property propagation in batch processing of PPTX files.
// - Ensure consistent custom properties across presentation assets.
// - Integrate property sync into .NET based document management workflows.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SyncCustomProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define paths for source and target presentations
            string dataDir = @"C:\Presentations\";
            string sourcePath = Path.Combine(dataDir, "Source.pptx");
            string targetPath = Path.Combine(dataDir, "Target.pptx");

            // Verify that both files exist
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source presentation not found: " + sourcePath);
                return;
            }

            if (!File.Exists(targetPath))
            {
                Console.WriteLine("Target presentation not found: " + targetPath);
                return;
            }

            try
            {
                // Load source presentation info and read its document properties
                IPresentationInfo sourceInfo = PresentationFactory.Instance.GetPresentationInfo(sourcePath);
                IDocumentProperties sourceProps = sourceInfo.ReadDocumentProperties();

                // Load target presentation info and read its document properties
                IPresentationInfo targetInfo = PresentationFactory.Instance.GetPresentationInfo(targetPath);
                IDocumentProperties targetProps = targetInfo.ReadDocumentProperties();

                // Synchronize custom properties from source to target
                int customCount = sourceProps.CountOfCustomProperties;
                for (int i = 0; i < customCount; i++)
                {
                    string propName = sourceProps.GetCustomPropertyName(i);
                    object propValue = sourceProps[propName];
                    targetProps[propName] = propValue;
                }

                // Update target presentation with the synchronized properties
                targetInfo.UpdateDocumentProperties(targetProps);
                targetInfo.WriteBindedPresentation(targetPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // The presentation format may not be supported by Aspose.Slides.
            }
        }
    }
}
