module Stingray.Extension

open Fable.Core
open Fable.Import
open Fable.Core.JsInterop

open FSharp.Control

open Fable.Import.vscode
open Helpers

let activate (ctx : vscode.ExtensionContext) =
  vscode.commands.registerCommand("stingray.startRepl", fun _ -> None |> unbox)
    |> ctx.subscriptions.Add
  ignore

