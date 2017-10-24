// Basic 1
let add x y = x + y

let times n x = n * x

let add3Times5 = add 3 >> times 5

let addNTimes5 x = add x >> times 5

// Basic 2
let capitalize (x : string) = x.ToUpper ()

let trim (x : string) = x.Trim ()

let remove c (x : string) = x.Replace(c, "")

let normalize = trim >> remove "-" >> capitalize

// Basic 3
type SendNotificationRequest = 
  { Id: string
    ReportId : int }

type Report =
  { Id : int
    Data : string }

type Notification = 
  { From : string
    Body : string }

let getReports id = [ { Id = id; Data = "text" } ]

let buildNotification reports = { From = "test"; Body = (List.head reports).Data }

let sendNotification notification = ()

let handleInternal = 
  getReports
  >> buildNotification
  >> sendNotification

let handle request = 
  handleInternal request.ReportId