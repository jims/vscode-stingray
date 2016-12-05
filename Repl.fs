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
            "nested" ==> createObj [ "a number" ==> 12 ];
            "bollen" ==> 1
        ]

    //decodeObject ("filed2" := string) object |> log
    //decodeObject (at ["nested"; "a number"] int) object |> log
 
    let addInts = map2 (+) (at ["nested"; "a number"] int) (field "field1" int)

    object
    |> addInts
    |> log

    let addTheNumbersDecoder = decode {
        let! added = addInts
        let! prefix = field "filed2" string
        let! boll = maybe (field "bollen" int)
        return sprintf "'%s' goes with ~%i.%s" prefix added
            (match boll with
            | Some n -> " Samt " + (if n > 1 then "flera" else "en eller inga") + " bollar"
            | None -> "")
    }

    object
    |> addTheNumbersDecoder
    |> log
let activate (ctx : vscode.ExtensionContext) : unit =
    vscode.commands.registerCommand("stingray.startRepl", testDecode |> unbox<System.Func<obj, obj>>)
    |> ctx.subscriptions.Add

    printfn "command registered"
    testDecode()

    vscode.window.createOutputChannel("Stingray")
    |> ignore

