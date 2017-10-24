// Basic 1
let doWork data callback = 
  if String.length data > 5 then
    callback data
  else 
    ()

// Basic 2
let rec forEach func (lst : 'a list) = 
  match lst with
  | [] -> ()
  | x :: xs -> 
    func x
    forEach func xs

let rec whereL pred lst = 
  match lst with
  | [] -> []
  | x :: xs ->
    if pred x then
      x :: whereL pred lst
    else
      whereL pred xs

let whereS pred lst = 
  seq { 
    for x in lst do
      if pred x then
        yield x
  }

// Basic 3 Before
type Book = string

let getFromDb id : Book = "book data"

let translate id =

  let book = getFromDb id

  String.map (fun _ -> 'b') book

// Basic 3 After
let translateAfter query id =

  let book : Book = query id

  String.map (fun _ -> 'b') book