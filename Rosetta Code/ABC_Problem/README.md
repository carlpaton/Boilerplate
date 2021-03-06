You are given a collection of ABC blocks  (maybe like the ones you had when you were a kid).

There are twenty blocks with two letters on each block.

A complete alphabet is guaranteed amongst all sides of the blocks.

The sample collection of blocks:

```
(B O)
(X K)
(D Q)
(C P)
(N A)
(G T)
(R E)
(T G)
(Q D)
(F S)
(J W)
(H U)
(V I)
(A N)
(O B)
(E R)
(F S)
(L Y)
(P C)
(Z M)
```

**Task**

Write a function that takes a string (word) and determines whether the word can be spelled with the given collection of blocks.


The rules are simple:

**Example**

```
>>> can_make_word("A")
True
>>> can_make_word("BARK")
True
>>> can_make_word("BOOK")
False
>>> can_make_word("TREAT")
True
>>> can_make_word("COMMON")
False
>>> can_make_word("SQUAD")
True
>>> can_make_word("CONFUSE")
True
```

The word `BARK` was made up using blocks as follows:
 
![Blocks Example](https://raw.githubusercontent.com/carlpaton/Boilerplate/master/Rosetta%20Code/ABC_Problem/blocks%20example.jpg)

### References

* http://rosettacode.org/wiki/ABC_Problem
