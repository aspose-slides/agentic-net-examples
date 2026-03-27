using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define output directory and ensure it exists
        var outputDir = System.IO.Path.Combine(System.Environment.CurrentDirectory, "Output");
        if (!System.IO.Directory.Exists(outputDir))
            System.IO.Directory.CreateDirectory(outputDir);

        // Define output PPTX file path
        var outputPath = System.IO.Path.Combine(outputDir, "ArchitectureDemo.pptx");

        // Create a new presentation and add a default slide
        using (var presentation = new Presentation())
        {
            var slide = presentation.Slides[0];
            // Save the presentation (required before exit)
            presentation.Save(outputPath, SaveFormat.Pptx);
        }

        // Describe the ZIP package architecture of a PPTX file
        Console.WriteLine("PPTX files are ZIP archives that follow the Open XML Packaging Convention.");
        Console.WriteLine("Key parts and their purposes:");
        Console.WriteLine(" - [Content_Types].xml : Lists content types for each part in the package.");
        Console.WriteLine(" - _rels/.rels : Package-level relationships (e.g., link to the presentation part).");
        Console.WriteLine(" - ppt/presentation.xml : Root presentation part; contains slide IDs, master references, and overall settings.");
        Console.WriteLine(" - ppt/slides/slide1.xml, slide2.xml, ... : Individual slide content (shapes, text, animations).");
        Console.WriteLine(" - ppt/slideMasters/slideMaster1.xml : Definitions of slide masters (common layout, styles).");
        Console.WriteLine(" - ppt/slideLayouts/slideLayout1.xml, ... : Layouts used by slides, referencing masters.");
        Console.WriteLine(" - ppt/theme/theme1.xml : Theme definitions (color scheme, fonts, effects).");
        Console.WriteLine(" - ppt/media/... : Embedded media files such as images, audio, and video.");
        Console.WriteLine(" - ppt/embeddings/... : Embedded OLE objects.");
        Console.WriteLine(" - ppt/notesSlides/notesSlide1.xml, ... : Notes associated with each slide.");
        Console.WriteLine(" - ppt/_rels/... : Relationship files for each part (e.g., slide relationships to media).");

        Console.WriteLine("\nRelationships overview:");
        Console.WriteLine(" - The package .rels file points to ppt/presentation.xml as the main part.");
        Console.WriteLine(" - presentation.xml has relationships to slide masters, slide parts, and other resources.");
        Console.WriteLine(" - Each slide part has its own .rels linking to its layout, images, notes, and embedded objects.");
        Console.WriteLine(" - Slide master parts relate to slide layouts and the theme part.");
        Console.WriteLine(" - Layout parts may reference the theme and any required resources.");
        Console.WriteLine("\nThis hierarchical organization enables modular editing and efficient reuse of resources within a PPTX file.");
    }
}