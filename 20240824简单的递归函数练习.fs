// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
// See the 'F# Tutorial' project for more help.

let public truth : string = "Lewd Virino Meritas Lauxdon."

// Define a function to construct a message to print


open System
open System.Windows.Forms
open System.Drawing

let rec public tiaojianpanduan = fun e ->
    Console.WriteLine("这里是条件判断部分，请输入一个数字，与0比较！")
    let mutable enterword : string = Console.ReadLine()
    
    try
        let mutable trans : int = int enterword
        if trans = 0 then
            Console.WriteLine("这个数字等于0！")
        elif trans < 0 then
            Console.WriteLine("这个数字小于0！")
        elif trans > 0 then
            Console.WriteLine("这个数字大于0！")
    with
        | :? FormatException -> Console.WriteLine("错误，请输入数字！") 
                                do tiaojianpanduan() 
        | _ -> Console.WriteLine("未知错误！") 
               do tiaojianpanduan()
    let rec yesornoPART args = 
        Console.WriteLine("需要继续使用本模块吗？Y/N")
        let yes_or_no : string = Console.ReadLine()
        let yes_or_no' = yes_or_no.ToUpper()
        match yes_or_no' with
            | _ when ( yes_or_no'= "Y" ) -> do tiaojianpanduan()
            | _ when ( yes_or_no' = "N") -> Console.WriteLine("感谢使用，按任意键返回主模块。")
                                            Console.ReadKey() |>ignore
                                            main_part()
            | _ -> Console.WriteLine("错误！请输入正确指令！")
                   do yesornoPART()
    yesornoPART()                                    
     


and winform_part  = fun e -> 
    let test_form = new Windows.Forms.Form()
    test_form.Text <- "这是一个窗口"
    test_form.MouseClick.Add (fun e -> MessageBox.Show("这是一个弹出的窗口。%s","1")|>ignore)
    let run' = fun e -> test_form.ShowDialog()
    let rec yesornoPART'winform args = 
        Console.WriteLine("需要继续使用本模块吗？Y/N")
        let yes_or_no : string = Console.ReadLine()
        let yes_or_no' = yes_or_no.ToUpper()
        match yes_or_no' with
            | "Y" -> do winform_part()
            | _ when ( yes_or_no' = "N") -> Console.WriteLine("感谢使用，按任意键返回主模块。")
                                            Console.ReadKey() |>ignore
                                            main_part()
            | _ -> Console.WriteLine("错误！请输入正确指令！")
                   do yesornoPART'winform()
    do run'() |>ignore
    do yesornoPART'winform()

and main_part = fun e ->
    Console.WriteLine("输入数字来进入相应功能：1-条件判断；2-窗口创建；")
    let choice = Console.ReadLine()
    match choice with
    | "1" -> tiaojianpanduan()
    | "2" -> winform_part()|>ignore
    | _ ->  Console.WriteLine("无效输入，请重新输入！")
            main_part()

[<EntryPoint>]
main_part()
