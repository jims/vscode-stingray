namespace Fable.Import
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Error =
    abstract stack: string option with get, set

and [<AllowNullLiteral>] ErrorConstructor =
    abstract stackTraceLimit: float with get, set
    abstract captureStackTrace: targetObject: obj * ?constructorOpt: Function -> unit

and [<AllowNullLiteral>] MapConstructor =
    interface end

and [<AllowNullLiteral>] WeakMapConstructor =
    interface end

and [<AllowNullLiteral>] SetConstructor =
    interface end

and [<AllowNullLiteral>] WeakSetConstructor =
    interface end

and [<AllowNullLiteral>] NodeRequireFunction =
    [<Emit("$0($1...)")>] abstract Invoke: id: string -> obj

and [<AllowNullLiteral>] NodeRequire =
    inherit NodeRequireFunction
    abstract cache: obj with get, set
    abstract extensions: obj with get, set
    abstract main: obj with get, set
    abstract resolve: id: string -> string

and [<AllowNullLiteral>] NodeModule =
    abstract exports: obj with get, set
    abstract require: NodeRequireFunction with get, set
    abstract id: string with get, set
    abstract filename: string with get, set
    abstract loaded: bool with get, set
    abstract parent: obj with get, set
    abstract children: ResizeArray<obj> with get, set

and [<AllowNullLiteral>] SlowBufferType =
    abstract prototype: Buffer with get, set
    [<Emit("new $0($1...)")>] abstract Create: str: string * ?encoding: string -> Buffer
    [<Emit("new $0($1...)")>] abstract Create: size: float -> Buffer
    [<Emit("new $0($1...)")>] abstract Create: size: Uint8Array -> Buffer
    [<Emit("new $0($1...)")>] abstract Create: array: ResizeArray<obj> -> Buffer
    abstract isBuffer: obj: obj -> bool
    abstract byteLength: string: string * ?encoding: string -> float
    abstract concat: list: ResizeArray<Buffer> * ?totalLength: float -> Buffer

and [<AllowNullLiteral>] BufferEncoding =
    (* TODO StringEnum ascii | utf8 | utf16le | ucs2 | binary | hex *) string

and [<AllowNullLiteral>] Buffer =
    inherit NodeBuffer


and [<AllowNullLiteral>] BufferType =
    abstract prototype: Buffer with get, set
    [<Emit("new $0($1...)")>] abstract Create: str: string * ?encoding: string -> Buffer
    [<Emit("new $0($1...)")>] abstract Create: size: float -> Buffer
    [<Emit("new $0($1...)")>] abstract Create: array: Uint8Array -> Buffer
    [<Emit("new $0($1...)")>] abstract Create: arrayBuffer: ArrayBuffer -> Buffer
    [<Emit("new $0($1...)")>] abstract Create: array: ResizeArray<obj> -> Buffer
    [<Emit("new $0($1...)")>] abstract Create: buffer: Buffer -> Buffer
    abstract from: array: ResizeArray<obj> -> Buffer
    abstract from: arrayBuffer: ArrayBuffer * ?byteOffset: float * ?length: float -> Buffer
    abstract from: buffer: Buffer -> Buffer
    abstract from: str: string * ?encoding: string -> Buffer
    abstract isBuffer: obj: obj -> obj
    abstract isEncoding: encoding: string -> bool
    abstract byteLength: string: string * ?encoding: string -> float
    abstract concat: list: ResizeArray<Buffer> * ?totalLength: float -> Buffer
    abstract compare: buf1: Buffer * buf2: Buffer -> float
    abstract alloc: size: float * ?fill: U3<string, Buffer, float> * ?encoding: string -> Buffer
    abstract allocUnsafe: size: float -> Buffer
    abstract allocUnsafeSlow: size: float -> Buffer

and [<AllowNullLiteral>] IterableIterator<'T> =
    interface end

and [<AllowNullLiteral>] NodeBuffer =
    inherit Uint8Array
    abstract write: string: string * ?offset: float * ?length: float * ?encoding: string -> float
    abstract toString: ?encoding: string * ?start: float * ?``end``: float -> string
    abstract toJSON: unit -> obj
    abstract equals: otherBuffer: Buffer -> bool
    abstract compare: otherBuffer: Buffer * ?targetStart: float * ?targetEnd: float * ?sourceStart: float * ?sourceEnd: float -> float
    abstract copy: targetBuffer: Buffer * ?targetStart: float * ?sourceStart: float * ?sourceEnd: float -> float
    abstract slice: ?start: float * ?``end``: float -> Buffer
    abstract writeUIntLE: value: float * offset: float * byteLength: float * ?noAssert: bool -> float
    abstract writeUIntBE: value: float * offset: float * byteLength: float * ?noAssert: bool -> float
    abstract writeIntLE: value: float * offset: float * byteLength: float * ?noAssert: bool -> float
    abstract writeIntBE: value: float * offset: float * byteLength: float * ?noAssert: bool -> float
    abstract readUIntLE: offset: float * byteLength: float * ?noAssert: bool -> float
    abstract readUIntBE: offset: float * byteLength: float * ?noAssert: bool -> float
    abstract readIntLE: offset: float * byteLength: float * ?noAssert: bool -> float
    abstract readIntBE: offset: float * byteLength: float * ?noAssert: bool -> float
    abstract readUInt8: offset: float * ?noAssert: bool -> float
    abstract readUInt16LE: offset: float * ?noAssert: bool -> float
    abstract readUInt16BE: offset: float * ?noAssert: bool -> float
    abstract readUInt32LE: offset: float * ?noAssert: bool -> float
    abstract readUInt32BE: offset: float * ?noAssert: bool -> float
    abstract readInt8: offset: float * ?noAssert: bool -> float
    abstract readInt16LE: offset: float * ?noAssert: bool -> float
    abstract readInt16BE: offset: float * ?noAssert: bool -> float
    abstract readInt32LE: offset: float * ?noAssert: bool -> float
    abstract readInt32BE: offset: float * ?noAssert: bool -> float
    abstract readFloatLE: offset: float * ?noAssert: bool -> float
    abstract readFloatBE: offset: float * ?noAssert: bool -> float
    abstract readDoubleLE: offset: float * ?noAssert: bool -> float
    abstract readDoubleBE: offset: float * ?noAssert: bool -> float
    abstract swap16: unit -> Buffer
    abstract swap32: unit -> Buffer
    abstract swap64: unit -> Buffer
    abstract writeUInt8: value: float * offset: float * ?noAssert: bool -> float
    abstract writeUInt16LE: value: float * offset: float * ?noAssert: bool -> float
    abstract writeUInt16BE: value: float * offset: float * ?noAssert: bool -> float
    abstract writeUInt32LE: value: float * offset: float * ?noAssert: bool -> float
    abstract writeUInt32BE: value: float * offset: float * ?noAssert: bool -> float
    abstract writeInt8: value: float * offset: float * ?noAssert: bool -> float
    abstract writeInt16LE: value: float * offset: float * ?noAssert: bool -> float
    abstract writeInt16BE: value: float * offset: float * ?noAssert: bool -> float
    abstract writeInt32LE: value: float * offset: float * ?noAssert: bool -> float
    abstract writeInt32BE: value: float * offset: float * ?noAssert: bool -> float
    abstract writeFloatLE: value: float * offset: float * ?noAssert: bool -> float
    abstract writeFloatBE: value: float * offset: float * ?noAssert: bool -> float
    abstract writeDoubleLE: value: float * offset: float * ?noAssert: bool -> float
    abstract writeDoubleBE: value: float * offset: float * ?noAssert: bool -> float
    abstract fill: value: obj * ?offset: float * ?``end``: float -> obj
    abstract indexOf: value: U3<string, float, Buffer> * ?byteOffset: float * ?encoding: string -> float
    abstract lastIndexOf: value: U3<string, float, Buffer> * ?byteOffset: float * ?encoding: string -> float
    abstract entries: unit -> IterableIterator<float * float>
    abstract includes: value: U3<string, float, Buffer> * ?byteOffset: float * ?encoding: string -> bool
    abstract keys: unit -> IterableIterator<float>
    abstract values: unit -> IterableIterator<float>

type [<Erase>]Globals =
    [<Global>] static member ``process`` with get(): NodeJS.Process = jsNative and set(v: NodeJS.Process): unit = jsNative
    [<Global>] static member ``global`` with get(): NodeJS.Global = jsNative and set(v: NodeJS.Global): unit = jsNative
    [<Global>] static member ___filename with get(): string = jsNative and set(v: string): unit = jsNative
    [<Global>] static member ___dirname with get(): string = jsNative and set(v: string): unit = jsNative
    [<Global>] static member require with get(): NodeRequire = jsNative and set(v: NodeRequire): unit = jsNative
    [<Global>] static member ``module`` with get(): NodeModule = jsNative and set(v: NodeModule): unit = jsNative
    [<Global>] static member exports with get(): obj = jsNative and set(v: obj): unit = jsNative
    [<Global>] static member SlowBuffer with get(): SlowBufferType = jsNative and set(v: SlowBufferType): unit = jsNative
    [<Global>] static member Buffer with get(): BufferType = jsNative and set(v: BufferType): unit = jsNative

module NodeJS =
    type [<AllowNullLiteral>] ErrnoException =
        inherit Error
        abstract errno: string option with get, set
        abstract code: string option with get, set
        abstract path: string option with get, set
        abstract syscall: string option with get, set
        abstract stack: string option with get, set

    and [<AllowNullLiteral>] [<Import("EventEmitter","NodeJS")>] EventEmitter() =
        member __.addListener(``event``: U2<string, Symbol>, listener: Function): obj = jsNative
        member __.on(``event``: U2<string, Symbol>, listener: Function): obj = jsNative
        member __.once(``event``: U2<string, Symbol>, listener: Function): obj = jsNative
        member __.removeListener(``event``: U2<string, Symbol>, listener: Function): obj = jsNative
        member __.removeAllListeners(?``event``: U2<string, Symbol>): obj = jsNative
        member __.setMaxListeners(n: float): obj = jsNative
        member __.getMaxListeners(): float = jsNative
        member __.listeners(``event``: U2<string, Symbol>): ResizeArray<Function> = jsNative
        member __.emit(``event``: U2<string, Symbol>, [<ParamArray>] args: obj[]): bool = jsNative
        member __.listenerCount(``type``: U2<string, Symbol>): float = jsNative
        member __.prependListener(``event``: U2<string, Symbol>, listener: Function): obj = jsNative
        member __.prependOnceListener(``event``: U2<string, Symbol>, listener: Function): obj = jsNative
        member __.eventNames(): ResizeArray<U2<string, Symbol>> = jsNative

    and [<AllowNullLiteral>] ReadableStream =
        abstract addListener: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract on: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract once: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract removeListener: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract removeAllListeners: ?``event``: U2<string, Symbol> -> obj
        abstract setMaxListeners: n: float -> obj
        abstract getMaxListeners: unit -> float
        abstract listeners: ``event``: U2<string, Symbol> -> ResizeArray<Function>
        abstract emit: ``event``: U2<string, Symbol> * [<ParamArray>] args: obj[] -> bool
        abstract listenerCount: ``type``: U2<string, Symbol> -> float
        abstract prependListener: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract prependOnceListener: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract eventNames: unit -> ResizeArray<U2<string, Symbol>>
        abstract readable: bool with get, set
        abstract read: ?size: float -> U2<string, Buffer>
        abstract setEncoding: encoding: string -> unit
        abstract pause: unit -> ReadableStream
        abstract resume: unit -> ReadableStream
        abstract pipe: destination: 'T * ?options: obj -> 'T
        abstract unpipe: ?destination: 'T -> unit
        abstract unshift: chunk: string -> unit
        abstract unshift: chunk: Buffer -> unit
        abstract wrap: oldStream: ReadableStream -> ReadableStream

    and [<AllowNullLiteral>] WritableStream =
        abstract addListener: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract on: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract once: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract removeListener: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract removeAllListeners: ?``event``: U2<string, Symbol> -> obj
        abstract setMaxListeners: n: float -> obj
        abstract getMaxListeners: unit -> float
        abstract listeners: ``event``: U2<string, Symbol> -> ResizeArray<Function>
        abstract emit: ``event``: U2<string, Symbol> * [<ParamArray>] args: obj[] -> bool
        abstract listenerCount: ``type``: U2<string, Symbol> -> float
        abstract prependListener: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract prependOnceListener: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract eventNames: unit -> ResizeArray<U2<string, Symbol>>
        abstract writable: bool with get, set
        abstract write: buffer: U2<Buffer, string> * ?cb: Function -> bool
        abstract write: str: string * ?encoding: string * ?cb: Function -> bool
        abstract ``end``: unit -> unit
        abstract ``end``: buffer: Buffer * ?cb: Function -> unit
        abstract ``end``: str: string * ?cb: Function -> unit
        abstract ``end``: str: string * ?encoding: string * ?cb: Function -> unit

    and [<AllowNullLiteral>] ReadWriteStream =
        inherit ReadableStream
        inherit WritableStream
        abstract pause: unit -> ReadWriteStream
        abstract resume: unit -> ReadWriteStream

    and [<AllowNullLiteral>] Events =
        abstract addListener: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract on: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract once: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract removeListener: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract removeAllListeners: ?``event``: U2<string, Symbol> -> obj
        abstract setMaxListeners: n: float -> obj
        abstract getMaxListeners: unit -> float
        abstract listeners: ``event``: U2<string, Symbol> -> ResizeArray<Function>
        abstract emit: ``event``: U2<string, Symbol> * [<ParamArray>] args: obj[] -> bool
        abstract listenerCount: ``type``: U2<string, Symbol> -> float
        abstract prependListener: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract prependOnceListener: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract eventNames: unit -> ResizeArray<U2<string, Symbol>>


    and [<AllowNullLiteral>] Domain =
        inherit Events
        abstract run: fn: Function -> unit
        abstract add: emitter: Events -> unit
        abstract remove: emitter: Events -> unit
        abstract bind: cb: Func<Error, obj, obj> -> obj
        abstract intercept: cb: Func<obj, obj> -> obj
        abstract dispose: unit -> unit
        abstract addListener: ``event``: string * listener: Function -> obj
        abstract on: ``event``: string * listener: Function -> obj
        abstract once: ``event``: string * listener: Function -> obj
        abstract removeListener: ``event``: string * listener: Function -> obj
        abstract removeAllListeners: ?``event``: string -> obj

    and [<AllowNullLiteral>] MemoryUsage =
        abstract rss: float with get, set
        abstract heapTotal: float with get, set
        abstract heapUsed: float with get, set

    and [<AllowNullLiteral>] ProcessVersions =
        abstract http_parser: string with get, set
        abstract node: string with get, set
        abstract v8: string with get, set
        abstract ares: string with get, set
        abstract uv: string with get, set
        abstract zlib: string with get, set
        abstract modules: string with get, set
        abstract openssl: string with get, set

    and [<AllowNullLiteral>] Process =
        abstract addListener: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract on: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract once: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract removeListener: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract removeAllListeners: ?``event``: U2<string, Symbol> -> obj
        abstract setMaxListeners: n: float -> obj
        abstract getMaxListeners: unit -> float
        abstract listeners: ``event``: U2<string, Symbol> -> ResizeArray<Function>
        abstract emit: ``event``: U2<string, Symbol> * [<ParamArray>] args: obj[] -> bool
        abstract listenerCount: ``type``: U2<string, Symbol> -> float
        abstract prependListener: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract prependOnceListener: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract eventNames: unit -> ResizeArray<U2<string, Symbol>>
        abstract stdout: WritableStream with get, set
        abstract stderr: WritableStream with get, set
        abstract stdin: ReadableStream with get, set
        abstract argv: ResizeArray<string> with get, set
        abstract argv0: string with get, set
        abstract execArgv: ResizeArray<string> with get, set
        abstract execPath: string with get, set
        abstract env: obj with get, set
        abstract exitCode: float with get, set
        abstract version: string with get, set
        abstract versions: ProcessVersions with get, set
        abstract config: obj with get, set
        abstract pid: float with get, set
        abstract title: string with get, set
        abstract arch: string with get, set
        abstract platform: string with get, set
        abstract domain: Domain with get, set
        abstract connected: bool with get, set
        abstract abort: unit -> unit
        abstract chdir: directory: string -> unit
        abstract cwd: unit -> string
        abstract exit: ?code: float -> unit
        abstract getgid: unit -> float
        abstract setgid: id: float -> unit
        abstract setgid: id: string -> unit
        abstract getuid: unit -> float
        abstract setuid: id: float -> unit
        abstract setuid: id: string -> unit
        abstract kill: pid: float * ?signal: U2<string, float> -> unit
        abstract memoryUsage: unit -> MemoryUsage
        abstract nextTick: callback: Function * [<ParamArray>] args: obj[] -> unit
        abstract umask: ?mask: float -> float
        abstract uptime: unit -> float
        abstract hrtime: ?time: ResizeArray<float> -> ResizeArray<float>
        abstract send: message: obj * ?sendHandle: obj -> unit
        abstract disconnect: unit -> unit

    and [<AllowNullLiteral>] Global =
        abstract Array: obj with get, set
        abstract ArrayBuffer: obj with get, set
        abstract Boolean: obj with get, set
        abstract Buffer: obj with get, set
        abstract DataView: obj with get, set
        abstract Date: obj with get, set
        abstract Error: obj with get, set
        abstract EvalError: obj with get, set
        abstract Float32Array: obj with get, set
        abstract Float64Array: obj with get, set
        abstract Function: obj with get, set
        abstract GLOBAL: Global with get, set
        abstract Infinity: obj with get, set
        abstract Int16Array: obj with get, set
        abstract Int32Array: obj with get, set
        abstract Int8Array: obj with get, set
        abstract Intl: obj with get, set
        abstract JSON: obj with get, set
        abstract Map: MapConstructor with get, set
        abstract Math: obj with get, set
        abstract NaN: obj with get, set
        abstract Number: obj with get, set
        abstract Object: obj with get, set
        abstract Promise: Function with get, set
        abstract RangeError: obj with get, set
        abstract ReferenceError: obj with get, set
        abstract RegExp: obj with get, set
        abstract Set: SetConstructor with get, set
        abstract String: obj with get, set
        abstract Symbol: Function with get, set
        abstract SyntaxError: obj with get, set
        abstract TypeError: obj with get, set
        abstract URIError: obj with get, set
        abstract Uint16Array: obj with get, set
        abstract Uint32Array: obj with get, set
        abstract Uint8Array: obj with get, set
        abstract Uint8ClampedArray: Function with get, set
        abstract WeakMap: WeakMapConstructor with get, set
        abstract WeakSet: WeakSetConstructor with get, set
        abstract clearImmediate: Func<obj, unit> with get, set
        abstract clearInterval: Func<NodeJS.Timer, unit> with get, set
        abstract clearTimeout: Func<NodeJS.Timer, unit> with get, set
        abstract console: obj with get, set
        abstract decodeURI: obj with get, set
        abstract decodeURIComponent: obj with get, set
        abstract encodeURI: obj with get, set
        abstract encodeURIComponent: obj with get, set
        abstract escape: Func<string, string> with get, set
        abstract eval: obj with get, set
        abstract ``global``: Global with get, set
        abstract isFinite: obj with get, set
        abstract isNaN: obj with get, set
        abstract parseFloat: obj with get, set
        abstract parseInt: obj with get, set
        abstract ``process``: Process with get, set
        abstract root: Global with get, set
        abstract setImmediate: Func<Func<obj, unit>, obj, obj> with get, set
        abstract setInterval: Func<Func<obj, unit>, float, obj, NodeJS.Timer> with get, set
        abstract setTimeout: Func<Func<obj, unit>, float, obj, NodeJS.Timer> with get, set
        abstract undefined: obj with get, set
        abstract unescape: Func<string, string> with get, set
        abstract gc: Func<unit, unit> with get, set
        abstract v8debug: obj option with get, set

    and [<AllowNullLiteral>] Timer =
        abstract ref: unit -> unit
        abstract unref: unit -> unit



module buffer =
    type [<Import("*","buffer")>] Globals =
        static member INSPECT_MAX_BYTES with get(): float = jsNative and set(v: float): unit = jsNative
        static member BuffType with get(): obj = jsNative and set(v: obj): unit = jsNative
        static member SlowBuffType with get(): obj = jsNative and set(v: obj): unit = jsNative



module querystring =
    type [<AllowNullLiteral>] StringifyOptions =
        abstract encodeURIComponent: Function option with get, set

    and [<AllowNullLiteral>] ParseOptions =
        abstract maxKeys: float option with get, set
        abstract decodeURIComponent: Function option with get, set

    type [<Import("*","querystring")>] Globals =
        static member stringify(obj: 'T, ?sep: string, ?eq: string, ?options: StringifyOptions): string = jsNative
        static member parse(str: string, ?sep: string, ?eq: string, ?options: ParseOptions): obj = jsNative
        static member parse(str: string, ?sep: string, ?eq: string, ?options: ParseOptions): 'T = jsNative
        static member escape(str: string): string = jsNative
        static member unescape(str: string): string = jsNative



module events =
    type [<AllowNullLiteral>] [<Import("EventEmitter","events")>] EventEmitter() =
        inherit NodeJS.EventEmitter()
        member __.EventEmitter with get(): EventEmitter = jsNative and set(v: EventEmitter): unit = jsNative
        member __.defaultMaxListeners with get(): float = jsNative and set(v: float): unit = jsNative
        static member listenerCount(emitter: EventEmitter, ``event``: U2<string, Symbol>): float = jsNative
        member __.addListener(``event``: U2<string, Symbol>, listener: Function): obj = jsNative
        member __.on(``event``: U2<string, Symbol>, listener: Function): obj = jsNative
        member __.once(``event``: U2<string, Symbol>, listener: Function): obj = jsNative
        member __.prependListener(``event``: U2<string, Symbol>, listener: Function): obj = jsNative
        member __.prependOnceListener(``event``: U2<string, Symbol>, listener: Function): obj = jsNative
        member __.removeListener(``event``: U2<string, Symbol>, listener: Function): obj = jsNative
        member __.removeAllListeners(?``event``: U2<string, Symbol>): obj = jsNative
        member __.setMaxListeners(n: float): obj = jsNative
        member __.getMaxListeners(): float = jsNative
        member __.listeners(``event``: U2<string, Symbol>): ResizeArray<Function> = jsNative
        member __.emit(``event``: U2<string, Symbol>, [<ParamArray>] args: obj[]): bool = jsNative
        member __.eventNames(): ResizeArray<U2<string, Symbol>> = jsNative
        member __.listenerCount(``type``: U2<string, Symbol>): float = jsNative



module http =
    type [<AllowNullLiteral>] RequestOptions =
        abstract protocol: string option with get, set
        abstract host: string option with get, set
        abstract hostname: string option with get, set
        abstract family: float option with get, set
        abstract port: float option with get, set
        abstract localAddress: string option with get, set
        abstract socketPath: string option with get, set
        abstract ``method``: string option with get, set
        abstract path: string option with get, set
        abstract headers: obj option with get, set
        abstract auth: string option with get, set
        abstract agent: U2<Agent, bool> option with get, set

    and [<AllowNullLiteral>] Server =
        inherit net.Server
        abstract maxHeadersCount: float with get, set
        abstract timeout: float with get, set
        abstract listening: bool with get, set
        abstract setTimeout: msecs: float * callback: Function -> unit

    and [<AllowNullLiteral>] ServerRequest =
        inherit IncomingMessage
        abstract connection: net.Socket with get, set

    and [<AllowNullLiteral>] ServerResponse =
        inherit stream.Writable
        abstract statusCode: float with get, set
        abstract statusMessage: string with get, set
        abstract headersSent: bool with get, set
        abstract sendDate: bool with get, set
        abstract finished: bool with get, set
        abstract write: buffer: Buffer -> bool
        abstract write: buffer: Buffer * ?cb: Function -> bool
        abstract write: str: string * ?cb: Function -> bool
        abstract write: str: string * ?encoding: string * ?cb: Function -> bool
        abstract write: str: string * ?encoding: string * ?fd: string -> bool
        abstract writeContinue: unit -> unit
        abstract writeHead: statusCode: float * ?reasonPhrase: string * ?headers: obj -> unit
        abstract writeHead: statusCode: float * ?headers: obj -> unit
        abstract setHeader: name: string * value: U2<string, ResizeArray<string>> -> unit
        abstract setTimeout: msecs: float * callback: Function -> ServerResponse
        abstract getHeader: name: string -> string
        abstract removeHeader: name: string -> unit
        abstract write: chunk: obj * ?encoding: string -> obj
        abstract addTrailers: headers: obj -> unit
        abstract ``end``: unit -> unit
        abstract ``end``: buffer: Buffer * ?cb: Function -> unit
        abstract ``end``: str: string * ?cb: Function -> unit
        abstract ``end``: str: string * ?encoding: string * ?cb: Function -> unit
        abstract ``end``: ?data: obj * ?encoding: string -> unit

    and [<AllowNullLiteral>] ClientRequest =
        inherit stream.Writable
        abstract write: buffer: Buffer -> bool
        abstract write: buffer: Buffer * ?cb: Function -> bool
        abstract write: str: string * ?cb: Function -> bool
        abstract write: str: string * ?encoding: string * ?cb: Function -> bool
        abstract write: str: string * ?encoding: string * ?fd: string -> bool
        abstract write: chunk: obj * ?encoding: string -> unit
        abstract abort: unit -> unit
        abstract setTimeout: timeout: float * ?callback: Function -> unit
        abstract setNoDelay: ?noDelay: bool -> unit
        abstract setSocketKeepAlive: ?enable: bool * ?initialDelay: float -> unit
        abstract setHeader: name: string * value: U2<string, ResizeArray<string>> -> unit
        abstract getHeader: name: string -> string
        abstract removeHeader: name: string -> unit
        abstract addTrailers: headers: obj -> unit
        abstract ``end``: unit -> unit
        abstract ``end``: buffer: Buffer * ?cb: Function -> unit
        abstract ``end``: str: string * ?cb: Function -> unit
        abstract ``end``: str: string * ?encoding: string * ?cb: Function -> unit
        abstract ``end``: ?data: obj * ?encoding: string -> unit

    and [<AllowNullLiteral>] IncomingMessage =
        inherit stream.Readable
        abstract httpVersion: string with get, set
        abstract httpVersionMajor: float with get, set
        abstract httpVersionMinor: float with get, set
        abstract connection: net.Socket with get, set
        abstract headers: obj with get, set
        abstract rawHeaders: ResizeArray<string> with get, set
        abstract trailers: obj with get, set
        abstract rawTrailers: obj with get, set
        abstract ``method``: string option with get, set
        abstract url: string option with get, set
        abstract statusCode: float option with get, set
        abstract statusMessage: string option with get, set
        abstract socket: net.Socket with get, set
        abstract setTimeout: msecs: float * callback: Function -> NodeJS.Timer
        abstract destroy: ?error: Error -> unit

    and [<AllowNullLiteral>] ClientResponse =
        inherit IncomingMessage


    and [<AllowNullLiteral>] AgentOptions =
        abstract keepAlive: bool option with get, set
        abstract keepAliveMsecs: float option with get, set
        abstract maxSockets: float option with get, set
        abstract maxFreeSockets: float option with get, set

    and [<AllowNullLiteral>] [<Import("Agent","http")>] Agent(?opts: AgentOptions) =
        member __.maxSockets with get(): float = jsNative and set(v: float): unit = jsNative
        member __.sockets with get(): obj = jsNative and set(v: obj): unit = jsNative
        member __.requests with get(): obj = jsNative and set(v: obj): unit = jsNative
        member __.destroy(): unit = jsNative

    and [<AllowNullLiteral>] STATUS_CODESType =
        [<Emit("$0[$1]{{=$2}}")>] abstract Item: errorCode: float -> string with get, set
        [<Emit("$0[$1]{{=$2}}")>] abstract Item: errorCode: string -> string with get, set

    type [<Import("*","http")>] Globals =
        static member METHODS with get(): ResizeArray<string> = jsNative and set(v: ResizeArray<string>): unit = jsNative
        static member STATUS_CODES with get(): STATUS_CODESType = jsNative and set(v: STATUS_CODESType): unit = jsNative
        static member globalAgent with get(): Agent = jsNative and set(v: Agent): unit = jsNative
        static member createServer(?requestListener: Func<IncomingMessage, ServerResponse, unit>): Server = jsNative
        static member createClient(?port: float, ?host: string): obj = jsNative
        static member request(options: RequestOptions, ?callback: Func<IncomingMessage, unit>): ClientRequest = jsNative
        static member get(options: obj, ?callback: Func<IncomingMessage, unit>): ClientRequest = jsNative



module cluster =
    type [<AllowNullLiteral>] ClusterSettings =
        abstract execArgv: ResizeArray<string> option with get, set
        abstract exec: string option with get, set
        abstract args: ResizeArray<string> option with get, set
        abstract silent: bool option with get, set
        abstract stdio: ResizeArray<obj> option with get, set
        abstract uid: float option with get, set
        abstract gid: float option with get, set

    and [<AllowNullLiteral>] ClusterSetupMasterSettings =
        abstract exec: string option with get, set
        abstract args: ResizeArray<string> option with get, set
        abstract silent: bool option with get, set
        abstract stdio: ResizeArray<obj> option with get, set

    and [<AllowNullLiteral>] Address =
        abstract address: string with get, set
        abstract port: float with get, set
        abstract addressType: U3<float, obj, obj> with get, set

    and [<AllowNullLiteral>] [<Import("Worker","cluster")>] Worker() =
        inherit events.EventEmitter()
        member __.id with get(): string = jsNative and set(v: string): unit = jsNative
        member __.``process`` with get(): child.ChildProcess = jsNative and set(v: child.ChildProcess): unit = jsNative
        member __.suicide with get(): bool = jsNative and set(v: bool): unit = jsNative
        member __.exitedAfterDisconnect with get(): bool = jsNative and set(v: bool): unit = jsNative
        member __.send(message: obj, ?sendHandle: obj): bool = jsNative
        member __.kill(?signal: string): unit = jsNative
        member __.destroy(?signal: string): unit = jsNative
        member __.disconnect(): unit = jsNative
        member __.isConnected(): bool = jsNative
        member __.isDead(): bool = jsNative
        member __.addListener(``event``: string, listener: Function): obj = jsNative
        [<Emit("$0.addListener('disconnect',$1...)")>] member __.addListener_disconnect(listener: Func<unit, unit>): obj = jsNative
        [<Emit("$0.addListener('error',$1...)")>] member __.addListener_error(listener: Func<float, string, unit>): obj = jsNative
        [<Emit("$0.addListener('exit',$1...)")>] member __.addListener_exit(listener: Func<float, string, unit>): obj = jsNative
        [<Emit("$0.addListener('listening',$1...)")>] member __.addListener_listening(listener: Func<Address, unit>): obj = jsNative
        [<Emit("$0.addListener('message',$1...)")>] member __.addListener_message(listener: Func<obj, U2<net.Socket, net.Server>, unit>): obj = jsNative
        [<Emit("$0.addListener('online',$1...)")>] member __.addListener_online(listener: Func<unit, unit>): obj = jsNative
        member __.emit(``event``: string, listener: Function): bool = jsNative
        [<Emit("$0.emit('disconnect',$1...)")>] member __.emit_disconnect(listener: Func<unit, unit>): bool = jsNative
        [<Emit("$0.emit('error',$1...)")>] member __.emit_error(listener: Func<float, string, unit>): bool = jsNative
        [<Emit("$0.emit('exit',$1...)")>] member __.emit_exit(listener: Func<float, string, unit>): bool = jsNative
        [<Emit("$0.emit('listening',$1...)")>] member __.emit_listening(listener: Func<Address, unit>): bool = jsNative
        [<Emit("$0.emit('message',$1...)")>] member __.emit_message(listener: Func<obj, U2<net.Socket, net.Server>, unit>): bool = jsNative
        [<Emit("$0.emit('online',$1...)")>] member __.emit_online(listener: Func<unit, unit>): bool = jsNative
        member __.on(``event``: string, listener: Function): obj = jsNative
        [<Emit("$0.on('disconnect',$1...)")>] member __.on_disconnect(listener: Func<unit, unit>): obj = jsNative
        [<Emit("$0.on('error',$1...)")>] member __.on_error(listener: Func<float, string, unit>): obj = jsNative
        [<Emit("$0.on('exit',$1...)")>] member __.on_exit(listener: Func<float, string, unit>): obj = jsNative
        [<Emit("$0.on('listening',$1...)")>] member __.on_listening(listener: Func<Address, unit>): obj = jsNative
        [<Emit("$0.on('message',$1...)")>] member __.on_message(listener: Func<obj, U2<net.Socket, net.Server>, unit>): obj = jsNative
        [<Emit("$0.on('online',$1...)")>] member __.on_online(listener: Func<unit, unit>): obj = jsNative
        member __.once(``event``: string, listener: Function): obj = jsNative
        [<Emit("$0.once('disconnect',$1...)")>] member __.once_disconnect(listener: Func<unit, unit>): obj = jsNative
        [<Emit("$0.once('error',$1...)")>] member __.once_error(listener: Func<float, string, unit>): obj = jsNative
        [<Emit("$0.once('exit',$1...)")>] member __.once_exit(listener: Func<float, string, unit>): obj = jsNative
        [<Emit("$0.once('listening',$1...)")>] member __.once_listening(listener: Func<Address, unit>): obj = jsNative
        [<Emit("$0.once('message',$1...)")>] member __.once_message(listener: Func<obj, U2<net.Socket, net.Server>, unit>): obj = jsNative
        [<Emit("$0.once('online',$1...)")>] member __.once_online(listener: Func<unit, unit>): obj = jsNative
        member __.prependListener(``event``: string, listener: Function): obj = jsNative
        [<Emit("$0.prependListener('disconnect',$1...)")>] member __.prependListener_disconnect(listener: Func<unit, unit>): obj = jsNative
        [<Emit("$0.prependListener('error',$1...)")>] member __.prependListener_error(listener: Func<float, string, unit>): obj = jsNative
        [<Emit("$0.prependListener('exit',$1...)")>] member __.prependListener_exit(listener: Func<float, string, unit>): obj = jsNative
        [<Emit("$0.prependListener('listening',$1...)")>] member __.prependListener_listening(listener: Func<Address, unit>): obj = jsNative
        [<Emit("$0.prependListener('message',$1...)")>] member __.prependListener_message(listener: Func<obj, U2<net.Socket, net.Server>, unit>): obj = jsNative
        [<Emit("$0.prependListener('online',$1...)")>] member __.prependListener_online(listener: Func<unit, unit>): obj = jsNative
        member __.prependOnceListener(``event``: string, listener: Function): obj = jsNative
        [<Emit("$0.prependOnceListener('disconnect',$1...)")>] member __.prependOnceListener_disconnect(listener: Func<unit, unit>): obj = jsNative
        [<Emit("$0.prependOnceListener('error',$1...)")>] member __.prependOnceListener_error(listener: Func<float, string, unit>): obj = jsNative
        [<Emit("$0.prependOnceListener('exit',$1...)")>] member __.prependOnceListener_exit(listener: Func<float, string, unit>): obj = jsNative
        [<Emit("$0.prependOnceListener('listening',$1...)")>] member __.prependOnceListener_listening(listener: Func<Address, unit>): obj = jsNative
        [<Emit("$0.prependOnceListener('message',$1...)")>] member __.prependOnceListener_message(listener: Func<obj, U2<net.Socket, net.Server>, unit>): obj = jsNative
        [<Emit("$0.prependOnceListener('online',$1...)")>] member __.prependOnceListener_online(listener: Func<unit, unit>): obj = jsNative

    and [<AllowNullLiteral>] Cluster =
        abstract EventEmitter: EventEmitter with get, set
        abstract defaultMaxListeners: float with get, set
        abstract listenerCount: emitter: EventEmitter * ``event``: U2<string, Symbol> -> float
        abstract addListener: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract on: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract once: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract prependListener: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract prependOnceListener: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract removeListener: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract removeAllListeners: ?``event``: U2<string, Symbol> -> obj
        abstract setMaxListeners: n: float -> obj
        abstract getMaxListeners: unit -> float
        abstract listeners: ``event``: U2<string, Symbol> -> ResizeArray<Function>
        abstract emit: ``event``: U2<string, Symbol> * [<ParamArray>] args: obj[] -> bool
        abstract eventNames: unit -> ResizeArray<U2<string, Symbol>>
        abstract listenerCount: ``type``: U2<string, Symbol> -> float
        abstract Worker: Worker with get, set
        abstract isMaster: bool with get, set
        abstract isWorker: bool with get, set
        abstract settings: ClusterSettings with get, set
        abstract worker: Worker with get, set
        abstract workers: obj with get, set
        abstract disconnect: ?callback: Function -> unit
        abstract fork: ?env: obj -> Worker
        abstract setupMaster: ?settings: ClusterSetupMasterSettings -> unit
        abstract addListener: ``event``: string * listener: Function -> obj
        [<Emit("$0.addListener('disconnect',$1...)")>] abstract addListener_disconnect: listener: Func<Worker, unit> -> obj
        [<Emit("$0.addListener('exit',$1...)")>] abstract addListener_exit: listener: Func<Worker, float, string, unit> -> obj
        [<Emit("$0.addListener('fork',$1...)")>] abstract addListener_fork: listener: Func<Worker, unit> -> obj
        [<Emit("$0.addListener('listening',$1...)")>] abstract addListener_listening: listener: Func<Worker, Address, unit> -> obj
        [<Emit("$0.addListener('message',$1...)")>] abstract addListener_message: listener: Func<Worker, obj, U2<net.Socket, net.Server>, unit> -> obj
        [<Emit("$0.addListener('online',$1...)")>] abstract addListener_online: listener: Func<Worker, unit> -> obj
        [<Emit("$0.addListener('setup',$1...)")>] abstract addListener_setup: listener: Func<obj, unit> -> obj
        abstract emit: ``event``: string * listener: Function -> bool
        [<Emit("$0.emit('disconnect',$1...)")>] abstract emit_disconnect: listener: Func<Worker, unit> -> bool
        [<Emit("$0.emit('exit',$1...)")>] abstract emit_exit: listener: Func<Worker, float, string, unit> -> bool
        [<Emit("$0.emit('fork',$1...)")>] abstract emit_fork: listener: Func<Worker, unit> -> bool
        [<Emit("$0.emit('listening',$1...)")>] abstract emit_listening: listener: Func<Worker, Address, unit> -> bool
        [<Emit("$0.emit('message',$1...)")>] abstract emit_message: listener: Func<Worker, obj, U2<net.Socket, net.Server>, unit> -> bool
        [<Emit("$0.emit('online',$1...)")>] abstract emit_online: listener: Func<Worker, unit> -> bool
        [<Emit("$0.emit('setup',$1...)")>] abstract emit_setup: listener: Func<obj, unit> -> bool
        abstract on: ``event``: string * listener: Function -> obj
        [<Emit("$0.on('disconnect',$1...)")>] abstract on_disconnect: listener: Func<Worker, unit> -> obj
        [<Emit("$0.on('exit',$1...)")>] abstract on_exit: listener: Func<Worker, float, string, unit> -> obj
        [<Emit("$0.on('fork',$1...)")>] abstract on_fork: listener: Func<Worker, unit> -> obj
        [<Emit("$0.on('listening',$1...)")>] abstract on_listening: listener: Func<Worker, Address, unit> -> obj
        [<Emit("$0.on('message',$1...)")>] abstract on_message: listener: Func<Worker, obj, U2<net.Socket, net.Server>, unit> -> obj
        [<Emit("$0.on('online',$1...)")>] abstract on_online: listener: Func<Worker, unit> -> obj
        [<Emit("$0.on('setup',$1...)")>] abstract on_setup: listener: Func<obj, unit> -> obj
        abstract once: ``event``: string * listener: Function -> obj
        [<Emit("$0.once('disconnect',$1...)")>] abstract once_disconnect: listener: Func<Worker, unit> -> obj
        [<Emit("$0.once('exit',$1...)")>] abstract once_exit: listener: Func<Worker, float, string, unit> -> obj
        [<Emit("$0.once('fork',$1...)")>] abstract once_fork: listener: Func<Worker, unit> -> obj
        [<Emit("$0.once('listening',$1...)")>] abstract once_listening: listener: Func<Worker, Address, unit> -> obj
        [<Emit("$0.once('message',$1...)")>] abstract once_message: listener: Func<Worker, obj, U2<net.Socket, net.Server>, unit> -> obj
        [<Emit("$0.once('online',$1...)")>] abstract once_online: listener: Func<Worker, unit> -> obj
        [<Emit("$0.once('setup',$1...)")>] abstract once_setup: listener: Func<obj, unit> -> obj
        abstract prependListener: ``event``: string * listener: Function -> obj
        [<Emit("$0.prependListener('disconnect',$1...)")>] abstract prependListener_disconnect: listener: Func<Worker, unit> -> obj
        [<Emit("$0.prependListener('exit',$1...)")>] abstract prependListener_exit: listener: Func<Worker, float, string, unit> -> obj
        [<Emit("$0.prependListener('fork',$1...)")>] abstract prependListener_fork: listener: Func<Worker, unit> -> obj
        [<Emit("$0.prependListener('listening',$1...)")>] abstract prependListener_listening: listener: Func<Worker, Address, unit> -> obj
        [<Emit("$0.prependListener('message',$1...)")>] abstract prependListener_message: listener: Func<Worker, obj, U2<net.Socket, net.Server>, unit> -> obj
        [<Emit("$0.prependListener('online',$1...)")>] abstract prependListener_online: listener: Func<Worker, unit> -> obj
        [<Emit("$0.prependListener('setup',$1...)")>] abstract prependListener_setup: listener: Func<obj, unit> -> obj
        abstract prependOnceListener: ``event``: string * listener: Function -> obj
        [<Emit("$0.prependOnceListener('disconnect',$1...)")>] abstract prependOnceListener_disconnect: listener: Func<Worker, unit> -> obj
        [<Emit("$0.prependOnceListener('exit',$1...)")>] abstract prependOnceListener_exit: listener: Func<Worker, float, string, unit> -> obj
        [<Emit("$0.prependOnceListener('fork',$1...)")>] abstract prependOnceListener_fork: listener: Func<Worker, unit> -> obj
        [<Emit("$0.prependOnceListener('listening',$1...)")>] abstract prependOnceListener_listening: listener: Func<Worker, Address, unit> -> obj
        [<Emit("$0.prependOnceListener('message',$1...)")>] abstract prependOnceListener_message: listener: Func<Worker, obj, U2<net.Socket, net.Server>, unit> -> obj
        [<Emit("$0.prependOnceListener('online',$1...)")>] abstract prependOnceListener_online: listener: Func<Worker, unit> -> obj
        [<Emit("$0.prependOnceListener('setup',$1...)")>] abstract prependOnceListener_setup: listener: Func<obj, unit> -> obj

    and [<AllowNullLiteral>] workersType =
        [<Emit("$0[$1]{{=$2}}")>] abstract Item: index: string -> Worker with get, set

    type [<Import("*","cluster")>] Globals =
        static member isMaster with get(): bool = jsNative and set(v: bool): unit = jsNative
        static member isWorker with get(): bool = jsNative and set(v: bool): unit = jsNative
        static member settings with get(): ClusterSettings = jsNative and set(v: ClusterSettings): unit = jsNative
        static member worker with get(): Worker = jsNative and set(v: Worker): unit = jsNative
        static member workers with get(): workersType = jsNative and set(v: workersType): unit = jsNative
        static member disconnect(?callback: Function): unit = jsNative
        static member fork(?env: obj): Worker = jsNative
        static member setupMaster(?settings: ClusterSetupMasterSettings): unit = jsNative
        static member addListener(``event``: string, listener: Function): Cluster = jsNative
        [<Emit("$0.addListener('disconnect',$1...)")>] static member addListener_disconnect(listener: Func<Worker, unit>): Cluster = jsNative
        [<Emit("$0.addListener('exit',$1...)")>] static member addListener_exit(listener: Func<Worker, float, string, unit>): Cluster = jsNative
        [<Emit("$0.addListener('fork',$1...)")>] static member addListener_fork(listener: Func<Worker, unit>): Cluster = jsNative
        [<Emit("$0.addListener('listening',$1...)")>] static member addListener_listening(listener: Func<Worker, Address, unit>): Cluster = jsNative
        [<Emit("$0.addListener('message',$1...)")>] static member addListener_message(listener: Func<Worker, obj, U2<net.Socket, net.Server>, unit>): Cluster = jsNative
        [<Emit("$0.addListener('online',$1...)")>] static member addListener_online(listener: Func<Worker, unit>): Cluster = jsNative
        [<Emit("$0.addListener('setup',$1...)")>] static member addListener_setup(listener: Func<obj, unit>): Cluster = jsNative
        static member emit(``event``: string, listener: Function): bool = jsNative
        [<Emit("$0.emit('disconnect',$1...)")>] static member emit_disconnect(listener: Func<Worker, unit>): bool = jsNative
        [<Emit("$0.emit('exit',$1...)")>] static member emit_exit(listener: Func<Worker, float, string, unit>): bool = jsNative
        [<Emit("$0.emit('fork',$1...)")>] static member emit_fork(listener: Func<Worker, unit>): bool = jsNative
        [<Emit("$0.emit('listening',$1...)")>] static member emit_listening(listener: Func<Worker, Address, unit>): bool = jsNative
        [<Emit("$0.emit('message',$1...)")>] static member emit_message(listener: Func<Worker, obj, U2<net.Socket, net.Server>, unit>): bool = jsNative
        [<Emit("$0.emit('online',$1...)")>] static member emit_online(listener: Func<Worker, unit>): bool = jsNative
        [<Emit("$0.emit('setup',$1...)")>] static member emit_setup(listener: Func<obj, unit>): bool = jsNative
        static member on(``event``: string, listener: Function): Cluster = jsNative
        [<Emit("$0.on('disconnect',$1...)")>] static member on_disconnect(listener: Func<Worker, unit>): Cluster = jsNative
        [<Emit("$0.on('exit',$1...)")>] static member on_exit(listener: Func<Worker, float, string, unit>): Cluster = jsNative
        [<Emit("$0.on('fork',$1...)")>] static member on_fork(listener: Func<Worker, unit>): Cluster = jsNative
        [<Emit("$0.on('listening',$1...)")>] static member on_listening(listener: Func<Worker, Address, unit>): Cluster = jsNative
        [<Emit("$0.on('message',$1...)")>] static member on_message(listener: Func<Worker, obj, U2<net.Socket, net.Server>, unit>): Cluster = jsNative
        [<Emit("$0.on('online',$1...)")>] static member on_online(listener: Func<Worker, unit>): Cluster = jsNative
        [<Emit("$0.on('setup',$1...)")>] static member on_setup(listener: Func<obj, unit>): Cluster = jsNative
        static member once(``event``: string, listener: Function): Cluster = jsNative
        [<Emit("$0.once('disconnect',$1...)")>] static member once_disconnect(listener: Func<Worker, unit>): Cluster = jsNative
        [<Emit("$0.once('exit',$1...)")>] static member once_exit(listener: Func<Worker, float, string, unit>): Cluster = jsNative
        [<Emit("$0.once('fork',$1...)")>] static member once_fork(listener: Func<Worker, unit>): Cluster = jsNative
        [<Emit("$0.once('listening',$1...)")>] static member once_listening(listener: Func<Worker, Address, unit>): Cluster = jsNative
        [<Emit("$0.once('message',$1...)")>] static member once_message(listener: Func<Worker, obj, U2<net.Socket, net.Server>, unit>): Cluster = jsNative
        [<Emit("$0.once('online',$1...)")>] static member once_online(listener: Func<Worker, unit>): Cluster = jsNative
        [<Emit("$0.once('setup',$1...)")>] static member once_setup(listener: Func<obj, unit>): Cluster = jsNative
        static member removeListener(``event``: string, listener: Function): Cluster = jsNative
        static member removeAllListeners(?``event``: string): Cluster = jsNative
        static member setMaxListeners(n: float): Cluster = jsNative
        static member getMaxListeners(): float = jsNative
        static member listeners(``event``: string): ResizeArray<Function> = jsNative
        static member listenerCount(``type``: string): float = jsNative
        static member prependListener(``event``: string, listener: Function): Cluster = jsNative
        [<Emit("$0.prependListener('disconnect',$1...)")>] static member prependListener_disconnect(listener: Func<Worker, unit>): Cluster = jsNative
        [<Emit("$0.prependListener('exit',$1...)")>] static member prependListener_exit(listener: Func<Worker, float, string, unit>): Cluster = jsNative
        [<Emit("$0.prependListener('fork',$1...)")>] static member prependListener_fork(listener: Func<Worker, unit>): Cluster = jsNative
        [<Emit("$0.prependListener('listening',$1...)")>] static member prependListener_listening(listener: Func<Worker, Address, unit>): Cluster = jsNative
        [<Emit("$0.prependListener('message',$1...)")>] static member prependListener_message(listener: Func<Worker, obj, U2<net.Socket, net.Server>, unit>): Cluster = jsNative
        [<Emit("$0.prependListener('online',$1...)")>] static member prependListener_online(listener: Func<Worker, unit>): Cluster = jsNative
        [<Emit("$0.prependListener('setup',$1...)")>] static member prependListener_setup(listener: Func<obj, unit>): Cluster = jsNative
        static member prependOnceListener(``event``: string, listener: Function): Cluster = jsNative
        [<Emit("$0.prependOnceListener('disconnect',$1...)")>] static member prependOnceListener_disconnect(listener: Func<Worker, unit>): Cluster = jsNative
        [<Emit("$0.prependOnceListener('exit',$1...)")>] static member prependOnceListener_exit(listener: Func<Worker, float, string, unit>): Cluster = jsNative
        [<Emit("$0.prependOnceListener('fork',$1...)")>] static member prependOnceListener_fork(listener: Func<Worker, unit>): Cluster = jsNative
        [<Emit("$0.prependOnceListener('listening',$1...)")>] static member prependOnceListener_listening(listener: Func<Worker, Address, unit>): Cluster = jsNative
        [<Emit("$0.prependOnceListener('message',$1...)")>] static member prependOnceListener_message(listener: Func<Worker, obj, U2<net.Socket, net.Server>, unit>): Cluster = jsNative
        [<Emit("$0.prependOnceListener('online',$1...)")>] static member prependOnceListener_online(listener: Func<Worker, unit>): Cluster = jsNative
        [<Emit("$0.prependOnceListener('setup',$1...)")>] static member prependOnceListener_setup(listener: Func<obj, unit>): Cluster = jsNative
        static member eventNames(): ResizeArray<string> = jsNative



module zlib =
    type [<AllowNullLiteral>] ZlibOptions =
        abstract chunkSize: float option with get, set
        abstract windowBits: float option with get, set
        abstract level: float option with get, set
        abstract memLevel: float option with get, set
        abstract strategy: float option with get, set
        abstract dictionary: obj option with get, set

    and [<AllowNullLiteral>] Gzip =
        inherit stream.Transform


    and [<AllowNullLiteral>] Gunzip =
        inherit stream.Transform


    and [<AllowNullLiteral>] Deflate =
        inherit stream.Transform


    and [<AllowNullLiteral>] Inflate =
        inherit stream.Transform


    and [<AllowNullLiteral>] DeflateRaw =
        inherit stream.Transform


    and [<AllowNullLiteral>] InflateRaw =
        inherit stream.Transform


    and [<AllowNullLiteral>] Unzip =
        inherit stream.Transform


    type [<Import("*","zlib")>] Globals =
        static member Z_NO_FLUSH with get(): float = jsNative and set(v: float): unit = jsNative
        static member Z_PARTIAL_FLUSH with get(): float = jsNative and set(v: float): unit = jsNative
        static member Z_SYNC_FLUSH with get(): float = jsNative and set(v: float): unit = jsNative
        static member Z_FULL_FLUSH with get(): float = jsNative and set(v: float): unit = jsNative
        static member Z_FINISH with get(): float = jsNative and set(v: float): unit = jsNative
        static member Z_BLOCK with get(): float = jsNative and set(v: float): unit = jsNative
        static member Z_TREES with get(): float = jsNative and set(v: float): unit = jsNative
        static member Z_OK with get(): float = jsNative and set(v: float): unit = jsNative
        static member Z_STREAM_END with get(): float = jsNative and set(v: float): unit = jsNative
        static member Z_NEED_DICT with get(): float = jsNative and set(v: float): unit = jsNative
        static member Z_ERRNO with get(): float = jsNative and set(v: float): unit = jsNative
        static member Z_STREAM_ERROR with get(): float = jsNative and set(v: float): unit = jsNative
        static member Z_DATA_ERROR with get(): float = jsNative and set(v: float): unit = jsNative
        static member Z_MEM_ERROR with get(): float = jsNative and set(v: float): unit = jsNative
        static member Z_BUF_ERROR with get(): float = jsNative and set(v: float): unit = jsNative
        static member Z_VERSION_ERROR with get(): float = jsNative and set(v: float): unit = jsNative
        static member Z_NO_COMPRESSION with get(): float = jsNative and set(v: float): unit = jsNative
        static member Z_BEST_SPEED with get(): float = jsNative and set(v: float): unit = jsNative
        static member Z_BEST_COMPRESSION with get(): float = jsNative and set(v: float): unit = jsNative
        static member Z_DEFAULT_COMPRESSION with get(): float = jsNative and set(v: float): unit = jsNative
        static member Z_FILTERED with get(): float = jsNative and set(v: float): unit = jsNative
        static member Z_HUFFMAN_ONLY with get(): float = jsNative and set(v: float): unit = jsNative
        static member Z_RLE with get(): float = jsNative and set(v: float): unit = jsNative
        static member Z_FIXED with get(): float = jsNative and set(v: float): unit = jsNative
        static member Z_DEFAULT_STRATEGY with get(): float = jsNative and set(v: float): unit = jsNative
        static member Z_BINARY with get(): float = jsNative and set(v: float): unit = jsNative
        static member Z_TEXT with get(): float = jsNative and set(v: float): unit = jsNative
        static member Z_ASCII with get(): float = jsNative and set(v: float): unit = jsNative
        static member Z_UNKNOWN with get(): float = jsNative and set(v: float): unit = jsNative
        static member Z_DEFLATED with get(): float = jsNative and set(v: float): unit = jsNative
        static member Z_NULL with get(): float = jsNative and set(v: float): unit = jsNative
        static member createGzip(?options: ZlibOptions): Gzip = jsNative
        static member createGunzip(?options: ZlibOptions): Gunzip = jsNative
        static member createDeflate(?options: ZlibOptions): Deflate = jsNative
        static member createInflate(?options: ZlibOptions): Inflate = jsNative
        static member createDeflateRaw(?options: ZlibOptions): DeflateRaw = jsNative
        static member createInflateRaw(?options: ZlibOptions): InflateRaw = jsNative
        static member createUnzip(?options: ZlibOptions): Unzip = jsNative
        static member deflate(buf: Buffer, callback: Func<Error, obj, unit>): unit = jsNative
        static member deflateSync(buf: Buffer, ?options: ZlibOptions): obj = jsNative
        static member deflateRaw(buf: Buffer, callback: Func<Error, obj, unit>): unit = jsNative
        static member deflateRawSync(buf: Buffer, ?options: ZlibOptions): obj = jsNative
        static member gzip(buf: Buffer, callback: Func<Error, obj, unit>): unit = jsNative
        static member gzipSync(buf: Buffer, ?options: ZlibOptions): obj = jsNative
        static member gunzip(buf: Buffer, callback: Func<Error, obj, unit>): unit = jsNative
        static member gunzipSync(buf: Buffer, ?options: ZlibOptions): obj = jsNative
        static member inflate(buf: Buffer, callback: Func<Error, obj, unit>): unit = jsNative
        static member inflateSync(buf: Buffer, ?options: ZlibOptions): obj = jsNative
        static member inflateRaw(buf: Buffer, callback: Func<Error, obj, unit>): unit = jsNative
        static member inflateRawSync(buf: Buffer, ?options: ZlibOptions): obj = jsNative
        static member unzip(buf: Buffer, callback: Func<Error, obj, unit>): unit = jsNative
        static member unzipSync(buf: Buffer, ?options: ZlibOptions): obj = jsNative



module os =
    type [<AllowNullLiteral>] CpuInfo =
        abstract model: string with get, set
        abstract speed: float with get, set
        abstract times: obj with get, set

    and [<AllowNullLiteral>] NetworkInterfaceInfo =
        abstract address: string with get, set
        abstract netmask: string with get, set
        abstract family: string with get, set
        abstract mac: string with get, set
        abstract ``internal``: bool with get, set

    and [<AllowNullLiteral>] constantsType =
        abstract UV_UDP_REUSEADDR: float with get, set
        abstract errno: obj with get, set
        abstract signals: obj with get, set

    type [<Import("*","os")>] Globals =
        static member constants with get(): constantsType = jsNative and set(v: constantsType): unit = jsNative
        static member EOL with get(): string = jsNative and set(v: string): unit = jsNative
        static member hostname(): string = jsNative
        static member loadavg(): ResizeArray<float> = jsNative
        static member uptime(): float = jsNative
        static member freemem(): float = jsNative
        static member totalmem(): float = jsNative
        static member cpus(): ResizeArray<CpuInfo> = jsNative
        static member ``type``(): string = jsNative
        static member release(): string = jsNative
        static member networkInterfaces(): obj = jsNative
        static member homedir(): string = jsNative
        static member userInfo(?options: obj): obj = jsNative
        static member arch(): string = jsNative
        static member platform(): string = jsNative
        static member tmpdir(): string = jsNative
        static member endianness(): (* TODO StringEnum BE | LE *) string = jsNative



module https =
    type [<AllowNullLiteral>] ServerOptions =
        abstract pfx: obj option with get, set
        abstract key: obj option with get, set
        abstract passphrase: string option with get, set
        abstract cert: obj option with get, set
        abstract ca: obj option with get, set
        abstract crl: obj option with get, set
        abstract ciphers: string option with get, set
        abstract honorCipherOrder: bool option with get, set
        abstract requestCert: bool option with get, set
        abstract rejectUnauthorized: bool option with get, set
        abstract NPNProtocols: obj option with get, set
        abstract SNICallback: Func<string, Func<Error, tls.SecureContext, obj>, obj> option with get, set

    and [<AllowNullLiteral>] RequestOptions =
        inherit http.RequestOptions
        abstract pfx: obj option with get, set
        abstract key: obj option with get, set
        abstract passphrase: string option with get, set
        abstract cert: obj option with get, set
        abstract ca: obj option with get, set
        abstract ciphers: string option with get, set
        abstract rejectUnauthorized: bool option with get, set
        abstract secureProtocol: string option with get, set

    and [<AllowNullLiteral>] Agent =
        abstract maxSockets: float with get, set
        abstract sockets: obj with get, set
        abstract requests: obj with get, set
        abstract destroy: unit -> unit


    and [<AllowNullLiteral>] AgentOptions =
        inherit http.AgentOptions
        abstract pfx: obj option with get, set
        abstract key: obj option with get, set
        abstract passphrase: string option with get, set
        abstract cert: obj option with get, set
        abstract ca: obj option with get, set
        abstract ciphers: string option with get, set
        abstract rejectUnauthorized: bool option with get, set
        abstract secureProtocol: string option with get, set
        abstract maxCachedSessions: float option with get, set

    and [<AllowNullLiteral>] AgentType =
        [<Emit("new $0($1...)")>] abstract Create: ?options: AgentOptions -> Agent

    and [<AllowNullLiteral>] Server =
        inherit tls.Server


    type [<Import("*","https")>] Globals =
        static member Agent with get(): AgentType = jsNative and set(v: AgentType): unit = jsNative
        static member globalAgent with get(): Agent = jsNative and set(v: Agent): unit = jsNative
        static member createServer(options: ServerOptions, ?requestListener: Function): Server = jsNative
        static member request(options: RequestOptions, ?callback: Func<http.IncomingMessage, unit>): http.ClientRequest = jsNative
        static member get(options: RequestOptions, ?callback: Func<http.IncomingMessage, unit>): http.ClientRequest = jsNative



module punycode =
    type [<AllowNullLiteral>] ucs2 =
        abstract decode: string: string -> ResizeArray<float>
        abstract encode: codePoints: ResizeArray<float> -> string

    type [<Import("*","punycode")>] Globals =
        static member ucs2 with get(): ucs2 = jsNative and set(v: ucs2): unit = jsNative
        static member version with get(): obj = jsNative and set(v: obj): unit = jsNative
        static member decode(string: string): string = jsNative
        static member encode(string: string): string = jsNative
        static member toUnicode(domain: string): string = jsNative
        static member toASCII(domain: string): string = jsNative



module repl =
    type [<AllowNullLiteral>] ReplOptions =
        abstract prompt: string option with get, set
        abstract input: NodeJS.ReadableStream option with get, set
        abstract output: NodeJS.WritableStream option with get, set
        abstract terminal: bool option with get, set
        abstract eval: Function option with get, set
        abstract useColors: bool option with get, set
        abstract useGlobal: bool option with get, set
        abstract ignoreUndefined: bool option with get, set
        abstract writer: Function option with get, set
        abstract completer: Function option with get, set
        abstract replMode: obj option with get, set
        abstract breakEvalOnSigint: obj option with get, set

    and [<AllowNullLiteral>] REPLServer =
        inherit readline.ReadLine
        abstract defineCommand: keyword: string * cmd: U2<Function, obj> -> unit
        abstract displayPrompt: ?preserveCursor: bool -> unit

    type [<Import("*","repl")>] Globals =
        static member start(options: ReplOptions): REPLServer = jsNative



module readline =
    type [<AllowNullLiteral>] Key =
        abstract sequence: string option with get, set
        abstract name: string option with get, set
        abstract ctrl: bool option with get, set
        abstract meta: bool option with get, set
        abstract shift: bool option with get, set

    and [<AllowNullLiteral>] ReadLine =
        abstract EventEmitter: EventEmitter with get, set
        abstract defaultMaxListeners: float with get, set
        abstract listenerCount: emitter: EventEmitter * ``event``: U2<string, Symbol> -> float
        abstract addListener: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract on: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract once: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract prependListener: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract prependOnceListener: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract removeListener: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract removeAllListeners: ?``event``: U2<string, Symbol> -> obj
        abstract setMaxListeners: n: float -> obj
        abstract getMaxListeners: unit -> float
        abstract listeners: ``event``: U2<string, Symbol> -> ResizeArray<Function>
        abstract emit: ``event``: U2<string, Symbol> * [<ParamArray>] args: obj[] -> bool
        abstract eventNames: unit -> ResizeArray<U2<string, Symbol>>
        abstract listenerCount: ``type``: U2<string, Symbol> -> float
        abstract setPrompt: prompt: string -> unit
        abstract prompt: ?preserveCursor: bool -> unit
        abstract question: query: string * callback: Func<string, unit> -> unit
        abstract pause: unit -> ReadLine
        abstract resume: unit -> ReadLine
        abstract close: unit -> unit
        abstract write: data: U2<string, Buffer> * ?key: Key -> unit

    and [<AllowNullLiteral>] Completer =
        [<Emit("$0($1...)")>] abstract Invoke: line: string -> CompleterResult
        [<Emit("$0($1...)")>] abstract Invoke: line: string * callback: Func<obj, CompleterResult, unit> -> obj

    and [<AllowNullLiteral>] CompleterResult =
        abstract completions: ResizeArray<string> with get, set
        abstract line: string with get, set

    and [<AllowNullLiteral>] ReadLineOptions =
        abstract input: NodeJS.ReadableStream with get, set
        abstract output: NodeJS.WritableStream option with get, set
        abstract completer: Completer option with get, set
        abstract terminal: bool option with get, set
        abstract historySize: float option with get, set

    type [<Import("*","readline")>] Globals =
        static member createInterface(input: NodeJS.ReadableStream, ?output: NodeJS.WritableStream, ?completer: Completer, ?terminal: bool): ReadLine = jsNative
        static member createInterface(options: ReadLineOptions): ReadLine = jsNative
        static member cursorTo(stream: NodeJS.WritableStream, x: float, y: float): unit = jsNative
        static member moveCursor(stream: NodeJS.WritableStream, dx: U2<float, string>, dy: U2<float, string>): unit = jsNative
        static member clearLine(stream: NodeJS.WritableStream, dir: float): unit = jsNative
        static member clearScreenDown(stream: NodeJS.WritableStream): unit = jsNative



module vm =
    type [<AllowNullLiteral>] Context =
        interface end

    and [<AllowNullLiteral>] ScriptOptions =
        abstract filename: string option with get, set
        abstract lineOffset: float option with get, set
        abstract columnOffset: float option with get, set
        abstract displayErrors: bool option with get, set
        abstract timeout: float option with get, set
        abstract cachedData: Buffer option with get, set
        abstract produceCachedData: bool option with get, set

    and [<AllowNullLiteral>] RunningScriptOptions =
        abstract filename: string option with get, set
        abstract lineOffset: float option with get, set
        abstract columnOffset: float option with get, set
        abstract displayErrors: bool option with get, set
        abstract timeout: float option with get, set

    and [<AllowNullLiteral>] [<Import("Script","vm")>] Script(code: string, ?options: ScriptOptions) =
        member __.runInContext(contextifiedSandbox: Context, ?options: RunningScriptOptions): obj = jsNative
        member __.runInNewContext(?sandbox: Context, ?options: RunningScriptOptions): obj = jsNative
        member __.runInThisContext(?options: RunningScriptOptions): obj = jsNative

    type [<Import("*","vm")>] Globals =
        static member createContext(?sandbox: Context): Context = jsNative
        static member isContext(sandbox: Context): bool = jsNative
        static member runInContext(code: string, contextifiedSandbox: Context, ?options: RunningScriptOptions): obj = jsNative
        static member runInDebugContext(code: string): obj = jsNative
        static member runInNewContext(code: string, ?sandbox: Context, ?options: RunningScriptOptions): obj = jsNative
        static member runInThisContext(code: string, ?options: RunningScriptOptions): obj = jsNative



module child_process =
    type [<AllowNullLiteral>] ChildProcess =
        abstract EventEmitter: EventEmitter with get, set
        abstract defaultMaxListeners: float with get, set
        abstract listenerCount: emitter: EventEmitter * ``event``: U2<string, Symbol> -> float
        abstract addListener: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract on: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract once: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract prependListener: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract prependOnceListener: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract removeListener: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract removeAllListeners: ?``event``: U2<string, Symbol> -> obj
        abstract setMaxListeners: n: float -> obj
        abstract getMaxListeners: unit -> float
        abstract listeners: ``event``: U2<string, Symbol> -> ResizeArray<Function>
        abstract emit: ``event``: U2<string, Symbol> * [<ParamArray>] args: obj[] -> bool
        abstract eventNames: unit -> ResizeArray<U2<string, Symbol>>
        abstract listenerCount: ``type``: U2<string, Symbol> -> float
        abstract stdin: stream.Writable with get, set
        abstract stdout: stream.Readable with get, set
        abstract stderr: stream.Readable with get, set
        abstract stdio: stream.Writable * stream.Readable * stream.Readable with get, set
        abstract pid: float with get, set
        abstract connected: bool with get, set
        abstract kill: ?signal: string -> unit
        abstract send: message: obj * ?sendHandle: obj -> bool
        abstract disconnect: unit -> unit
        abstract unref: unit -> unit
        abstract ref: unit -> unit

    and [<AllowNullLiteral>] SpawnOptions =
        abstract cwd: string option with get, set
        abstract env: obj option with get, set
        abstract stdio: obj option with get, set
        abstract detached: bool option with get, set
        abstract uid: float option with get, set
        abstract gid: float option with get, set
        abstract shell: U2<bool, string> option with get, set

    and [<AllowNullLiteral>] ExecOptions =
        abstract cwd: string option with get, set
        abstract env: obj option with get, set
        abstract shell: string option with get, set
        abstract timeout: float option with get, set
        abstract maxBuffer: float option with get, set
        abstract killSignal: string option with get, set
        abstract uid: float option with get, set
        abstract gid: float option with get, set

    and [<AllowNullLiteral>] ExecOptionsWithStringEncoding =
        inherit ExecOptions
        abstract encoding: BufferEncoding with get, set

    and [<AllowNullLiteral>] ExecOptionsWithBufferEncoding =
        inherit ExecOptions
        abstract encoding: string with get, set

    and [<AllowNullLiteral>] ExecFileOptions =
        abstract cwd: string option with get, set
        abstract env: obj option with get, set
        abstract timeout: float option with get, set
        abstract maxBuffer: float option with get, set
        abstract killSignal: string option with get, set
        abstract uid: float option with get, set
        abstract gid: float option with get, set

    and [<AllowNullLiteral>] ExecFileOptionsWithStringEncoding =
        inherit ExecFileOptions
        abstract encoding: BufferEncoding with get, set

    and [<AllowNullLiteral>] ExecFileOptionsWithBufferEncoding =
        inherit ExecFileOptions
        abstract encoding: string with get, set

    and [<AllowNullLiteral>] ForkOptions =
        abstract cwd: string option with get, set
        abstract env: obj option with get, set
        abstract execPath: string option with get, set
        abstract execArgv: ResizeArray<string> option with get, set
        abstract silent: bool option with get, set
        abstract uid: float option with get, set
        abstract gid: float option with get, set

    and [<AllowNullLiteral>] SpawnSyncOptions =
        abstract cwd: string option with get, set
        abstract input: U2<string, Buffer> option with get, set
        abstract stdio: obj option with get, set
        abstract env: obj option with get, set
        abstract uid: float option with get, set
        abstract gid: float option with get, set
        abstract timeout: float option with get, set
        abstract killSignal: string option with get, set
        abstract maxBuffer: float option with get, set
        abstract encoding: string option with get, set
        abstract shell: U2<bool, string> option with get, set

    and [<AllowNullLiteral>] SpawnSyncOptionsWithStringEncoding =
        inherit SpawnSyncOptions
        abstract encoding: BufferEncoding with get, set

    and [<AllowNullLiteral>] SpawnSyncOptionsWithBufferEncoding =
        inherit SpawnSyncOptions
        abstract encoding: string with get, set

    and [<AllowNullLiteral>] SpawnSyncReturns<'T> =
        abstract pid: float with get, set
        abstract output: ResizeArray<string> with get, set
        abstract stdout: 'T with get, set
        abstract stderr: 'T with get, set
        abstract status: float with get, set
        abstract signal: string with get, set
        abstract error: Error with get, set

    and [<AllowNullLiteral>] ExecSyncOptions =
        abstract cwd: string option with get, set
        abstract input: U2<string, Buffer> option with get, set
        abstract stdio: obj option with get, set
        abstract env: obj option with get, set
        abstract shell: string option with get, set
        abstract uid: float option with get, set
        abstract gid: float option with get, set
        abstract timeout: float option with get, set
        abstract killSignal: string option with get, set
        abstract maxBuffer: float option with get, set
        abstract encoding: string option with get, set

    and [<AllowNullLiteral>] ExecSyncOptionsWithStringEncoding =
        inherit ExecSyncOptions
        abstract encoding: BufferEncoding with get, set

    and [<AllowNullLiteral>] ExecSyncOptionsWithBufferEncoding =
        inherit ExecSyncOptions
        abstract encoding: string with get, set

    and [<AllowNullLiteral>] ExecFileSyncOptions =
        abstract cwd: string option with get, set
        abstract input: U2<string, Buffer> option with get, set
        abstract stdio: obj option with get, set
        abstract env: obj option with get, set
        abstract uid: float option with get, set
        abstract gid: float option with get, set
        abstract timeout: float option with get, set
        abstract killSignal: string option with get, set
        abstract maxBuffer: float option with get, set
        abstract encoding: string option with get, set

    and [<AllowNullLiteral>] ExecFileSyncOptionsWithStringEncoding =
        inherit ExecFileSyncOptions
        abstract encoding: BufferEncoding with get, set

    and [<AllowNullLiteral>] ExecFileSyncOptionsWithBufferEncoding =
        inherit ExecFileSyncOptions
        abstract encoding: string with get, set

    type [<Import("*","child_process")>] Globals =
        static member spawn(command: string, ?args: ResizeArray<string>, ?options: SpawnOptions): ChildProcess = jsNative
        static member exec(command: string, ?callback: Func<Error, string, string, unit>): ChildProcess = jsNative
        static member exec(command: string, options: ExecOptionsWithStringEncoding, ?callback: Func<Error, string, string, unit>): ChildProcess = jsNative
        static member exec(command: string, options: ExecOptionsWithBufferEncoding, ?callback: Func<Error, Buffer, Buffer, unit>): ChildProcess = jsNative
        static member exec(command: string, options: ExecOptions, ?callback: Func<Error, string, string, unit>): ChildProcess = jsNative
        static member execFile(file: string, ?callback: Func<Error, string, string, unit>): ChildProcess = jsNative
        static member execFile(file: string, ?options: ExecFileOptionsWithStringEncoding, ?callback: Func<Error, string, string, unit>): ChildProcess = jsNative
        static member execFile(file: string, ?options: ExecFileOptionsWithBufferEncoding, ?callback: Func<Error, Buffer, Buffer, unit>): ChildProcess = jsNative
        static member execFile(file: string, ?options: ExecFileOptions, ?callback: Func<Error, string, string, unit>): ChildProcess = jsNative
        static member execFile(file: string, ?args: ResizeArray<string>, ?callback: Func<Error, string, string, unit>): ChildProcess = jsNative
        static member execFile(file: string, ?args: ResizeArray<string>, ?options: ExecFileOptionsWithStringEncoding, ?callback: Func<Error, string, string, unit>): ChildProcess = jsNative
        static member execFile(file: string, ?args: ResizeArray<string>, ?options: ExecFileOptionsWithBufferEncoding, ?callback: Func<Error, Buffer, Buffer, unit>): ChildProcess = jsNative
        static member execFile(file: string, ?args: ResizeArray<string>, ?options: ExecFileOptions, ?callback: Func<Error, string, string, unit>): ChildProcess = jsNative
        static member fork(modulePath: string, ?args: ResizeArray<string>, ?options: ForkOptions): ChildProcess = jsNative
        static member spawnSync(command: string): SpawnSyncReturns<Buffer> = jsNative
        static member spawnSync(command: string, ?options: SpawnSyncOptionsWithStringEncoding): SpawnSyncReturns<string> = jsNative
        static member spawnSync(command: string, ?options: SpawnSyncOptionsWithBufferEncoding): SpawnSyncReturns<Buffer> = jsNative
        static member spawnSync(command: string, ?options: SpawnSyncOptions): SpawnSyncReturns<Buffer> = jsNative
        static member spawnSync(command: string, ?args: ResizeArray<string>, ?options: SpawnSyncOptionsWithStringEncoding): SpawnSyncReturns<string> = jsNative
        static member spawnSync(command: string, ?args: ResizeArray<string>, ?options: SpawnSyncOptionsWithBufferEncoding): SpawnSyncReturns<Buffer> = jsNative
        static member spawnSync(command: string, ?args: ResizeArray<string>, ?options: SpawnSyncOptions): SpawnSyncReturns<Buffer> = jsNative
        static member execSync(command: string): Buffer = jsNative
        static member execSync(command: string, ?options: ExecSyncOptionsWithStringEncoding): string = jsNative
        static member execSync(command: string, ?options: ExecSyncOptionsWithBufferEncoding): Buffer = jsNative
        static member execSync(command: string, ?options: ExecSyncOptions): Buffer = jsNative
        static member execFileSync(command: string): Buffer = jsNative
        static member execFileSync(command: string, ?options: ExecFileSyncOptionsWithStringEncoding): string = jsNative
        static member execFileSync(command: string, ?options: ExecFileSyncOptionsWithBufferEncoding): Buffer = jsNative
        static member execFileSync(command: string, ?options: ExecFileSyncOptions): Buffer = jsNative
        static member execFileSync(command: string, ?args: ResizeArray<string>, ?options: ExecFileSyncOptionsWithStringEncoding): string = jsNative
        static member execFileSync(command: string, ?args: ResizeArray<string>, ?options: ExecFileSyncOptionsWithBufferEncoding): Buffer = jsNative
        static member execFileSync(command: string, ?args: ResizeArray<string>, ?options: ExecFileSyncOptions): Buffer = jsNative



module url =
    type [<AllowNullLiteral>] Url =
        abstract href: string option with get, set
        abstract protocol: string option with get, set
        abstract auth: string option with get, set
        abstract hostname: string option with get, set
        abstract port: string option with get, set
        abstract host: string option with get, set
        abstract pathname: string option with get, set
        abstract search: string option with get, set
        abstract query: U2<string, obj> option with get, set
        abstract slashes: bool option with get, set
        abstract hash: string option with get, set
        abstract path: string option with get, set

    type [<Import("*","url")>] Globals =
        static member parse(urlStr: string, ?parseQueryString: bool, ?slashesDenoteHost: bool): Url = jsNative
        static member format(url: Url): string = jsNative
        static member resolve(from: string, ``to``: string): string = jsNative



module dns =
    type [<AllowNullLiteral>] MxRecord =
        abstract exchange: string with get, set
        abstract priority: float with get, set

    type [<Import("*","dns")>] Globals =
        static member NODATA with get(): string = jsNative and set(v: string): unit = jsNative
        static member FORMERR with get(): string = jsNative and set(v: string): unit = jsNative
        static member SERVFAIL with get(): string = jsNative and set(v: string): unit = jsNative
        static member NOTFOUND with get(): string = jsNative and set(v: string): unit = jsNative
        static member NOTIMP with get(): string = jsNative and set(v: string): unit = jsNative
        static member REFUSED with get(): string = jsNative and set(v: string): unit = jsNative
        static member BADQUERY with get(): string = jsNative and set(v: string): unit = jsNative
        static member BADNAME with get(): string = jsNative and set(v: string): unit = jsNative
        static member BADFAMILY with get(): string = jsNative and set(v: string): unit = jsNative
        static member BADRESP with get(): string = jsNative and set(v: string): unit = jsNative
        static member CONNREFUSED with get(): string = jsNative and set(v: string): unit = jsNative
        static member TIMEOUT with get(): string = jsNative and set(v: string): unit = jsNative
        static member EOF with get(): string = jsNative and set(v: string): unit = jsNative
        static member FILE with get(): string = jsNative and set(v: string): unit = jsNative
        static member NOMEM with get(): string = jsNative and set(v: string): unit = jsNative
        static member DESTRUCTION with get(): string = jsNative and set(v: string): unit = jsNative
        static member BADSTR with get(): string = jsNative and set(v: string): unit = jsNative
        static member BADFLAGS with get(): string = jsNative and set(v: string): unit = jsNative
        static member NONAME with get(): string = jsNative and set(v: string): unit = jsNative
        static member BADHINTS with get(): string = jsNative and set(v: string): unit = jsNative
        static member NOTINITIALIZED with get(): string = jsNative and set(v: string): unit = jsNative
        static member LOADIPHLPAPI with get(): string = jsNative and set(v: string): unit = jsNative
        static member ADDRGETNETWORKPARAMS with get(): string = jsNative and set(v: string): unit = jsNative
        static member CANCELLED with get(): string = jsNative and set(v: string): unit = jsNative
        static member lookup(domain: string, family: float, callback: Func<Error, string, float, unit>): string = jsNative
        static member lookup(domain: string, callback: Func<Error, string, float, unit>): string = jsNative
        static member resolve(domain: string, rrtype: string, callback: Func<Error, ResizeArray<string>, unit>): ResizeArray<string> = jsNative
        static member resolve(domain: string, callback: Func<Error, ResizeArray<string>, unit>): ResizeArray<string> = jsNative
        static member resolve4(domain: string, callback: Func<Error, ResizeArray<string>, unit>): ResizeArray<string> = jsNative
        static member resolve6(domain: string, callback: Func<Error, ResizeArray<string>, unit>): ResizeArray<string> = jsNative
        static member resolveMx(domain: string, callback: Func<Error, ResizeArray<MxRecord>, unit>): ResizeArray<string> = jsNative
        static member resolveTxt(domain: string, callback: Func<Error, ResizeArray<string>, unit>): ResizeArray<string> = jsNative
        static member resolveSrv(domain: string, callback: Func<Error, ResizeArray<string>, unit>): ResizeArray<string> = jsNative
        static member resolveNs(domain: string, callback: Func<Error, ResizeArray<string>, unit>): ResizeArray<string> = jsNative
        static member resolveCname(domain: string, callback: Func<Error, ResizeArray<string>, unit>): ResizeArray<string> = jsNative
        static member reverse(ip: string, callback: Func<Error, ResizeArray<string>, unit>): ResizeArray<string> = jsNative
        static member setServers(servers: ResizeArray<string>): unit = jsNative



module net =
    type [<AllowNullLiteral>] Socket =
        inherit stream.Duplex
        abstract bufferSize: float with get, set
        abstract remoteAddress: string with get, set
        abstract remoteFamily: string with get, set
        abstract remotePort: float with get, set
        abstract localAddress: string with get, set
        abstract localPort: float with get, set
        abstract bytesRead: float with get, set
        abstract bytesWritten: float with get, set
        abstract write: buffer: Buffer -> bool
        abstract write: buffer: Buffer * ?cb: Function -> bool
        abstract write: str: string * ?cb: Function -> bool
        abstract write: str: string * ?encoding: string * ?cb: Function -> bool
        abstract write: str: string * ?encoding: string * ?fd: string -> bool
        abstract connect: port: float * ?host: string * ?connectionListener: Function -> unit
        abstract connect: path: string * ?connectionListener: Function -> unit
        abstract setEncoding: ?encoding: string -> unit
        abstract write: data: obj * ?encoding: string * ?callback: Function -> unit
        abstract destroy: unit -> unit
        abstract pause: unit -> Socket
        abstract resume: unit -> Socket
        abstract setTimeout: timeout: float * ?callback: Function -> unit
        abstract setNoDelay: ?noDelay: bool -> unit
        abstract setKeepAlive: ?enable: bool * ?initialDelay: float -> unit
        abstract address: unit -> obj
        abstract unref: unit -> unit
        abstract ref: unit -> unit
        abstract ``end``: unit -> unit
        abstract ``end``: buffer: Buffer * ?cb: Function -> unit
        abstract ``end``: str: string * ?cb: Function -> unit
        abstract ``end``: str: string * ?encoding: string * ?cb: Function -> unit
        abstract ``end``: ?data: obj * ?encoding: string -> unit
        abstract addListener: ``event``: string * listener: Function -> obj
        [<Emit("$0.addListener('close',$1...)")>] abstract addListener_close: listener: Func<bool, unit> -> obj
        [<Emit("$0.addListener('connect',$1...)")>] abstract addListener_connect: listener: Func<unit, unit> -> obj
        [<Emit("$0.addListener('data',$1...)")>] abstract addListener_data: listener: Func<Buffer, unit> -> obj
        [<Emit("$0.addListener('drain',$1...)")>] abstract addListener_drain: listener: Func<unit, unit> -> obj
        [<Emit("$0.addListener('end',$1...)")>] abstract addListener_end: listener: Func<unit, unit> -> obj
        [<Emit("$0.addListener('error',$1...)")>] abstract addListener_error: listener: Func<Error, unit> -> obj
        [<Emit("$0.addListener('lookup',$1...)")>] abstract addListener_lookup: listener: Func<Error, string, U2<string, float>, string, unit> -> obj
        [<Emit("$0.addListener('timeout',$1...)")>] abstract addListener_timeout: listener: Func<unit, unit> -> obj
        abstract emit: ``event``: string * [<ParamArray>] args: obj[] -> bool
        [<Emit("$0.emit('close',$1...)")>] abstract emit_close: had_error: bool -> bool
        [<Emit("$0.emit('connect')")>] abstract emit_connect: unit -> bool
        [<Emit("$0.emit('data',$1...)")>] abstract emit_data: data: Buffer -> bool
        [<Emit("$0.emit('drain')")>] abstract emit_drain: unit -> bool
        [<Emit("$0.emit('end')")>] abstract emit_end: unit -> bool
        [<Emit("$0.emit('error',$1...)")>] abstract emit_error: err: Error -> bool
        [<Emit("$0.emit('lookup',$1...)")>] abstract emit_lookup: err: Error * address: string * family: U2<string, float> * host: string -> bool
        [<Emit("$0.emit('timeout')")>] abstract emit_timeout: unit -> bool
        abstract on: ``event``: string * listener: Function -> obj
        [<Emit("$0.on('close',$1...)")>] abstract on_close: listener: Func<bool, unit> -> obj
        [<Emit("$0.on('connect',$1...)")>] abstract on_connect: listener: Func<unit, unit> -> obj
        [<Emit("$0.on('data',$1...)")>] abstract on_data: listener: Func<Buffer, unit> -> obj
        [<Emit("$0.on('drain',$1...)")>] abstract on_drain: listener: Func<unit, unit> -> obj
        [<Emit("$0.on('end',$1...)")>] abstract on_end: listener: Func<unit, unit> -> obj
        [<Emit("$0.on('error',$1...)")>] abstract on_error: listener: Func<Error, unit> -> obj
        [<Emit("$0.on('lookup',$1...)")>] abstract on_lookup: listener: Func<Error, string, U2<string, float>, string, unit> -> obj
        [<Emit("$0.on('timeout',$1...)")>] abstract on_timeout: listener: Func<unit, unit> -> obj
        abstract once: ``event``: string * listener: Function -> obj
        [<Emit("$0.once('close',$1...)")>] abstract once_close: listener: Func<bool, unit> -> obj
        [<Emit("$0.once('connect',$1...)")>] abstract once_connect: listener: Func<unit, unit> -> obj
        [<Emit("$0.once('data',$1...)")>] abstract once_data: listener: Func<Buffer, unit> -> obj
        [<Emit("$0.once('drain',$1...)")>] abstract once_drain: listener: Func<unit, unit> -> obj
        [<Emit("$0.once('end',$1...)")>] abstract once_end: listener: Func<unit, unit> -> obj
        [<Emit("$0.once('error',$1...)")>] abstract once_error: listener: Func<Error, unit> -> obj
        [<Emit("$0.once('lookup',$1...)")>] abstract once_lookup: listener: Func<Error, string, U2<string, float>, string, unit> -> obj
        [<Emit("$0.once('timeout',$1...)")>] abstract once_timeout: listener: Func<unit, unit> -> obj
        abstract prependListener: ``event``: string * listener: Function -> obj
        [<Emit("$0.prependListener('close',$1...)")>] abstract prependListener_close: listener: Func<bool, unit> -> obj
        [<Emit("$0.prependListener('connect',$1...)")>] abstract prependListener_connect: listener: Func<unit, unit> -> obj
        [<Emit("$0.prependListener('data',$1...)")>] abstract prependListener_data: listener: Func<Buffer, unit> -> obj
        [<Emit("$0.prependListener('drain',$1...)")>] abstract prependListener_drain: listener: Func<unit, unit> -> obj
        [<Emit("$0.prependListener('end',$1...)")>] abstract prependListener_end: listener: Func<unit, unit> -> obj
        [<Emit("$0.prependListener('error',$1...)")>] abstract prependListener_error: listener: Func<Error, unit> -> obj
        [<Emit("$0.prependListener('lookup',$1...)")>] abstract prependListener_lookup: listener: Func<Error, string, U2<string, float>, string, unit> -> obj
        [<Emit("$0.prependListener('timeout',$1...)")>] abstract prependListener_timeout: listener: Func<unit, unit> -> obj
        abstract prependOnceListener: ``event``: string * listener: Function -> obj
        [<Emit("$0.prependOnceListener('close',$1...)")>] abstract prependOnceListener_close: listener: Func<bool, unit> -> obj
        [<Emit("$0.prependOnceListener('connect',$1...)")>] abstract prependOnceListener_connect: listener: Func<unit, unit> -> obj
        [<Emit("$0.prependOnceListener('data',$1...)")>] abstract prependOnceListener_data: listener: Func<Buffer, unit> -> obj
        [<Emit("$0.prependOnceListener('drain',$1...)")>] abstract prependOnceListener_drain: listener: Func<unit, unit> -> obj
        [<Emit("$0.prependOnceListener('end',$1...)")>] abstract prependOnceListener_end: listener: Func<unit, unit> -> obj
        [<Emit("$0.prependOnceListener('error',$1...)")>] abstract prependOnceListener_error: listener: Func<Error, unit> -> obj
        [<Emit("$0.prependOnceListener('lookup',$1...)")>] abstract prependOnceListener_lookup: listener: Func<Error, string, U2<string, float>, string, unit> -> obj
        [<Emit("$0.prependOnceListener('timeout',$1...)")>] abstract prependOnceListener_timeout: listener: Func<unit, unit> -> obj

    and [<AllowNullLiteral>] SocketType =
        [<Emit("new $0($1...)")>] abstract Create: ?options: obj -> Socket

    and [<AllowNullLiteral>] ListenOptions =
        abstract port: float option with get, set
        abstract host: string option with get, set
        abstract backlog: float option with get, set
        abstract path: string option with get, set
        abstract exclusive: bool option with get, set

    and [<AllowNullLiteral>] Server =
        abstract EventEmitter: EventEmitter with get, set
        abstract defaultMaxListeners: float with get, set
        abstract listenerCount: emitter: EventEmitter * ``event``: U2<string, Symbol> -> float
        abstract addListener: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract on: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract once: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract prependListener: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract prependOnceListener: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract removeListener: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract removeAllListeners: ?``event``: U2<string, Symbol> -> obj
        abstract setMaxListeners: n: float -> obj
        abstract getMaxListeners: unit -> float
        abstract listeners: ``event``: U2<string, Symbol> -> ResizeArray<Function>
        abstract emit: ``event``: U2<string, Symbol> * [<ParamArray>] args: obj[] -> bool
        abstract eventNames: unit -> ResizeArray<U2<string, Symbol>>
        abstract listenerCount: ``type``: U2<string, Symbol> -> float
        abstract maxConnections: float with get, set
        abstract connections: float with get, set
        abstract listen: port: float * ?hostname: string * ?backlog: float * ?listeningListener: Function -> Server
        abstract listen: port: float * ?hostname: string * ?listeningListener: Function -> Server
        abstract listen: port: float * ?backlog: float * ?listeningListener: Function -> Server
        abstract listen: port: float * ?listeningListener: Function -> Server
        abstract listen: path: string * ?backlog: float * ?listeningListener: Function -> Server
        abstract listen: path: string * ?listeningListener: Function -> Server
        abstract listen: handle: obj * ?backlog: float * ?listeningListener: Function -> Server
        abstract listen: handle: obj * ?listeningListener: Function -> Server
        abstract listen: options: ListenOptions * ?listeningListener: Function -> Server
        abstract close: ?callback: Function -> Server
        abstract address: unit -> obj
        abstract getConnections: cb: Func<Error, float, unit> -> unit
        abstract ref: unit -> Server
        abstract unref: unit -> Server
        abstract addListener: ``event``: string * listener: Function -> obj
        [<Emit("$0.addListener('close',$1...)")>] abstract addListener_close: listener: Func<unit, unit> -> obj
        [<Emit("$0.addListener('connection',$1...)")>] abstract addListener_connection: listener: Func<Socket, unit> -> obj
        [<Emit("$0.addListener('error',$1...)")>] abstract addListener_error: listener: Func<Error, unit> -> obj
        [<Emit("$0.addListener('listening',$1...)")>] abstract addListener_listening: listener: Func<unit, unit> -> obj
        abstract emit: ``event``: string * [<ParamArray>] args: obj[] -> bool
        [<Emit("$0.emit('close')")>] abstract emit_close: unit -> bool
        [<Emit("$0.emit('connection',$1...)")>] abstract emit_connection: socket: Socket -> bool
        [<Emit("$0.emit('error',$1...)")>] abstract emit_error: err: Error -> bool
        [<Emit("$0.emit('listening')")>] abstract emit_listening: unit -> bool
        abstract on: ``event``: string * listener: Function -> obj
        [<Emit("$0.on('close',$1...)")>] abstract on_close: listener: Func<unit, unit> -> obj
        [<Emit("$0.on('connection',$1...)")>] abstract on_connection: listener: Func<Socket, unit> -> obj
        [<Emit("$0.on('error',$1...)")>] abstract on_error: listener: Func<Error, unit> -> obj
        [<Emit("$0.on('listening',$1...)")>] abstract on_listening: listener: Func<unit, unit> -> obj
        abstract once: ``event``: string * listener: Function -> obj
        [<Emit("$0.once('close',$1...)")>] abstract once_close: listener: Func<unit, unit> -> obj
        [<Emit("$0.once('connection',$1...)")>] abstract once_connection: listener: Func<Socket, unit> -> obj
        [<Emit("$0.once('error',$1...)")>] abstract once_error: listener: Func<Error, unit> -> obj
        [<Emit("$0.once('listening',$1...)")>] abstract once_listening: listener: Func<unit, unit> -> obj
        abstract prependListener: ``event``: string * listener: Function -> obj
        [<Emit("$0.prependListener('close',$1...)")>] abstract prependListener_close: listener: Func<unit, unit> -> obj
        [<Emit("$0.prependListener('connection',$1...)")>] abstract prependListener_connection: listener: Func<Socket, unit> -> obj
        [<Emit("$0.prependListener('error',$1...)")>] abstract prependListener_error: listener: Func<Error, unit> -> obj
        [<Emit("$0.prependListener('listening',$1...)")>] abstract prependListener_listening: listener: Func<unit, unit> -> obj
        abstract prependOnceListener: ``event``: string * listener: Function -> obj
        [<Emit("$0.prependOnceListener('close',$1...)")>] abstract prependOnceListener_close: listener: Func<unit, unit> -> obj
        [<Emit("$0.prependOnceListener('connection',$1...)")>] abstract prependOnceListener_connection: listener: Func<Socket, unit> -> obj
        [<Emit("$0.prependOnceListener('error',$1...)")>] abstract prependOnceListener_error: listener: Func<Error, unit> -> obj
        [<Emit("$0.prependOnceListener('listening',$1...)")>] abstract prependOnceListener_listening: listener: Func<unit, unit> -> obj

    type [<Import("*","net")>] Globals =
        static member Socket with get(): SocketType = jsNative and set(v: SocketType): unit = jsNative
        static member createServer(?connectionListener: Func<Socket, unit>): Server = jsNative
        static member createServer(?options: obj, ?connectionListener: Func<Socket, unit>): Server = jsNative
        static member connect(options: obj, ?connectionListener: Function): Socket = jsNative
        static member connect(port: float, ?host: string, ?connectionListener: Function): Socket = jsNative
        static member connect(path: string, ?connectionListener: Function): Socket = jsNative
        static member createConnection(options: obj, ?connectionListener: Function): Socket = jsNative
        static member createConnection(port: float, ?host: string, ?connectionListener: Function): Socket = jsNative
        static member createConnection(path: string, ?connectionListener: Function): Socket = jsNative
        static member isIP(input: string): float = jsNative
        static member isIPv4(input: string): bool = jsNative
        static member isIPv6(input: string): bool = jsNative



module dgram =
    type [<AllowNullLiteral>] RemoteInfo =
        abstract address: string with get, set
        abstract family: string with get, set
        abstract port: float with get, set

    and [<AllowNullLiteral>] AddressInfo =
        abstract address: string with get, set
        abstract family: string with get, set
        abstract port: float with get, set

    and [<AllowNullLiteral>] BindOptions =
        abstract port: float with get, set
        abstract address: string option with get, set
        abstract exclusive: bool option with get, set

    and [<AllowNullLiteral>] SocketOptions =
        abstract ``type``: (* TODO StringEnum udp4 | udp6 *) string with get, set
        abstract reuseAddr: bool option with get, set

    and [<AllowNullLiteral>] Socket =
        abstract EventEmitter: EventEmitter with get, set
        abstract defaultMaxListeners: float with get, set
        abstract listenerCount: emitter: EventEmitter * ``event``: U2<string, Symbol> -> float
        abstract addListener: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract on: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract once: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract prependListener: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract prependOnceListener: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract removeListener: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract removeAllListeners: ?``event``: U2<string, Symbol> -> obj
        abstract setMaxListeners: n: float -> obj
        abstract getMaxListeners: unit -> float
        abstract listeners: ``event``: U2<string, Symbol> -> ResizeArray<Function>
        abstract emit: ``event``: U2<string, Symbol> * [<ParamArray>] args: obj[] -> bool
        abstract eventNames: unit -> ResizeArray<U2<string, Symbol>>
        abstract listenerCount: ``type``: U2<string, Symbol> -> float
        abstract send: msg: U3<Buffer, string, ResizeArray<obj>> * port: float * address: string * ?callback: Func<Error, float, unit> -> unit
        abstract send: msg: U3<Buffer, string, ResizeArray<obj>> * offset: float * length: float * port: float * address: string * ?callback: Func<Error, float, unit> -> unit
        abstract bind: ?port: float * ?address: string * ?callback: Func<unit, unit> -> unit
        abstract bind: options: BindOptions * ?callback: Function -> unit
        abstract close: ?callback: obj -> unit
        abstract address: unit -> AddressInfo
        abstract setBroadcast: flag: bool -> unit
        abstract setTTL: ttl: float -> unit
        abstract setMulticastTTL: ttl: float -> unit
        abstract setMulticastLoopback: flag: bool -> unit
        abstract addMembership: multicastAddress: string * ?multicastInterface: string -> unit
        abstract dropMembership: multicastAddress: string * ?multicastInterface: string -> unit
        abstract ref: unit -> unit
        abstract unref: unit -> unit
        abstract addListener: ``event``: string * listener: Function -> obj
        [<Emit("$0.addListener('close',$1...)")>] abstract addListener_close: listener: Func<unit, unit> -> obj
        [<Emit("$0.addListener('error',$1...)")>] abstract addListener_error: listener: Func<Error, unit> -> obj
        [<Emit("$0.addListener('listening',$1...)")>] abstract addListener_listening: listener: Func<unit, unit> -> obj
        [<Emit("$0.addListener('message',$1...)")>] abstract addListener_message: listener: Func<string, AddressInfo, unit> -> obj
        abstract emit: ``event``: string * [<ParamArray>] args: obj[] -> bool
        [<Emit("$0.emit('close')")>] abstract emit_close: unit -> bool
        [<Emit("$0.emit('error',$1...)")>] abstract emit_error: err: Error -> bool
        [<Emit("$0.emit('listening')")>] abstract emit_listening: unit -> bool
        [<Emit("$0.emit('message',$1...)")>] abstract emit_message: msg: string * rinfo: AddressInfo -> bool
        abstract on: ``event``: string * listener: Function -> obj
        [<Emit("$0.on('close',$1...)")>] abstract on_close: listener: Func<unit, unit> -> obj
        [<Emit("$0.on('error',$1...)")>] abstract on_error: listener: Func<Error, unit> -> obj
        [<Emit("$0.on('listening',$1...)")>] abstract on_listening: listener: Func<unit, unit> -> obj
        [<Emit("$0.on('message',$1...)")>] abstract on_message: listener: Func<string, AddressInfo, unit> -> obj
        abstract once: ``event``: string * listener: Function -> obj
        [<Emit("$0.once('close',$1...)")>] abstract once_close: listener: Func<unit, unit> -> obj
        [<Emit("$0.once('error',$1...)")>] abstract once_error: listener: Func<Error, unit> -> obj
        [<Emit("$0.once('listening',$1...)")>] abstract once_listening: listener: Func<unit, unit> -> obj
        [<Emit("$0.once('message',$1...)")>] abstract once_message: listener: Func<string, AddressInfo, unit> -> obj
        abstract prependListener: ``event``: string * listener: Function -> obj
        [<Emit("$0.prependListener('close',$1...)")>] abstract prependListener_close: listener: Func<unit, unit> -> obj
        [<Emit("$0.prependListener('error',$1...)")>] abstract prependListener_error: listener: Func<Error, unit> -> obj
        [<Emit("$0.prependListener('listening',$1...)")>] abstract prependListener_listening: listener: Func<unit, unit> -> obj
        [<Emit("$0.prependListener('message',$1...)")>] abstract prependListener_message: listener: Func<string, AddressInfo, unit> -> obj
        abstract prependOnceListener: ``event``: string * listener: Function -> obj
        [<Emit("$0.prependOnceListener('close',$1...)")>] abstract prependOnceListener_close: listener: Func<unit, unit> -> obj
        [<Emit("$0.prependOnceListener('error',$1...)")>] abstract prependOnceListener_error: listener: Func<Error, unit> -> obj
        [<Emit("$0.prependOnceListener('listening',$1...)")>] abstract prependOnceListener_listening: listener: Func<unit, unit> -> obj
        [<Emit("$0.prependOnceListener('message',$1...)")>] abstract prependOnceListener_message: listener: Func<string, AddressInfo, unit> -> obj

    type [<Import("*","dgram")>] Globals =
        static member createSocket(``type``: string, ?callback: Func<Buffer, RemoteInfo, unit>): Socket = jsNative
        static member createSocket(options: SocketOptions, ?callback: Func<Buffer, RemoteInfo, unit>): Socket = jsNative



module fs =
    type [<AllowNullLiteral>] Stats =
        abstract dev: float with get, set
        abstract ino: float with get, set
        abstract mode: float with get, set
        abstract nlink: float with get, set
        abstract uid: float with get, set
        abstract gid: float with get, set
        abstract rdev: float with get, set
        abstract size: float with get, set
        abstract blksize: float with get, set
        abstract blocks: float with get, set
        abstract atime: DateTime with get, set
        abstract mtime: DateTime with get, set
        abstract ctime: DateTime with get, set
        abstract birthtime: DateTime with get, set
        abstract isFile: unit -> bool
        abstract isDirectory: unit -> bool
        abstract isBlockDevice: unit -> bool
        abstract isCharacterDevice: unit -> bool
        abstract isSymbolicLink: unit -> bool
        abstract isFIFO: unit -> bool
        abstract isSocket: unit -> bool

    and [<AllowNullLiteral>] FSWatcher =
        abstract EventEmitter: EventEmitter with get, set
        abstract defaultMaxListeners: float with get, set
        abstract listenerCount: emitter: EventEmitter * ``event``: U2<string, Symbol> -> float
        abstract addListener: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract on: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract once: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract prependListener: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract prependOnceListener: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract removeListener: ``event``: U2<string, Symbol> * listener: Function -> obj
        abstract removeAllListeners: ?``event``: U2<string, Symbol> -> obj
        abstract setMaxListeners: n: float -> obj
        abstract getMaxListeners: unit -> float
        abstract listeners: ``event``: U2<string, Symbol> -> ResizeArray<Function>
        abstract emit: ``event``: U2<string, Symbol> * [<ParamArray>] args: obj[] -> bool
        abstract eventNames: unit -> ResizeArray<U2<string, Symbol>>
        abstract listenerCount: ``type``: U2<string, Symbol> -> float
        abstract close: unit -> unit
        abstract addListener: ``event``: string * listener: Function -> obj
        [<Emit("$0.addListener('change',$1...)")>] abstract addListener_change: listener: Func<string, U2<string, Buffer>, unit> -> obj
        [<Emit("$0.addListener('error',$1...)")>] abstract addListener_error: listener: Func<float, string, unit> -> obj
        abstract on: ``event``: string * listener: Function -> obj
        [<Emit("$0.on('change',$1...)")>] abstract on_change: listener: Func<string, U2<string, Buffer>, unit> -> obj
        [<Emit("$0.on('error',$1...)")>] abstract on_error: listener: Func<float, string, unit> -> obj
        abstract once: ``event``: string * listener: Function -> obj
        [<Emit("$0.once('change',$1...)")>] abstract once_change: listener: Func<string, U2<string, Buffer>, unit> -> obj
        [<Emit("$0.once('error',$1...)")>] abstract once_error: listener: Func<float, string, unit> -> obj
        abstract prependListener: ``event``: string * listener: Function -> obj
        [<Emit("$0.prependListener('change',$1...)")>] abstract prependListener_change: listener: Func<string, U2<string, Buffer>, unit> -> obj
        [<Emit("$0.prependListener('error',$1...)")>] abstract prependListener_error: listener: Func<float, string, unit> -> obj
        abstract prependOnceListener: ``event``: string * listener: Function -> obj
        [<Emit("$0.prependOnceListener('change',$1...)")>] abstract prependOnceListener_change: listener: Func<string, U2<string, Buffer>, unit> -> obj
        [<Emit("$0.prependOnceListener('error',$1...)")>] abstract prependOnceListener_error: listener: Func<float, string, unit> -> obj

    and [<AllowNullLiteral>] ReadStream =
        inherit stream.Readable
        abstract close: unit -> unit
        abstract destroy: unit -> unit
        abstract addListener: ``event``: string * listener: Function -> obj
        [<Emit("$0.addListener('open',$1...)")>] abstract addListener_open: listener: Func<float, unit> -> obj
        [<Emit("$0.addListener('close',$1...)")>] abstract addListener_close: listener: Func<unit, unit> -> obj
        abstract on: ``event``: string * listener: Function -> obj
        [<Emit("$0.on('open',$1...)")>] abstract on_open: listener: Func<float, unit> -> obj
        [<Emit("$0.on('close',$1...)")>] abstract on_close: listener: Func<unit, unit> -> obj
        abstract once: ``event``: string * listener: Function -> obj
        [<Emit("$0.once('open',$1...)")>] abstract once_open: listener: Func<float, unit> -> obj
        [<Emit("$0.once('close',$1...)")>] abstract once_close: listener: Func<unit, unit> -> obj
        abstract prependListener: ``event``: string * listener: Function -> obj
        [<Emit("$0.prependListener('open',$1...)")>] abstract prependListener_open: listener: Func<float, unit> -> obj
        [<Emit("$0.prependListener('close',$1...)")>] abstract prependListener_close: listener: Func<unit, unit> -> obj
        abstract prependOnceListener: ``event``: string * listener: Function -> obj
        [<Emit("$0.prependOnceListener('open',$1...)")>] abstract prependOnceListener_open: listener: Func<float, unit> -> obj
        [<Emit("$0.prependOnceListener('close',$1...)")>] abstract prependOnceListener_close: listener: Func<unit, unit> -> obj

    and [<AllowNullLiteral>] WriteStream =
        inherit stream.Writable
        abstract bytesWritten: float with get, set
        abstract path: U2<string, Buffer> with get, set
        abstract close: unit -> unit
        abstract addListener: ``event``: string * listener: Function -> obj
        [<Emit("$0.addListener('open',$1...)")>] abstract addListener_open: listener: Func<float, unit> -> obj
        [<Emit("$0.addListener('close',$1...)")>] abstract addListener_close: listener: Func<unit, unit> -> obj
        abstract on: ``event``: string * listener: Function -> obj
        [<Emit("$0.on('open',$1...)")>] abstract on_open: listener: Func<float, unit> -> obj
        [<Emit("$0.on('close',$1...)")>] abstract on_close: listener: Func<unit, unit> -> obj
        abstract once: ``event``: string * listener: Function -> obj
        [<Emit("$0.once('open',$1...)")>] abstract once_open: listener: Func<float, unit> -> obj
        [<Emit("$0.once('close',$1...)")>] abstract once_close: listener: Func<unit, unit> -> obj
        abstract prependListener: ``event``: string * listener: Function -> obj
        [<Emit("$0.prependListener('open',$1...)")>] abstract prependListener_open: listener: Func<float, unit> -> obj
        [<Emit("$0.prependListener('close',$1...)")>] abstract prependListener_close: listener: Func<unit, unit> -> obj
        abstract prependOnceListener: ``event``: string * listener: Function -> obj
        [<Emit("$0.prependOnceListener('open',$1...)")>] abstract prependOnceListener_open: listener: Func<float, unit> -> obj
        [<Emit("$0.prependOnceListener('close',$1...)")>] abstract prependOnceListener_close: listener: Func<unit, unit> -> obj

    type [<Import("*","fs")>] Globals =
        static member rename(oldPath: string, newPath: string, ?callback: Func<NodeJS.ErrnoException, unit>): unit = jsNative
        static member renameSync(oldPath: string, newPath: string): unit = jsNative
        static member truncate(path: U2<string, Buffer>, ?callback: Func<NodeJS.ErrnoException, unit>): unit = jsNative
        static member truncate(path: U2<string, Buffer>, len: float, ?callback: Func<NodeJS.ErrnoException, unit>): unit = jsNative
        static member truncateSync(path: U2<string, Buffer>, ?len: float): unit = jsNative
        static member ftruncate(fd: float, ?callback: Func<NodeJS.ErrnoException, unit>): unit = jsNative
        static member ftruncate(fd: float, len: float, ?callback: Func<NodeJS.ErrnoException, unit>): unit = jsNative
        static member ftruncateSync(fd: float, ?len: float): unit = jsNative
        static member chown(path: U2<string, Buffer>, uid: float, gid: float, ?callback: Func<NodeJS.ErrnoException, unit>): unit = jsNative
        static member chownSync(path: U2<string, Buffer>, uid: float, gid: float): unit = jsNative
        static member fchown(fd: float, uid: float, gid: float, ?callback: Func<NodeJS.ErrnoException, unit>): unit = jsNative
        static member fchownSync(fd: float, uid: float, gid: float): unit = jsNative
        static member lchown(path: U2<string, Buffer>, uid: float, gid: float, ?callback: Func<NodeJS.ErrnoException, unit>): unit = jsNative
        static member lchownSync(path: U2<string, Buffer>, uid: float, gid: float): unit = jsNative
        static member chmod(path: U2<string, Buffer>, mode: float, ?callback: Func<NodeJS.ErrnoException, unit>): unit = jsNative
        static member chmod(path: U2<string, Buffer>, mode: string, ?callback: Func<NodeJS.ErrnoException, unit>): unit = jsNative
        static member chmodSync(path: U2<string, Buffer>, mode: float): unit = jsNative
        static member chmodSync(path: U2<string, Buffer>, mode: string): unit = jsNative
        static member fchmod(fd: float, mode: float, ?callback: Func<NodeJS.ErrnoException, unit>): unit = jsNative
        static member fchmod(fd: float, mode: string, ?callback: Func<NodeJS.ErrnoException, unit>): unit = jsNative
        static member fchmodSync(fd: float, mode: float): unit = jsNative
        static member fchmodSync(fd: float, mode: string): unit = jsNative
        static member lchmod(path: U2<string, Buffer>, mode: float, ?callback: Func<NodeJS.ErrnoException, unit>): unit = jsNative
        static member lchmod(path: U2<string, Buffer>, mode: string, ?callback: Func<NodeJS.ErrnoException, unit>): unit = jsNative
        static member lchmodSync(path: U2<string, Buffer>, mode: float): unit = jsNative
        static member lchmodSync(path: U2<string, Buffer>, mode: string): unit = jsNative
        static member stat(path: U2<string, Buffer>, ?callback: Func<NodeJS.ErrnoException, Stats, obj>): unit = jsNative
        static member lstat(path: U2<string, Buffer>, ?callback: Func<NodeJS.ErrnoException, Stats, obj>): unit = jsNative
        static member fstat(fd: float, ?callback: Func<NodeJS.ErrnoException, Stats, obj>): unit = jsNative
        static member statSync(path: U2<string, Buffer>): Stats = jsNative
        static member lstatSync(path: U2<string, Buffer>): Stats = jsNative
        static member fstatSync(fd: float): Stats = jsNative
        static member link(srcpath: U2<string, Buffer>, dstpath: U2<string, Buffer>, ?callback: Func<NodeJS.ErrnoException, unit>): unit = jsNative
        static member linkSync(srcpath: U2<string, Buffer>, dstpath: U2<string, Buffer>): unit = jsNative
        static member symlink(srcpath: U2<string, Buffer>, dstpath: U2<string, Buffer>, ?``type``: string, ?callback: Func<NodeJS.ErrnoException, unit>): unit = jsNative
        static member symlinkSync(srcpath: U2<string, Buffer>, dstpath: U2<string, Buffer>, ?``type``: string): unit = jsNative
        static member readlink(path: U2<string, Buffer>, ?callback: Func<NodeJS.ErrnoException, string, obj>): unit = jsNative
        static member readlinkSync(path: U2<string, Buffer>): string = jsNative
        static member realpath(path: U2<string, Buffer>, ?callback: Func<NodeJS.ErrnoException, string, obj>): unit = jsNative
        static member realpath(path: U2<string, Buffer>, cache: obj, callback: Func<NodeJS.ErrnoException, string, obj>): unit = jsNative
        static member realpathSync(path: U2<string, Buffer>, ?cache: obj): string = jsNative
        static member unlink(path: U2<string, Buffer>, ?callback: Func<NodeJS.ErrnoException, unit>): unit = jsNative
        static member unlinkSync(path: U2<string, Buffer>): unit = jsNative
        static member rmdir(path: U2<string, Buffer>, ?callback: Func<NodeJS.ErrnoException, unit>): unit = jsNative
        static member rmdirSync(path: U2<string, Buffer>): unit = jsNative
        static member mkdir(path: U2<string, Buffer>, ?callback: Func<NodeJS.ErrnoException, unit>): unit = jsNative
        static member mkdir(path: U2<string, Buffer>, mode: float, ?callback: Func<NodeJS.ErrnoException, unit>): unit = jsNative
        static member mkdir(path: U2<string, Buffer>, mode: string, ?callback: Func<NodeJS.ErrnoException, unit>): unit = jsNative
        static member mkdirSync(path: U2<string, Buffer>, ?mode: float): unit = jsNative
        static member mkdirSync(path: U2<string, Buffer>, ?mode: string): unit = jsNative
        static member mkdtemp(prefix: string, ?callback: Func<NodeJS.ErrnoException, string, unit>): unit = jsNative
        static member mkdtempSync(prefix: string): string = jsNative
        static member readdir(path: U2<string, Buffer>, ?callback: Func<NodeJS.ErrnoException, ResizeArray<string>, unit>): unit = jsNative
        static member readdirSync(path: U2<string, Buffer>): ResizeArray<string> = jsNative
        static member close(fd: float, ?callback: Func<NodeJS.ErrnoException, unit>): unit = jsNative
        static member closeSync(fd: float): unit = jsNative
        static member ``open``(path: U2<string, Buffer>, flags: U2<string, float>, callback: Func<NodeJS.ErrnoException, float, unit>): unit = jsNative
        static member ``open``(path: U2<string, Buffer>, flags: U2<string, float>, mode: float, callback: Func<NodeJS.ErrnoException, float, unit>): unit = jsNative
        static member openSync(path: U2<string, Buffer>, flags: U2<string, float>, ?mode: float): float = jsNative
        static member utimes(path: U2<string, Buffer>, atime: float, mtime: float, ?callback: Func<NodeJS.ErrnoException, unit>): unit = jsNative
        static member utimes(path: U2<string, Buffer>, atime: DateTime, mtime: DateTime, ?callback: Func<NodeJS.ErrnoException, unit>): unit = jsNative
        static member utimesSync(path: U2<string, Buffer>, atime: float, mtime: float): unit = jsNative
        static member utimesSync(path: U2<string, Buffer>, atime: DateTime, mtime: DateTime): unit = jsNative
        static member futimes(fd: float, atime: float, mtime: float, ?callback: Func<NodeJS.ErrnoException, unit>): unit = jsNative
        static member futimes(fd: float, atime: DateTime, mtime: DateTime, ?callback: Func<NodeJS.ErrnoException, unit>): unit = jsNative
        static member futimesSync(fd: float, atime: float, mtime: float): unit = jsNative
        static member futimesSync(fd: float, atime: DateTime, mtime: DateTime): unit = jsNative
        static member fsync(fd: float, ?callback: Func<NodeJS.ErrnoException, unit>): unit = jsNative
        static member fsyncSync(fd: float): unit = jsNative
        static member write(fd: float, buffer: Buffer, offset: float, length: float, position: float, ?callback: Func<NodeJS.ErrnoException, float, Buffer, unit>): unit = jsNative
        static member write(fd: float, buffer: Buffer, offset: float, length: float, ?callback: Func<NodeJS.ErrnoException, float, Buffer, unit>): unit = jsNative
        static member write(fd: float, data: obj, ?callback: Func<NodeJS.ErrnoException, float, string, unit>): unit = jsNative
        static member write(fd: float, data: obj, offset: float, ?callback: Func<NodeJS.ErrnoException, float, string, unit>): unit = jsNative
        static member write(fd: float, data: obj, offset: float, encoding: string, ?callback: Func<NodeJS.ErrnoException, float, string, unit>): unit = jsNative
        static member writeSync(fd: float, buffer: Buffer, offset: float, length: float, ?position: float): float = jsNative
        static member writeSync(fd: float, data: obj, ?position: float, ?enconding: string): float = jsNative
        static member read(fd: float, buffer: Buffer, offset: float, length: float, position: float, ?callback: Func<NodeJS.ErrnoException, float, Buffer, unit>): unit = jsNative
        static member readSync(fd: float, buffer: Buffer, offset: float, length: float, position: float): float = jsNative
        static member readFile(filename: string, encoding: string, callback: Func<NodeJS.ErrnoException, string, unit>): unit = jsNative
        static member readFile(filename: string, options: obj, callback: Func<NodeJS.ErrnoException, string, unit>): unit = jsNative
        static member readFile(filename: string, options: obj, callback: Func<NodeJS.ErrnoException, Buffer, unit>): unit = jsNative
        static member readFile(filename: string, callback: Func<NodeJS.ErrnoException, Buffer, unit>): unit = jsNative
        static member readFileSync(filename: string, encoding: string): string = jsNative
        static member readFileSync(filename: string, options: obj): string = jsNative
        static member readFileSync(filename: string, ?options: obj): Buffer = jsNative
        static member writeFile(filename: string, data: obj, ?callback: Func<NodeJS.ErrnoException, unit>): unit = jsNative
        static member writeFile(filename: string, data: obj, options: obj, ?callback: Func<NodeJS.ErrnoException, unit>): unit = jsNative
        static member writeFile(filename: string, data: obj, options: obj, ?callback: Func<NodeJS.ErrnoException, unit>): unit = jsNative
        static member writeFileSync(filename: string, data: obj, ?options: obj): unit = jsNative
        static member writeFileSync(filename: string, data: obj, ?options: obj): unit = jsNative
        static member appendFile(filename: string, data: obj, options: obj, ?callback: Func<NodeJS.ErrnoException, unit>): unit = jsNative
        static member appendFile(filename: string, data: obj, options: obj, ?callback: Func<NodeJS.ErrnoException, unit>): unit = jsNative
        static member appendFile(filename: string, data: obj, ?callback: Func<NodeJS.ErrnoException, unit>): unit = jsNative
        static member appendFileSync(filename: string, data: obj, ?options: obj): unit = jsNative
        static member appendFileSync(filename: string, data: obj, ?options: obj): unit = jsNative
        static member watchFile(filename: string, listener: Func<Stats, Stats, unit>): unit = jsNative
        static member watchFile(filename: string, options: obj, listener: Func<Stats, Stats, unit>): unit = jsNative
        static member unwatchFile(filename: string, ?listener: Func<Stats, Stats, unit>): unit = jsNative
        static member watch(filename: string, ?listener: Func<string, string, obj>): FSWatcher = jsNative
        static member watch(filename: string, encoding: string, ?listener: Func<string, U2<string, Buffer>, obj>): FSWatcher = jsNative
        static member watch(filename: string, options: obj, ?listener: Func<string, U2<string, Buffer>, obj>): FSWatcher = jsNative
        static member exists(path: U2<string, Buffer>, ?callback: Func<bool, unit>): unit = jsNative
        static member existsSync(path: U2<string, Buffer>): bool = jsNative
        static member access(path: U2<string, Buffer>, callback: Func<NodeJS.ErrnoException, unit>): unit = jsNative
        static member access(path: U2<string, Buffer>, mode: float, callback: Func<NodeJS.ErrnoException, unit>): unit = jsNative
        static member accessSync(path: U2<string, Buffer>, ?mode: float): unit = jsNative
        static member createReadStream(path: U2<string, Buffer>, ?options: obj): ReadStream = jsNative
        static member createWriteStream(path: U2<string, Buffer>, ?options: obj): WriteStream = jsNative
        static member fdatasync(fd: float, callback: Function): unit = jsNative
        static member fdatasyncSync(fd: float): unit = jsNative

    module constants =
        type [<Import("constants","fs")>] Globals =
            static member F_OK with get(): float = jsNative and set(v: float): unit = jsNative
            static member R_OK with get(): float = jsNative and set(v: float): unit = jsNative
            static member W_OK with get(): float = jsNative and set(v: float): unit = jsNative
            static member X_OK with get(): float = jsNative and set(v: float): unit = jsNative
            static member O_RDONLY with get(): float = jsNative and set(v: float): unit = jsNative
            static member O_WRONLY with get(): float = jsNative and set(v: float): unit = jsNative
            static member O_RDWR with get(): float = jsNative and set(v: float): unit = jsNative
            static member O_CREAT with get(): float = jsNative and set(v: float): unit = jsNative
            static member O_EXCL with get(): float = jsNative and set(v: float): unit = jsNative
            static member O_NOCTTY with get(): float = jsNative and set(v: float): unit = jsNative
            static member O_TRUNC with get(): float = jsNative and set(v: float): unit = jsNative
            static member O_APPEND with get(): float = jsNative and set(v: float): unit = jsNative
            static member O_DIRECTORY with get(): float = jsNative and set(v: float): unit = jsNative
            static member O_NOATIME with get(): float = jsNative and set(v: float): unit = jsNative
            static member O_NOFOLLOW with get(): float = jsNative and set(v: float): unit = jsNative
            static member O_SYNC with get(): float = jsNative and set(v: float): unit = jsNative
            static member O_SYMLINK with get(): float = jsNative and set(v: float): unit = jsNative
            static member O_DIRECT with get(): float = jsNative and set(v: float): unit = jsNative
            static member O_NONBLOCK with get(): float = jsNative and set(v: float): unit = jsNative
            static member S_IFMT with get(): float = jsNative and set(v: float): unit = jsNative
            static member S_IFREG with get(): float = jsNative and set(v: float): unit = jsNative
            static member S_IFDIR with get(): float = jsNative and set(v: float): unit = jsNative
            static member S_IFCHR with get(): float = jsNative and set(v: float): unit = jsNative
            static member S_IFBLK with get(): float = jsNative and set(v: float): unit = jsNative
            static member S_IFIFO with get(): float = jsNative and set(v: float): unit = jsNative
            static member S_IFLNK with get(): float = jsNative and set(v: float): unit = jsNative
            static member S_IFSOCK with get(): float = jsNative and set(v: float): unit = jsNative
            static member S_IRWXU with get(): float = jsNative and set(v: float): unit = jsNative
            static member S_IRUSR with get(): float = jsNative and set(v: float): unit = jsNative
            static member S_IWUSR with get(): float = jsNative and set(v: float): unit = jsNative
            static member S_IXUSR with get(): float = jsNative and set(v: float): unit = jsNative
            static member S_IRWXG with get(): float = jsNative and set(v: float): unit = jsNative
            static member S_IRGRP with get(): float = jsNative and set(v: float): unit = jsNative
            static member S_IWGRP with get(): float = jsNative and set(v: float): unit = jsNative
            static member S_IXGRP with get(): float = jsNative and set(v: float): unit = jsNative
            static member S_IRWXO with get(): float = jsNative and set(v: float): unit = jsNative
            static member S_IROTH with get(): float = jsNative and set(v: float): unit = jsNative
            static member S_IWOTH with get(): float = jsNative and set(v: float): unit = jsNative
            static member S_IXOTH with get(): float = jsNative and set(v: float): unit = jsNative



module path =
    type [<AllowNullLiteral>] ParsedPath =
        abstract root: string with get, set
        abstract dir: string with get, set
        abstract ``base``: string with get, set
        abstract ext: string with get, set
        abstract name: string with get, set

    type [<Import("*","path")>] Globals =
        static member sep with get(): string = jsNative and set(v: string): unit = jsNative
        static member delimiter with get(): string = jsNative and set(v: string): unit = jsNative
        static member normalize(p: string): string = jsNative
        static member join([<ParamArray>] paths: obj[]): string = jsNative
        static member join([<ParamArray>] paths: string[]): string = jsNative
        static member resolve([<ParamArray>] pathSegments: obj[]): string = jsNative
        static member isAbsolute(path: string): bool = jsNative
        static member relative(from: string, ``to``: string): string = jsNative
        static member dirname(p: string): string = jsNative
        static member basename(p: string, ?ext: string): string = jsNative
        static member extname(p: string): string = jsNative
        static member parse(pathString: string): ParsedPath = jsNative
        static member format(pathObject: ParsedPath): string = jsNative

    module posix =
        type [<Import("posix","path")>] Globals =
            static member sep with get(): string = jsNative and set(v: string): unit = jsNative
            static member delimiter with get(): string = jsNative and set(v: string): unit = jsNative
            static member normalize(p: string): string = jsNative
            static member join([<ParamArray>] paths: obj[]): string = jsNative
            static member resolve([<ParamArray>] pathSegments: obj[]): string = jsNative
            static member isAbsolute(p: string): bool = jsNative
            static member relative(from: string, ``to``: string): string = jsNative
            static member dirname(p: string): string = jsNative
            static member basename(p: string, ?ext: string): string = jsNative
            static member extname(p: string): string = jsNative
            static member parse(p: string): ParsedPath = jsNative
            static member format(pP: ParsedPath): string = jsNative



    module win32 =
        type [<Import("win32","path")>] Globals =
            static member sep with get(): string = jsNative and set(v: string): unit = jsNative
            static member delimiter with get(): string = jsNative and set(v: string): unit = jsNative
            static member normalize(p: string): string = jsNative
            static member join([<ParamArray>] paths: obj[]): string = jsNative
            static member resolve([<ParamArray>] pathSegments: obj[]): string = jsNative
            static member isAbsolute(p: string): bool = jsNative
            static member relative(from: string, ``to``: string): string = jsNative
            static member dirname(p: string): string = jsNative
            static member basename(p: string, ?ext: string): string = jsNative
            static member extname(p: string): string = jsNative
            static member parse(p: string): ParsedPath = jsNative
            static member format(pP: ParsedPath): string = jsNative



module string_decoder =
    type [<AllowNullLiteral>] NodeStringDecoder =
        abstract write: buffer: Buffer -> string
        abstract ``end``: ?buffer: Buffer -> string

    and [<AllowNullLiteral>] StringDecoderType =
        [<Emit("new $0($1...)")>] abstract Create: ?encoding: string -> NodeStringDecoder

    type [<Import("*","string_decoder")>] Globals =
        static member StringDecoder with get(): StringDecoderType = jsNative and set(v: StringDecoderType): unit = jsNative



module tls =
    type [<AllowNullLiteral>] Certificate =
        abstract C: string with get, set
        abstract ST: string with get, set
        abstract L: string with get, set
        abstract O: string with get, set
        abstract OU: string with get, set
        abstract CN: string with get, set

    and [<AllowNullLiteral>] CipherNameAndProtocol =
        abstract name: string with get, set
        abstract version: string with get, set

    and [<AllowNullLiteral>] [<Import("TLSSocket","tls")>] TLSSocket(socket: net.Socket, ?options: obj) =
        interface stream.Duplex
        member __.authorized with get(): bool = jsNative and set(v: bool): unit = jsNative
        member __.authorizationError with get(): Error = jsNative and set(v: Error): unit = jsNative
        member __.encrypted with get(): bool = jsNative and set(v: bool): unit = jsNative
        member __.localAddress with get(): string = jsNative and set(v: string): unit = jsNative
        member __.localPort with get(): string = jsNative and set(v: string): unit = jsNative
        member __.remoteAddress with get(): string = jsNative and set(v: string): unit = jsNative
        member __.remoteFamily with get(): string = jsNative and set(v: string): unit = jsNative
        member __.remotePort with get(): float = jsNative and set(v: float): unit = jsNative
        member __.address(): obj = jsNative
        member __.getCipher(): CipherNameAndProtocol = jsNative
        member __.getPeerCertificate(?detailed: bool): obj = jsNative
        member __.getSession(): obj = jsNative
        member __.getTLSTicket(): obj = jsNative
        member __.renegotiate(options: TlsOptions, callback: Func<Error, obj>): obj = jsNative
        member __.setMaxSendFragment(size: float): bool = jsNative
        member __.addListener(``event``: string, listener: Function): obj = jsNative
        [<Emit("$0.addListener('OCSPResponse',$1...)")>] member __.addListener_OCSPResponse(listener: Func<Buffer, unit>): obj = jsNative
        [<Emit("$0.addListener('secureConnect',$1...)")>] member __.addListener_secureConnect(listener: Func<unit, unit>): obj = jsNative
        member __.emit(``event``: string, [<ParamArray>] args: obj[]): bool = jsNative
        [<Emit("$0.emit('OCSPResponse',$1...)")>] member __.emit_OCSPResponse(response: Buffer): bool = jsNative
        [<Emit("$0.emit('secureConnect')")>] member __.emit_secureConnect(): bool = jsNative
        member __.on(``event``: string, listener: Function): obj = jsNative
        [<Emit("$0.on('OCSPResponse',$1...)")>] member __.on_OCSPResponse(listener: Func<Buffer, unit>): obj = jsNative
        [<Emit("$0.on('secureConnect',$1...)")>] member __.on_secureConnect(listener: Func<unit, unit>): obj = jsNative
        member __.once(``event``: string, listener: Function): obj = jsNative
        [<Emit("$0.once('OCSPResponse',$1...)")>] member __.once_OCSPResponse(listener: Func<Buffer, unit>): obj = jsNative
        [<Emit("$0.once('secureConnect',$1...)")>] member __.once_secureConnect(listener: Func<unit, unit>): obj = jsNative
        member __.prependListener(``event``: string, listener: Function): obj = jsNative
        [<Emit("$0.prependListener('OCSPResponse',$1...)")>] member __.prependListener_OCSPResponse(listener: Func<Buffer, unit>): obj = jsNative
        [<Emit("$0.prependListener('secureConnect',$1...)")>] member __.prependListener_secureConnect(listener: Func<unit, unit>): obj = jsNative
        member __.prependOnceListener(``event``: string, listener: Function): obj = jsNative
        [<Emit("$0.prependOnceListener('OCSPResponse',$1...)")>] member __.prependOnceListener_OCSPResponse(listener: Func<Buffer, unit>): obj = jsNative
        [<Emit("$0.prependOnceListener('secureConnect',$1...)")>] member __.prependOnceListener_secureConnect(listener: Func<unit, unit>): obj = jsNative

    and [<AllowNullLiteral>] TlsOptions =
        abstract host: string option with get, set
        abstract port: float option with get, set
        abstract pfx: U2<string, ResizeArray<Buffer>> option with get, set
        abstract key: U4<string, ResizeArray<string>, Buffer, ResizeArray<obj>> option with get, set
        abstract passphrase: string option with get, set
        abstract cert: U4<string, ResizeArray<string>, Buffer, ResizeArray<Buffer>> option with get, set
        abstract ca: U4<string, ResizeArray<string>, Buffer, ResizeArray<Buffer>> option with get, set
        abstract crl: U2<string, ResizeArray<string>> option with get, set
        abstract ciphers: string option with get, set
        abstract honorCipherOrder: bool option with get, set
        abstract requestCert: bool option with get, set
        abstract rejectUnauthorized: bool option with get, set
        abstract NPNProtocols: U2<ResizeArray<string>, Buffer> option with get, set
        abstract SNICallback: Func<string, Func<Error, SecureContext, obj>, obj> option with get, set
        abstract ecdhCurve: string option with get, set
        abstract dhparam: U2<string, Buffer> option with get, set
        abstract handshakeTimeout: float option with get, set
        abstract ALPNProtocols: U2<ResizeArray<string>, Buffer> option with get, set
        abstract sessionTimeout: float option with get, set
        abstract ticketKeys: obj option with get, set
        abstract sessionIdContext: string option with get, set
        abstract secureProtocol: string option with get, set

    and [<AllowNullLiteral>] ConnectionOptions =
        abstract host: string option with get, set
        abstract port: float option with get, set
        abstract socket: net.Socket option with get, set
        abstract pfx: U2<string, Buffer> option with get, set
        abstract key: U4<string, ResizeArray<string>, Buffer, ResizeArray<Buffer>> option with get, set
        abstract passphrase: string option with get, set
        abstract cert: U4<string, ResizeArray<string>, Buffer, ResizeArray<Buffer>> option with get, set
        abstract ca: U3<string, Buffer, ResizeArray<U2<string, Buffer>>> option with get, set
        abstract rejectUnauthorized: bool option with get, set
        abstract NPNProtocols: ResizeArray<U2<string, Buffer>> option with get, set
        abstract servername: string option with get, set
        abstract path: string option with get, set
        abstract ALPNProtocols: ResizeArray<U2<string, Buffer>> option with get, set
        abstract checkServerIdentity: Func<string, U3<string, Buffer, ResizeArray<U2<string, Buffer>>>, obj> option with get, set
        abstract secureProtocol: string option with get, set
        abstract secureContext: obj option with get, set
        abstract session: Buffer option with get, set
        abstract minDHSize: float option with get, set

    and [<AllowNullLiteral>] Server =
        inherit net.Server
        abstract maxConnections: float with get, set
        abstract connections: float with get, set
        abstract close: unit -> Server
        abstract address: unit -> obj
        abstract addContext: hostName: string * credentials: obj -> unit
        abstract addListener: ``event``: string * listener: Function -> obj
        [<Emit("$0.addListener('tlsClientError',$1...)")>] abstract addListener_tlsClientError: listener: Func<Error, TLSSocket, unit> -> obj
        [<Emit("$0.addListener('newSession',$1...)")>] abstract addListener_newSession: listener: Func<obj, obj, Func<Error, Buffer, unit>, unit> -> obj
        [<Emit("$0.addListener('OCSPRequest',$1...)")>] abstract addListener_OCSPRequest: listener: Func<Buffer, Buffer, Function, unit> -> obj
        [<Emit("$0.addListener('resumeSession',$1...)")>] abstract addListener_resumeSession: listener: Func<obj, Func<Error, obj, unit>, unit> -> obj
        [<Emit("$0.addListener('secureConnection',$1...)")>] abstract addListener_secureConnection: listener: Func<TLSSocket, unit> -> obj
        abstract emit: ``event``: string * [<ParamArray>] args: obj[] -> bool
        [<Emit("$0.emit('tlsClientError',$1...)")>] abstract emit_tlsClientError: err: Error * tlsSocket: TLSSocket -> bool
        [<Emit("$0.emit('newSession',$1...)")>] abstract emit_newSession: sessionId: obj * sessionData: obj * callback: Func<Error, Buffer, unit> -> bool
        [<Emit("$0.emit('OCSPRequest',$1...)")>] abstract emit_OCSPRequest: certificate: Buffer * issuer: Buffer * callback: Function -> bool
        [<Emit("$0.emit('resumeSession',$1...)")>] abstract emit_resumeSession: sessionId: obj * callback: Func<Error, obj, unit> -> bool
        [<Emit("$0.emit('secureConnection',$1...)")>] abstract emit_secureConnection: tlsSocket: TLSSocket -> bool
        abstract on: ``event``: string * listener: Function -> obj
        [<Emit("$0.on('tlsClientError',$1...)")>] abstract on_tlsClientError: listener: Func<Error, TLSSocket, unit> -> obj
        [<Emit("$0.on('newSession',$1...)")>] abstract on_newSession: listener: Func<obj, obj, Func<Error, Buffer, unit>, unit> -> obj
        [<Emit("$0.on('OCSPRequest',$1...)")>] abstract on_OCSPRequest: listener: Func<Buffer, Buffer, Function, unit> -> obj
        [<Emit("$0.on('resumeSession',$1...)")>] abstract on_resumeSession: listener: Func<obj, Func<Error, obj, unit>, unit> -> obj
        [<Emit("$0.on('secureConnection',$1...)")>] abstract on_secureConnection: listener: Func<TLSSocket, unit> -> obj
        abstract once: ``event``: string * listener: Function -> obj
        [<Emit("$0.once('tlsClientError',$1...)")>] abstract once_tlsClientError: listener: Func<Error, TLSSocket, unit> -> obj
        [<Emit("$0.once('newSession',$1...)")>] abstract once_newSession: listener: Func<obj, obj, Func<Error, Buffer, unit>, unit> -> obj
        [<Emit("$0.once('OCSPRequest',$1...)")>] abstract once_OCSPRequest: listener: Func<Buffer, Buffer, Function, unit> -> obj
        [<Emit("$0.once('resumeSession',$1...)")>] abstract once_resumeSession: listener: Func<obj, Func<Error, obj, unit>, unit> -> obj
        [<Emit("$0.once('secureConnection',$1...)")>] abstract once_secureConnection: listener: Func<TLSSocket, unit> -> obj
        abstract prependListener: ``event``: string * listener: Function -> obj
        [<Emit("$0.prependListener('tlsClientError',$1...)")>] abstract prependListener_tlsClientError: listener: Func<Error, TLSSocket, unit> -> obj
        [<Emit("$0.prependListener('newSession',$1...)")>] abstract prependListener_newSession: listener: Func<obj, obj, Func<Error, Buffer, unit>, unit> -> obj
        [<Emit("$0.prependListener('OCSPRequest',$1...)")>] abstract prependListener_OCSPRequest: listener: Func<Buffer, Buffer, Function, unit> -> obj
        [<Emit("$0.prependListener('resumeSession',$1...)")>] abstract prependListener_resumeSession: listener: Func<obj, Func<Error, obj, unit>, unit> -> obj
        [<Emit("$0.prependListener('secureConnection',$1...)")>] abstract prependListener_secureConnection: listener: Func<TLSSocket, unit> -> obj
        abstract prependOnceListener: ``event``: string * listener: Function -> obj
        [<Emit("$0.prependOnceListener('tlsClientError',$1...)")>] abstract prependOnceListener_tlsClientError: listener: Func<Error, TLSSocket, unit> -> obj
        [<Emit("$0.prependOnceListener('newSession',$1...)")>] abstract prependOnceListener_newSession: listener: Func<obj, obj, Func<Error, Buffer, unit>, unit> -> obj
        [<Emit("$0.prependOnceListener('OCSPRequest',$1...)")>] abstract prependOnceListener_OCSPRequest: listener: Func<Buffer, Buffer, Function, unit> -> obj
        [<Emit("$0.prependOnceListener('resumeSession',$1...)")>] abstract prependOnceListener_resumeSession: listener: Func<obj, Func<Error, obj, unit>, unit> -> obj
        [<Emit("$0.prependOnceListener('secureConnection',$1...)")>] abstract prependOnceListener_secureConnection: listener: Func<TLSSocket, unit> -> obj

    and [<AllowNullLiteral>] ClearTextStream =
        inherit stream.Duplex
        abstract authorized: bool with get, set
        abstract authorizationError: Error with get, set
        abstract getCipher: obj with get, set
        abstract address: obj with get, set
        abstract remoteAddress: string with get, set
        abstract remotePort: float with get, set
        abstract getPeerCertificate: unit -> obj

    and [<AllowNullLiteral>] SecurePair =
        abstract encrypted: obj with get, set
        abstract cleartext: obj with get, set

    and [<AllowNullLiteral>] SecureContextOptions =
        abstract pfx: U2<string, Buffer> option with get, set
        abstract key: U2<string, Buffer> option with get, set
        abstract passphrase: string option with get, set
        abstract cert: U2<string, Buffer> option with get, set
        abstract ca: U2<string, Buffer> option with get, set
        abstract crl: U2<string, ResizeArray<string>> option with get, set
        abstract ciphers: string option with get, set
        abstract honorCipherOrder: bool option with get, set

    and [<AllowNullLiteral>] SecureContext =
        abstract context: obj with get, set

    type [<Import("*","tls")>] Globals =
        static member CLIENT_RENEG_LIMIT with get(): float = jsNative and set(v: float): unit = jsNative
        static member CLIENT_RENEG_WINDOW with get(): float = jsNative and set(v: float): unit = jsNative
        static member createServer(options: TlsOptions, ?secureConnectionListener: Func<ClearTextStream, unit>): Server = jsNative
        static member connect(options: ConnectionOptions, ?secureConnectionListener: Func<unit, unit>): ClearTextStream = jsNative
        static member connect(port: float, ?host: string, ?options: ConnectionOptions, ?secureConnectListener: Func<unit, unit>): ClearTextStream = jsNative
        static member connect(port: float, ?options: ConnectionOptions, ?secureConnectListener: Func<unit, unit>): ClearTextStream = jsNative
        static member createSecurePair(?credentials: crypto.Credentials, ?isServer: bool, ?requestCert: bool, ?rejectUnauthorized: bool): SecurePair = jsNative
        static member createSecureContext(details: SecureContextOptions): SecureContext = jsNative



module crypto =
    type [<AllowNullLiteral>] Certificate =
        abstract exportChallenge: spkac: U2<string, Buffer> -> Buffer
        abstract exportPublicKey: spkac: U2<string, Buffer> -> Buffer
        abstract verifySpkac: spkac: Buffer -> bool

    and [<AllowNullLiteral>] CertificateType =
        [<Emit("new $0($1...)")>] abstract Create: unit -> Certificate
        [<Emit("$0($1...)")>] abstract Invoke: unit -> Certificate

    and [<AllowNullLiteral>] CredentialDetails =
        abstract pfx: string with get, set
        abstract key: string with get, set
        abstract passphrase: string with get, set
        abstract cert: string with get, set
        abstract ca: U2<string, ResizeArray<string>> with get, set
        abstract crl: U2<string, ResizeArray<string>> with get, set
        abstract ciphers: string with get, set

    and [<AllowNullLiteral>] Credentials =
        abstract context: obj option with get, set

    and [<AllowNullLiteral>] [<StringEnum>] Utf8AsciiLatin1Encoding =
        | Utf8 | Ascii | Latin1

    and [<AllowNullLiteral>] [<StringEnum>] HexBase64Latin1Encoding =
        | Latin1 | Hex | Base64

    and [<AllowNullLiteral>] [<StringEnum>] Utf8AsciiBinaryEncoding =
        | Utf8 | Ascii | Binary

    and [<AllowNullLiteral>] [<StringEnum>] HexBase64BinaryEncoding =
        | Binary | Base64 | Hex

    and [<AllowNullLiteral>] [<StringEnum>] ECDHKeyFormat =
        | Compressed | Uncompressed | Hybrid

    and [<AllowNullLiteral>] Hash =
        inherit NodeJS.ReadWriteStream
        abstract update: data: U2<string, Buffer> -> Hash
        abstract update: data: U2<string, Buffer> * input_encoding: Utf8AsciiLatin1Encoding -> Hash
        abstract digest: unit -> Buffer
        abstract digest: encoding: HexBase64Latin1Encoding -> string

    and [<AllowNullLiteral>] Hmac =
        inherit NodeJS.ReadWriteStream
        abstract update: data: U2<string, Buffer> -> Hmac
        abstract update: data: U2<string, Buffer> * input_encoding: Utf8AsciiLatin1Encoding -> Hmac
        abstract digest: unit -> Buffer
        abstract digest: encoding: HexBase64Latin1Encoding -> string

    and [<AllowNullLiteral>] Cipher =
        inherit NodeJS.ReadWriteStream
        abstract update: data: Buffer -> Buffer
        abstract update: data: string * input_encoding: Utf8AsciiBinaryEncoding -> Buffer
        abstract update: data: Buffer * input_encoding: obj * output_encoding: HexBase64BinaryEncoding -> string
        abstract update: data: string * input_encoding: Utf8AsciiBinaryEncoding * output_encoding: HexBase64BinaryEncoding -> string
        abstract final: unit -> Buffer
        abstract final: output_encoding: string -> string
        abstract setAutoPadding: ?auto_padding: bool -> unit
        abstract getAuthTag: unit -> Buffer
        abstract setAAD: buffer: Buffer -> unit

    and [<AllowNullLiteral>] Decipher =
        inherit NodeJS.ReadWriteStream
        abstract update: data: Buffer -> Buffer
        abstract update: data: string * input_encoding: HexBase64BinaryEncoding -> Buffer
        abstract update: data: Buffer * input_encoding: obj * output_encoding: Utf8AsciiBinaryEncoding -> string
        abstract update: data: string * input_encoding: HexBase64BinaryEncoding * output_encoding: Utf8AsciiBinaryEncoding -> string
        abstract final: unit -> Buffer
        abstract final: output_encoding: string -> string
        abstract setAutoPadding: ?auto_padding: bool -> unit
        abstract setAuthTag: tag: Buffer -> unit
        abstract setAAD: buffer: Buffer -> unit

    and [<AllowNullLiteral>] Signer =
        inherit NodeJS.WritableStream
        abstract update: data: U2<string, Buffer> -> Signer
        abstract update: data: U2<string, Buffer> * input_encoding: Utf8AsciiLatin1Encoding -> Signer
        abstract sign: private_key: U2<string, obj> -> Buffer
        abstract sign: private_key: U2<string, obj> * output_format: HexBase64Latin1Encoding -> string

    and [<AllowNullLiteral>] Verify =
        inherit NodeJS.WritableStream
        abstract update: data: U2<string, Buffer> -> Verify
        abstract update: data: U2<string, Buffer> * input_encoding: Utf8AsciiLatin1Encoding -> Verify
        abstract verify: ``object``: string * signature: Buffer -> bool
        abstract verify: ``object``: string * signature: string * signature_format: HexBase64Latin1Encoding -> bool

    and [<AllowNullLiteral>] DiffieHellman =
        abstract verifyError: float with get, set
        abstract generateKeys: unit -> Buffer
        abstract generateKeys: encoding: HexBase64Latin1Encoding -> string
        abstract computeSecret: other_public_key: Buffer -> Buffer
        abstract computeSecret: other_public_key: string * input_encoding: HexBase64Latin1Encoding -> Buffer
        abstract computeSecret: other_public_key: string * input_encoding: HexBase64Latin1Encoding * output_encoding: HexBase64Latin1Encoding -> string
        abstract getPrime: unit -> Buffer
        abstract getPrime: encoding: HexBase64Latin1Encoding -> string
        abstract getGenerator: unit -> Buffer
        abstract getGenerator: encoding: HexBase64Latin1Encoding -> string
        abstract getPublicKey: unit -> Buffer
        abstract getPublicKey: encoding: HexBase64Latin1Encoding -> string
        abstract getPrivateKey: unit -> Buffer
        abstract getPrivateKey: encoding: HexBase64Latin1Encoding -> string
        abstract setPublicKey: public_key: Buffer -> unit
        abstract setPublicKey: public_key: string * encoding: string -> unit
        abstract setPrivateKey: private_key: Buffer -> unit
        abstract setPrivateKey: private_key: string * encoding: string -> unit

    and [<AllowNullLiteral>] RsaPublicKey =
        abstract key: string with get, set
        abstract padding: float option with get, set

    and [<AllowNullLiteral>] RsaPrivateKey =
        abstract key: string with get, set
        abstract passphrase: string option with get, set
        abstract padding: float option with get, set

    and [<AllowNullLiteral>] ECDH =
        abstract generateKeys: unit -> Buffer
        abstract generateKeys: encoding: HexBase64Latin1Encoding -> string
        abstract generateKeys: encoding: HexBase64Latin1Encoding * format: ECDHKeyFormat -> string
        abstract computeSecret: other_public_key: Buffer -> Buffer
        abstract computeSecret: other_public_key: string * input_encoding: HexBase64Latin1Encoding -> Buffer
        abstract computeSecret: other_public_key: string * input_encoding: HexBase64Latin1Encoding * output_encoding: HexBase64Latin1Encoding -> string
        abstract getPrivateKey: unit -> Buffer
        abstract getPrivateKey: encoding: HexBase64Latin1Encoding -> string
        abstract getPublicKey: unit -> Buffer
        abstract getPublicKey: encoding: HexBase64Latin1Encoding -> string
        abstract getPublicKey: encoding: HexBase64Latin1Encoding * format: ECDHKeyFormat -> string
        abstract setPrivateKey: private_key: Buffer -> unit
        abstract setPrivateKey: private_key: string * encoding: HexBase64Latin1Encoding -> unit

    type [<Import("*","crypto")>] Globals =
        static member Certificate with get(): CertificateType = jsNative and set(v: CertificateType): unit = jsNative
        static member fips with get(): bool = jsNative and set(v: bool): unit = jsNative
        static member DEFAULT_ENCODING with get(): string = jsNative and set(v: string): unit = jsNative
        static member createCredentials(details: CredentialDetails): Credentials = jsNative
        static member createHash(algorithm: string): Hash = jsNative
        static member createHmac(algorithm: string, key: U2<string, Buffer>): Hmac = jsNative
        static member createCipher(algorithm: string, password: obj): Cipher = jsNative
        static member createCipheriv(algorithm: string, key: obj, iv: obj): Cipher = jsNative
        static member createDecipher(algorithm: string, password: obj): Decipher = jsNative
        static member createDecipheriv(algorithm: string, key: obj, iv: obj): Decipher = jsNative
        static member createSign(algorithm: string): Signer = jsNative
        static member createVerify(algorith: string): Verify = jsNative
        static member createDiffieHellman(prime_length: float, ?generator: float): DiffieHellman = jsNative
        static member createDiffieHellman(prime: Buffer): DiffieHellman = jsNative
        static member createDiffieHellman(prime: string, prime_encoding: HexBase64Latin1Encoding): DiffieHellman = jsNative
        static member createDiffieHellman(prime: string, prime_encoding: HexBase64Latin1Encoding, generator: U2<float, Buffer>): DiffieHellman = jsNative
        static member createDiffieHellman(prime: string, prime_encoding: HexBase64Latin1Encoding, generator: string, generator_encoding: HexBase64Latin1Encoding): DiffieHellman = jsNative
        static member getDiffieHellman(group_name: string): DiffieHellman = jsNative
        static member pbkdf2(password: U2<string, Buffer>, salt: U2<string, Buffer>, iterations: float, keylen: float, digest: string, callback: Func<Error, Buffer, obj>): unit = jsNative
        static member pbkdf2Sync(password: U2<string, Buffer>, salt: U2<string, Buffer>, iterations: float, keylen: float, digest: string): Buffer = jsNative
        static member randomBytes(size: float): Buffer = jsNative
        static member randomBytes(size: float, callback: Func<Error, Buffer, unit>): unit = jsNative
        static member pseudoRandomBytes(size: float): Buffer = jsNative
        static member pseudoRandomBytes(size: float, callback: Func<Error, Buffer, unit>): unit = jsNative
        static member publicEncrypt(public_key: U2<string, RsaPublicKey>, buffer: Buffer): Buffer = jsNative
        static member privateDecrypt(private_key: U2<string, RsaPrivateKey>, buffer: Buffer): Buffer = jsNative
        static member privateEncrypt(private_key: U2<string, RsaPrivateKey>, buffer: Buffer): Buffer = jsNative
        static member publicDecrypt(public_key: U2<string, RsaPublicKey>, buffer: Buffer): Buffer = jsNative
        static member getCiphers(): ResizeArray<string> = jsNative
        static member getCurves(): ResizeArray<string> = jsNative
        static member getHashes(): ResizeArray<string> = jsNative
        static member createECDH(curve_name: string): ECDH = jsNative
        static member timingSafeEqual(a: Buffer, b: Buffer): bool = jsNative



module stream =
    type [<AllowNullLiteral>] [<Import("internal","stream")>] ``internal``() =
        inherit events.EventEmitter()
        member __.pipe(destination: 'T, ?options: obj): 'T = jsNative

    module ``internal`` =
        type [<AllowNullLiteral>] [<Import("internal.Stream","stream")>] Stream() =
            interface internal


        and [<AllowNullLiteral>] ReadableOptions =
            abstract highWaterMark: float option with get, set
            abstract encoding: string option with get, set
            abstract objectMode: bool option with get, set
            abstract read: Func<float, obj> option with get, set

        and [<AllowNullLiteral>] [<Import("internal.Readable","stream")>] Readable(?opts: ReadableOptions) =
            inherit events.EventEmitter()
            interface ReadableStream with
                member __.readable with get(): bool = jsNative and set(v: bool): unit = jsNative
                member __.read(?size: float): U2<string, Buffer> = jsNative
                member __.setEncoding(encoding: string): unit = jsNative
                member __.pause(): ReadableStream = jsNative
                member __.resume(): ReadableStream = jsNative
                member __.pipe(destination: 'T, ?options: obj): 'T = jsNative
                member __.unpipe(?destination: 'T): unit = jsNative
                member __.unshift(chunk: string): unit = jsNative
                member __.unshift(chunk: Buffer): unit = jsNative
                member __.wrap(oldStream: ReadableStream): ReadableStream = jsNative
            member __._read(size: float): unit = jsNative
            member __.unshift(chunk: obj): unit = jsNative
            member __.wrap(oldStream: NodeJS.ReadableStream): NodeJS.ReadableStream = jsNative
            member __.push(chunk: obj, ?encoding: string): bool = jsNative
            member __.addListener(``event``: string, listener: Function): obj = jsNative
            [<Emit("$0.addListener('close',$1...)")>] member __.addListener_close(listener: Func<unit, unit>): obj = jsNative
            [<Emit("$0.addListener('data',$1...)")>] member __.addListener_data(listener: Func<U2<Buffer, string>, unit>): obj = jsNative
            [<Emit("$0.addListener('end',$1...)")>] member __.addListener_end(listener: Func<unit, unit>): obj = jsNative
            [<Emit("$0.addListener('readable',$1...)")>] member __.addListener_readable(listener: Func<unit, unit>): obj = jsNative
            [<Emit("$0.addListener('error',$1...)")>] member __.addListener_error(listener: Func<Error, unit>): obj = jsNative
            member __.emit(``event``: string, [<ParamArray>] args: obj[]): bool = jsNative
            [<Emit("$0.emit('close')")>] member __.emit_close(): bool = jsNative
            [<Emit("$0.emit('data',$1...)")>] member __.emit_data(chunk: U2<Buffer, string>): bool = jsNative
            [<Emit("$0.emit('end')")>] member __.emit_end(): bool = jsNative
            [<Emit("$0.emit('readable')")>] member __.emit_readable(): bool = jsNative
            [<Emit("$0.emit('error',$1...)")>] member __.emit_error(err: Error): bool = jsNative
            member __.on(``event``: string, listener: Function): obj = jsNative
            [<Emit("$0.on('close',$1...)")>] member __.on_close(listener: Func<unit, unit>): obj = jsNative
            [<Emit("$0.on('data',$1...)")>] member __.on_data(listener: Func<U2<Buffer, string>, unit>): obj = jsNative
            [<Emit("$0.on('end',$1...)")>] member __.on_end(listener: Func<unit, unit>): obj = jsNative
            [<Emit("$0.on('readable',$1...)")>] member __.on_readable(listener: Func<unit, unit>): obj = jsNative
            [<Emit("$0.on('error',$1...)")>] member __.on_error(listener: Func<Error, unit>): obj = jsNative
            member __.once(``event``: string, listener: Function): obj = jsNative
            [<Emit("$0.once('close',$1...)")>] member __.once_close(listener: Func<unit, unit>): obj = jsNative
            [<Emit("$0.once('data',$1...)")>] member __.once_data(listener: Func<U2<Buffer, string>, unit>): obj = jsNative
            [<Emit("$0.once('end',$1...)")>] member __.once_end(listener: Func<unit, unit>): obj = jsNative
            [<Emit("$0.once('readable',$1...)")>] member __.once_readable(listener: Func<unit, unit>): obj = jsNative
            [<Emit("$0.once('error',$1...)")>] member __.once_error(listener: Func<Error, unit>): obj = jsNative
            member __.prependListener(``event``: string, listener: Function): obj = jsNative
            [<Emit("$0.prependListener('close',$1...)")>] member __.prependListener_close(listener: Func<unit, unit>): obj = jsNative
            [<Emit("$0.prependListener('data',$1...)")>] member __.prependListener_data(listener: Func<U2<Buffer, string>, unit>): obj = jsNative
            [<Emit("$0.prependListener('end',$1...)")>] member __.prependListener_end(listener: Func<unit, unit>): obj = jsNative
            [<Emit("$0.prependListener('readable',$1...)")>] member __.prependListener_readable(listener: Func<unit, unit>): obj = jsNative
            [<Emit("$0.prependListener('error',$1...)")>] member __.prependListener_error(listener: Func<Error, unit>): obj = jsNative
            member __.prependOnceListener(``event``: string, listener: Function): obj = jsNative
            [<Emit("$0.prependOnceListener('close',$1...)")>] member __.prependOnceListener_close(listener: Func<unit, unit>): obj = jsNative
            [<Emit("$0.prependOnceListener('data',$1...)")>] member __.prependOnceListener_data(listener: Func<U2<Buffer, string>, unit>): obj = jsNative
            [<Emit("$0.prependOnceListener('end',$1...)")>] member __.prependOnceListener_end(listener: Func<unit, unit>): obj = jsNative
            [<Emit("$0.prependOnceListener('readable',$1...)")>] member __.prependOnceListener_readable(listener: Func<unit, unit>): obj = jsNative
            [<Emit("$0.prependOnceListener('error',$1...)")>] member __.prependOnceListener_error(listener: Func<Error, unit>): obj = jsNative
            member __.removeListener(``event``: string, listener: Function): obj = jsNative
            [<Emit("$0.removeListener('close',$1...)")>] member __.removeListener_close(listener: Func<unit, unit>): obj = jsNative
            [<Emit("$0.removeListener('data',$1...)")>] member __.removeListener_data(listener: Func<U2<Buffer, string>, unit>): obj = jsNative
            [<Emit("$0.removeListener('end',$1...)")>] member __.removeListener_end(listener: Func<unit, unit>): obj = jsNative
            [<Emit("$0.removeListener('readable',$1...)")>] member __.removeListener_readable(listener: Func<unit, unit>): obj = jsNative
            [<Emit("$0.removeListener('error',$1...)")>] member __.removeListener_error(listener: Func<Error, unit>): obj = jsNative

        and [<AllowNullLiteral>] WritableOptions =
            abstract highWaterMark: float option with get, set
            abstract decodeStrings: bool option with get, set
            abstract objectMode: bool option with get, set
            abstract write: Func<U2<string, Buffer>, string, Function, obj> option with get, set
            abstract writev: Func<ResizeArray<obj>, Function, obj> option with get, set

        and [<AllowNullLiteral>] [<Import("internal.Writable","stream")>] Writable(?opts: WritableOptions) =
            inherit events.EventEmitter()
            interface WritableStream with
                member __.writable with get(): bool = jsNative and set(v: bool): unit = jsNative
                member __.write(buffer: U2<Buffer, string>, ?cb: Function): bool = jsNative
                member __.write(str: string, ?encoding: string, ?cb: Function): bool = jsNative
                member __.``end``(): unit = jsNative
                member __.``end``(buffer: Buffer, ?cb: Function): unit = jsNative
                member __.``end``(str: string, ?cb: Function): unit = jsNative
                member __.``end``(str: string, ?encoding: string, ?cb: Function): unit = jsNative
            member __._write(chunk: obj, encoding: string, callback: Function): unit = jsNative
            member __.write(chunk: obj, ?cb: Function): bool = jsNative
            member __.write(chunk: obj, ?encoding: string, ?cb: Function): bool = jsNative
            member __.``end``(chunk: obj, ?cb: Function): unit = jsNative
            member __.``end``(chunk: obj, ?encoding: string, ?cb: Function): unit = jsNative
            member __.addListener(``event``: string, listener: Function): obj = jsNative
            [<Emit("$0.addListener('close',$1...)")>] member __.addListener_close(listener: Func<unit, unit>): obj = jsNative
            [<Emit("$0.addListener('drain',$1...)")>] member __.addListener_drain(listener: Func<unit, unit>): obj = jsNative
            [<Emit("$0.addListener('error',$1...)")>] member __.addListener_error(listener: Func<Error, unit>): obj = jsNative
            [<Emit("$0.addListener('finish',$1...)")>] member __.addListener_finish(listener: Func<unit, unit>): obj = jsNative
            [<Emit("$0.addListener('pipe',$1...)")>] member __.addListener_pipe(listener: Func<Readable, unit>): obj = jsNative
            [<Emit("$0.addListener('unpipe',$1...)")>] member __.addListener_unpipe(listener: Func<Readable, unit>): obj = jsNative
            member __.emit(``event``: string, [<ParamArray>] args: obj[]): bool = jsNative
            [<Emit("$0.emit('close')")>] member __.emit_close(): bool = jsNative
            [<Emit("$0.emit('drain',$1...)")>] member __.emit_drain(chunk: U2<Buffer, string>): bool = jsNative
            [<Emit("$0.emit('error',$1...)")>] member __.emit_error(err: Error): bool = jsNative
            [<Emit("$0.emit('finish')")>] member __.emit_finish(): bool = jsNative
            [<Emit("$0.emit('pipe',$1...)")>] member __.emit_pipe(src: Readable): bool = jsNative
            [<Emit("$0.emit('unpipe',$1...)")>] member __.emit_unpipe(src: Readable): bool = jsNative
            member __.on(``event``: string, listener: Function): obj = jsNative
            [<Emit("$0.on('close',$1...)")>] member __.on_close(listener: Func<unit, unit>): obj = jsNative
            [<Emit("$0.on('drain',$1...)")>] member __.on_drain(listener: Func<unit, unit>): obj = jsNative
            [<Emit("$0.on('error',$1...)")>] member __.on_error(listener: Func<Error, unit>): obj = jsNative
            [<Emit("$0.on('finish',$1...)")>] member __.on_finish(listener: Func<unit, unit>): obj = jsNative
            [<Emit("$0.on('pipe',$1...)")>] member __.on_pipe(listener: Func<Readable, unit>): obj = jsNative
            [<Emit("$0.on('unpipe',$1...)")>] member __.on_unpipe(listener: Func<Readable, unit>): obj = jsNative
            member __.once(``event``: string, listener: Function): obj = jsNative
            [<Emit("$0.once('close',$1...)")>] member __.once_close(listener: Func<unit, unit>): obj = jsNative
            [<Emit("$0.once('drain',$1...)")>] member __.once_drain(listener: Func<unit, unit>): obj = jsNative
            [<Emit("$0.once('error',$1...)")>] member __.once_error(listener: Func<Error, unit>): obj = jsNative
            [<Emit("$0.once('finish',$1...)")>] member __.once_finish(listener: Func<unit, unit>): obj = jsNative
            [<Emit("$0.once('pipe',$1...)")>] member __.once_pipe(listener: Func<Readable, unit>): obj = jsNative
            [<Emit("$0.once('unpipe',$1...)")>] member __.once_unpipe(listener: Func<Readable, unit>): obj = jsNative
            member __.prependListener(``event``: string, listener: Function): obj = jsNative
            [<Emit("$0.prependListener('close',$1...)")>] member __.prependListener_close(listener: Func<unit, unit>): obj = jsNative
            [<Emit("$0.prependListener('drain',$1...)")>] member __.prependListener_drain(listener: Func<unit, unit>): obj = jsNative
            [<Emit("$0.prependListener('error',$1...)")>] member __.prependListener_error(listener: Func<Error, unit>): obj = jsNative
            [<Emit("$0.prependListener('finish',$1...)")>] member __.prependListener_finish(listener: Func<unit, unit>): obj = jsNative
            [<Emit("$0.prependListener('pipe',$1...)")>] member __.prependListener_pipe(listener: Func<Readable, unit>): obj = jsNative
            [<Emit("$0.prependListener('unpipe',$1...)")>] member __.prependListener_unpipe(listener: Func<Readable, unit>): obj = jsNative
            member __.prependOnceListener(``event``: string, listener: Function): obj = jsNative
            [<Emit("$0.prependOnceListener('close',$1...)")>] member __.prependOnceListener_close(listener: Func<unit, unit>): obj = jsNative
            [<Emit("$0.prependOnceListener('drain',$1...)")>] member __.prependOnceListener_drain(listener: Func<unit, unit>): obj = jsNative
            [<Emit("$0.prependOnceListener('error',$1...)")>] member __.prependOnceListener_error(listener: Func<Error, unit>): obj = jsNative
            [<Emit("$0.prependOnceListener('finish',$1...)")>] member __.prependOnceListener_finish(listener: Func<unit, unit>): obj = jsNative
            [<Emit("$0.prependOnceListener('pipe',$1...)")>] member __.prependOnceListener_pipe(listener: Func<Readable, unit>): obj = jsNative
            [<Emit("$0.prependOnceListener('unpipe',$1...)")>] member __.prependOnceListener_unpipe(listener: Func<Readable, unit>): obj = jsNative
            member __.removeListener(``event``: string, listener: Function): obj = jsNative
            [<Emit("$0.removeListener('close',$1...)")>] member __.removeListener_close(listener: Func<unit, unit>): obj = jsNative
            [<Emit("$0.removeListener('drain',$1...)")>] member __.removeListener_drain(listener: Func<unit, unit>): obj = jsNative
            [<Emit("$0.removeListener('error',$1...)")>] member __.removeListener_error(listener: Func<Error, unit>): obj = jsNative
            [<Emit("$0.removeListener('finish',$1...)")>] member __.removeListener_finish(listener: Func<unit, unit>): obj = jsNative
            [<Emit("$0.removeListener('pipe',$1...)")>] member __.removeListener_pipe(listener: Func<Readable, unit>): obj = jsNative
            [<Emit("$0.removeListener('unpipe',$1...)")>] member __.removeListener_unpipe(listener: Func<Readable, unit>): obj = jsNative

        and [<AllowNullLiteral>] DuplexOptions =
            inherit ReadableOptions
            inherit WritableOptions
            abstract allowHalfOpen: bool option with get, set
            abstract readableObjectMode: bool option with get, set
            abstract writableObjectMode: bool option with get, set

        and [<AllowNullLiteral>] [<Import("internal.Duplex","stream")>] Duplex(?opts: DuplexOptions) =
            inherit Readable()
            interface ReadWriteStream with
                member __.pause(): ReadWriteStream = jsNative
                member __.resume(): ReadWriteStream = jsNative
            member __.writable with get(): bool = jsNative and set(v: bool): unit = jsNative
            member __._write(chunk: obj, encoding: string, callback: Function): unit = jsNative
            member __.write(chunk: obj, ?cb: Function): bool = jsNative
            member __.write(chunk: obj, ?encoding: string, ?cb: Function): bool = jsNative
            member __.``end``(): unit = jsNative
            member __.``end``(chunk: obj, ?cb: Function): unit = jsNative
            member __.``end``(chunk: obj, ?encoding: string, ?cb: Function): unit = jsNative

        and [<AllowNullLiteral>] TransformOptions =
            inherit DuplexOptions
            abstract transform: Func<U2<string, Buffer>, string, Function, obj> option with get, set
            abstract flush: Func<Function, obj> option with get, set

        and [<AllowNullLiteral>] [<Import("internal.Transform","stream")>] Transform(?opts: TransformOptions) =
            inherit events.EventEmitter()
            interface ReadWriteStream with
                member __.pause(): ReadWriteStream = jsNative
                member __.resume(): ReadWriteStream = jsNative
            member __.readable with get(): bool = jsNative and set(v: bool): unit = jsNative
            member __.writable with get(): bool = jsNative and set(v: bool): unit = jsNative
            member __._transform(chunk: obj, encoding: string, callback: Function): unit = jsNative
            member __._flush(callback: Function): unit = jsNative
            member __.read(?size: float): obj = jsNative
            member __.setEncoding(encoding: string): unit = jsNative
            member __.pipe(destination: 'T, ?options: obj): 'T = jsNative
            member __.unpipe(?destination: 'T): unit = jsNative
            member __.unshift(chunk: obj): unit = jsNative
            member __.wrap(oldStream: NodeJS.ReadableStream): NodeJS.ReadableStream = jsNative
            member __.push(chunk: obj, ?encoding: string): bool = jsNative
            member __.write(chunk: obj, ?cb: Function): bool = jsNative
            member __.write(chunk: obj, ?encoding: string, ?cb: Function): bool = jsNative
            member __.``end``(): unit = jsNative
            member __.``end``(chunk: obj, ?cb: Function): unit = jsNative
            member __.``end``(chunk: obj, ?encoding: string, ?cb: Function): unit = jsNative

        and [<AllowNullLiteral>] [<Import("internal.PassThrough","stream")>] PassThrough() =
            inherit Transform()




module util =
    type [<AllowNullLiteral>] InspectOptions =
        abstract showHidden: bool option with get, set
        abstract depth: float option with get, set
        abstract colors: bool option with get, set
        abstract customInspect: bool option with get, set

    type [<Import("*","util")>] Globals =
        static member format(format: obj, [<ParamArray>] param: obj[]): string = jsNative
        static member debug(string: string): unit = jsNative
        static member error([<ParamArray>] param: obj[]): unit = jsNative
        static member puts([<ParamArray>] param: obj[]): unit = jsNative
        static member print([<ParamArray>] param: obj[]): unit = jsNative
        static member log(string: string): unit = jsNative
        static member inspect(``object``: obj, ?showHidden: bool, ?depth: float, ?color: bool): string = jsNative
        static member inspect(``object``: obj, options: InspectOptions): string = jsNative
        static member isArray(``object``: obj): bool = jsNative
        static member isRegExp(``object``: obj): bool = jsNative
        static member isDate(``object``: obj): bool = jsNative
        static member isError(``object``: obj): bool = jsNative
        static member inherits(``constructor``: obj, superConstructor: obj): unit = jsNative
        static member debuglog(key: string): Func<string, obj, unit> = jsNative
        static member isBoolean(``object``: obj): bool = jsNative
        static member isBuffer(``object``: obj): bool = jsNative
        static member isFunction(``object``: obj): bool = jsNative
        static member isNull(``object``: obj): bool = jsNative
        static member isNullOrUndefined(``object``: obj): bool = jsNative
        static member isNumber(``object``: obj): bool = jsNative
        static member isObject(``object``: obj): bool = jsNative
        static member isPrimitive(``object``: obj): bool = jsNative
        static member isString(``object``: obj): bool = jsNative
        static member isSymbol(``object``: obj): bool = jsNative
        static member isUndefined(``object``: obj): bool = jsNative
        static member deprecate(fn: Function, message: string): Function = jsNative



module ``assert`` =
    type [<Import("*","assert")>] Globals =
        static member ``internal``(value: obj, ?message: string): unit = jsNative

    module ``internal`` =
        type [<AllowNullLiteral>] [<Import("internal.AssertionError","assert")>] AssertionError(?options: obj) =
            interface Error
            member __.name with get(): string = jsNative and set(v: string): unit = jsNative
            member __.message with get(): string = jsNative and set(v: string): unit = jsNative
            member __.actual with get(): obj = jsNative and set(v: obj): unit = jsNative
            member __.expected with get(): obj = jsNative and set(v: obj): unit = jsNative
            member __.operator with get(): string = jsNative and set(v: string): unit = jsNative
            member __.generatedMessage with get(): bool = jsNative and set(v: bool): unit = jsNative

        and [<AllowNullLiteral>] throwsType =
            [<Emit("$0($1...)")>] abstract Invoke: block: Function * ?message: string -> unit
            [<Emit("$0($1...)")>] abstract Invoke: block: Function * error: Function * ?message: string -> unit
            [<Emit("$0($1...)")>] abstract Invoke: block: Function * error: Regex * ?message: string -> unit
            [<Emit("$0($1...)")>] abstract Invoke: block: Function * error: Func<obj, bool> * ?message: string -> unit

        and [<AllowNullLiteral>] doesNotThrowType =
            [<Emit("$0($1...)")>] abstract Invoke: block: Function * ?message: string -> unit
            [<Emit("$0($1...)")>] abstract Invoke: block: Function * error: Function * ?message: string -> unit
            [<Emit("$0($1...)")>] abstract Invoke: block: Function * error: Regex * ?message: string -> unit
            [<Emit("$0($1...)")>] abstract Invoke: block: Function * error: Func<obj, bool> * ?message: string -> unit

        type [<Import("internal","assert")>] Globals =
            static member throws with get(): throwsType = jsNative and set(v: throwsType): unit = jsNative
            static member doesNotThrow with get(): doesNotThrowType = jsNative and set(v: doesNotThrowType): unit = jsNative
            static member fail(actual: obj, expected: obj, message: string, operator: string): unit = jsNative
            static member ok(value: obj, ?message: string): unit = jsNative
            static member equal(actual: obj, expected: obj, ?message: string): unit = jsNative
            static member notEqual(actual: obj, expected: obj, ?message: string): unit = jsNative
            static member deepEqual(actual: obj, expected: obj, ?message: string): unit = jsNative
            static member notDeepEqual(acutal: obj, expected: obj, ?message: string): unit = jsNative
            static member strictEqual(actual: obj, expected: obj, ?message: string): unit = jsNative
            static member notStrictEqual(actual: obj, expected: obj, ?message: string): unit = jsNative
            static member deepStrictEqual(actual: obj, expected: obj, ?message: string): unit = jsNative
            static member notDeepStrictEqual(actual: obj, expected: obj, ?message: string): unit = jsNative
            static member ifError(value: obj): unit = jsNative



module tty =
    type [<AllowNullLiteral>] ReadStream =
        inherit net.Socket
        abstract isRaw: bool with get, set
        abstract isTTY: bool with get, set
        abstract setRawMode: mode: bool -> unit

    and [<AllowNullLiteral>] WriteStream =
        inherit net.Socket
        abstract columns: float with get, set
        abstract rows: float with get, set
        abstract isTTY: bool with get, set

    type [<Import("*","tty")>] Globals =
        static member isatty(fd: float): bool = jsNative



module domain =
    type [<AllowNullLiteral>] [<Import("Domain","domain")>] Domain() =
        inherit events.EventEmitter()
        interface Domain with
            member __.run(fn: Function): unit = jsNative
            member __.add(emitter: Events): unit = jsNative
            member __.remove(emitter: Events): unit = jsNative
            member __.bind(cb: Func<Error, obj, obj>): obj = jsNative
            member __.intercept(cb: Func<obj, obj>): obj = jsNative
            member __.dispose(): unit = jsNative
            member __.addListener(``event``: string, listener: Function): obj = jsNative
            member __.on(``event``: string, listener: Function): obj = jsNative
            member __.once(``event``: string, listener: Function): obj = jsNative
            member __.removeListener(``event``: string, listener: Function): obj = jsNative
            member __.removeAllListeners(?``event``: string): obj = jsNative
        member __.members with get(): ResizeArray<obj> = jsNative and set(v: ResizeArray<obj>): unit = jsNative
        member __.add(emitter: events.EventEmitter): unit = jsNative
        member __.remove(emitter: events.EventEmitter): unit = jsNative
        member __.enter(): unit = jsNative
        member __.exit(): unit = jsNative

    type [<Import("*","domain")>] Globals =
        static member create(): Domain = jsNative



module constants =
    type [<Import("*","constants")>] Globals =
        static member E2BIG with get(): float = jsNative and set(v: float): unit = jsNative
        static member EACCES with get(): float = jsNative and set(v: float): unit = jsNative
        static member EADDRINUSE with get(): float = jsNative and set(v: float): unit = jsNative
        static member EADDRNOTAVAIL with get(): float = jsNative and set(v: float): unit = jsNative
        static member EAFNOSUPPORT with get(): float = jsNative and set(v: float): unit = jsNative
        static member EAGAIN with get(): float = jsNative and set(v: float): unit = jsNative
        static member EALREADY with get(): float = jsNative and set(v: float): unit = jsNative
        static member EBADF with get(): float = jsNative and set(v: float): unit = jsNative
        static member EBADMSG with get(): float = jsNative and set(v: float): unit = jsNative
        static member EBUSY with get(): float = jsNative and set(v: float): unit = jsNative
        static member ECANCELED with get(): float = jsNative and set(v: float): unit = jsNative
        static member ECHILD with get(): float = jsNative and set(v: float): unit = jsNative
        static member ECONNABORTED with get(): float = jsNative and set(v: float): unit = jsNative
        static member ECONNREFUSED with get(): float = jsNative and set(v: float): unit = jsNative
        static member ECONNRESET with get(): float = jsNative and set(v: float): unit = jsNative
        static member EDEADLK with get(): float = jsNative and set(v: float): unit = jsNative
        static member EDESTADDRREQ with get(): float = jsNative and set(v: float): unit = jsNative
        static member EDOM with get(): float = jsNative and set(v: float): unit = jsNative
        static member EEXIST with get(): float = jsNative and set(v: float): unit = jsNative
        static member EFAULT with get(): float = jsNative and set(v: float): unit = jsNative
        static member EFBIG with get(): float = jsNative and set(v: float): unit = jsNative
        static member EHOSTUNREACH with get(): float = jsNative and set(v: float): unit = jsNative
        static member EIDRM with get(): float = jsNative and set(v: float): unit = jsNative
        static member EILSEQ with get(): float = jsNative and set(v: float): unit = jsNative
        static member EINPROGRESS with get(): float = jsNative and set(v: float): unit = jsNative
        static member EINTR with get(): float = jsNative and set(v: float): unit = jsNative
        static member EINVAL with get(): float = jsNative and set(v: float): unit = jsNative
        static member EIO with get(): float = jsNative and set(v: float): unit = jsNative
        static member EISCONN with get(): float = jsNative and set(v: float): unit = jsNative
        static member EISDIR with get(): float = jsNative and set(v: float): unit = jsNative
        static member ELOOP with get(): float = jsNative and set(v: float): unit = jsNative
        static member EMFILE with get(): float = jsNative and set(v: float): unit = jsNative
        static member EMLINK with get(): float = jsNative and set(v: float): unit = jsNative
        static member EMSGSIZE with get(): float = jsNative and set(v: float): unit = jsNative
        static member ENAMETOOLONG with get(): float = jsNative and set(v: float): unit = jsNative
        static member ENETDOWN with get(): float = jsNative and set(v: float): unit = jsNative
        static member ENETRESET with get(): float = jsNative and set(v: float): unit = jsNative
        static member ENETUNREACH with get(): float = jsNative and set(v: float): unit = jsNative
        static member ENFILE with get(): float = jsNative and set(v: float): unit = jsNative
        static member ENOBUFS with get(): float = jsNative and set(v: float): unit = jsNative
        static member ENODATA with get(): float = jsNative and set(v: float): unit = jsNative
        static member ENODEV with get(): float = jsNative and set(v: float): unit = jsNative
        static member ENOENT with get(): float = jsNative and set(v: float): unit = jsNative
        static member ENOEXEC with get(): float = jsNative and set(v: float): unit = jsNative
        static member ENOLCK with get(): float = jsNative and set(v: float): unit = jsNative
        static member ENOLINK with get(): float = jsNative and set(v: float): unit = jsNative
        static member ENOMEM with get(): float = jsNative and set(v: float): unit = jsNative
        static member ENOMSG with get(): float = jsNative and set(v: float): unit = jsNative
        static member ENOPROTOOPT with get(): float = jsNative and set(v: float): unit = jsNative
        static member ENOSPC with get(): float = jsNative and set(v: float): unit = jsNative
        static member ENOSR with get(): float = jsNative and set(v: float): unit = jsNative
        static member ENOSTR with get(): float = jsNative and set(v: float): unit = jsNative
        static member ENOSYS with get(): float = jsNative and set(v: float): unit = jsNative
        static member ENOTCONN with get(): float = jsNative and set(v: float): unit = jsNative
        static member ENOTDIR with get(): float = jsNative and set(v: float): unit = jsNative
        static member ENOTEMPTY with get(): float = jsNative and set(v: float): unit = jsNative
        static member ENOTSOCK with get(): float = jsNative and set(v: float): unit = jsNative
        static member ENOTSUP with get(): float = jsNative and set(v: float): unit = jsNative
        static member ENOTTY with get(): float = jsNative and set(v: float): unit = jsNative
        static member ENXIO with get(): float = jsNative and set(v: float): unit = jsNative
        static member EOPNOTSUPP with get(): float = jsNative and set(v: float): unit = jsNative
        static member EOVERFLOW with get(): float = jsNative and set(v: float): unit = jsNative
        static member EPERM with get(): float = jsNative and set(v: float): unit = jsNative
        static member EPIPE with get(): float = jsNative and set(v: float): unit = jsNative
        static member EPROTO with get(): float = jsNative and set(v: float): unit = jsNative
        static member EPROTONOSUPPORT with get(): float = jsNative and set(v: float): unit = jsNative
        static member EPROTOTYPE with get(): float = jsNative and set(v: float): unit = jsNative
        static member ERANGE with get(): float = jsNative and set(v: float): unit = jsNative
        static member EROFS with get(): float = jsNative and set(v: float): unit = jsNative
        static member ESPIPE with get(): float = jsNative and set(v: float): unit = jsNative
        static member ESRCH with get(): float = jsNative and set(v: float): unit = jsNative
        static member ETIME with get(): float = jsNative and set(v: float): unit = jsNative
        static member ETIMEDOUT with get(): float = jsNative and set(v: float): unit = jsNative
        static member ETXTBSY with get(): float = jsNative and set(v: float): unit = jsNative
        static member EWOULDBLOCK with get(): float = jsNative and set(v: float): unit = jsNative
        static member EXDEV with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAEINTR with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAEBADF with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAEACCES with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAEFAULT with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAEINVAL with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAEMFILE with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAEWOULDBLOCK with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAEINPROGRESS with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAEALREADY with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAENOTSOCK with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAEDESTADDRREQ with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAEMSGSIZE with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAEPROTOTYPE with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAENOPROTOOPT with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAEPROTONOSUPPORT with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAESOCKTNOSUPPORT with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAEOPNOTSUPP with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAEPFNOSUPPORT with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAEAFNOSUPPORT with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAEADDRINUSE with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAEADDRNOTAVAIL with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAENETDOWN with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAENETUNREACH with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAENETRESET with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAECONNABORTED with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAECONNRESET with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAENOBUFS with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAEISCONN with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAENOTCONN with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAESHUTDOWN with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAETOOMANYREFS with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAETIMEDOUT with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAECONNREFUSED with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAELOOP with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAENAMETOOLONG with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAEHOSTDOWN with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAEHOSTUNREACH with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAENOTEMPTY with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAEPROCLIM with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAEUSERS with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAEDQUOT with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAESTALE with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAEREMOTE with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSASYSNOTREADY with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAVERNOTSUPPORTED with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSANOTINITIALISED with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAEDISCON with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAENOMORE with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAECANCELLED with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAEINVALIDPROCTABLE with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAEINVALIDPROVIDER with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAEPROVIDERFAILEDINIT with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSASYSCALLFAILURE with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSASERVICE_NOT_FOUND with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSATYPE_NOT_FOUND with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSA_E_NO_MORE with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSA_E_CANCELLED with get(): float = jsNative and set(v: float): unit = jsNative
        static member WSAEREFUSED with get(): float = jsNative and set(v: float): unit = jsNative
        static member SIGHUP with get(): float = jsNative and set(v: float): unit = jsNative
        static member SIGINT with get(): float = jsNative and set(v: float): unit = jsNative
        static member SIGILL with get(): float = jsNative and set(v: float): unit = jsNative
        static member SIGABRT with get(): float = jsNative and set(v: float): unit = jsNative
        static member SIGFPE with get(): float = jsNative and set(v: float): unit = jsNative
        static member SIGKILL with get(): float = jsNative and set(v: float): unit = jsNative
        static member SIGSEGV with get(): float = jsNative and set(v: float): unit = jsNative
        static member SIGTERM with get(): float = jsNative and set(v: float): unit = jsNative
        static member SIGBREAK with get(): float = jsNative and set(v: float): unit = jsNative
        static member SIGWINCH with get(): float = jsNative and set(v: float): unit = jsNative
        static member SSL_OP_ALL with get(): float = jsNative and set(v: float): unit = jsNative
        static member SSL_OP_ALLOW_UNSAFE_LEGACY_RENEGOTIATION with get(): float = jsNative and set(v: float): unit = jsNative
        static member SSL_OP_CIPHER_SERVER_PREFERENCE with get(): float = jsNative and set(v: float): unit = jsNative
        static member SSL_OP_CISCO_ANYCONNECT with get(): float = jsNative and set(v: float): unit = jsNative
        static member SSL_OP_COOKIE_EXCHANGE with get(): float = jsNative and set(v: float): unit = jsNative
        static member SSL_OP_CRYPTOPRO_TLSEXT_BUG with get(): float = jsNative and set(v: float): unit = jsNative
        static member SSL_OP_DONT_INSERT_EMPTY_FRAGMENTS with get(): float = jsNative and set(v: float): unit = jsNative
        static member SSL_OP_EPHEMERAL_RSA with get(): float = jsNative and set(v: float): unit = jsNative
        static member SSL_OP_LEGACY_SERVER_CONNECT with get(): float = jsNative and set(v: float): unit = jsNative
        static member SSL_OP_MICROSOFT_BIG_SSLV3_BUFFER with get(): float = jsNative and set(v: float): unit = jsNative
        static member SSL_OP_MICROSOFT_SESS_ID_BUG with get(): float = jsNative and set(v: float): unit = jsNative
        static member SSL_OP_MSIE_SSLV2_RSA_PADDING with get(): float = jsNative and set(v: float): unit = jsNative
        static member SSL_OP_NETSCAPE_CA_DN_BUG with get(): float = jsNative and set(v: float): unit = jsNative
        static member SSL_OP_NETSCAPE_CHALLENGE_BUG with get(): float = jsNative and set(v: float): unit = jsNative
        static member SSL_OP_NETSCAPE_DEMO_CIPHER_CHANGE_BUG with get(): float = jsNative and set(v: float): unit = jsNative
        static member SSL_OP_NETSCAPE_REUSE_CIPHER_CHANGE_BUG with get(): float = jsNative and set(v: float): unit = jsNative
        static member SSL_OP_NO_COMPRESSION with get(): float = jsNative and set(v: float): unit = jsNative
        static member SSL_OP_NO_QUERY_MTU with get(): float = jsNative and set(v: float): unit = jsNative
        static member SSL_OP_NO_SESSION_RESUMPTION_ON_RENEGOTIATION with get(): float = jsNative and set(v: float): unit = jsNative
        static member SSL_OP_NO_SSLv2 with get(): float = jsNative and set(v: float): unit = jsNative
        static member SSL_OP_NO_SSLv3 with get(): float = jsNative and set(v: float): unit = jsNative
        static member SSL_OP_NO_TICKET with get(): float = jsNative and set(v: float): unit = jsNative
        static member SSL_OP_NO_TLSv1 with get(): float = jsNative and set(v: float): unit = jsNative
        static member SSL_OP_NO_TLSv1_1 with get(): float = jsNative and set(v: float): unit = jsNative
        static member SSL_OP_NO_TLSv1_2 with get(): float = jsNative and set(v: float): unit = jsNative
        static member SSL_OP_PKCS1_CHECK_1 with get(): float = jsNative and set(v: float): unit = jsNative
        static member SSL_OP_PKCS1_CHECK_2 with get(): float = jsNative and set(v: float): unit = jsNative
        static member SSL_OP_SINGLE_DH_USE with get(): float = jsNative and set(v: float): unit = jsNative
        static member SSL_OP_SINGLE_ECDH_USE with get(): float = jsNative and set(v: float): unit = jsNative
        static member SSL_OP_SSLEAY_080_CLIENT_DH_BUG with get(): float = jsNative and set(v: float): unit = jsNative
        static member SSL_OP_SSLREF2_REUSE_CERT_TYPE_BUG with get(): float = jsNative and set(v: float): unit = jsNative
        static member SSL_OP_TLS_BLOCK_PADDING_BUG with get(): float = jsNative and set(v: float): unit = jsNative
        static member SSL_OP_TLS_D5_BUG with get(): float = jsNative and set(v: float): unit = jsNative
        static member SSL_OP_TLS_ROLLBACK_BUG with get(): float = jsNative and set(v: float): unit = jsNative
        static member ENGINE_METHOD_DSA with get(): float = jsNative and set(v: float): unit = jsNative
        static member ENGINE_METHOD_DH with get(): float = jsNative and set(v: float): unit = jsNative
        static member ENGINE_METHOD_RAND with get(): float = jsNative and set(v: float): unit = jsNative
        static member ENGINE_METHOD_ECDH with get(): float = jsNative and set(v: float): unit = jsNative
        static member ENGINE_METHOD_ECDSA with get(): float = jsNative and set(v: float): unit = jsNative
        static member ENGINE_METHOD_CIPHERS with get(): float = jsNative and set(v: float): unit = jsNative
        static member ENGINE_METHOD_DIGESTS with get(): float = jsNative and set(v: float): unit = jsNative
        static member ENGINE_METHOD_STORE with get(): float = jsNative and set(v: float): unit = jsNative
        static member ENGINE_METHOD_PKEY_METHS with get(): float = jsNative and set(v: float): unit = jsNative
        static member ENGINE_METHOD_PKEY_ASN1_METHS with get(): float = jsNative and set(v: float): unit = jsNative
        static member ENGINE_METHOD_ALL with get(): float = jsNative and set(v: float): unit = jsNative
        static member ENGINE_METHOD_NONE with get(): float = jsNative and set(v: float): unit = jsNative
        static member DH_CHECK_P_NOT_SAFE_PRIME with get(): float = jsNative and set(v: float): unit = jsNative
        static member DH_CHECK_P_NOT_PRIME with get(): float = jsNative and set(v: float): unit = jsNative
        static member DH_UNABLE_TO_CHECK_GENERATOR with get(): float = jsNative and set(v: float): unit = jsNative
        static member DH_NOT_SUITABLE_GENERATOR with get(): float = jsNative and set(v: float): unit = jsNative
        static member NPN_ENABLED with get(): float = jsNative and set(v: float): unit = jsNative
        static member RSA_PKCS1_PADDING with get(): float = jsNative and set(v: float): unit = jsNative
        static member RSA_SSLV23_PADDING with get(): float = jsNative and set(v: float): unit = jsNative
        static member RSA_NO_PADDING with get(): float = jsNative and set(v: float): unit = jsNative
        static member RSA_PKCS1_OAEP_PADDING with get(): float = jsNative and set(v: float): unit = jsNative
        static member RSA_X931_PADDING with get(): float = jsNative and set(v: float): unit = jsNative
        static member RSA_PKCS1_PSS_PADDING with get(): float = jsNative and set(v: float): unit = jsNative
        static member POINT_CONVERSION_COMPRESSED with get(): float = jsNative and set(v: float): unit = jsNative
        static member POINT_CONVERSION_UNCOMPRESSED with get(): float = jsNative and set(v: float): unit = jsNative
        static member POINT_CONVERSION_HYBRID with get(): float = jsNative and set(v: float): unit = jsNative
        static member O_RDONLY with get(): float = jsNative and set(v: float): unit = jsNative
        static member O_WRONLY with get(): float = jsNative and set(v: float): unit = jsNative
        static member O_RDWR with get(): float = jsNative and set(v: float): unit = jsNative
        static member S_IFMT with get(): float = jsNative and set(v: float): unit = jsNative
        static member S_IFREG with get(): float = jsNative and set(v: float): unit = jsNative
        static member S_IFDIR with get(): float = jsNative and set(v: float): unit = jsNative
        static member S_IFCHR with get(): float = jsNative and set(v: float): unit = jsNative
        static member S_IFBLK with get(): float = jsNative and set(v: float): unit = jsNative
        static member S_IFIFO with get(): float = jsNative and set(v: float): unit = jsNative
        static member S_IFSOCK with get(): float = jsNative and set(v: float): unit = jsNative
        static member S_IRWXU with get(): float = jsNative and set(v: float): unit = jsNative
        static member S_IRUSR with get(): float = jsNative and set(v: float): unit = jsNative
        static member S_IWUSR with get(): float = jsNative and set(v: float): unit = jsNative
        static member S_IXUSR with get(): float = jsNative and set(v: float): unit = jsNative
        static member S_IRWXG with get(): float = jsNative and set(v: float): unit = jsNative
        static member S_IRGRP with get(): float = jsNative and set(v: float): unit = jsNative
        static member S_IWGRP with get(): float = jsNative and set(v: float): unit = jsNative
        static member S_IXGRP with get(): float = jsNative and set(v: float): unit = jsNative
        static member S_IRWXO with get(): float = jsNative and set(v: float): unit = jsNative
        static member S_IROTH with get(): float = jsNative and set(v: float): unit = jsNative
        static member S_IWOTH with get(): float = jsNative and set(v: float): unit = jsNative
        static member S_IXOTH with get(): float = jsNative and set(v: float): unit = jsNative
        static member S_IFLNK with get(): float = jsNative and set(v: float): unit = jsNative
        static member O_CREAT with get(): float = jsNative and set(v: float): unit = jsNative
        static member O_EXCL with get(): float = jsNative and set(v: float): unit = jsNative
        static member O_NOCTTY with get(): float = jsNative and set(v: float): unit = jsNative
        static member O_DIRECTORY with get(): float = jsNative and set(v: float): unit = jsNative
        static member O_NOATIME with get(): float = jsNative and set(v: float): unit = jsNative
        static member O_NOFOLLOW with get(): float = jsNative and set(v: float): unit = jsNative
        static member O_SYNC with get(): float = jsNative and set(v: float): unit = jsNative
        static member O_SYMLINK with get(): float = jsNative and set(v: float): unit = jsNative
        static member O_DIRECT with get(): float = jsNative and set(v: float): unit = jsNative
        static member O_NONBLOCK with get(): float = jsNative and set(v: float): unit = jsNative
        static member O_TRUNC with get(): float = jsNative and set(v: float): unit = jsNative
        static member O_APPEND with get(): float = jsNative and set(v: float): unit = jsNative
        static member F_OK with get(): float = jsNative and set(v: float): unit = jsNative
        static member R_OK with get(): float = jsNative and set(v: float): unit = jsNative
        static member W_OK with get(): float = jsNative and set(v: float): unit = jsNative
        static member X_OK with get(): float = jsNative and set(v: float): unit = jsNative
        static member UV_UDP_REUSEADDR with get(): float = jsNative and set(v: float): unit = jsNative
        static member SIGQUIT with get(): float = jsNative and set(v: float): unit = jsNative
        static member SIGTRAP with get(): float = jsNative and set(v: float): unit = jsNative
        static member SIGIOT with get(): float = jsNative and set(v: float): unit = jsNative
        static member SIGBUS with get(): float = jsNative and set(v: float): unit = jsNative
        static member SIGUSR1 with get(): float = jsNative and set(v: float): unit = jsNative
        static member SIGUSR2 with get(): float = jsNative and set(v: float): unit = jsNative
        static member SIGPIPE with get(): float = jsNative and set(v: float): unit = jsNative
        static member SIGALRM with get(): float = jsNative and set(v: float): unit = jsNative
        static member SIGCHLD with get(): float = jsNative and set(v: float): unit = jsNative
        static member SIGSTKFLT with get(): float = jsNative and set(v: float): unit = jsNative
        static member SIGCONT with get(): float = jsNative and set(v: float): unit = jsNative
        static member SIGSTOP with get(): float = jsNative and set(v: float): unit = jsNative
        static member SIGTSTP with get(): float = jsNative and set(v: float): unit = jsNative
        static member SIGTTIN with get(): float = jsNative and set(v: float): unit = jsNative
        static member SIGTTOU with get(): float = jsNative and set(v: float): unit = jsNative
        static member SIGURG with get(): float = jsNative and set(v: float): unit = jsNative
        static member SIGXCPU with get(): float = jsNative and set(v: float): unit = jsNative
        static member SIGXFSZ with get(): float = jsNative and set(v: float): unit = jsNative
        static member SIGVTALRM with get(): float = jsNative and set(v: float): unit = jsNative
        static member SIGPROF with get(): float = jsNative and set(v: float): unit = jsNative
        static member SIGIO with get(): float = jsNative and set(v: float): unit = jsNative
        static member SIGPOLL with get(): float = jsNative and set(v: float): unit = jsNative
        static member SIGPWR with get(): float = jsNative and set(v: float): unit = jsNative
        static member SIGSYS with get(): float = jsNative and set(v: float): unit = jsNative
        static member SIGUNUSED with get(): float = jsNative and set(v: float): unit = jsNative
        static member defaultCoreCipherList with get(): string = jsNative and set(v: string): unit = jsNative
        static member defaultCipherList with get(): string = jsNative and set(v: string): unit = jsNative
        static member ENGINE_METHOD_RSA with get(): float = jsNative and set(v: float): unit = jsNative
        static member ALPN_ENABLED with get(): float = jsNative and set(v: float): unit = jsNative



module v8 =
    type [<AllowNullLiteral>] HeapSpaceInfo =
        abstract space_name: string with get, set
        abstract space_size: float with get, set
        abstract space_used_size: float with get, set
        abstract space_available_size: float with get, set
        abstract physical_space_size: float with get, set

    type [<Import("*","v8")>] Globals =
        static member getHeapStatistics(): obj = jsNative
        static member getHeapSpaceStatistics(): ResizeArray<HeapSpaceInfo> = jsNative
        static member setFlagsFromString(flags: string): unit = jsNative



module timers =
    type [<Import("*","timers")>] Globals =
        static member setTimeout(callback: Func<obj, unit>, ms: float, [<ParamArray>] args: obj[]): NodeJS.Timer = jsNative
        static member clearTimeout(timeoutId: NodeJS.Timer): unit = jsNative
        static member setInterval(callback: Func<obj, unit>, ms: float, [<ParamArray>] args: obj[]): NodeJS.Timer = jsNative
        static member clearInterval(intervalId: NodeJS.Timer): unit = jsNative
        static member setImmediate(callback: Func<obj, unit>, [<ParamArray>] args: obj[]): obj = jsNative
        static member clearImmediate(immediateId: obj): unit = jsNative


