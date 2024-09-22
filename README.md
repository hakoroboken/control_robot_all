# Contoroller_UI
Unityでコントローラーの出力結果をUDP通信で送信するプログラムです。

~~~mermaid
flowchart TD

subgraph 操作時
b1[通信せず 固定値 IP非ロック]-->c1{JOINボタン}
c1-->|IP,Portロック|b2[通信中 固定値 IPロック]
b1-->b3{IP Portボタン}
b3-->b9[通信せず 固定値 IP非ロック]
b9-->c1
b2-->c2{OKボタン}
b5-->c4{STOPボタン}
c2-->|コントローラー入力開始 IP,Portロック|b5[通信中 操作値 IPロック]
b5-->c7{IP Portボタン}
c7-->|ロック解除|b7[通信中 操作値 IP非ロック]
b7-->c4
b7-->c8{IP Portボタン}
c8-->|ロック|b5
c4-->|コントローラー入力停止|b6
b2-->c3{IP Portボタン}
c3-->|ロック解除|b6[通信中 固定値 IP非ロック]
b6-->c6{IP Portボタン}
c6-->|ロック|b2
b6-->c2
end

subgraph 起動時
a1[App ロゴ]-->|4s|a2[Unity ロゴ]
a2-->|3s|a3[待機画面]
a3-->|Controller,Keyboardの入力|a4[遷移画面]
a4-->|4s|a5[操作画面]
end
~~~
