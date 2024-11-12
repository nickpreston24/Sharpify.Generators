using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

// namespace HelloWorldSrcGen;

[Generator]
public sealed class HydroGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterPostInitializationOutput(ctx =>
        {
            string codebehind = $$"""
                                  using Hydro;
                                  namespace hydro_examples
                                  {
                                       public class PageCounter2 : HydroComponent
                                      {
                                          public int Count { get; set; }
                                          
                                          public void Add()
                                          {
                                              Count++;
                                          }
                                      }
                                  }
                                  """;

            string ui = $$"""
                          @model PageCounter2

                          <div class='text-accent'>
                            Count: <strong>@Model.Count</strong>
                            <button on:click="@(() => Model.Add())">
                              Add
                            </button>
                          </div>

                          """;
            ctx.AddSource("PageCounter2.cshtml.g", SourceText.From(codebehind, Encoding.UTF8));
            // ctx.AddSource("PageCounter2.cshtml.g", SourceText.From(ui, Encoding.UTF8));
        });
        
        context.RegisterPostInitializationOutput(ctx =>
        {
            string source_text = $$"""
                                  using Hydro;
                                  namespace hydro_examples
                                  {
                                     
                                     public static class Sprocs
                                       {
                                               public static string GetAllParts = "select * from todos";
                                       }
                                  }
                                  """;

           
            ctx.AddSource("Sprocs.g", SourceText.From(source_text, Encoding.UTF8));
        });
    }
}