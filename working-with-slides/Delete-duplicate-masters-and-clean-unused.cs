using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths to source and destination presentations
        string sourcePath = "source.pptx";
        string destinationPath = "dest.pptx";

        // Verify source file exists
        if (!File.Exists(sourcePath))
        {
            Console.WriteLine("Source file not found: " + sourcePath);
            return;
        }

        try
        {
            // Load source presentation
            using (Presentation sourcePresentation = new Presentation(sourcePath))
            // Create a new destination presentation
            using (Presentation destinationPresentation = new Presentation())
            {
                // Import master slides from source to destination, avoiding duplicates by name
                foreach (IMasterSlide sourceMaster in sourcePresentation.Masters)
                {
                    bool alreadyExists = false;
                    foreach (IMasterSlide destMaster in destinationPresentation.Masters)
                    {
                        if (destMaster.Name == sourceMaster.Name)
                        {
                            alreadyExists = true;
                            break;
                        }
                    }

                    if (!alreadyExists)
                    {
                        destinationPresentation.Masters.AddClone(sourceMaster);
                    }
                }

                // Remove duplicate master slides based on equality
                for (int i = 0; i < destinationPresentation.Masters.Count; i++)
                {
                    for (int j = i + 1; j < destinationPresentation.Masters.Count; j++)
                    {
                        if (destinationPresentation.Masters[i].Equals(destinationPresentation.Masters[j]))
                        {
                            // Remove the later duplicate
                            destinationPresentation.Masters.RemoveAt(j);
                            j--; // Adjust index after removal
                        }
                    }
                }

                // Clean up unused master slides
                destinationPresentation.Masters.RemoveUnused(false);

                // Save the resulting presentation
                destinationPresentation.Save(destinationPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Handle unsupported format
            Console.WriteLine("The specified file format is not supported.");
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}