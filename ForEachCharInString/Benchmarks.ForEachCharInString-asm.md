## .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
```assembly
; Benchmarks.ForEachCharInString.CharInString()
       xor       eax,eax
       mov       rdx,[rcx+8]
       xor       ecx,ecx
       mov       r8d,[rdx+8]
       test      r8d,r8d
       jle       short M00_L01
M00_L00:
       mov       r9d,ecx
       movzx     r9d,word ptr [rdx+r9*2+0C]
       mov       r10d,eax
       shl       r10d,5
       add       r10d,eax
       add       r10d,r9d
       shl       r9d,7
       lea       eax,[r10+r9]
       inc       ecx
       cmp       r8d,ecx
       jg        short M00_L00
M00_L01:
       mov       edx,eax
       sar       edx,10
       xor       eax,edx
       and       eax,0FFFF
       ret
; Total bytes of code 67
```

## .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
```assembly
; Benchmarks.ForEachCharInString.CharInSpan()
       xor       eax,eax
       mov       rdx,[rcx+8]
       test      rdx,rdx
       je        short M00_L03
       lea       rcx,[rdx+0C]
       mov       r8d,[rdx+8]
M00_L00:
       xor       edx,edx
       test      r8d,r8d
       jle       short M00_L02
M00_L01:
       mov       r9d,edx
       movzx     r9d,word ptr [rcx+r9*2]
       mov       r10d,eax
       shl       r10d,5
       add       r10d,eax
       add       r10d,r9d
       shl       r9d,7
       lea       eax,[r10+r9]
       inc       edx
       cmp       edx,r8d
       jl        short M00_L01
M00_L02:
       mov       edx,eax
       sar       edx,10
       xor       eax,edx
       and       eax,0FFFF
       ret
M00_L03:
       xor       ecx,ecx
       xor       r8d,r8d
       jmp       short M00_L00
; Total bytes of code 82
```

## .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
```assembly
; Benchmarks.ForEachCharInString.CharInPinnedString()
       push      rax
       xor       eax,eax
       mov       [rsp],rax
       xor       eax,eax
       mov       rdx,[rcx+8]
       mov       rcx,rdx
       test      rcx,rcx
       jne       short M00_L00
       xor       r8d,r8d
       jmp       short M00_L01
M00_L00:
       add       rcx,0C
       mov       [rsp],rcx
       mov       r8,[rsp]
M00_L01:
       mov       edx,[rdx+8]
       xor       ecx,ecx
       test      edx,edx
       jle       short M00_L03
M00_L02:
       movsxd    r9,ecx
       movzx     r9d,word ptr [r8+r9*2]
       mov       r10d,eax
       shl       r10d,5
       add       r10d,eax
       add       r10d,r9d
       shl       r9d,7
       lea       eax,[r10+r9]
       inc       ecx
       cmp       ecx,edx
       jl        short M00_L02
M00_L03:
       xor       edx,edx
       mov       [rsp],rdx
       mov       edx,eax
       sar       edx,10
       xor       eax,edx
       and       eax,0FFFF
       add       rsp,8
       ret
; Total bytes of code 105
```

## .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
```assembly
; Benchmarks.ForEachCharInString.CharInPinnedString_NoIteratorVar()
       push      rax
       xor       eax,eax
       mov       [rsp],rax
       xor       eax,eax
       mov       rdx,[rcx+8]
       mov       rcx,rdx
       test      rcx,rcx
       jne       short M00_L00
       xor       r8d,r8d
       jmp       short M00_L01
M00_L00:
       add       rcx,0C
       mov       [rsp],rcx
       mov       r8,[rsp]
M00_L01:
       mov       edx,[rdx+8]
       xor       ecx,ecx
       test      edx,edx
       jle       short M00_L03
M00_L02:
       mov       r9d,eax
       shl       r9d,5
       add       r9d,eax
       movsxd    rax,ecx
       movzx     eax,word ptr [r8+rax*2]
       add       r9d,eax
       shl       eax,7
       add       eax,r9d
       inc       ecx
       cmp       ecx,edx
       jl        short M00_L02
M00_L03:
       xor       edx,edx
       mov       [rsp],rdx
       mov       edx,eax
       sar       edx,10
       xor       eax,edx
       and       eax,0FFFF
       add       rsp,8
       ret
; Total bytes of code 103
```

## .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
```assembly
; Benchmarks.ForEachCharInString.CharInPinnedString_LengthInCondition()
       push      rax
       xor       eax,eax
       mov       [rsp],rax
       xor       eax,eax
       mov       rdx,[rcx+8]
       mov       rcx,rdx
       test      rcx,rcx
       jne       short M00_L00
       xor       r8d,r8d
       jmp       short M00_L01
M00_L00:
       add       rcx,0C
       mov       [rsp],rcx
       mov       r8,[rsp]
M00_L01:
       xor       ecx,ecx
       cmp       dword ptr [rdx+8],0
       jle       short M00_L03
M00_L02:
       movsxd    r9,ecx
       movzx     r9d,word ptr [r8+r9*2]
       mov       r10d,eax
       shl       r10d,5
       add       r10d,eax
       add       r10d,r9d
       shl       r9d,7
       lea       eax,[r10+r9]
       inc       ecx
       cmp       [rdx+8],ecx
       jg        short M00_L02
M00_L03:
       xor       edx,edx
       mov       [rsp],rdx
       mov       edx,eax
       sar       edx,10
       xor       eax,edx
       and       eax,0FFFF
       add       rsp,8
       ret
; Total bytes of code 105
```

## .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
```assembly
; Benchmarks.ForEachCharInString.CharInPinnedString_LengthInCondition_NoIteratorVar()
       push      rax
       xor       eax,eax
       mov       [rsp],rax
       xor       eax,eax
       mov       rdx,[rcx+8]
       mov       rcx,rdx
       test      rcx,rcx
       jne       short M00_L00
       xor       r8d,r8d
       jmp       short M00_L01
M00_L00:
       add       rcx,0C
       mov       [rsp],rcx
       mov       r8,[rsp]
M00_L01:
       xor       ecx,ecx
       cmp       dword ptr [rdx+8],0
       jle       short M00_L03
M00_L02:
       mov       r9d,eax
       shl       r9d,5
       add       r9d,eax
       movsxd    rax,ecx
       movzx     eax,word ptr [r8+rax*2]
       add       r9d,eax
       shl       eax,7
       add       eax,r9d
       inc       ecx
       cmp       [rdx+8],ecx
       jg        short M00_L02
M00_L03:
       xor       edx,edx
       mov       [rsp],rdx
       mov       edx,eax
       sar       edx,10
       xor       eax,edx
       and       eax,0FFFF
       add       rsp,8
       ret
; Total bytes of code 103
```

