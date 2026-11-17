# 引き継ぎ資料（日本語版 1.6.0）

作業日: 2026-11-17。ブランチ: `ja-edition`（`main` = LED-N 1.5.1 + content.json 更新 から分岐）。

## 目的

`C:\Users\Administrator\Downloads\Fortnite-ChestCounter-main`（1.3.0 ベースのコンソール版。日本語・試合時間・平均・効率・`M` キーの履歴編集を実装済み）の機能を、ウィンドウ UI になった最新の 1.5.1 に移植した日本語版。

## 実装内容

| 機能 | 主な場所 |
|---|---|
| 日本語 | `Lang.cs`（`L.T(fr, en, es, ja)`・`L.Count(..., ja)` は `{0}` 入りの助数詞パターン・`L.Ja`・`L.WeekName`・`L.Duration`・12時間制は「午後 10:54」順）。全ファイルの `L.T` に第4引数を追加。`NativeOverlay` は日本語時に Yu Gothic UI。`Updater.ReleaseNotes` は `**日本語**` セクション、`content.json` の notice は `ja` キーも読む（なければ英語） |
| 試合時間・平均・効率 | `MatchHistory.cs` の `MatchStats`（平均試合時間・1分あたりの宝箱・効率 `Of`／全試合一括 `OfAll`）。効率は同じプロフィールで開始時刻が厳密に前の試合だけを基準にし、`chests × seconds` で厳密比較 |
| 履歴編集 | `MatchHistory`（`Adjust`／`ResetAdjust`／`Delete`／`Restore`／`CarryOver`）。`MatchRecord.ManualChestsAdded`（`ChestsOpened` に含む）、`MatchRecord.DeletedUtc`、`TrackerData.DeletedMatches` |
| 再解析時の扱い | `Tracker.Process`: 削除済みの SessionId は再追加せず（新しい解析結果は削除済みコピーに反映）、既存試合の再解析では手動補正を引き継ぐ |
| ウィンドウ | `GuiPage.cs` に「履歴」タブ（一覧25件ずつ・鉛筆で編集ダイアログ・削除済み一覧と復元）。ホームに平均試合時間タイルと前回の試合時間。アクション `matchAdjust`／`matchReset`／`matchDelete`／`matchRestore`（`Program.cs`） |
| レポート・CSV | 平均試合時間・1分あたりの宝箱タイル、試合一覧に「試合時間」「効率」列と ✎ 印。CSV は末尾に `duration_s;chests_by_hand;chests_per_minute`（日本語は `試合時間_秒;手動補正;1分あたりの宝箱`）。今週の確率には、その週の試合への手動補正も含める |
| 配布先 | `AppInfo.Repo` = `cherjp/Fortnite-ChestCounter`（アップデート・問題報告）。`AppInfo.ContentRepo` = `LED-N/Fortnite-ChestCounter`（毎週更新される content.json とお宝画像）。バージョン 1.6.0 |

旧版にあった「合計だけに宝箱を加算（TotalOnlyChests）」は、1.5.1 の「宝箱の合計」の鉛筆（手動追加の履歴付き）と同じ役割なので移植していない。旧版の復号鍵まわりの修正は、1.5.1 側にリプレイヘッダーの鍵チェック（`ReplayHeaderProbe.KeyMissing`）があるため移植していない。

## 翻訳の追加方法

新しい文言は `L.T("français", "English", "español", "日本語")` と書く。日本語を省くと英語が表示される。一括で日本語を差し込んだときのツール（Roslyn で 3 引数の `L.T` を抽出・挿入）はスクラッチ領域に置いたもので、リポジトリには含めていない。抜けの確認は回帰テストの「Every text of the window in Japanese」で行える（ウィンドウの文言のみ）。

## 検証

```
dotnet run --project tests/Regression -c Release     # 50 passed, 0 failed
dotnet build src/ChestCounter/ChestCounter.csproj -c Release
```

- サンプル履歴（13試合・補正1件・削除1件）で `--once --lang ja` を実行し、日本語レポートと CSV を生成、Edge ヘッドレスで目視確認
- `CHESTCOUNTER_GUI_URL_FILE` でウィンドウの URL を出させ、ブラウザペインで履歴タブを操作: +5 補正 → 合計・効率・平均が再計算、削除 → 合計から除外・削除一覧に表示、復元 → 補正を保ったまま復帰、ホームの新タイルを確認
- 実リプレイでの解析と、WebView2 のウィンドウ自体での表示は今回未確認

## オーバーレイのカード型（1.6.0 リリース後に追加、未リリース）

`NativeOverlay` に既定スタイル `card` を追加（`RelayoutCard`／`PaintCard`）。左にアプリのアイコン（exe のリソース 32512 を `LoadImageW`、読めなければ GDI の宝箱）、右に見出し＋線、大きな合計、区切り線の右に 前回・セッション・（チーム）・お宝。OBS 用 `overlay.html` も同じ見た目（`ReportWriter.OverlayCard`）。新規設定の既定は `card`、既存の設定は変更しない。プレビューは `--overlay-preview <file.png>` で全スタイル×3状態を出力できる。

ユーザーから、宝箱の絵を Fortnite 本体のアイコン（金の宝箱）にしたいと依頼あり。FModel MCP は Fortnite [LIVE] に非対応で、現行版の `C:\Program Files\Epic Games\Fortnite`（43.10）は MCP の入力許可リスト外のため未着手。ユーザーが FModel デスクトップ版で PNG を書き出すことになった。受け皿として `ChestPicture`（データフォルダーの `overlay-chest.png`）を実装済み: `NativeOverlay.ChestPictureAt` が System.Drawing で縮小して描き、OBS ページは data: URI で埋め込む。ゲームのアセットはリポジトリにも exe にも同梱しない方針（Epic の画像のため、各自の PC にだけ置く）。

その後 FModel MCP で発見: `FortniteGame/Plugins/GameFeatures/DelilahTreasureHuntShared/Content/Assets/Icons/T_UI_DelilahTreasureHunt_ItemGeneric`（128×128、DXT5、`pakchunk50-WindowsClient.utoc` で暗号化なし）。開き方: ディレクトリ `C:\Program Files\Epic Games\Fortnite\FortniteGame\Content\Paks`、`GAME_UE5_LATEST`、AES キーなし、mappings は 43.00 の usmap（43.10 の usmap は v5 で MCP 1.1.1 の解析器が非対応）。FModel の設定に「Fortnite [LIVE]」の項目が残っていると `list_saved_games`／`open_saved_game` が「directory is not absolute」で失敗するため `open_game` を直接使った。PNG はユーザーの `%APPDATA%\ChestCounter\overlay-chest.png` に配置済み。

## 残っていること

- `README.fr.md`／`README.es.md` は言語リンクの追加のみ（履歴タブの説明は英語・日本語の README のみ）
- GitHub への push、`cherjp/Fortnite-ChestCounter` でのリリース作成（`v1.6.0` タグを push すると Actions が exe を添付）は未実施
