open System

type complex_numb = {real: float; im : float}

let InputComplex() : complex_numb =
    printf "Действительная часть: "
    let r = float(Console.ReadLine())
    printf "Мнимая часть: "
    let i = float(Console.ReadLine())
    {real = r; im = i}

let PrintComplex (numb:complex_numb) = 
    if numb.im < 0.0 then
        printfn "%f - %fi" (numb.real) (abs numb.im)
    elif numb.im = 0.0 then
        printfn "%f" (numb.real)
    elif numb.real = 0.0 then
        printfn "%fi" (numb.im)
    else
        printfn "%f + %fi" (numb.real) (numb.im)

let add (n1 : complex_numb) (n2 : complex_numb) : complex_numb =
    {real = n1.real + n2.real; im = n1.im + n2.im}

let sub (n1 : complex_numb) (n2 : complex_numb) : complex_numb =
    {real = n1.real - n2.real; im = n1.im - n2.im}

let multiply (n1 : complex_numb) (n2 : complex_numb) : complex_numb =
    {real = n1.real * n2.real - n1.im * n2.im;
    im = n1.real * n2.im + n1.im * n2.real}

let divide (a: complex_numb) (b: complex_numb) : complex_numb =
    let denom = b.real * b.real + b.im * b.im
    if denom = 0.0 then
        printfn "Ошибка: деление на ноль!"
        {real = 0.0; im = 0.0}
    else
        {real = (a.real * b.real + a.im * b.im) / denom;
          im = (a.im * b.real - a.real * b.im) / denom}

let rec power (numb: complex_numb) (n: int) : complex_numb =
    if n < 0 then
        printfn "Ошибка: степень должна быть неотрицательной"
        {real = 0.0; im = 0.0}
    elif n = 0 then {real = 1.0; im = 0.0}
    elif n = 1 then numb
    else
        let p = power numb (n / 2)
        let p2 = multiply p p
        if n % 2 = 0 then p2 else multiply numb p2

[<EntryPoint>]
let main _ =
    printfn "Введите первое число"
    let numb1 : complex_numb = InputComplex()
    PrintComplex numb1
    printfn "\nВведите второе число"
    let numb2 : complex_numb = InputComplex()
    PrintComplex numb2
    printfn "\n___Операции с комплексными числами___"
    printf "Сложение: "
    PrintComplex (add numb1 numb2)
    printf "\nВычитание: "
    PrintComplex (sub numb1 numb2)
    printf "\nУмножение: "
    PrintComplex (multiply numb1 numb2)
    printf "\nДеление: "
    PrintComplex (divide numb1 numb2)
    printf "\n\nКакое число возвести в степень? (1 - первое, 2 - второе): "
    let choice = int(Console.ReadLine())
    printf "Введите степень: "
    let n = int(Console.ReadLine())
    printf "Возведение в степень: "
    if choice = 1 then
        PrintComplex (power numb1 n)
    elif choice = 2 then
        PrintComplex (power numb2 n)
    else
        printfn "Некорректный выбор!"
    0