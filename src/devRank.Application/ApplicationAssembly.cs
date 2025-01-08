using System.Reflection;

namespace devRank.Application;

public class ApplicationAssembly
{
    public static Assembly Assembly => typeof(ApplicationAssembly).Assembly;
}