module Stingray.Decoder

open Fable.Core
open Fable.Core.JsInterop

type Result<'a, 'b> =
    | Ok of 'a
    | Err of 'b

module Result =
    let map fn res =
        match res with
        | Ok(a) -> Ok(fn a)
        | Err(e) -> Err(e)

    let map2 fn ra rb =
        match (ra, rb) with
        | (Ok a, Ok b) -> Ok(fn a b)
        | (Err e, _) -> Err(e)
        | (_, Err e) -> Err(e)

    let bind fn res =
        match res with
        | Ok(a) -> fn a
        | Err(e) -> Err(e)

    let withDefault def res =
        match res with
        | Ok(a) -> a
        | _ -> def

type DecodeError = string
type DecodeResult<'a> = Result<'a, DecodeError>
type Decoder<'a> = obj -> DecodeResult<'a>

module Decode =
    [<Emit("typeof($0)")>]
    let jstypeof a : string = jsNative

    let primitiveType<'a> test obj =
        if (test obj)
        then Ok (unbox<'a> obj)
        else Err (sprintf "expected a string")

    let string<'a> = primitiveType<System.String> (jstypeof >> ((=) "string"))
    let int<'a> = primitiveType<int> (jstypeof >> ((=) "number"))
    let float<'a> = primitiveType<float> (jstypeof >> ((=) "number"))
    let bool<'a> = primitiveType<bool> (jstypeof >> ((=) "bool"))

    let field (a : string) (b : Decoder<'a>) : Decoder<'a> = fun obj ->
        match unbox<'a option>(obj?(a)) with
        | Some(value) -> b value
        | None -> Err (sprintf "object has no key '%s'" a)

    let index (i : int) (b : Decoder<'a>) : Decoder<'a> = fun obj ->
        match unbox<'a option>(b obj?(i)) with
        | Some(value) -> Ok(value)
        | None -> Err (sprintf "array index out of bounds '%i'" i)

    let at (path : string list) (b : Decoder<'a>) = List.foldBack field path b

    let fail (err : string) : Decoder<'a> = fun _ -> Err err

    let maybe (a : Decoder<'a>) : Decoder<'a option> = fun obj ->
        match (a obj) with
        | Ok v -> Ok (Some v)
        | Err _ -> Ok (None)
    let map (fn : 'a -> 'value) (a : Decoder<'a>) = fun obj -> Result.map fn (a obj)

    let map2 (fn : 'a -> 'b -> 'value) (a : Decoder<'a>) (b : Decoder<'b>) = fun obj -> Result.map2 fn (a obj) (b obj)

    let bind (fn : 'a -> Decoder<'b>) (a : Decoder<'a>) = fun obj ->
        match (a obj) with
        | Ok res -> (fn res) obj
        | Err e -> Err e

    let succeed a : Decoder<'a> = fun _ -> Ok a
    let (>>=) = bind

    let (:=) = field

    let decodeObject (decoder : Decoder<'a>) (obj : obj) =
        decoder obj

    type DecoderBuilder() =
        member x.Bind(a, fn) = bind fn a
        member x.Return a = succeed a
        member x.ReturnFrom a = a 

    let decode = DecoderBuilder()