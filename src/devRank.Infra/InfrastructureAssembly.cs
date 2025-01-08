using System.Reflection;

namespace devRank.Infra;

public class InfrastructureAssembly
{
    public static Assembly Assembly => typeof(InfrastructureAssembly).Assembly;
}