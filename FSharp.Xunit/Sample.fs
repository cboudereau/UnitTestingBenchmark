module Sample

open Xunit
open FSharp.Xunit

let [<Fact>] ``result : actual message not exact, the code compiles even if types aren't compatible`` () =
    let actual = Ok "1J"
    let expected = Ok "1P"

    actual |> shouldBe expected

