_start:                    
	mov [256d], 0d
	mov ebx, 1d

LOOPSTAGE:
	inc eax
	cmp [256d], 10d
	jz InvertMeandr
	jmp LOOPSTAGE
InvertMeandr:
	not ebx
	mov [256d], 0d
	jmp LOOPSTAGE