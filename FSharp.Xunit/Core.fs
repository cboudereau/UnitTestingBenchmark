[<AutoOpen>]
module FSharp.Xunit

let private pretty x = sprintf "%A" x

let shouldBe (expected:'a) (actual:'a) = 
    if expected <> actual then 
        raise (Xunit.Sdk.EqualException(pretty expected, pretty actual))

let shouldNotBe (expected:'a) (actual:'a) = 
    if expected = actual then
        raise (Xunit.Sdk.NotEqualException(pretty expected, pretty actual))
    
let shouldBeTrue condition = Xunit.Assert.True(condition:bool)

module Test = 
    let asParallel (x:#seq<Async<unit>>) = Async.Parallel(x, 4) |> Async.Ignore 
    
module Result = 
    let get = function Ok x -> x | Error e -> failwithf "expected a ok result but got an error %A" e
    
    let shouldBe ok error expected actual = 
        match expected, actual with
        | Ok e, Ok a -> ok e a 
        | Error e, Error a -> error e a
        | Ok _, Error e -> failwithf "expected a Ok result but got an Error %A" e
        | Error e, Ok x -> failwithf "expected an Error %A but git an Ok %A" e x