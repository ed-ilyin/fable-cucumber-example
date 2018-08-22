// ts2fable 0.0.0
module rec Fable.Import.Cucumber
open System
open Fable.Core
open Fable.Import.JS


type [<AllowNullLiteral>] IExports =
    abstract After: code: HookCode -> unit
    abstract After: options: U2<HookOptions, string> * code: HookCode -> unit
    abstract AfterAll: code: GlobalHookCode -> unit
    abstract AfterAll: options: U2<HookOptions, string> * code: GlobalHookCode -> unit
    abstract Before: code: HookCode -> unit
    abstract Before: options: U2<HookOptions, string> * code: HookCode -> unit
    abstract BeforeAll: code: GlobalHookCode -> unit
    abstract BeforeAll: options: U2<HookOptions, string> * code: GlobalHookCode -> unit
    abstract defineParameterType: transform: Transform -> unit
    abstract defineStep: pattern: U2<RegExp, string> * code: StepDefinitionCode -> unit
    abstract defineStep: pattern: U2<RegExp, string> * options: StepDefinitionOptions * code: StepDefinitionCode -> unit
    abstract Given: pattern: U2<RegExp, string> * code: StepDefinitionCode -> unit
    abstract Given: pattern: U2<RegExp, string> * options: StepDefinitionOptions * code: StepDefinitionCode -> unit
    abstract setDefaultTimeout: time: float -> unit
    abstract setDefinitionFunctionWrapper: fn: (unit -> unit) * ?options: SetDefinitionFunctionWrapperOptions -> unit
    abstract setWorldConstructor: world: U2<(World -> obj -> unit), obj> -> unit
    abstract Then: pattern: U2<RegExp, string> * options: StepDefinitionOptions * code: StepDefinitionCode -> unit
    abstract Then: pattern: U2<RegExp, string> * code: StepDefinitionCode -> unit
    abstract When: pattern: U2<RegExp, string> * options: StepDefinitionOptions * code: StepDefinitionCode -> unit
    abstract When: pattern: U2<RegExp, string> * code: StepDefinitionCode -> unit
    abstract EventListener: EventListenerStatic
    abstract Listener: unit -> EventListener
    abstract defineSupportCode: consumer: SupportCodeConsumer -> unit
    abstract getSupportCodeFns: unit -> ResizeArray<SupportCodeConsumer>
    abstract clearSupportCodeFns: unit -> unit
    abstract Formatter: FormatterStatic
    abstract SummaryFormatter: SummaryFormatterStatic
    abstract PrettyFormatter: PrettyFormatterStatic
    abstract ProgressFormatter: ProgressFormatterStatic
    abstract RerunFormatter: RerunFormatterStatic
    abstract SnippetsFormatter: SnippetsFormatterStatic
    abstract UsageFormatter: UsageFormatterStatic
    abstract UsageJsonFormatter: UsageJsonFormatterStatic
    abstract JsonFormatter: JsonFormatterStatic

type [<AllowNullLiteral>] SetDefinitionFunctionWrapperOptions =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

type [<StringEnum>] [<RequireQualifiedAccess>] Status =
    | [<CompiledName "ambiguous">] AMBIGUOUS
    | [<CompiledName "failed">] FAILED
    | [<CompiledName "passed">] PASSED
    | [<CompiledName "pending">] PENDING
    | [<CompiledName "skipped">] SKIPPED
    | [<CompiledName "undefined">] UNDEFINED

type [<AllowNullLiteral>] World =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

type [<AllowNullLiteral>] CallbackStepDefinition =
    abstract pending: unit -> PromiseLike<obj option>
    [<Emit "$0($1...)">] abstract Invoke: ?error: obj option * ?pending: string -> unit

type [<AllowNullLiteral>] TableDefinition =
    abstract raw: unit -> ResizeArray<ResizeArray<string>>
    abstract rows: unit -> ResizeArray<ResizeArray<string>>
    abstract rowsHash: unit -> obj
    abstract hashes: unit -> Array<obj>

type [<AllowNullLiteral>] StepDefinitionCode =
    [<Emit "$0($1...)">] abstract Invoke: this: World * [<ParamArray>] stepArgs: ResizeArray<obj option> -> obj option

type [<AllowNullLiteral>] StepDefinitionOptions =
    abstract timeout: float option with get, set

type [<AllowNullLiteral>] StepDefinitions =
    abstract Given: pattern: U2<RegExp, string> * options: StepDefinitionOptions * code: StepDefinitionCode -> unit
    abstract Given: pattern: U2<RegExp, string> * code: StepDefinitionCode -> unit
    abstract When: pattern: U2<RegExp, string> * options: StepDefinitionOptions * code: StepDefinitionCode -> unit
    abstract When: pattern: U2<RegExp, string> * code: StepDefinitionCode -> unit
    abstract Then: pattern: U2<RegExp, string> * options: StepDefinitionOptions * code: StepDefinitionCode -> unit
    abstract Then: pattern: U2<RegExp, string> * code: StepDefinitionCode -> unit
    abstract setDefaultTimeout: time: float -> unit

type [<AllowNullLiteral>] HookScenarioResult =
    abstract sourceLocation: SourceLocation with get, set
    abstract result: ScenarioResult with get, set
    abstract pickle: Pickle.Pickle with get, set

type [<AllowNullLiteral>] SourceLocation =
    abstract line: float with get, set
    abstract uri: string with get, set

type [<AllowNullLiteral>] ScenarioResult =
    abstract duration: float with get, set
    abstract status: Status with get, set

module Pickle =

    type [<AllowNullLiteral>] Pickle =
        abstract language: string with get, set
        abstract locations: ResizeArray<Location> with get, set
        abstract name: string with get, set
        abstract steps: ResizeArray<Step> with get, set
        abstract tags: ResizeArray<Tag> with get, set

    type [<AllowNullLiteral>] Location =
        abstract column: float with get, set
        abstract line: float with get, set

    type [<AllowNullLiteral>] Step =
        abstract arguments: ResizeArray<Argument> with get, set
        abstract locations: ResizeArray<Location> with get, set
        abstract text: string with get, set

    type [<AllowNullLiteral>] Argument =
        abstract rows: ResizeArray<Cell> with get, set

    type [<AllowNullLiteral>] Cell =
        abstract location: Location with get, set
        abstract value: string with get, set

    type [<AllowNullLiteral>] Tag =
        abstract name: string with get, set
        abstract location: Location with get, set

type [<AllowNullLiteral>] HookCode =
    [<Emit "$0($1...)">] abstract Invoke: this: World * scenario: HookScenarioResult * ?callback: CallbackStepDefinition -> unit

type [<AllowNullLiteral>] GlobalHookCode =
    [<Emit "$0($1...)">] abstract Invoke: ?callback: CallbackStepDefinition -> unit

type [<AllowNullLiteral>] Transform =
    abstract regexp: RegExp with get, set
    abstract transformer: this: World * [<ParamArray>] arg: ResizeArray<string> -> obj option
    abstract useForSnippets: bool option with get, set
    abstract preferForRegexpMatch: bool option with get, set
    abstract name: string option with get, set
    abstract typeName: string option with get, set

type [<AllowNullLiteral>] HookOptions =
    abstract timeout: float option with get, set
    abstract tags: obj option with get, set

type [<AllowNullLiteral>] Hooks =
    abstract Before: code: HookCode -> unit
    abstract Before: options: U2<HookOptions, string> * code: HookCode -> unit
    abstract BeforeAll: code: GlobalHookCode -> unit
    abstract BeforeAll: options: U2<HookOptions, string> * code: GlobalHookCode -> unit
    abstract After: code: HookCode -> unit
    abstract After: options: U2<HookOptions, string> * code: HookCode -> unit
    abstract AfterAll: code: GlobalHookCode -> unit
    abstract AfterAll: options: U2<HookOptions, string> * code: GlobalHookCode -> unit
    abstract setDefaultTimeout: time: float -> unit
    abstract setWorldConstructor: world: U2<(World -> obj -> unit), obj> -> unit
    abstract defineParameterType: transform: Transform -> unit

type [<AllowNullLiteral>] EventListener =
    abstract hear: ``event``: Events.Event * callback: (unit -> unit) -> unit
    abstract hasHandlerForEvent: ``event``: Events.Event -> bool
    abstract buildHandlerNameForEvent: ``event``: Events.Event -> string
    abstract getHandlerForEvent: ``event``: Events.Event -> EventHook
    abstract buildHandlerName: shortName: string -> string
    abstract setHandlerForEvent: shortName: string * handler: EventListener -> unit

type [<AllowNullLiteral>] EventListenerStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> EventListener

module Events =

    type [<AllowNullLiteral>] Event =
        abstract name: string with get, set
        abstract data: obj option with get, set

    type [<AllowNullLiteral>] EventPayload =
        interface end

    type [<AllowNullLiteral>] FeaturesPayload =
        inherit EventPayload
        abstract getFeatures: unit -> ResizeArray<obj option>

    type [<AllowNullLiteral>] FeaturesResultPayload =
        inherit EventPayload
        abstract duration: float with get, set
        abstract scenarioResults: ResizeArray<obj option> with get, set
        abstract success: bool with get, set
        abstract stepsResults: ResizeArray<obj option> with get, set
        abstract strict: bool with get, set

    type [<AllowNullLiteral>] FeaturePayload =
        inherit EventPayload
        abstract description: string with get, set
        abstract keyword: string with get, set
        abstract line: float with get, set
        abstract name: string with get, set
        abstract tags: ResizeArray<Tag> with get, set
        abstract uri: string with get, set
        abstract scenarios: ResizeArray<Scenario> with get, set

    type [<AllowNullLiteral>] ScenarioPayload =
        inherit EventPayload
        abstract feature: Feature with get, set
        abstract ``exception``: Error with get, set
        abstract keyword: string with get, set
        abstract lines: ResizeArray<float> with get, set
        abstract name: string with get, set
        abstract tags: ResizeArray<Tag> with get, set
        abstract uri: string with get, set
        abstract line: float with get, set
        abstract description: string with get, set
        abstract steps: ResizeArray<Step> with get, set

    type [<AllowNullLiteral>] ScenarioResultPayload =
        inherit EventPayload
        abstract duration: obj option with get, set
        abstract failureException: Error with get, set
        abstract scenario: Scenario with get, set
        abstract status: Status with get, set
        abstract stepResults: ResizeArray<obj option> with get, set

    type [<AllowNullLiteral>] StepPayload =
        inherit EventPayload
        abstract arguments: obj option with get, set
        abstract line: float with get, set
        abstract name: string with get, set
        abstract scenario: Scenario with get, set
        abstract uri: string with get, set
        abstract isBackground: bool with get, set
        abstract keyword: string with get, set
        abstract keywordType: string with get, set

    type [<AllowNullLiteral>] StepResultPayload =
        inherit EventPayload
        abstract ambiguousStepDefinitions: obj option with get, set
        abstract attachments: ResizeArray<obj option> with get, set
        abstract duration: obj option with get, set
        abstract failureException: Error with get, set
        abstract step: Step with get, set
        abstract stepDefinition: StepDefinition with get, set
        abstract status: Status with get, set

type [<AllowNullLiteral>] StepDefinition =
    abstract code: Function with get, set
    abstract line: float with get, set
    abstract options: obj with get, set
    abstract pattern: obj option with get, set
    abstract uri: string with get, set

type [<AllowNullLiteral>] Tag =
    abstract name: string with get, set
    abstract line: float with get, set

type [<AllowNullLiteral>] Step =
    abstract arguments: obj option with get, set
    abstract line: float with get, set
    abstract name: string with get, set
    abstract scenario: Scenario with get, set
    abstract uri: string with get, set
    abstract isBackground: bool with get, set
    abstract keyword: string with get, set
    abstract keywordType: string with get, set

type [<AllowNullLiteral>] Scenario =
    abstract feature: Feature with get, set
    abstract ``exception``: Error with get, set
    abstract keyword: string with get, set
    abstract lines: ResizeArray<float> with get, set
    abstract name: string with get, set
    abstract tags: ResizeArray<Tag> with get, set
    abstract uri: string with get, set
    abstract line: float with get, set
    abstract description: string with get, set
    abstract steps: ResizeArray<Step> with get, set

type [<AllowNullLiteral>] Feature =
    abstract description: string with get, set
    abstract keyword: string with get, set
    abstract line: float with get, set
    abstract name: string with get, set
    abstract tags: ResizeArray<Tag> with get, set
    abstract uri: string with get, set
    abstract scenarios: ResizeArray<Scenario> with get, set

type [<AllowNullLiteral>] EventHook =
    [<Emit "$0($1...)">] abstract Invoke: ``event``: Events.Event * ?callback: (unit -> unit) -> unit

type [<AllowNullLiteral>] SupportCodeConsumer =
    [<Emit "$0($1...)">] abstract Invoke: stepDefinitions: obj -> unit

type [<AllowNullLiteral>] Formatter =
    abstract log: data: obj option -> unit

type [<AllowNullLiteral>] FormatterStatic =
    [<Emit "new $0($1...)">] abstract Create: ?options: obj option -> Formatter

type [<AllowNullLiteral>] SummaryFormatter =
    inherit Formatter
    abstract indent: text: string * numberOfSpaces: float -> obj option

type [<AllowNullLiteral>] SummaryFormatterStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> SummaryFormatter

type [<AllowNullLiteral>] PrettyFormatter =
    inherit SummaryFormatter
    abstract formatTags: tags: ResizeArray<Tag> -> obj option
    abstract logIndented: text: string * level: float -> unit
    abstract logStepResult: stepResult: obj option -> unit

type [<AllowNullLiteral>] PrettyFormatterStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> PrettyFormatter

type [<AllowNullLiteral>] ProgressFormatter =
    inherit SummaryFormatter

type [<AllowNullLiteral>] ProgressFormatterStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> ProgressFormatter

type [<AllowNullLiteral>] RerunFormatter =
    inherit Formatter

type [<AllowNullLiteral>] RerunFormatterStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> RerunFormatter

type [<AllowNullLiteral>] SnippetsFormatter =
    inherit Formatter

type [<AllowNullLiteral>] SnippetsFormatterStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> SnippetsFormatter

type [<AllowNullLiteral>] UsageFormatter =
    inherit Formatter

type [<AllowNullLiteral>] UsageFormatterStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> UsageFormatter

type [<AllowNullLiteral>] UsageJsonFormatter =
    inherit Formatter

type [<AllowNullLiteral>] UsageJsonFormatterStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> UsageJsonFormatter

type [<AllowNullLiteral>] JsonFormatter =
    inherit Formatter

type [<AllowNullLiteral>] JsonFormatterStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> JsonFormatter
