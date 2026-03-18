using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InsertSlidesIntoSection
{
    class Program
    {
        static void Main()
        {
            try
            {
                var inputPath = "input.pptx";
                var outputPath = "output.pptx";
                var targetSectionName = "Target Section";

                using (var presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Find the target section by name
                    Aspose.Slides.ISection targetSection = null;
                    foreach (var sec in presentation.Sections)
                    {
                        if (sec.Name == targetSectionName)
                        {
                            targetSection = sec;
                            break;
                        }
                    }

                    // If the section does not exist, create it starting from the first slide
                    if (targetSection == null)
                    {
                        var firstSlide = presentation.Slides[0];
                        targetSection = presentation.Sections.AddSection(targetSectionName, firstSlide);
                    }

                    // Get slides belonging to the target section
                    var slidesInSection = targetSection.GetSlidesListOfSection();

                    // Determine insertion index (after the last slide of the section)
                    var lastSlideInSection = slidesInSection[slidesInSection.Count - 1];
                    var insertIndex = presentation.Slides.IndexOf(lastSlideInSection) + 1;

                    // Insert three new empty slides into the section
                    var layout = presentation.LayoutSlides[0];
                    for (int i = 0; i < 3; i++)
                    {
                        presentation.Slides.InsertEmptySlide(insertIndex + i, layout);
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}