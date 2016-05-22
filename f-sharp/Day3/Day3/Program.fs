let location (x,y) ch =
  match ch with
  |'<' -> (x-1,y)
  |'>' -> (x+1,y)
  |'v' -> (x,y+1)
  |'^' -> (x,y-1)
  |_ -> (x,y)

[<EntryPoint>]
let main argv = 
    let input = System.IO.File.ReadAllText("""C:\temp\day3.txt""")
    let result1 = 
        input
          |> Seq.scan location (0,0)
          |> Seq.distinct
          |> Seq.length
    printfn "For first: %d got them" result1
    printfn "%A" argv
    0 // return an integer exit code
