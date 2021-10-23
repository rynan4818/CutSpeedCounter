これは、CountersPlusのWikiにある[Custom Counter System](https://github.com/Caeden117/CountersPlus/wiki/For-Developers#custom-counter-system)の説明をmod作成の参考にするために、日本語訳したものです。

www.DeepL.com/Translator（無料版）で翻訳しました。

---------------------------------------------------------------------------------------
# Custom Counter System

Counters+に独自のカウンターを追加したいと思ったことがありますが、それを独自のスタンドアローンMODにしたいと思ったことはありませんか？Counters+には、任意のカウンタをCounters+システムに簡単に実装することができるソリューションがあります。

UIエンハンスメントMODを作成する開発者は、ユーザーがあなたのMODと衝突する設定をしている可能性があるので、Counters+の統合を検討してください。

### 依存するかしないか？

カスタムカウンタシステムは、Counters+依存がオプションであるように設計されていますが、**ハードCounters+依存を持つことは、開発者の側で容易になります。**
ハードな依存関係があれば、Counters+がインストールされている場合とされていない場合の2つの別々のコードを維持することを心配する必要はありません。

## はじめに
-------------------------------------------------------------------------------------
まず、プラグインの `manifest.json` ファイルにアクセスします。

Counters+ 2.0.0のカスタムカウンタシステムは、BSIPA 4.0.5以降のバージョンで導入された新しいBSIPA Feature'sシステムを使用しています。
必要に応じて、最新のBSIPAビルドを入手することができます。

以下は `manifest.json` で定義されたカスタムカウンタの例です。

    "features": {
      "CountersPlus.CustomCounter": {
        "Name": "Example Custom Counter",
        "CounterLocation": "ExampleCustomCounterMod.CustomCounter",
        "ConfigDefaults": {
          "Enabled": true,
          "Position": "AboveCombo",
          "Distance": 0
        },
        "BSML": {
          "Resource": "ExampleCustomCounterMod.TestCustomUI.bsml",
          "Host": "ExampleCustomCounterMod.TestCustomUIHost",
          "Icon": "ExampleCustomCounterMod.william_gay.png"
        }
      }
    }

まだ定義されていない場合は、マニフェストに`Features`オブジェクトを追加します。
以前とは異なり、この新しいFeaturesシステムでは、配列ではなくオブジェクトを使用します。
この後、この下に`CountersPlus.CustomCounter`という新しい子オブジェクトを作成したいと思います。

### Name (必須)
カスタムカウンターの名前です。
Counters+の設定メニューに表示されるほか、さまざまな内部コンポーネントの識別子としても使用されます。
**注意してください** 最初の公開後に変更することはお勧めできませんので、良い名前を考えてください。

### Description#
あなたのカスタムカウンターの説明です。現在は未使用です。

### CounterLocation (必須)
実装したいカスタムカウンタの名前空間の場所です。これは、`MonoBehaviour`、Counters+ Custom Counterタイプを継承したクラス、またはそのいずれでもないものです。

**インスタンス作成の心配は無用です!** Counters+では、Zenjectを使用して、曲の入力時にカスタム・カウンターのインスタンスを生成します。これにより、カスタム・カウンターでZenjectを最大限に活用することができます。

## ConfigDefaults
カウンタの設置場所について独自のデフォルトを提供したい場合は、このオブジェクトをオーバーライドしてください。これは`ConfigModel`で、3つの部分で構成されています。

  * **Enabled**  これは、そもそも有効になっているかどうかを制御するものです。
  * **Position** これは、"相対的な "ポイントとなる文字列値のEnumです。
    有効なオプションは
    * `AboveCombo` and `BelowCombo`
    * `AboveMultiplier` and `BelowMultiplier`
    * `BelowEnergy`
    * `AboveHighway`
* **Distance** これは、これらの相対的なポイントからのステップで、最終的な位置を決定します。

### BSML
Counters+設定メニューでの動作を記述するオプションのオブジェクトです。設定オプションやカスタムアイコンの提供を予定していない場合は、このオブジェクトを省略することができます。

### Resource
これは、`ConfigModel`のオプションの下に付加される`.bsml`ファイルへの名前空間の位置です。

このBSMLファイルでは、Counters+との整合性を保つために、このテンプレートをベースにしてUIを作成することが推奨されます。

    <vertical xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xsi:schemaLocation='https://monkeymanboy.github.io/BSML-Docs/ https://raw.githubusercontent.com/monkeymanboy/BSML-Docs/gh-pages/BSMLSchema.xsd' spacing='1' horizontal-fit='PreferredSize' vertical-fit='PreferredSize'>
        <!-- BSML goes here -->
    </vertical>

この項目を空白にしても構いません。空白にした場合、追加のコンテンツ（またはホストオブジェクト）は追加されません。

### Host
これは、提供されたBSMLファイルのすべての`UIValues`、`UIActions`、`UIEvents`を処理するTypeの名前空間の位置です。

`CounterLocation`と同様に、Counters+はZenjectマジックを使って、必要な時にこのオブジェクトを自動的に作成します。
また、このオブジェクトの中でZenjectをフル活用することができます。

### Icon
これは、すべてのカウンターのリストに表示されるデフォルトのカスタムカウンターアイコンを上書きするイメージのネームスペースの位置です。

サポートされているすべてのファイル形式については正確にはわかりませんが、`.png`が動作することは100％、`.jpg`が動作することは85％ほどです。他のもので運試しはしないほうがいいと思います。

## カウンターの作成
-------------------------------------------------------------------------------------------------------------------
再利用したい`MonoBehaviour`がすでにある場合は、それを`CounterLocation`に差し込めば、Counters+は喜んでそれを拾い、ゲームにロードしてくれます。
しかし、Counters+ 2.0.0の機能を十分に活用するためには、カスタムカウンターを最初から作成することをお勧めします。

Counters+では、`CountersPlus.Counters.Custom`名前空間で、カスタムカウントを高速化するために継承できるいくつかのパブリッククラスを提供しています。

## `BasicCustomCounter`
これは、いくつかのユーティリティー・オブジェクト（Zenject で注入）といくつかのメソッドを提供するだけの、必要最低限のカスタム・カウンター・クラスです。

### CanvasUtility
`CanvasUtility`は、このクラス内のフィールドで、Counters+のキャンバスに関連する機能に素早くアクセスしたり、テキストを素早く簡単に生成することができます。

### Settings
これは、カスタムカウンターに使用される`CustomConfigModel`です。これを`CanvasUtility`と組み合わせることで、たった1行のコードで簡単にカスタムテキストを作成することができます。

### CounterInit
CounterInitは、Counters+がオブジェクトをロードするときに呼び出される抽象メソッドです（つまり、オーバーライドする必要があります）。このメソッドでは、カウンターのテキストを作成したり、イベントを購読したりします。

### CounterDestroy
CounterDestroyは、オブジェクトが破壊されたときに呼び出される抽象メソッドです（つまり、オーバーライドしなければなりません）。ここでは、自分自身の後始末、イベントの購読停止、Unityに自動的に拾われない可能性のあるものの破棄などを行います。

## `CanvasCustomCounter`
既存のCanvasをどうしても再利用したい場合は、数行の追加コードとCustom Counterを使って、Counters+に再配置させることができます。

この`CanvasCustomCounter`クラスは`BasicCustomCounter`を継承しているので、`Settings`オブジェクトや`CanvasUtility`のようなヘルパーも`CanvasCustomCounter`に引き継がれます。

`CanvasCustomCounter`クラスは、定義されたCanvasオブジェクトを探すように設計されており、名前や直接参照であるかどうかにかかわらず、それをCounters+システムに再配置します。

### CanvasReference
これは、`Canvas`オブジェクトを直接指定する仮想プロパティ（オーバーライドはオプション）です。まずはこれを使ってみてください。覚えておいてください。あなたが使用するカスタム・カウンターは、Zenject の利点を最大限に活用することができます。もし、あなたのMODが独自のコンポーネントにZenjectを使用しているのであれば、メインのCanvasをCustom Counterタイプに簡単に注入することができます。

### CanvasObjectName
これは仮想プロパティであり（オーバーライドはオプション）、CanvasコンポーネントがアタッチされたGameObjectの正確な名前を、大文字小文字を区別して指定する。Counters+は、この`Canvas`オブジェクトを見つけるために、カスタムカウンターに10回のショットを与えて、諦めさせます。

### PreReparent
Counters+がCanvasを検索しようとする前に起動される仮想メソッドです（オーバーライドは任意）。これは`CounterInit`と基本的には同じですが、イベントのサブスクライブが必要な場合には、このメソッドを使用します。

### PostReparent
これは、Counters+がCanvasをCounters+システムに再ペアリングすることに成功した後に起動されるバーチャルメソッドです（オーバーライドは任意です）。再配置や手動での作業が必要な場合は、`PostReparent`関数で行うことができます。

## Helper Interfaces
------------------------------------------------------------------------------------------------------------------
しかし、それだけではありません。

Counters+には、ノートカット/ミッシングやスコア更新などの基本的なゲームイベントを購読する必要がある場合、これらのイベントを公開するインターフェイスがあり、自分でオブジェクトリファレンスを探してこれらのイベントを購読しなくても、自動的にイベントが発生します。
さらに、これらのインターフェイスは、ゲームのアップデートでModが壊れた場合に、Counters+が1箇所だけ壊れるように設計されています。つまり、私は一箇所だけコードを修正すればよく、これらのインターフェイスは完全に動作するということです。

これらのヘルパーインターフェースは、`CountersPlus.Counters.Interfaces` 名前空間にあります。

## INoteEventHandler
このインターフェースは、基本的なノートカットとミッシングイベントを公開します。

## IScoreEventHandler
このインターフェースは、基本スコア更新イベントと最大スコア更新イベントを公開します。どちらのメソッドも修正スコア（ユーザーの修正ボーナスを考慮したスコア）のみを提供します。

