# 翠巒祭 販売システム
- [English Version](./README.md)

[![CI/CD](https://github.com/mint73/suiran/actions/workflows/main.yml/badge.svg)](https://github.com/mint73/suiran/actions/workflows/main.yml)

高崎高校主催の文化祭「翠巒祭」の模擬店での販売で、お客様が使用する会計用のシステムです。 [Blazor WebAssembly](https://blazor.net) で構築しています。

## 技術
- フレームワーク: Blazor wasm (.NET8)
- 構文: Razor (HTML + CSS + C#)

**動作方法**
1. [*.NET CLI* をインストール](https://learn.microsoft.com/ja-jp/dotnet/core/install/)

1. *wasm-tools* をインストール
    ```shell
    $ dotnet workload install wasm-tools
    ```
1. 対象ディレクトリに移動
    ```shell
    $ cd suiran
    ```

1. アプリケーションをビルド
    ```shell
    $ dotnet watch run
    ```

1. ブラウザでアクセス  
ローカルホスト: http://localhost:5291

## ライセンス
[MIT ライセンス](./LICENSE)の下にライセンスされています。
