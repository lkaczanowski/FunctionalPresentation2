// Example 1 
module OptionMonad = 
  let bind f a = 
    match a with
    | None -> None 
    | Some x -> f x

  let (>==) a f = bind f a

// Example 2
module ResultMonad =

  let bind f a = 
    match a with
      | Error e -> Error e
      | Ok x -> f x 

// Example 3
module ListMonad = 

  let rec bind f a = 
    match a with
    | [] -> []
    | [x] -> f x
    | x :: xs -> f x @ bind f xs
    // above is not tail recursive, but leave it for the sake of simplicity

  let bind2 (f : 'a -> 'b list) (a : 'a list) =
    [ for ax in a -> f ax ]
    |> List.fold (@) []
    // can be reduced with List.collect