///Initial solution for day 2 (need to be changed)
type Box = {
    l: int
    w:  int
    h: int
}

let PaperRequired (b: Box) =
    let sides = [b.l * b.w; b.w * b.h; b.h * b.l]
    let double x = x * 2
    let surfaceArea = List.map double sides |> List.sum
    let slack = List.min sides
    surfaceArea + slack

let input = System.IO.File.ReadAllLines("""C:\temp\day2.txt""")

let getBoxes (str: string) = 
    let dimensions = str.Split([|'x'|])
    { l = int dimensions.[0]; w = int dimensions.[1]; h = int dimensions.[2]}

let allBoxes = Array.map getBoxes input

let totalPaper = 
    Array.map PaperRequired allBoxes
    |> Array.sum

let ribbonRequired (b:Box) = 
    let dimensions = [b.l; b.w; b.h]
    let bow = List.reduce (*) dimensions
    let ribbon =
        dimensions
        |> List.sortDescending
        |> List.tail
        |> List.map (fun x -> x + x)
        |> List.sum
    ribbon + bow

let totalRibbonRequired = 
    Array.map ribbonRequired allBoxes
    |> Array.sum