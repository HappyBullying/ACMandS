_start:
    mov [0], 16
    mov [1], 4
    mov [2], 3
    mov [3], 11
    mov [4], 1
    mov [5], 15
    mov [6], 7
    mov [7], 8
    mov [8], 2
    mov [9], 5
    mov [10], 10
    mov [11], 9
    mov [12], 6
    mov [13], 13
    mov [14], 12
    mov [15], 0
    mov [16], 14

    jmp Ini_I

Ini_I:
    mov eax, 16d
    jmp Ini_J

Ini_J:
    mov ebx, 1d
    jmp If_State

I_Loop:
    jmp Ini_J

I_End:
    dec eax
    push eax
    push 0d
    cmp
    ja Ini_J
    jbe Exit

J_End:
    inc ebx
    push eax
    push ebx
    cmp
    ja If_State
    jbe I_End

If_State:
    mov ecx, ebx
    inc ecx
    push [ebx]
    push [ecx]
    cmp
    ja Swap
    jbe J_End

Swap:
    push [ebx]
    push [ecx]
    pop [ebx]
    pop [ecx]
    jmp J_End

Exit:
    nop