# -*- coding: utf-8 -*-
"""Getting Started Python.ipynb

Automatically generated by Colaboratory.

Original file is located at
    https://colab.research.google.com/gist/yishizu/f4e735025320107cdb483748e67f97cd/getting-started-python.ipynb

# Pythonをはじめよう
"""

#四則演算
100+80

100-80

10*2

10/2

10%2

#べき乗
10**2

#変数を使う
a = 5
b = 10
a + b

#コメントの作り方
#をコメントの前に入れます

#Print 中身を確認
print(a)

#String
"Hello"

"Hello" + " " + "TAEC"

"!"*4

"""# Listとは

Listの作成
"""

[0,3,45, 4, 8]

list = ["a", "apple", "orange", "lemon"]

"""### Listの編集"""

listA = []

"""# 繰り返しの処理"""

a=0
for i in range(10):
  a= i**2
  print(a)

a = 0
for i in range(10):
 a= a+i
 print(a)
 
 
print("result:"+str(a))

list = ["apple","orange","lemon"]

for a in list:
  print(a)

for fruit in list:
  info = fruit+ ": 100yen"
  print(info)

for i, fruit in enumerate(list):
  print(str(i) + ":"+ fruit)

"""# 論理演算・条件分岐"""

a= 10
b =2
print(a>b)

print(a<b)

print(a==b)

print(a>=b)

print(a<=b)

"""ブール値"""

a = True
b = False

print(a and b)

print(a or b)

print (a is not b)

a =10
b = 2

if a<b:
  print("大きい")
else:
  print("小さい")