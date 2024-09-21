namespace TUnit.Engine

open global.TUnit.Core
open global.TUnit.Engine

type MyTest_MyTestClass() =
    static member Initialise() =
        try
            let methodInfo = typeof<global.MyTestProject.MyTestClass>.GetMethod("MyTest", 0, [||])
            let resettableClassFactory = ResettableLazy<_>(fun () -> global.MyTestProject.MyTestClass())
            
            TestRegistrar.RegisterTest<_>(
                TestMetadata<global.MyTestProject.MyTestClass>(
                    TestId = $"TestAttribute:MyTestProject.MyTestClass.MyTest:0",
                    TestClassArguments = [||],
                    TestMethodArguments = [||],
                    InternalTestClassArguments = [||],
                    InternalTestMethodArguments = [||],
                    CurrentRepeatAttempt = 0,
                    RepeatLimit = 0,
                    MethodInfo = methodInfo,
                    ResettableClassFactory = resettableClassFactory,
                    TestMethodFactory = (fun classInstance cancellationToken -> AsyncConvert.Convert(fun () -> classInstance.MyTest())),
                    TestExecutor = DefaultExecutor.Instance,
                    ClassConstructor = null,
                    ParallelLimit = null,
                    DisplayName = $"MyTest",
                    TestFilePath = @"C:\Dev\TUnitPlayground\TUnitPlayground\Program.cs",
                    TestLineNumber = 11,
                    AttributeTypes = [| typeof<global.TUnit.Core.TestAttribute> |]
                )
            )
        with _exception ->
            TestRegistrar.Failed(
                $"TestAttribute:MyTestProject.MyTestClass.MyTest:0",
                FailedInitializationTest(
                    TestId = $"TestAttribute:MyTestProject.MyTestClass.MyTest:0",
                    TestName = "MyTest",
                    DisplayName = "MyTest",
                    TestFilePath = @"C:\Dev\TUnitPlayground\TUnitPlayground\Program.cs",
                    TestLineNumber = 11,
                    Exception = _exception
                )
            )
