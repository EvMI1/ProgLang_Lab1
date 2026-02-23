open System

let rec count_even n cnt = 
    if n = 0 then
        cnt
    else
        if (n%10)%2 = 0 then
            count_even (n/10) (cnt+1)
        else
            count_even (n/10) cnt

[<EntryPoint>]
let main _ =
    printf "Введите целочисленное число: "
    let numb = int(Console.ReadLine())
    if numb <= 0 then
        printfn "Не является натуральным числом"
    else
        printf "Кол-во чётных цифр в записи числа %i = %i" numb (count_even numb 0)
    0