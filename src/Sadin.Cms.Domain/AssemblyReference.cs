using System.Reflection;

namespace Sadin.Cms.Domain;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}