module TestingPlatformEntryPoint

let asyncMain args = task {
    return TestEntryPoint.Lib.sum 1 2
}

[<EntryPoint>]
let main args =    
    asyncMain(args).GetAwaiter().GetResult()