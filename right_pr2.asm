_start:
    jmp Ini_I

Ini_I:
    mov eax, n;иницивлизация i
    jmp Ini_J

Ini_J:
    mov ebx, 0;иницивлизация j
    jmp If_State

I_Loop:
    jmp Ini_J

I_End:
    dec eax; декремент i 
    push eax
    push 0
    cmp; i > 0
    ja Ini_J;начать новую итерацию j-цикла
    jbe Exit;завершить сортировку

J_End:
    inc ebx;инкремент j
    push eax
    push ebx
    cmp; j < i
    ja If_State;снова if
    jbe I_End;новая итерация i-цикла

If_State:
    mov ecx, ebx; tmp
    inc ecx
    push [ebx]
    push [ecx]
    cmp;сравнить a[j] и a[j + 1]
    ja Swap
    jbe J_End

Swap:
    push [ebx]
    push [ecx]
    pop [ebx]
    pop [ecx];поменять местами
    jmp J_End

Exit:
    nop