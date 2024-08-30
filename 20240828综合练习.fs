open Microsoft.VisualBasic

let the_Highest_Truth = "Lewd Virino Meritas Lauxdon."

open System
open System.Windows.Forms
open System.Drawing
open Microsoft.FSharp.NativeInterop

// 定义角色基本类
type char (name,age,atk) =
    class
        member val Name : string = name with get,set
        member val Age : int = age with get,set
        member val ATK : int = atk with get,set
        member this.ShowInfo = fun _ ->
            Console.WriteLine("这个角色叫做{0}，年龄是{1}，当前攻击力为{2}.",name,age,atk)
    end

// 定义装备基本类
type equipment (id,name,atk_add) = 
    class
        member val Name : string = name with get,set
        member val ID : int = id with get,set
        member val ATK_add : int = atk_add with get,set
        member this.EquipInfo = fun _ ->
            Console.WriteLine("装备ID{0}，装备名称{1}，增加攻击力{2}.",id,name,atk_add)
    end

// 定义操作装备属性的函数
let put_equip (Char:char,Equip:equipment) =
    Char.ATK <- Char.ATK + Equip.ATK_add


// 条件判断部分
let rec Panduan_Part = fun e ->
    Console.WriteLine("这是条件判断部分，请输入一个数字，与10比较大小：")
    try
        let enter_num = int (Console.ReadLine())
        match enter_num with
            | _ when (enter_num = 10) -> Console.WriteLine("这个数字等于10.")
            | _ when (enter_num < 10) -> Console.WriteLine("这个数字小于10.")
            | _ when (enter_num > 10) -> Console.WriteLine("这个数字大于10.")
    with
        | :? FormatException -> Console.WriteLine("错误，你输入的不是数字！")
                                do Panduan_Part()
        | _ -> Console.WriteLine("未知错误！")
               do Panduan_Part()
    do Panduan_Part_Select()

    
// 条件判断的退出选择部分    
and Panduan_Part_Select = fun _ ->    
    Console.WriteLine("要继续使用该部分吗：Y-继续使用；N-返回上一页面。")
    try
        let enter_string : string = Console.ReadLine().ToUpper()
        if enter_string = "Y" then
            do Panduan_Part()
        elif enter_string = "N" then
            do Main_Part() 
        else
            Console.WriteLine("错误，请重新输入指令！")
            do Panduan_Part_Select()
    with
        | _ -> Console.WriteLine("未知错误！")
               do Panduan_Part_Select()

// WinForm生成部分
and WinForm_Part = fun _ ->
    let testform = new Windows.Forms.Form()
    testform.Text <- "示例窗口"
    testform.MouseClick.Add(fun _ ->
        MessageBox.Show("这是一个弹出信息。")
        |>ignore
    )
    do testform.ShowDialog() |> ignore
    do WinForm_Part_Select()

 // WinForm生成部分的退出选择部分
 and WinForm_Part_Select = fun _ ->    
     Console.WriteLine("要继续使用该部分吗：Y-继续使用；N-返回上一页面。")
     let enter_string : string = Console.ReadLine().ToUpper()
     if enter_string = "Y" then
         do WinForm_Part()
     elif enter_string = "N" then
         do Main_Part()
     else
         Console.WriteLine("错误，请重新输入指令！")
         do WinForm_Part_Select()

// 装备操作部分
and ZhuangBei = fun _ ->
    Console.WriteLine("这里是装备操作部分，请输入您的角色名。")
    let enter_name = Console.ReadLine()
    let Juese = new char(enter_name,18,10)
    let SexyBra = new equipment(1,"Transparent Bra",50)
    do Juese.ShowInfo()
    Console.WriteLine("这里现有一件装备，信息如下，请问是否需要装备到{0}身上？y/n",Juese.Name)
    do SexyBra.EquipInfo()
    let choice : string = Console.ReadLine().ToUpper()
    if choice = "Y" then
        do put_equip(Juese,SexyBra)
        Console.WriteLine("装备完成，现在角色的攻击力为：{0}。",Juese.ATK)
    elif choice = "是" then
        do put_equip(Juese,SexyBra)
        Console.WriteLine("装备完成，现在角色的攻击力为：{0}。",Juese.ATK)
    elif choice = "N" then
        Console.WriteLine("未装备，现在角色的攻击力为：{0}。",Juese.ATK)
    elif choice = "否" then
        Console.WriteLine("未装备，现在角色的攻击力为：{0}。",Juese.ATK)
    else
        Console.WriteLine("错误，请输入正确的指令。")
        do ZhuangBei()
    do ZhuangBei_Select()
    
// 装备操作的退出选择部分
and ZhuangBei_Select = fun _ ->
    Console.WriteLine("要继续使用该部分吗：Y-继续使用；N-返回上一页面。")
    let enter_string : string = Console.ReadLine().ToUpper()
    if enter_string = "Y" then
        do ZhuangBei()
    elif enter_string = "N" then
        do Main_Part()
    else
        Console.WriteLine("错误，请重新输入指令！")
        do ZhuangBei_Select()
 

and Main_Part = fun e ->
    Console.WriteLine("这里是主部分，请输入数字进入相应部分：1-条件判断；2-WinForm；3-装备操作。")
    try
        let choice : int = int (Console.ReadLine())
        match choice with
        | 1 -> do Panduan_Part()
        | 2 -> do WinForm_Part()
        | 3 -> do ZhuangBei()
    with
        | :? FormatException -> Console.WriteLine("错误，你输入的不是数字！")
                                do Main_Part()
        | :? MatchFailureException -> Console.WriteLine("错误，请输入正确的数字1-3！")
                                      do Main_Part()
        | _ -> Console.WriteLine("未知错误，重新调用本函数。")
               do Main_Part()

[<EntryPoint>]
Main_Part()

// 完成于公司电脑 2024年8月28日10:28:37。Visual Studio 2019 Enterprise.