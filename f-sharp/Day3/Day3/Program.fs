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
    let day1 = 
        input
          |> Seq.scan location (0,0)
          |> Seq.distinct
          |> Seq.length
    let day2 = 
        input
          |> Seq.scan (fun (x,y) c -> (location y c, x)) ((0,0),(0,0))
          |> Seq.map fst
          |> Seq.distinct
          |> Seq.length
    printfn "For first : %d got them" day1
    printfn "For 2nd: %d got them" day2
    printfn "%A" argv
    0 // return an integer exit code

