open System

// 定义角色基本类
type Juese (name,atk,slutvalue) =
    class
        member val Name : string = name 
        member val ATK : int = atk with get,set
        member val SlutValue :int = slutvalue with get,set
        member this.ShowInfo()= fun _ ->
            Console.WriteLine("这个角色叫做{0},她的攻击力是：{1},当前淫乱值是：{2}。",name,atk,slutvalue)
    end

// 定义装备基本类
type Equipment (id,name,atk,slutvalue) =
    class
        member val ID : int = id with get,set
        member val Name : string = name with get,set
        member val ATK : int = atk with get,set
        member val SlutValue : int = slutvalue with get,set
        member this.ShowInformation () = fun _ ->
            Console.WriteLine("这件装备序号为{0}，装备名：{1}，攻击力：{2}，淫乱值加成：{3}。",id,name,atk,slutvalue)
    end

// 定义操作装备的函数
let rec put = fun (juese:Juese) (zhuangbei:Equipment) ->
    juese.ATK <- juese.ATK + zhuangbei.ATK
    juese.SlutValue <- juese.SlutValue + zhuangbei.SlutValue

let rec Main = fun e ->
    Console.WriteLine("请输入角色名字：")
    try
        let charname = Console.ReadLine()
        Console.WriteLine("请输入角色初始攻击力：")
        let source_atk = int (Console.ReadLine())
        Console.WriteLine("请输入角色初始淫乱值：")
        let source_slutvalue = int (Console.ReadLine())
        let char = new Juese(charname,source_atk,source_slutvalue)
        Console.WriteLine("生成角色成功！")
        char.ShowInfo 
        let sexy_bra = new Equipment(1,"情趣文胸",10,20)
        Console.WriteLine("请问是否为角色装备“情趣文胸”？【y/n】")
        let answer : string = Console.ReadLine().ToUpper()
        if answer = "Y" then
            do put char sexy_bra
            Console.WriteLine("这个角色叫做{0},她的攻击力是：{1},当前淫乱值是：{2}。",char.Name,char.ATK,char.SlutValue)
        elif answer = "N" then
            Console.WriteLine("这个角色叫做{0},她的攻击力是：{1},当前淫乱值是：{2}。",char.Name,char.ATK,char.SlutValue)
            do Main()
    with
        | :? FormatException -> Console.WriteLine("错误，请输入正确的字符。")
                                do Main()
        | _ -> Console.WriteLine("未知错误，返回程序入口点。")
               do Main()

[<EntryPoint>] 
Main()
