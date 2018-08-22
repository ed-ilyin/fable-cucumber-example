module Tests
open Fable.Core
open Fable.Import
open Fable.Core.JsInterop
open Fable.Import.JS

// const assert = require('assert');
let inline equal (expected: 'T) (actual: 'T): unit =
    Testing.Assert.AreEqual(expected, actual)

// const { Given, When, Then } = require('cucumber');
[<Import("Given","cucumber")>]
let _given (pattern: U2<RegExp, string>) (code: Cucumber.StepDefinitionCode) : unit = jsNative

let Given (pattern: string) (code: obj list -> 'State) =
    let sdc x y z =
        do printfn "x: %A" x
        do printfn "y: %A" y
        do printfn "z: %A" z
    do _given (U2.Case2 pattern) !!sdc


[<Import("When","cucumber")>]
let When (pattern: U2<RegExp, string>) (code: Cucumber.StepDefinitionCode) : unit = jsNative
[<Import("Then","cucumber")>]
let Then (pattern: U2<RegExp, string>) (code: Cucumber.StepDefinitionCode) : unit = jsNative

// function isItFriday(today) {
//   if (today === "Friday") {
//     return "TGIF";
//   } else {
//     return "Nope";
//   }
// }
let private isItFriday = function "Friday" -> "TGIF" | _ -> "Nope"

// Given('today is {string}', function (givenDay) {
//   this.today = givenDay;
// });
Given "today is {string}" List.tryHead

// When('I ask whether it\'s Friday yet', function () {
//   this.actualAnswer = isItFriday(this.today);
// });

// Then('I should be told {string}', function (expectedAnswer) {
//   assert.equal(this.actualAnswer, expectedAnswer);
// });
