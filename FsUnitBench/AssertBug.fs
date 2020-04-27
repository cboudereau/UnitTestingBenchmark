namespace FsUnitBench

open FsUnit.Xunit
open Xunit

module AssertBug =
    
    let [<Fact>] ``result bug`` () =
        Ok "hello" |> should equal (Ok "world")
