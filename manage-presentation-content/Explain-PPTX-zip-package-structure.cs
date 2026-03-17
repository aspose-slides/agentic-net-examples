using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ZipArchitectureDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Describe the ZIP package architecture of a PPTX file
                Console.WriteLine("PPTX files are ZIP packages conforming to the Open XML standard.");
                Console.WriteLine("The package contains a set of parts (XML files, media, relationships) organized in folders:");
                Console.WriteLine("- /ppt/presentation.xml : Main presentation part defining slide list and slide masters.");
                Console.WriteLine("- /ppt/slides/slide1.xml, slide2.xml, ... : Individual slide parts.");
                Console.WriteLine("- /ppt/slideMasters/slideMaster1.xml, ... : Slide master parts.");
                Console.WriteLine("- /ppt/notesSlides/notesSlide1.xml, ... : Notes slide parts.");
                Console.WriteLine("- /ppt/theme/theme1.xml : Theme definitions.");
                Console.WriteLine("- /ppt/slideLayouts/slideLayout1.xml, ... : Layout parts.");
                Console.WriteLine("- /ppt/media/ : Folder containing embedded images, audio, video files.");
                Console.WriteLine("- /ppt/_rels/presentation.xml.rels : Relationships for the presentation part.");
                Console.WriteLine("- /ppt/slides/_rels/slide1.xml.rels, ... : Relationships for each slide (e.g., images, hyperlinks).");
                Console.WriteLine("- /docProps/app.xml and /docProps/core.xml : Core and application properties.");
                Console.WriteLine("- [Content_Types].xml : Defines content types for each part.");
                Console.WriteLine("Relationships are defined using .rels files that map parts to each other, enabling the package to be navigated.");
                Console.WriteLine("When saved, Aspose.Slides writes these parts and relationships into a ZIP archive with the .pptx extension.");

                // Save the presentation before exiting
                string outputPath = "ZipArchitectureDemo.pptx";
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}