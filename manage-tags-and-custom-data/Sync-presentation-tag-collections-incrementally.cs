using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SyncTagCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define paths
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string localPath = Path.Combine(dataDir, "local.pptx");
            string cloudPath = Path.Combine(dataDir, "cloud.pptx");
            string outputPath = Path.Combine(dataDir, "merged.pptx");

            // Verify input files exist
            if (!File.Exists(localPath))
            {
                Console.WriteLine("Local presentation not found: " + localPath);
                return;
            }

            if (!File.Exists(cloudPath))
            {
                Console.WriteLine("Cloud presentation not found: " + cloudPath);
                return;
            }

            try
            {
                // Load local presentation
                using (Aspose.Slides.Presentation localPres = new Aspose.Slides.Presentation(localPath))
                // Load cloud presentation
                using (Aspose.Slides.Presentation cloudPres = new Aspose.Slides.Presentation(cloudPath))
                {
                    // Access tag collections
                    ITagCollection localTags = localPres.CustomData.Tags;
                    ITagCollection cloudTags = cloudPres.CustomData.Tags;

                    // Add or update tags from cloud to local
                    string[] cloudTagNames = cloudTags.GetNamesOfTags();
                    foreach (string tagName in cloudTagNames)
                    {
                        if (!localTags.Contains(tagName))
                        {
                            // Add new tag
                            localTags.Add(tagName, cloudTags[tagName]);
                        }
                        else
                        {
                            // Update existing tag if value differs
                            if (!object.Equals(localTags[tagName], cloudTags[tagName]))
                            {
                                localTags[tagName] = cloudTags[tagName];
                            }
                        }
                    }

                    // Remove tags from local that are not present in cloud (optional incremental cleanup)
                    string[] localTagNames = localTags.GetNamesOfTags();
                    foreach (string tagName in localTagNames)
                    {
                        if (!cloudTags.Contains(tagName))
                        {
                            localTags.Remove(tagName);
                        }
                    }

                    // Save the synchronized presentation
                    localPres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported for this operation.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., I/O errors, cloud service errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}