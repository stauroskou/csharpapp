using System.Reflection;

namespace CSharpApp.Application;

public static class AssemblyReference 
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
