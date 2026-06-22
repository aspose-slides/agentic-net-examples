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

## Developer FAQ

### How do I create and save a PowerPoint presentation in C#?
Use the standalone examples in this repository to create an `Aspose.Slides.Presentation`, add slides, shapes, text, charts, or media, and save with `Aspose.Slides.Export.SaveFormat.Pptx`.

### How do I convert PPTX files to PDF, HTML, TIFF, SVG, PNG, or JPEG?
See the [conversion](./conversion/) examples for C# code covering presentation export, slide thumbnails, image conversion, PDF options, HTML output, and format-specific save settings.

### How do I edit slides, shapes, charts, and text in .NET?
Use category examples such as [working-with-slides](./working-with-slides/), [working-with-shapes](./working-with-shapes/), [working-with-charts](./working-with-charts/), and [manage-presentation-text](./manage-presentation-text/).

### Are these examples suitable for coding agents and AI search engines?
Yes. The repository includes [AGENTS.md](./AGENTS.md), [llms.txt](./llms.txt), [index.json](./index.json), category README pages, and structured Q&A sections for AI retrieval and developer search.

## Real-World Use Cases

- Batch convert PPTX decks to PDF, HTML, images, or archival formats.
- Generate reporting presentations with charts, tables, formatted text, and branded layouts.
- Extract media, comments, notes, metadata, and custom tags from existing presentations.
- Secure, inspect, repair, or validate presentation files in backend .NET workflows.

Generated for SEO/GEO indexing on 2026-06-22. Total examples: 2273. Categories: 19.
<!-- SEO-GEO:END -->
