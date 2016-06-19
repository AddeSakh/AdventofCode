let showAnswer a b = printfn "Answer for part №1: %A, for part №2: %A" a b

let run() = 
  let lines = System.IO.File.ReadAllLines("c:\\temp\\day8.txt") 
  let escapedLength = lines |> Array.sumBy String.length
  let unescape s = 
    let us = System.Text.RegularExpressions.Regex.Unescape(s)
    us.[1 .. us.Length - 2]
  let unescapedLength = lines |> Array.sumBy (unescape >> String.length)
  let escape s = 
    let es = System.Text.RegularExpressions.Regex.Escape(s).Replace("\"", "\\\"")
    "\"" + es + "\""
  let escapedtwiceLength = lines |> Array.sumBy (escape >> String.length)
  (escapedLength - unescapedLength, escapedtwiceLength - escapedLength) ||> showAnswer

run()