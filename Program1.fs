open System

// функция разворота числа
let Reverse n =
    let sign = if n < 0 then -1 else 1
    let rec loop num acc =
        if num = 0 then acc
        else loop (num / 10) (acc * 10 + (num % 10))
    sign * loop (abs n) 0

// функция генерации списка
let generate_list N =
    let ls = 
        [
            for i=1 to N do
            printf "Число (целочисленное): "
            let numb = int(Console.ReadLine())
            yield Reverse numb
        ]
    ls

[<EntryPoint>]
let main argv = 
    printf "Введите размер списка: "
    let size_list = int(Console.ReadLine())
    if size_list <= 0 then
        printfn "Неверный ввод"
    else
        let numb_list = generate_list size_list
        printf "Список: %A" numb_list
    0