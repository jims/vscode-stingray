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

let tryConnect host port timeout : JS.Promise<int> =
    Promise.create (fun resolve reject ->
        let socket = createNew net.Socket |> unbox<Socket> 
        socket.setTimeout(float timeout)
        socket?on("connect", fun _ -> resolve port) |> ignore
        socket?on("error", reject) |> ignore
        socket.connect(host, None |> unbox))
    
let scanPorts (pstart : int) (pend : int) = seq {
    for p in pstart .. pend do
        

    yield 2
}

type Host = string * int
let runningEngines =
    let subject = Event<Host>()
    subject.Trigger(("localhost", 1405))
    