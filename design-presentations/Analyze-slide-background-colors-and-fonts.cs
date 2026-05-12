using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesManifest
{
    public class ManifestSlide
    {
        public int SlideIndex { get; set; }
        public string BackgroundType { get; set; }
        public List<string> CustomFonts { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";
            string manifestPath = "manifest.json";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            Presentation pres = null;
            try
            {
                pres = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other loading errors
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            List<ManifestSlide> manifest = new List<ManifestSlide>();

            for (int i = 0; i < pres.Slides.Count; i++)
            {
                ISlide slide = pres.Slides[i];
                string backgroundType = slide.Background.Type.ToString();

                int[] targetSlides = new int[] { i + 1 };
                IEnumerable<FontSubstitutionInfo> substitutions = pres.FontsManager.GetSubstitutions(targetSlides);
                List<string> fontList = new List<string>();
                foreach (FontSubstitutionInfo fontSubstitution in substitutions)
                {
                    string entry = fontSubstitution.OriginalFontName + "->" + fontSubstitution.SubstitutedFontName;
                    fontList.Add(entry);
                }

                ManifestSlide manifestSlide = new ManifestSlide();
                manifestSlide.SlideIndex = i + 1;
                manifestSlide.BackgroundType = backgroundType;
                manifestSlide.CustomFonts = fontList;
                manifest.Add(manifestSlide);
            }

            string json = JsonSerializer.Serialize(manifest, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(manifestPath, json);

            // Save the presentation before exit
            pres.Save(outputPath, SaveFormat.Pptx);
            pres.Dispose();
        }
    }
}