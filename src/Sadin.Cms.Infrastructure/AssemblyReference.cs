using System.Reflection;

namespace Sadin.Cms.Infrastructure;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}