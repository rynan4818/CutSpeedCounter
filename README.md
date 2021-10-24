# CutSpeedCounter
このBeatSaberプラグインは、ノーツカットのスピード[km/h]の平均値を表示する[CountersPlus](https://github.com/Caeden117/CountersPlus)用のカスタムカウンターです。

[BeatSaviorData](https://github.com/Mystogan98/BeatSaviorData)のリザルト画面で表示されるセイバー速度と同じ値になります。

# インストール方法
1. [リリースページ](https://github.com/rynan4818/CutSpeedCounter/releases)から最新のリリースをダウンロードします。

2. ダウンロードしたzipファイルをBeat Saberフォルダに解凍して、`Plugin`フォルダに`CutSpeedCounter.dll`ファイルをコピーします。
    
3. このmodは以下のプラグインに依存するため、[ModAssistant](https://github.com/Assistant/ModAssistant)でインストールして下さい。

    - BSIPA
    - BeatSaberMarkupLanguage
    - [CountersPlus](https://github.com/Caeden117/CountersPlus)
    
    それぞれの依存modの対応バージョンは[manifest.json](https://github.com/rynan4818/CutSpeedCounter/blob/main/CutSpeedCounter/manifest.json)の`dependsOn`項目を参照下さい。

# 使用方法
modをインストールすると、COUNTERS+の設定画面にCut Speed Counterが追加されますので、表示位置や詳細設定をして使用してください。
Cut Speed Counter特有の設定値は以下の通りです。
|項目|説明|
|:---|:---|
|SeparateSaber|左右のセイバーを分けて表示|
|DecimalPrecision|小数点以下を表示する桁数|
|EnableLabel|ラベル(Average Cut Speed)の表示|
|LabelFontSize|ラベルのフォントサイズ|
|FigureFontSize|カウンターのフォントサイズ|
|OffsetX|カウンターのX軸オフセット|
|OffsetY|カウンターのY軸オフセット|
|OffsetZ|カウンターのZ軸オフセット|

数値を細かく設定したい場合は、`UserData\CutSpeedCounter.json`を直接編集してください。