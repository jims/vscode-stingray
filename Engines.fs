module Stingray.Engines

open Fable.Core
open Fable.Core.JsInterop

open Fable.Import
open Fable.Import.Node
open Fable.Import.Node.net_types

open System
open System.Collections.Generic

open Stingray

open Helpers

module Scanner =
    let assetServerPort = 14032
    type Host = string * int
    let tryConnect host port timeout : JS.Promise<Host> =
        Promise.create (fun resolve reject ->
            let socket = createNew net.Socket () |> unbox<Socket>
            let res ok = socket.destroy >> (fun () -> if ok then resolve (host, port) else reject (host, port))

            socket.setTimeout(float timeout) 
            socket?on("connect", fun e -> res true) |> ignore
            socket?on("error", fun e -> res false) |> ignore
            socket?connect(createObj [ "host" ==> host; "port" ==> port ]) |> ignore)

    let scanPorts (ports : seq<int>) =
        seq { for p in ports -> tryConnect "localhost" p 1000 }
        |> Promise.allResolved

    type LinkSet = List<Host>
    type RunningEngines () =
        let observers = List<IObserver<LinkSet>>()
        let mutable connections = LinkSet()
        let iter f = observers |> Seq.iter f
        let emit (o : IObserver<LinkSet>) = o.OnNext connections
        let timer = new System.Timers.Timer(1000.0)
        let poll() =
            seq { 14000..14040 }
            |> Seq.filter (fun p -> p <> assetServerPort)
            |> scanPorts
            |> Promise.onSuccess (fun hosts ->
                let diff = Set.difference (Set.ofSeq connections) (Set.ofSeq hosts)
                if diff.Count > 0 then
                    connections <- hosts
                    iter emit)
            |> ignore

        do
            timer.Elapsed
            |> Event.add (fun _ -> if observers.Count > 0 then poll())
            timer.Start()

        interface IDisposable with
            member x.Dispose() =
                iter (fun o -> o.OnCompleted())
                //timer.Dispose() // Cannot find replacement for System.ComponentModel.Component.Dispose

        interface IObservable<LinkSet> with
            member x.Subscribe(obs : IObserver<LinkSet>) =
                observers.Add obs
                emit obs
                { new IDisposable with
                    member x.Dispose() = (observers.Remove obs) |> ignore }
let runningEngines = new Scanner.RunningEngines()
let activate (ctx : vscode.ExtensionContext) : unit =
    runningEngines
    |> Observable.subscribe (fun hosts -> (printfn "%A" hosts))
    |> ctx.subscriptions.Add