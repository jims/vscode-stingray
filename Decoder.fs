module Stingray.Decoder

open Fable.Core
open Fable.Core.JsInterop

type Result<'a, 'b> =
    | Success of 'a
    | Failure of 'b

type DecodeError = string
type DecodeResult<'a> = Result<'a, DecodeError>
type Decoder<'a> = obj -> DecodeResult<'a>

module Decode =
    [<Emit("typeof($0)")>]
    let jstypeof a : string = jsNative

    let islol a b = (jstypeof a) = b

    let primitiveType<'a> test obj =
        if (test obj)
        then Success (unbox<'a> obj)
        else Failure (sprintf "expected a string")

    let string<'a> = primitiveType<System.String> (fun obj -> (jstypeof obj) = "string")
    let number<'a> = primitiveType<System.Double> ((=) "number")
    //let number<'a> = primitiveType<System.Double> "number

    let (:=) (a : string) (b : Decoder<'a>) = fun obj -> b obj?(a)

    //let (>>=) (a : Decoder<'a>) (b : Decoder<'b>) : Decoder<'a> = ignore