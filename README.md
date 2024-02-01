# Suiran Accounting System / 翠巒祭会計システム
[![Blazor wasm](https://github.com/mint73/suiran/actions/workflows/main.yml/badge.svg)](https://github.com/mint73/suiran/actions/workflows/main.yml)

## Summary / 概要
This is accounting system for the school festival (customer side). / 高崎高校主催の学園祭「翠巒祭」の販売関係で使用する会計システム

## Tech / 技術
- Framework / フレームワーク: Blazor wasm (.NET8)
- Syntax / 構文: Razor(HTML + CSS + C#)

**How to develop this application / 動作方法**
1. Install dotnet command / dotnetコマンドをインストール<br />
(English: https://learn.microsoft.com/en-us/dotnet/core/install/ <br />
日本語: https://learn.microsoft.com/ja-jp/dotnet/core/install/)

2. Move to target directry / 対象ディレクトリに移動
```shell
$ cd suiran
```

3. Build this application / アプリケーションをビルド
```shell
$ dotnet watch run --pathbase=/suiran
```

4. Access on your brouser / ブラウザでアクセス<br />
Local Host / ローカルホスト: http://localhost:5291/suiran
