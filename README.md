# Contoroller_UI
Unityでコントローラーの出力結果をUDP通信で送信するプログラムです。

~~~mermaid
flowchart TD

subgraph 操作時
b1[通信せず 固定値 IP非ロック]-->c1{JOINボタン}
c1-->b2[通信中 固定値 IP非ロック]
b2-->c2{OKボタン}
b3[通信中 操作値 IPロック]-->c3{STOPボタン}
c2-->|コントローラー入力開始 IP,Portロック|b3
c3-->|コントローラー入力停止 IP,Portロック解除|b2
end

subgraph 起動時
a1[App ロゴ]-->|4s|a2[Unity ロゴ]
a2-->|3s|a3[待機画面]
a3-->|Controller,Keyboardの入力|a4[遷移画面]
a4-->|4s|a5[操作画面]
end
~~~