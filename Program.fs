open EdgeDB

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



    0
