module Stingray.Repl

open Fable.Core
open Fable.Import
open Fable.Core.JsInterop

open Fable.Import.vscode
open Helpers

open FSharp.Control

let activate (ctx : vscode.ExtensionContext) : unit =
    vscode.window.createOutputChannel("Stingray")
    |> ignore

