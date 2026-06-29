# Aspose.Slides for .NET Examples (V26.5.0)


       





AI-friendly repository containing validated C# examples for Aspose.Slides for .NET API.





## Overview





This repository provides working code examples demonstrating Aspose.Slides for .NET capabilities. All examples are automatically generated, compiled, and validated using the Aspose.Slides Examples Generator.





## Repository Structure





Examples are organized by feature category:


- `3d-presentations/` - 30 example(s)


- `animations/` - 34 example(s)


- `comments-and-notes/` - 120 example(s)


- `conversion/` - 397 example(s)


- `design-presentations/` - 161 example(s)


- `manage-presentation/` - 64 example(s)


- `manage-presentation-content/` - 101 example(s)


- `manage-presentation-media-files/` - 149 example(s)


- `manage-presentation-text/` - 104 example(s)


- `manage-tags-and-custom-data/` - 40 example(s)


- `math-equations/` - 29 example(s)


- `presentation-ink-objects/` - 35 example(s)


- `secure-presentations/` - 29 example(s)


- `vba-macros/` - 34 example(s)


- `working-with-charts/` - 463 example(s)


- `working-with-shapes/` - 208 example(s)


- `working-with-slides/` - 123 example(s)


- `working-with-smartart/` - 121 example(s)


- `working-with-tables/` - 31 example(s)





Each category contains standalone `.cs` files that can be compiled and run independently.





## Getting Started





### Prerequisites


- .NET SDK (net10.0 or compatible version)


- Aspose.Slides for .NET NuGet package


- Valid Aspose license (for production use)





### Running Examples





Each example is a self-contained C# file. To run an example:





```bash


cd <CategoryFolder>


dotnet new console -o ExampleProject


cd ExampleProject


dotnet add package Aspose.Slides


# Copy the example .cs file as Program.cs


dotnet run


```





## Code Patterns





### Loading a Presentation


```csharp


using (Presentation pres = new Presentation("input.pptx"))


{


    // Work with presentation


}


```





### Error Handling


```csharp


if (!File.Exists(inputPath))


{


    Console.Error.WriteLine($"Error: File not found – {inputPath}");


    return;


}





try


{


    // Operations


}


catch (Exception ex)


{


    Console.Error.WriteLine($"Error: {ex.Message}");


}


```





## Contributing





Examples in this repository are automatically generated.





## Related Resources





- [Aspose.Slides for .NET Documentation](https://docs.aspose.com/slides/net/)


- [API Reference](https://reference.aspose.com/slides/net/)


- [Aspose Forum](https://forum.aspose.com/c/slides/11)


- [AI Agent Guide](./AGENTS.md)





## License





All examples require a valid [Aspose license](https://purchase.aspose.com/) for production use.





---





*This repository is maintained by automated code generation.*



<!-- SEO-GEO:BEGIN -->

## Aspose.Slides for .NET Developer Capabilities



This repository contains build-validated C# examples for automating Microsoft PowerPoint and OpenDocument presentations with Aspose.Slides for .NET. Developers can find examples for PPTX creation, presentation conversion, slide manipulation, chart generation, animation, SmartArt, tables, text formatting, media extraction, security, VBA macros, comments, notes, and document metadata.



## Capability Table



| Capability | Examples | Common developer search targets |

| --- | ---: | --- |

| [3d-presentations](./3d-presentations/) | 30 | PPTX, PDF, HTML, images, charts, shapes, slides, text, media |

| [animations](./animations/) | 34 | PPTX, PDF, HTML, images, charts, shapes, slides, text, media |

| [comments-and-notes](./comments-and-notes/) | 120 | PPTX, PDF, HTML, images, charts, shapes, slides, text, media |

| [conversion](./conversion/) | 397 | PPTX, PDF, HTML, images, charts, shapes, slides, text, media |

| [design-presentations](./design-presentations/) | 161 | PPTX, PDF, HTML, images, charts, shapes, slides, text, media |

| [manage-presentation](./manage-presentation/) | 64 | PPTX, PDF, HTML, images, charts, shapes, slides, text, media |

| [manage-presentation-content](./manage-presentation-content/) | 101 | PPTX, PDF, HTML, images, charts, shapes, slides, text, media |

| [manage-presentation-media-files](./manage-presentation-media-files/) | 149 | PPTX, PDF, HTML, images, charts, shapes, slides, text, media |

| [manage-presentation-text](./manage-presentation-text/) | 104 | PPTX, PDF, HTML, images, charts, shapes, slides, text, media |

| [manage-tags-and-custom-data](./manage-tags-and-custom-data/) | 40 | PPTX, PDF, HTML, images, charts, shapes, slides, text, media |

| [math-equations](./math-equations/) | 29 | PPTX, PDF, HTML, images, charts, shapes, slides, text, media |

| [presentation-ink-objects](./presentation-ink-objects/) | 35 | PPTX, PDF, HTML, images, charts, shapes, slides, text, media |

| [secure-presentations](./secure-presentations/) | 29 | PPTX, PDF, HTML, images, charts, shapes, slides, text, media |

| [vba-macros](./vba-macros/) | 34 | PPTX, PDF, HTML, images, charts, shapes, slides, text, media |

| [working-with-charts](./working-with-charts/) | 463 | PPTX, PDF, HTML, images, charts, shapes, slides, text, media |

| [working-with-shapes](./working-with-shapes/) | 208 | PPTX, PDF, HTML, images, charts, shapes, slides, text, media |

| [working-with-slides](./working-with-slides/) | 123 | PPTX, PDF, HTML, images, charts, shapes, slides, text, media |

| [working-with-smartart](./working-with-smartart/) | 121 | PPTX, PDF, HTML, images, charts, shapes, slides, text, media |

| [working-with-tables](./working-with-tables/) | 31 | PPTX, PDF, HTML, images, charts, shapes, slides, text, media |



## Real-World Use Cases



- Batch convert PPTX decks to PDF, HTML, images, or archival formats.

- Generate reporting presentations with charts, tables, formatted text, and branded layouts.

- Extract media, comments, notes, metadata, and custom tags from existing presentations.

- Secure, inspect, repair, or validate presentation files in backend .NET workflows.



Generated for SEO/GEO indexing on 2026-06-22. Total examples: 2273. Categories: 19.

<!-- SEO-GEO:END -->

<!-- SEO-FAQ:BEGIN -->
## Developer FAQ

These answers target high-intent developer searches for C#, .NET, PowerPoint automation, PPTX conversion, presentation editing, and agentic code retrieval.

### How do I create or edit PowerPoint charts in C# with Aspose.Slides?
Use chart examples to add chart shapes, access `Aspose.Slides.Charts.IChart`, update chart data, format series, configure axes, and save the presentation. See [working-with-charts](./working-with-charts/) for related examples.

### How do I add or inspect PowerPoint animations in C#?
Use animation examples to work with slide timelines, animation sequences, effect types, triggers, and animated shapes through Aspose.Slides APIs. See [working-with-charts](./working-with-charts/) for related examples.

### How do I use Aspose.Slides for .NET for working with charts in C#?
Use the `working-with-charts` examples to find standalone C# patterns for working with charts. Each example shows how to load or create an `Aspose.Slides.Presentation`, apply the operation, and save output with the correct Aspose.Slides API. See [working-with-charts](./working-with-charts/) for related examples.

### Which working with charts examples are best for coding agents?
Start with the files listed in this directory and the category AGENTS.md. The strongest search terms for this category are: chart, csset, csadd, data, csexport. See [working-with-charts](./working-with-charts/) for related examples.

### Are the working-with-charts examples standalone C# programs?
Yes. The examples are generated as standalone console-style C# files and are intended to compile and run independently in .NET workflows. See [working-with-charts](./working-with-charts/) for related examples.

### How do I convert PowerPoint PPTX files to PDF, HTML, SVG, PNG, or JPEG in C#?
Use the conversion and export examples to load a `Presentation`, configure format-specific options when needed, and call `presentation.Save(...)` or slide image APIs with the correct `Aspose.Slides.Export.SaveFormat`. See [conversion](./conversion/) for related examples.

### How do I add, clone, reorder, or remove PowerPoint slides in .NET?
Use slide management examples to work with `ISlide`, slide collections, layouts, masters, and sections while preserving presentation structure. See [conversion](./conversion/) for related examples.

### How do I use Aspose.Slides for .NET for conversion in C#?
Use the `conversion` examples to find standalone C# patterns for conversion. Each example shows how to load or create an `Aspose.Slides.Presentation`, apply the operation, and save output with the correct Aspose.Slides API. See [conversion](./conversion/) for related examples.

### Which conversion examples are best for coding agents?
Start with the files listed in this directory and the category AGENTS.md. The strongest search terms for this category are: pptx, swf, pdf, ppt, with. See [conversion](./conversion/) for related examples.

### Are the conversion examples standalone C# programs?
Yes. The examples are generated as standalone console-style C# files and are intended to compile and run independently in .NET workflows. See [conversion](./conversion/) for related examples.

<!-- SEO-FAQ:END -->
