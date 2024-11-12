using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using CodeMechanic.FileSystem;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

// namespace Foo;

[Generator]
public sealed class SqlSelectGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterPostInitializationOutput(ctx =>
        {
            string cwd = Directory.GetCurrentDirectory();

            var sqlfiles = new Grepper()
            {
                RootPath = cwd,
                FileSearchMask = "*.sql"
            }.GetFileNames().ToList();

            if (sqlfiles.Count == 0) throw new Exception("OOOPs no files.");

            Console.WriteLine("results :>> " + sqlfiles.Count);

//             foreach (var file_path in sqlfiles)
//             {
//                 string text = File.ReadAllText(file_path);
//                 string file_name = Path.GetFileNameWithoutExtension(file_path);
//
//                 string source_text = $$"""
//                                        namespace hydro_examples
//                                        {
//                                            public static class Sprocs
//                                            {
//                                                    public static string GetAllParts = "select * from todos";
//                                            }
//                                        }
//                                        """;
//
//                 ctx.AddSource($"sprocs.g", SourceText.From(source_text, Encoding.UTF8));
//             }


            string source_text = $$"""
                                   namespace Foo
                                   {
                                       public static class Sprocs
                                       {
                                               public static string GetAllParts = "select * from todos";
                                       }
                                   }
                                   """;

            ctx.AddSource("sprocs.g", SourceText.From(source_text, Encoding.UTF8));
        });
    }
}

public record DotEnv
{
    public static void Load()
    {
    }
}