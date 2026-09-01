// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Analyze slide background colors and fonts using C#

//

// Description:

// Demonstrates how to analyze each slide's background type and font

// substitutions in a PowerPoint presentation using Aspose.Slides for .NET.

// The example creates a manifest JSON file that lists the slide index,

// background type, and any custom font substitutions detected. It also

// saves a copy of the original presentation. This pattern can be used to

// automate PPTX analysis, validate font usage, or integrate presentation

// inspection into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Analyze, Slide, Background,

// Fonts, Manifest, JSON, Presentation Processing, Office Automation

//

// Use Cases:

// - Generate a manifest of slide background types and font substitutions.

// - Validate that presentations use expected fonts before publishing.

// - Build tools that audit or transform PowerPoint files in .NET.

// - Automate extraction of slide metadata for reporting or compliance.

// -----------------------------------------------------------------------------

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



                ManifestSlide manifestSlide = new ManifestSlide

                {

                    SlideIndex = i + 1,

                    BackgroundType = backgroundType,

                    CustomFonts = fontList

                };

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

