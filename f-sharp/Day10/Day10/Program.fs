open System

let getInput() = "3113322113"

let iterate n func arg = 
  let rec go i v =  
    match i with
    | 0 -> v
    | _ -> go <| i - 1 <| func v
  go n arg

let showAnswer a b = printfn "Answer for part 1: %A, for part 2: %A" a b

let run() =
  let input, parseSeq = getInput(), Seq.map (string >> Int32.Parse) >> Seq.toList
  let lookAndSay sq =
    let rec go res s =
      let h = List.head s
      let n = s |> List.takeWhile((=) h) |> List.length
      let s', res' = s |> List.skip n, [h; n] @ res
      if s' |> List.isEmpty then res' |> List.rev else go res' s'
    go [] sq
  let solve n = input |> parseSeq |> iterate n lookAndSay |> Seq.length
  (solve 40, solve 50) ||> showAnswer

run()
