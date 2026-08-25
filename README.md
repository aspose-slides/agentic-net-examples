# Aspose.Slides for .NET Examples (V26.8.0)
       

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

<!-- latest-slides-verification:start -->
## Latest Aspose.Slides Verification

Generated examples were tested with Aspose.Slides for .NET 26.8.0 on 2026-08-25.

No examples are currently quarantined.
<!-- latest-slides-verification:end -->
