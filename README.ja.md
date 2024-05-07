# 翠巒祭会計システム
- [English Version](./README.md)

[![CI/CD](https://github.com/mint73/suiran/actions/workflows/main.yml/badge.svg)](https://github.com/mint73/suiran/actions/workflows/main.yml)

高崎高校主催の学園祭「翠巒祭」の販売関係で使用する会計システムです。
[Blazor WebAssembly](https://blazor.net) で構築しています。

## 技術
- フレームワーク: Blazor wasm (.NET8)
- 構文: Razor (HTML + CSS + C#)

**動作方法**
1. [.NET CLIをインストール](https://learn.microsoft.com/ja-jp/dotnet/core/install/)
2. 対象ディレクトリに移動
```shell
$ cd suiran
```

3. アプリケーションをビルド
```shell
$ dotnet watch run
```

4. ブラウザでアクセス<br />
ローカルホスト: http://localhost:5291

## ライセンス
[MIT](./LICENSE)
