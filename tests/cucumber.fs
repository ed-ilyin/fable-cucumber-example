module Cucumber
open Fable.Core
open Fable.Import
open Fable.Core.JsInterop
open System

type Parser = unit
type ParserStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> Parser
type Gherkin = {
    Parser: ParserStatic
}

[<Import("*","gherkin")>]
let private gherkin: Gherkin = jsNative

let parser = gherkin.Parser.Create ()
