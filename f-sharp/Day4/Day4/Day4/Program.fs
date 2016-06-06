open System.Security.Cryptography


[<EntryPoint>]
let main argv = 
    let md5 = MD5.Create()
    let input = "yzbqklnj"
