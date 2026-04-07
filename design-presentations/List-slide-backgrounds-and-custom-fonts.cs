using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideBackgroundAndFontManifest
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";

            // Ensure the input file exists; if not, create a new presentation.
            if (!File.Exists(inputPath))
            {
                using (Presentation newPres = new Presentation())
                {
                    // The default presentation already contains one empty slide.
                    newPres.Save(inputPath, SaveFormat.Pptx);
                }
            }

            try
            {
                using (Presentation pres = new Presentation(inputPath))
                {
                    List<SlideInfo> manifest = new List<SlideInfo>();

                    for (int i = 0; i < pres.Slides.Count; i++)
                    {
                        ISlide slide = pres.Slides[i];
                        BackgroundType bgType = slide.Background.Type;

                        // Slides are 1‑based for GetSubstitutions.
                        int[] slideIndices = new int[] { i + 1 };
                        IEnumerable<FontSubstitutionInfo> subs = pres.FontsManager.GetSubstitutions(slideIndices);

                        List<string> fonts = new List<string>();
                        foreach (FontSubstitutionInfo sub in subs)
                        {
                            fonts.Add(sub.OriginalFontName);
                        }

                        SlideInfo info = new SlideInfo();
                        info.SlideNumber = i + 1;
                        info.Background = bgType.ToString();
                        info.CustomFonts = fonts;
                        manifest.Add(info);
                    }

                    string json = JsonSerializer.Serialize(manifest, new JsonSerializerOptions { WriteIndented = true });
                    Console.WriteLine(json);

                    // Save the presentation before exiting.
                    pres.Save(inputPath, SaveFormat.Pptx);
                }
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported.
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    class SlideInfo
    {
        public int SlideNumber { get; set; }
        public string Background { get; set; }
        public List<string> CustomFonts { get; set; }
    }
}