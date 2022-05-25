open System
open System.IO

let smallFiles (path : string) = 
    // enumerate files just like in c#
    Directory.EnumerateFiles(path, "*.cs", SearchOption.AllDirectories)
    // map maps a function of the sequence for all input selements
    |> Seq.map (fun path -> (path, File.ReadAllLines(path).Length))
    // Seq.filter is filters an input sequence using a predicate function
    |> Seq.filter (fun (path, lines) -> lines < 10)
    // Seq.iter can be used to run a function for each element
    |> Seq.iter (fun (path, lines) -> 
        Console.WriteLine($"{path} contains just {lines} lines")
    )