open System.IO
//Part One
File.ReadAllText("c:\\temp\\day1.txt")
    |> Seq.sumBy (fun i -> if i = '(' then 1 else -1)

//Part B

File.ReadAllText("c:\\temp\\day1.txt")
    |> Seq.map (fun d -> if d = '(' then 1 else -1)
    |> Seq.scan (+) 0 
    |> Seq.findIndex (fun f -> f = -1)
