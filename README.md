# Chat-Chan
[![Build status](https://ci.appveyor.com/api/projects/status/xhc2xw33o1wh0f1l?svg=true)](https://ci.appveyor.com/project/P2PDevelop/chat-chan)
[![GitHub license](https://img.shields.io/github/license/P2P-Develop/Chat-Chan)](https://github.com/P2P-Develop/Chat-Chan/blob/master/LICENSE)
[![GitHub issues](https://img.shields.io/github/issues/P2P-Develop/Chat-Chan)](https://github.com/P2P-Develop/Chat-Chan/issues)
[![Maintainability](https://api.codeclimate.com/v1/badges/63fa91616c0b24aa5a24/maintainability)](https://codeclimate.com/github/P2P-Develop/Chat-Chan/maintainability)
## 概要
Linux風コンソールとユーザーチャットを組み合わせた新しいチャットアプリケーションです。  
Alpha版としてリリース予定です。
## 機能(予定)
- ユーザーチャット機能  
  ユーザーチャットによりコンソールで送信しないことを別で送信することができます。
- コンソールカラライズ機能  
  コンソールを色分けして表示します。
- 個人サーバー機能  
  個人で自由にサーバーを開くことができます。
## 使い方
### クライアント(本リポジトリ)
- exeファイルを起動して中央のテキストボックスにサーバーIPアドレス、またはホストを入力して接続ボタンを押してください。
- 左のテキストボックスにはbashのホスト名のような事が書けます。送信した時にテキストが消えません。
- 中央のテキストボックスに本文を記入します。改行可能です。送信した際にテキストが消える仕様です。
- 右のテキストボックスにユーザーチャットを入力します。コンソールとは別のメッセージとして送信することができます。
### サーバー
#### アプリケーションの使用には、専用の[サーバー](https://github.com/P2P-Develop/Chat-Chan-Server)が必要です。
