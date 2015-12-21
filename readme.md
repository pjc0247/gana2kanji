gana2kanji
====
convert hiragana into a complete sentence. 

```c#
using Gana2Kanji;

var segments = await G2K.Convert("なついろさぷらいず");

foreach(var segment in segments) {
    Console.WriteLine($"文節 : {segment.original}");
    foreach(var candidate in segment.candidates) {
        Console.WriteLine($"    候補 : {candidate}");
    }
    Console.WriteLine();
}
```
```c#
文節 : なついろ
    候補 : 夏色
    候補 : なついろ
    候補 : ナツイロ
    候補 : ﾅﾂｲﾛ

文節 : さぷらいず
    候補 : サプライズ
    候補 : Surprise
    候補 : surprise
    候補 : SURPRISE
    候補 : SURPRISE!
```

Guess the common case
----
```
/* 夏色サプライズ */
var msg = (await G2K.Convert("なついろさぷらいず")).CommonCase();
```
__G2K__ provides the `CommonCase` method. This is an extension method that concatenates each segment's first candidate. Remember that the result may not correct in all cases. It is a just guessing the most common case.

Google CGI API for Japanese Input
----
* [한국어](google_cgi.md)
* [日本語](https://www.google.co.jp/ime/cgiapi.html)
