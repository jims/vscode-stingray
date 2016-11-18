module Stingray.Connection

open Fable.Core

open Fable.Import
open Fable.Import.Browser

type Link =
    | Open of WebSocket
    | Closed of string * int


let ``open`` (host : string) (port : int) =
    let connection = WebSocket.Create("hejsan")
    connection

