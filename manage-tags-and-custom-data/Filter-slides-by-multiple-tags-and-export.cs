// -----------------------------------------------------------------------------
// Example: Filter slides by multiple tags and export using C#
//
// Description:
// Demonstrates how to filter slides in a PowerPoint presentation based on
// multiple custom tags (Category, Status, Urgent) using Aspose.Slides for .NET,
// export only the matching slides to a new PPTX file, and optionally save the
// original presentation. The example shows loading a presentation, accessing
// slide custom data, evaluating tag criteria, and saving a subset of slides.
// This pattern can be used to automate tag‑driven slide selection and export
// scenarios in .NET applications.
//
// Keywords:
// C#, Aspose.Slides for .NET, PowerPoint, PPTX, Slide Tags, CustomData, TagCollection, Filter Slides, Export Slides, Presentation Processing
//
// Use Cases:
// - Select and export slides that meet specific tag conditions.
// - Build .NET utilities that process presentations based on metadata.
// - Integrate tag‑based slide filtering into larger automation pipelines.
// - Preserve the original presentation while generating a filtered copy.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FilterSlidesByTags
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "filtered_output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // List to hold 1‑based slide numbers that match the criteria
                    List<int> matchingSlides = new List<int>();

                    // Iterate through all slides
                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        ISlide slide = presentation.Slides[i];

                        // Access tags via the slide's custom data
                        ITagCollection tags = slide.CustomData.Tags;

                        // Example criteria:
                        // (Tag "Category" == "Finance" AND Tag "Status" == "Approved")
                        // OR (Tag "Urgent" == "True")
                        bool hasCategoryFinance = tags.Contains("Category") && tags["Category"] == "Finance";
                        bool hasStatusApproved = tags.Contains("Status") && tags["Status"] == "Approved";
                        bool hasUrgentTrue = tags.Contains("Urgent") && tags["Urgent"] == "True";

                        bool matches = (hasCategoryFinance && hasStatusApproved) || hasUrgentTrue;

                        if (matches)
                        {
                            // Slides are 1‑based for the Save method
                            matchingSlides.Add(i + 1);
                        }
                    }

                    // If no slides match, inform the user
                    if (matchingSlides.Count == 0)
                    {
                        Console.WriteLine("No slides matched the specified tag criteria.");
                        return;
                    }

                    // Export only the matching slides
                    int[] slidesArray = matchingSlides.ToArray();
                    presentation.Save(outputPath, slidesArray, SaveFormat.Pptx);

                    // Save the full presentation before exit (as per requirement)
                    string fullSavePath = "full_presentation_saved.pptx";
                    presentation.Save(fullSavePath, SaveFormat.Pptx);
                }
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported for this operation.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
