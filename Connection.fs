module Stingray.Connection

open Fable.Core

open Fable.Import
open Fable.Import.Browser

type Link =
    inherit WebSocket

let ``open`` (host : string) (port : int) : Link =
    let connection = WebSocket.Create(sprintf "ws://%s:%d" host port) :?> Link
    connection

