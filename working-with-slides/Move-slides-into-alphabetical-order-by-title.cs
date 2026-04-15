using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MoveSlidesAlphabetical
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

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
                    // Get the slide collection
                    ISlideCollection slides = presentation.Slides;

                    // Build a list of slides with their titles (Name property)
                    List<ISlide> slideList = new List<ISlide>();
                    for (int i = 0; i < slides.Count; i++)
                    {
                        slideList.Add(slides[i]);
                    }

                    // Sort the list alphabetically by slide title (case-insensitive)
                    slideList.Sort((a, b) =>
                    {
                        string nameA = (a as IBaseSlide).Name ?? string.Empty;
                        string nameB = (b as IBaseSlide).Name ?? string.Empty;
                        return string.Compare(nameA, nameB, StringComparison.OrdinalIgnoreCase);
                    });

                    // Reorder slides in the presentation to match the sorted order
                    for (int targetIndex = 0; targetIndex < slideList.Count; targetIndex++)
                    {
                        ISlide slideToPlace = slideList[targetIndex];
                        int currentIndex = slides.IndexOf(slideToPlace);
                        if (currentIndex != targetIndex)
                        {
                            // Move the slide to the target position
                            slides.Reorder(targetIndex, slideToPlace);
                        }
                    }

                    // Save the reordered presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported for saving.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}