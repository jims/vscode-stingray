module Stingray.REPL

open Fable.Core
open Fable.Import
open Fable.Core.JsInterop

open Fable.Import.vscode
open Helpers

open FSharp.Control

let start =
    vscode.window.createOutputChannel("Stingray")

