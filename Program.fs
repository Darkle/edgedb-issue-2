open EdgeDB
open System.Collections.Generic

let config =
    EdgeDBClientPoolConfig(SchemaNamingStrategy = INamingStrategy.DefaultNamingStrategy, ExplicitObjectIds = false)

let dbClient = EdgeDBClient(config)

[<EntryPoint>]
let main _ =
    task {
        try
            do!
                dbClient.ExecuteAsync(
                    """
                  insert User{
                    name := <str>$username
                  }
                  """,
                    {| username = "Joe" |}
                )
        with err ->
            printfn "Error: %A" err
    }
    |> Async.AwaitTask
    |> Async.RunSynchronously

    task {
        try
            do!
                dbClient.ExecuteAsync(
                    """
                  insert Post{
                    postId := "post1",
                    title := "title",
                    score := <int32>$score
                  }
                  """,
                    {| score = 10 |}
                )
        with err ->
            printfn "Error: %A" err
    }
    |> Async.AwaitTask
    |> Async.RunSynchronously

    // Below also errors.
    let queryParams = new Dictionary<string, obj>()
    queryParams.Add("name", None)
    queryParams.Add("author", Some("joe"))

    task {
        try
            do!
                dbClient.ExecuteAsync(
                    """
                  insert Book{
                    name := <optional str>$name ?? "hello",
                    author := <optional str>$author ?? "merp"
                  }
                  """,
                    queryParams
                )
        with err ->
            printfn "Error: %A" err
    }
    |> Async.AwaitTask
    |> Async.RunSynchronously



    0
