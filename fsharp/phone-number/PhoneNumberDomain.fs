// module PhoneNumberDomain

// open System.Text.RegularExpressions

// let sanitiesInput s =

//     let stripNonNumbers s =
//         Regex.Replace(s, "[^0-9.]", "")

//     let stripDots s =
//         Regex.Replace(s, "\.", "")

//     let stripLeadingUSCountryCode (s:string) =
//         if s.Length = 11 && s.[0] = '1' then s.[1..10]
//         else s

//     (stripNonNumbers >> stripDots >> stripLeadingUSCountryCode)

// type UnverifiedPhonenumberWithCorrectLength = UnverifiedPhonenumberWithCorrectLength of string

// module UnverifiedPhonenumberWithCorrectLength =
//     let create (s:string) =
//         match s.Length with
//         | 10 -> Ok (UnverifiedPhonenumberWithCorrectLength s)
//         | _ -> Error "Phone number must have exactly 10 digits"


// type UnverifiedAreaCode = UnverifiedAreaCode of string

// type UnverifiedExchangeCode = UnverifiedExchangeCode of string

// type AreaCode = private AreaCode of string

// // module AreaCode =
// //     let create (s:UnverifiedAreaCode) =
// //         match s.Length with
// //         | 0 -> Error "AreaCode must have length larger than 0"
// //         | _ -> 
// //             if s.[0] = '0' || s.[0] = '1' then Ok (AreaCode s)
// //             else Error "AreaCode must start with '0' or '1'"

// type ExchangeCode = ExchangeCode of string

// // module ExchangeCode =
// //     let create (s:UnverifiedExchangeCode) =
// //         match s.Length with
// //         | 0 -> Error "ExchangeCode must have length larger than 0"
// //         | _ -> 
// //             if s.[0] = '0' || s.[0] = '1' then Ok (ExchangeCode s)
// //             else Error "ExchangeCode must start with '0' or '1'"

// // type PNumber = private PNumber of string

// type VerifyAreaCode = UnverifiedAreaCode -> Result<AreaCode, string>

// let verifyAreaCode : VerifyAreaCode =
//     // match s.Length with
//     // | 0 -> Error "AreaCode must have length larger than 0"
//     // | _ -> 
//     //     if s.[0] = '0' || s.[0] = '1' then Ok (AreaCode s)
//     //     else Error "AreaCode must start with '0' or '1'"


// type PNumber = {
//     AreaCode: AreaCode
//     ExchangeCode: ExchangeCode
// }

// module PNumber =

//     let create (s:string): Result<PNumber, string> =
        
//         let unverifiedAreaCode = UnverifiedAreaCode s.[0..2]
//         let unverifiedExchangeCode = UnverifiedExchangeCode s.[3..9]

//         let areaCodeResult = verifyAreaCode unverifiedAreaCode
//         let exchangeCodeResult = ExchangeCode.create unverifiedExchangeCode

//         match areaCodeResult, exchangeCodeResult with
//         | Error e1, Error e2 -> Error ("Invalid AreaCode: " + e1 + " Invalid ExchangeCode: " + e2)
//         | Error e1, _ -> Error ("Invalid AreaCode: " + e1)
//         | _, Error e2 -> Error ("Invalid ExchangeCode: " + e2)
//         | Ok areaCode, Ok exchangeCode -> Ok {AreaCode = areaCode; ExchangeCode =exchangeCode}
