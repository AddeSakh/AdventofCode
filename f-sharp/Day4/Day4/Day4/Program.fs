let showAnswer a b = printfn "Answer for part 1: %A, for part 2: %A" a b

let run() = 
  let input = "yzbqklnj"
  let solve startSeq = 
    let hasher = Security.Cryptography.MD5.Create()
    Seq.initInfinite id
    |> Seq.find(fun i -> 
      input + i.ToString() 
      |> Text.Encoding.ASCII.GetBytes 
      |> hasher.ComputeHash