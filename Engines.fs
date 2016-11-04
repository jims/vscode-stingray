module Stingray.Engines

open Fable.Core
open Fable.Core.JsInterop

open Fable.Import
open Fable.Import.Node
open Fable.Import.Node.net_types

open FSharp.Control
open Stingray

open Helpers

module Scanner =
    let assetServerPort = 14032
    type Host = string * int

    let tryConnect host port timeout : JS.Promise<bool> =
        Promise.create (fun resolve _ ->
            let socket = createNew net.Socket () |> unbox<Socket>
            let res ok =
                printfn "tried %i ok=%b" port ok
                socket.destroy() |> ignore
                resolve ok
            socket.setTimeout(float timeout) 
            socket?on("connect", fun _ -> res true) |> ignore
            socket?on("error", fun _ -> res false) |> ignore
            socket.connect(sprintf "%s:%i" host port, None |> unbox))

    let scanPorts (pstart : int) (pend : int) =
        let subject = Event<int>()
        
        for p in pstart .. pend do
            tryConnect "127.0.0.1" p 500
            |> Promise.onSuccess (function true -> subject.Trigger(p) | false -> ())
            |> ignore
            
        subject.Publish

let private a : Connection.Link list = []

let activate (ctx : vscode.ExtensionContext) : unit =
    Scanner.scanPorts 14033 14040
    |> Observable.subscribe (fun port -> printfn "%i" port)
    |> ctx.subscriptions.Add