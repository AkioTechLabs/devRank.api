using System.Reflection;

namespace devRank.Domain;

public class DomainAssembly
{
    public static Assembly Assembly => typeof(DomainAssembly).Assembly;
}