module TestingPlatformEntryPoint

let asyncMain args = task {
    let! (builder: global.Microsoft.Testing.Platform.Builder.ITestApplicationBuilder) =
        global.Microsoft.Testing.Platform.Builder.TestApplication.CreateBuilderAsync(args)
    Microsoft.Testing.Platform.MSBuild.TestingPlatformBuilderHook.AddExtensions(builder, args)
    TUnit.Engine.Framework.TestingPlatformBuilderHook.AddExtensions(builder, args)
    use! app = builder.BuildAsync()
    return! app.RunAsync()
}

[<EntryPoint>]
let main args =    
    asyncMain(args).GetAwaiter().GetResult()
