# Contoroller_UI
Unityでコントローラーの出力結果をUDP通信で送信するプログラムです。

~~~mermaid
flowchart TD

subgraph 操作時
b1[通信せず 固定値 IP非ロック]-->c1{JOINボタン}
c1-->|IP,Portロック|b2[通信 固定値 IPロック]
b1-->|数値入力|b3[IP,Port変更]
b3-->c1
b2-->c2{OKボタン}
b2-->c5{Leaveボタン}
c5-->b1
b5-->c4{STOPボタン}
c2-->b5[通信 操作値 IPロック]
b5-->c7{IP Portボタン}
c7-->b7[通信 操作値 IP非ロック]
b7-->c8{IP Portボタン}
c8-->b5
c4-->b2
b2-->c3{IP Portボタン}
c3-->b6[通信 固定値 IP非ロック]
b6-->c6{IP Portボタン}
c6-->b2
b6-->c5
b6-->c2
end

subgraph 起動時
a1[App ロゴ]-->|4s|a2[Unity ロゴ]
a2-->|3s|a3[待機画面]
a3-->|Controller,Keyboardの入力|a4[遷移画面]
a4-->|4s|a5[操作画面]
end
~~~
