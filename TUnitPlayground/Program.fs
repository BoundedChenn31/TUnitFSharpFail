// For more information see https://aka.ms/fsharp-console-apps
namespace MyTestProject

open System.Threading.Tasks
open TUnit.Assertions
open TUnit.Assertions.Extensions
open TUnit.Core

type MyTestClass() =
    
    [<Test>]
    member _.MyTest(): Task = task {
        let result = 1 + 2
        do! Assert.That(result).IsEqualTo(3)
    }
