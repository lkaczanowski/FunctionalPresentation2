type 'T ValidationResult = 
  | Success of 'T
  | Failure of (string * string) list 

// functor
let map f a =
  match a with
    | Success x -> f x |> Success
    | Failure z -> Failure z

let (<!>) = map

// applicative
let returnM a = Success a

let apply f a =
  match f, a with
    | Success fn, Success v -> returnM <| fn v
    | Failure lst, Success _ -> Failure lst
    | Success _, Failure lst -> Failure lst
    | Failure lst, Failure lst2 -> Failure (lst @ lst2) 

let (<*>) = apply

let lift2 f a b = f <!> a <*> b

// monad

let bind f a =
  match a with
    | Success v -> f v
    | Failure lst -> Failure lst

let (>>=) a f = bind f a 

// kleisli

let (>=>) f g = fun x -> f x >>= g

// helpers

let (<*) a b = lift2 (fun z _ -> z) a b

let validator pred error x =
  if pred x 
    then Success x
    else Failure [("", error)]

let validate validators name x =
  match validators with
    | [] -> returnM x
    | vs -> 
      let oneV = List.reduce (>=>) vs
      match oneV x with
        | Success x -> Success x
        | Failure err -> 
          err 
          |> List.map (fun (_, msg) -> (name, msg)) 
          |> Failure

// example validators
let (==) = LanguagePrimitives.PhysicalEquality

let (!=) a b = not (a == b)

let notNull = validator ((!=) null) "Value cannot be null"

let notEmpty = validator ((<>) "") "String cannot be empty"

let greaterThan n = validator ((<) n) (sprintf "Value must be greater than %i" n)

let lessThan n = validator ((>) n) (sprintf "Value must be less than %i" n)

let mustEquals x = validator ((=) x) (sprintf "Value must be equal to %A" x)


// test it!

type Address = 
  { Street : string
    Number : int
    Flat : int }

let validateAddress address = 
  let validateStreet = validate [notNull; notEmpty] "Street"
  let validateNumber = validate [greaterThan 0; lessThan 10] "Number"
  let validateFlat = validate [mustEquals 10] "Flat"

  returnM address
  <* validateStreet address.Street
  <* validateNumber address.Number
  <* validateFlat address.Flat