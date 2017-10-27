// Example 1
module EitherFunctor =

  type 'a Either = 
    | None
    | Some of 'a

  let fmap f a = 
    match a with
    | None -> None
    | Some v -> f v |> Some

// Example 2
module ListFunctor =

  let rec fmap f a =
    match a with
    | [] -> []
    | [x] -> [f x]
    | x :: xs ->
      f x :: fmap f xs

// Example 3
module TaskFunctor = 

  let fmap f (a : System.Threading.Tasks.Task) =
    // todo