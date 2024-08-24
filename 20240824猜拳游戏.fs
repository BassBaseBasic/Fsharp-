open System
open System.Drawing


let rec public guess_part = fun e ->
    let mutable win : int = 0
    let mutable lose : int = 0
    let mutable draw : int = 0

    let random = new Random()
    let computer_num : int =(random.Next(1,4))
    System.Console.WriteLine("与计算器猜拳吧，输入数字出拳：1-剪刀；2-石头；3-布；")
    try
        let user_num = int (Console.ReadLine())
        if computer_num = 1 then
            match user_num with
            | 1 -> Console.WriteLine("你出了剪刀，电脑也出了剪刀，平局！")
                   draw <- draw + 1
            | 2 -> Console.WriteLine("你出了石头，电脑出了剪刀，你赢了！")
                   win <- win + 1
            | 3 -> Console.WriteLine("你出了布，电脑出了剪刀，你输了！")
                   lose <- lose + 1
         elif computer_num = 2 then
        // 换一种Match写法
            match user_num with
            |_ when (user_num = 1) -> Console.WriteLine("你出了剪刀，电脑出了石头，你输了！")
                                      lose <- lose + 1
            |_ when (user_num = 2) -> Console.WriteLine("你出了石头，电脑也出了石头，平局！")
                                      draw <- draw + 1
            |_ when (user_num = 3) -> Console.WriteLine("你出了布，电脑出了石头，你赢了！")
                                      win <- win + 1
        elif computer_num = 3 then
            match user_num with
            |_ when (user_num = 1) -> Console.WriteLine("你出了剪刀，电脑出了布，你赢了！")
                                      win <- win + 1
            |_ when (user_num = 2) -> Console.WriteLine("你出了石头，电脑出了布，你输了！")
                                      lose <- lose + 1
            |_ when (user_num = 3) -> Console.WriteLine("你出了布，电脑也出了布，平局！")
                                      draw <- draw + 1
    with 
        | :? FormatException -> Console.WriteLine("错误，你输入的不是数字！")
        | :? MatchFailureException -> Console.WriteLine("错误，请输入正确的数字！")
        | _ -> Console.WriteLine("未知错误！")
    do guess_part()

and main_part = fun e ->
    Console.WriteLine("欢迎使用猜拳小游戏，按任意键进入游戏！")
    Console.ReadKey()|>ignore
    do guess_part()


    
main_part()