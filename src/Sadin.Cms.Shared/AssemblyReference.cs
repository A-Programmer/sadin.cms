using System.Reflection;

namespace Sadin.Cms.Shared;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}