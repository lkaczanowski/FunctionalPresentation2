let flip f a b = f b a

// Example 1
module OptionApplicative = 

  let returnM a = Some a

  let apply f a =
    match f, a with
      | Some f, Some a -> f a |> returnM
      | None, Some _ -> None
      | Some _, None -> None
      | None, None -> None
      // can be reduced to _ -> None

module ListApplicative = 

  let returnM a = [a]

  let apply f a =
    f 
    |> List.map (fun fi -> a |> List.map (fi))
    |> List.collect id
    // can be replaced with one collect, or with list comprehention 

  let apply2 f a = 
    f
    |> List.collect (fun fi -> a |> List.map fi)

  let apply3 (f : ('a -> 'b) list) (a : 'a list) = 
    [ for fi in f do
        for ai in a do 
          yield fi ai ]

  let (<*>) = apply