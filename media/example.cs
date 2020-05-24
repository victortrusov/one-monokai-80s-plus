using System;
using System.Linq;

/// <typeparam name="T">Class that contains environment variables as props</typeparam>
public partial class ExampleProvider<T> where T : class, new()
{
    private readonly Type type = typeof(T);
    private readonly List<MemberMap> members = new List<MemberMap>();

    /// <summary>
    /// Values of all defined environment variables
    /// </summary>
    public T Values { get; private set; }
    
    public EnvironmentProvider(T initialValues, string str, IEnumerable<int> numbers) : this(null) { 
        Values = initialValues ?? new T();
        var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
        foreach (var prop in properties)
        {
            members.Add(new MemberMap(prop) {
                Test = "test"
            });
        }
    }

    public void Example()
    {
        var str = "This is example string";
        int integer = 1231241423;
        double[] doubleArray = new double[] { 1.2323, 231.1 };
        List<MemberMap> memberMaps = Utils.CreateMemberMap(integer);
        Console.WriteLine(string.Join(", ", memberMaps.Select(x => x.Name)));
    }
}

