open System



type User = { name: string; lastSeen : DateTime }

let user = { name = "new User"; lastSeen = DateTime.Now }
let renamed = 
    { user with name = "alice" }

let square = fun x -> x * x 


// For more information see https://aka.ms/fsharp-console-apps
printfn "Hello from F#"

type Optional<'a> =
    | NoValue
    | SomeValue of 'a

// integer division. 
// division by zero is modeled by returning
// NoValue
let divSafe (a : int) (b : int) =
    if b = 0 then NoValue
    else SomeValue (a / b)

let test() =
    match divSafe 1 2 with
    | SomeValue v -> 
        Console.WriteLine("had value")
    