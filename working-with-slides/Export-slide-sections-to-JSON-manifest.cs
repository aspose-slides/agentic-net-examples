using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideSectionExport
{
    public class SectionInfo
    {
        public string Name { get; set; }
        public int StartIndex { get; set; }
        public int SlideCount { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Determine input file path
            string inputPath;
            if (args != null && args.Length > 0)
            {
                inputPath = args[0];
            }
            else
            {
                inputPath = "input.pptx";
            }

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Presentation presentation = null;
            try
            {
                // Load the presentation
                presentation = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or loading errors
                Console.WriteLine("Failed to load presentation. " + ex.Message);
                // Format not supported comment
                // Unsupported format
                return;
            }

            // Prepare list to hold section information
            List<SectionInfo> sections = new List<SectionInfo>();

            // Iterate through all sections
            int sectionCount = presentation.Sections.Count;
            for (int i = 0; i < sectionCount; i++)
            {
                ISection section = presentation.Sections[i];
                // Get the first slide of the section
                ISlide startSlide = section.StartedFromSlide;
                int startIndex = presentation.Slides.IndexOf(startSlide);
                // Get slide count in the section
                ISectionSlideCollection slideCollection = section.GetSlidesListOfSection();
                int slideCount = slideCollection.Count;

                SectionInfo info = new SectionInfo();
                info.Name = section.Name;
                info.StartIndex = startIndex;
                info.SlideCount = slideCount;
                sections.Add(info);
            }

            // Serialize sections to JSON
            JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
            jsonOptions.WriteIndented = true;
            string jsonManifest = JsonSerializer.Serialize(sections, jsonOptions);

            // Determine output directory and file
            string outputDir = Path.Combine(Environment.CurrentDirectory, "output");
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }
            string outputPath = Path.Combine(outputDir, "sections_manifest.json");

            // Write JSON manifest to file
            File.WriteAllText(outputPath, jsonManifest);
            Console.WriteLine("Section manifest written to: " + outputPath);

            // Save presentation before exit (no modifications made)
            try
            {
                presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle save errors (e.g., format not supported)
                Console.WriteLine("Failed to save presentation. " + ex.Message);
                // Format not supported comment
            }
            finally
            {
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}