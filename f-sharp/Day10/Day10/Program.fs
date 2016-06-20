open System
open System.IO

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

  (solve 40, solve 50) ||> showAnswer

run()