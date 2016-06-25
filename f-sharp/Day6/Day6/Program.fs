open System
open System.IO
open System.Text.RegularExpressions

type Action = On | Off | Toggle

let (|Contains|) sub (s : string) = s.Contains sub

let showAnswer a b = printfn "Answer for part 1: %A, for part 2: %A" a b

let regexMatches p (gs : int list) s = 
  Regex.Matches(s, p, RegexOptions.IgnoreCase)
  |> Seq.cast<Match>
  |> Seq.map (fun m -> gs |> List.map (fun i -> m.Groups.[i].Value))

let run() = 
  let solver matcher = 
    let parseCommand (s : string) = 
      let vs = 
        regexMatches @".+?(\d+),(\d+).+?(\d+),(\d+).*" [ 1; 2; 3; 4 ] s
        |> Seq.head |> Seq.toArray |> Array.map Int32.Parse
      (match s with
       | Contains "off"    true -> Off
       | Contains "toggle" true -> Toggle
       | Contains "on"     true -> On), ((vs.[0], vs.[1]), (vs.[2], vs.[3]))
  
    let executeCommand (g : int [,]) (a : Action, (tl : int * int, br : int * int)) =
      for x in [ fst tl .. fst br ] do
        for y in [ snd tl .. snd br ] do
          matcher g x y a
    let cmds, grid = File.ReadAllLines("c:\\temp\day6.txt"), Array2D.create 1000 1000 0
    cmds |> Array.map parseCommand |> Array.iter (executeCommand grid)

    let mutable nlights = 0
    grid |> Array2D.iter(fun e -> nlights <- nlights + e)
    nlights

  let matcher1 (grid : int [,]) x y = // rules for part 1
    function 
    | On     -> grid.[x, y] <- 1
    | Off    -> grid.[x, y] <- 0
    | Toggle -> grid.[x, y] <- 1 - grid.[x, y]
  let matcher2 (grid : int [,]) x y =  // rules for part 2
    function
    | On     ->                         grid.[x, y] <- grid.[x, y] + 1
    | Off    -> if grid.[x, y] > 0 then grid.[x, y] <- grid.[x, y] - 1
    | Toggle ->                         grid.[x, y] <- grid.[x, y] + 2
  (solver matcher1, solver matcher2) ||> showAnswer

run()