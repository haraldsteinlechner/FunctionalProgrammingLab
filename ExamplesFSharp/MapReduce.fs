let mapReduce2 (m : 's -> seq<'m>) (selector : 'm -> 'k) (reduce : 'k*seq<'m> -> seq<'r>) (xs : seq<'s>) =
    xs |> Seq.collect m |> Seq.groupBy selector |> Seq.collect reduce

// need no types in f#
let mapReduce m selector reduce xs =
    xs |> Seq.collect m |> Seq.groupBy selector |> Seq.collect reduce

// make parallel
open FSharp.Collections.ParallelSeq
let mapReduceP m selector reduce xs =
    xs |> PSeq.collect m |> PSeq.groupBy selector |> PSeq.collect reduce

open System.IO
open System.Linq

[<EntryPoint>]
let main argv = 

    let delimiters = 
        Enumerable.Range(0,256) 
        |> Seq.map char
        |> Seq.filter (fun c -> System.Char.IsWhiteSpace c || System.Char.IsPunctuation c)
        |> Seq.toArray

    let files = Directory.EnumerateFiles(argv.[0], "*" + argv.[1], SearchOption.AllDirectories) 

    let split lines = 
        lines 
        |> Seq.collect (fun (l : string) -> l.Split delimiters)

    let counts = 
        files 
        |> mapReduceP (split << File.ReadAllLines) id (fun (k,values) -> [k, Seq.length values])
        |> Seq.sortByDescending (fun (word, count) -> count)

    for c in counts do printfn "%A" c
   
    0 
