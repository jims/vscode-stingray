module Stingray.Extension

open Fable.Core
open Fable.Import
open Fable.Core.JsInterop

open FSharp.Control

open Fable.Import.vscode
open Helpers

let activate (ctx : vscode.ExtensionContext) =
  Stingray.Engines.activate ctx
  Stingray.Repl.activate ctx

