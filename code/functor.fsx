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
  open System.Threading.Tasks

  let fmap (f : 'a -> 'b) (a : System.Threading.Tasks.Task<'a>) =
    if a.IsCompleted then
      let result = a.Result
      Task.FromResult(f result)
    else
      a.ContinueWith(continuationFunction = fun (next : Task<'a>) -> next.Result |> f)