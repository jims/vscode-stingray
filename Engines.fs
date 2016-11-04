module Stingray.Engines

open Fable.Core
open Fable.Import
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.Node
open Fable.Import.Node.net_types

open FSharp.Control
open Stingray
open Helpers

[<Erase>]
module Scanner =
    let assetServerPort = 14032
    type Host = string * int

    let tryConnect host port timeout : JS.Promise<bool> =
        Promise.create (fun resolve _ ->
            let socket = createNew net.Socket |> unbox<Socket>
            let res ok =
                socket.destroy() |> ignore
                resolve ok
            socket.setTimeout(float timeout) 
            socket?on("connect", fun _ -> res true) |> ignore
            socket?on("error", res false) |> ignore
            socket.connect(host, None |> unbox))

    let scanPorts (pstart : int) (pend : int) =
        let subject = Event<int>()
        
        for p in pstart .. pend do
            tryConnect "127.0.0.1" p 500
            |> Promise.onSuccess (function true -> subject.Trigger(p) | false -> ())
            |> ignore
            
        subject.Publish

let activate (ctx : vscode.ExtensionContext) : unit =
    Scanner.scanPorts 14033 14040
    |> Observable.subscribe (fun port -> printfn "%A" port)
    |> ctx.subscriptions.Add