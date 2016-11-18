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
                socket.destroy() |> ignore
                resolve ok
            socket.setTimeout(float timeout) 
            socket?on("connect", fun e -> res true) |> ignore
            socket?on("error", fun e -> res false) |> ignore
            socket?connect(createObj [ "host" ==> host; "port" ==> port ]) |> ignore)

    let scanPorts (ports : seq<int>)  =
        let subject = Event<int>()
        
        for p in ports do
            tryConnect "localhost" p 1000
            |> Promise.onSuccess (function true -> subject.Trigger(p) | false -> ())
            |> ignore
            
        subject.Publish

let private a : Connection.Link list = []

let activate (ctx : vscode.ExtensionContext) : unit =
    seq { 14000..14040 }
    |> Seq.filter (fun p -> p <> Scanner.assetServerPort)
    |> Scanner.scanPorts 
    |> Observable.subscribe (fun port -> printfn "%i" port)
    |> ctx.subscriptions.Add