using NetArchTest.Rules;
using Xunit;

namespace LibraryService.ArchitectureTests;
public sealed class LayerDependencyTests
{
    [Fact]
    public void VerticalSlice_Should_Not_Generate_Separate_Layered_Project_Namespace_Dependencies()
    {
        var apiAssembly = typeof(LibraryService.Api.Domain.Shared.Result).Assembly;
        var types = Types.InAssembly(apiAssembly);
        var resultApp = types.ShouldNot().HaveDependencyOn("LibraryService.Api.Features").GetResult();
        var resultDomain = types.ShouldNot().HaveDependencyOn("LibraryService.Domain").GetResult();
        var resultInfra = types.ShouldNot().HaveDependencyOn("LibraryService.Infrastructure").GetResult();
        Assert.True(resultApp.IsSuccessful && resultDomain.IsSuccessful && resultInfra.IsSuccessful);
    }

    [Fact]
    public void VerticalSlice_Domain_Should_Not_Depend_On_Infrastructure()
    {
        var apiAssembly = typeof(LibraryService.Api.Domain.Shared.Result).Assembly;
        var result = Types.InAssembly(apiAssembly).That().ResideInNamespace("LibraryService.Api.Domain").ShouldNot().HaveDependencyOn("LibraryService.Api.Infrastructure").GetResult();
        Assert.True(result.IsSuccessful);
    }
}