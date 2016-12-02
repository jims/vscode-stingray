module Stingray.Repl

open Fable.Core
open Fable.Import
open Fable.Core.JsInterop

open Fable.Import.vscode
open Helpers

open FSharp.Control

open Stingray.Decoder
open Decoder.Decode
let testDecode () =
    let log : (DecodeResult<'a> -> unit) = function
        | Ok(v) -> (printfn "decoded %A" v) |> ignore
        | Err(e) -> (printfn "failed with %s" e) |> ignore

    let object =
        createObj [
            "field1" ==> 42;
            "filed2" ==> "I am a string";
            "nested" ==> createObj [ "a number" ==> false ]
        ]

    //decodeObject ("filed2" := string) object |> log
    //decodeObject (at ["nested"; "a number"] int) object |> log
 
    let addInts = map2 (+) (at ["nested"; "a number"] int) (field "field1" int)

    object
    |> addInts
    |> log
let activate (ctx : vscode.ExtensionContext) : unit =
    vscode.commands.registerCommand("stingray.startRepl", testDecode |> unbox<System.Func<obj, obj>>)
    |> ctx.subscriptions.Add

    printfn "command registered"
    testDecode()

    vscode.window.createOutputChannel("Stingray")
    |> ignore

