#r "node_modules/fable-core/Fable.Core.dll"
#load "fable-import-vscode.fsx"
#load "helpers.fsx"

open Fable.Core
open Fable.Import
open Fable.Import.vscode
open Fable.Core.JsInterop
open Helpers

module Extension =
    let rec pomme (msg : string) = promise {
        let! item = window.showInformationMessage(msg |> unbox, [|"Choice 1"; "Choice 2"|] |> Array.map unbox) |> unbox<JS.Promise<string>>
        return! pomme item
    }
    let activate (ctx : vscode.ExtensionContext) =
        commands.registerCommand("stingray.sayHello", fun _ -> pomme "Då börjas det!" |> unbox)
        |> ctx.subscriptions.Add

let activate = Extension.activate