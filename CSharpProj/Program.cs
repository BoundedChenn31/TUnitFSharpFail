// See https://aka.ms/new-console-template for more information

using TUnit.Assertions;
using TUnit.Assertions.Extensions;
using TUnit.Core;

namespace MyCSharpTestProject;

public class MyTestClass
{
    [Test]
    public async Task MyTest()
    {
        var result = Add(1, 2);

        await Assert.That(result).IsEqualTo(3);
    }

    private int Add(int x, int y)
    {
        return x + y;
    }
}