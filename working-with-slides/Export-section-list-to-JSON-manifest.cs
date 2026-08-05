// -----------------------------------------------------------------------------
// Example: Export section list to JSON manifest using C#
//
// Description:
// Demonstrates how to load a PowerPoint presentation, enumerate its sections,
// collect each section's name, starting slide index and slide count, and
// serialize this information to a JSON manifest file using Aspose.Slides for .NET.
// The example runs as a standalone console application suitable for automating
// PPTX section analysis and integration into .NET workflows.
//
// Keywords:
// C#, Aspose.Slides for .NET, PowerPoint, PPTX, JSON, Section Export, Presentation
// Processing, Office Automation, Console Application
//
// Use Cases:
// - Generate a JSON manifest of presentation sections for documentation or
//   downstream processing.
// - Build C# utilities that analyze or validate PowerPoint structure.
// - Integrate section metadata extraction into automated build or publishing pipelines.
// - Support custom reporting or migration tools that require section details.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideSectionExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output paths
            string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
            string outputPath = Path.Combine(Environment.CurrentDirectory, "sections.json");

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            // Load the presentation
            Presentation pres = null;
            try
            {
                pres = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or loading errors
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            // Collect section information
            List<SectionInfo> sections = new List<SectionInfo>();
            ISectionCollection sectionColl = pres.Sections;
            for (int i = 0; i < sectionColl.Count; i++)
            {
                ISection section = sectionColl[i];
                ISlide startSlide = section.StartedFromSlide;
                int startIndex = pres.Slides.IndexOf(startSlide);
                int slideCount = section.GetSlidesListOfSection().Count;

                sections.Add(new SectionInfo
                {
                    Name = section.Name,
                    StartIndex = startIndex,
                    SlideCount = slideCount
                });
            }

            // Serialize to JSON and write to file
            string json = JsonSerializer.Serialize(sections, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(outputPath, json);
            Console.WriteLine("Section manifest saved to " + outputPath);

            // Save presentation before exit
            pres.Save(inputPath, SaveFormat.Pptx);
            pres.Dispose();
        }
    }

    class SectionInfo
    {
        public string Name { get; set; }
        public int StartIndex { get; set; }
        public int SlideCount { get; set; }
    }
}
