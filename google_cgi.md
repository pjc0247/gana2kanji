﻿Google CGI API for Japanese Input
====

이 문서는 번역된 내용입니다. [원본](https://www.google.co.jp/ime/cgiapi.html)
<br><br>

__Google CGI API for Japanese Input__은 인터넷상에서 일본어 변환을 가능하도록 해주는 CGI 서비스입니다.

__리퀘스트__

http://www.google.com/transliterate 에 HTTP GET 메소드로 아래의 파라미터를 지정하여 요청해 주십시오.
```
langpair=ja-Hira|ja
text=（変換したいひらがな列）
```

text 파라미터의 히라가나는 UTF-8인코딩이어야 합니다. 예를들어 `へんかん`을 변환하는 경우에는
```
http://www.google.com/transliterate?langpair=ja-Hira|ja&text=%E3%81%B8%E3%82%93%E3%81%8B%E3%82%93
```
위 주소로 요청해야 합니다.

__리스폰스__

JSON 타입의 배열이 반환됩니다. 각 요소는 어절로 나뉘어져 있으며, 요소의 첫번째에는 원래 입력된 문자가, 두번째부터는 변환 후보들이 따라옵니다.

__샘플 리스폰스__
```
「ここではきものをぬぐ」と指定した場合の変換結果例。
[
  ["ここでは",
    ["ここでは", "個々では", "此処では"],
  ],
  ["きものを",
    ["着物を", "きものを", "キモノを"],
  ],
  ["ぬぐ",
    ["脱ぐ", "ぬぐ", "ヌグ"],
  ],
]
```

__구분 위치를 직접 지정하고 싶을 때__

text 파라미터에서 구분하고싶은 위치에 콤마(,)를 넣어주세요. 콤마가 있으면, Transliteration 서비스는 더 이상 자동으로 구분하지 않습니다.

__예시__

「ここではきものをぬぐ」 을 변환하고자 하면、원래의 경우 「ここでは」「きものを」「ぬぐ」 와 같이 자동으로 구분됩니다。여기서는 구분 위치를 변경하여 「ここで」「はきものを」 로 변경해 보겠습니다、
```
text=ここで,はきものを,ぬぐ
```
(「はきものを」 와 「ぬぐ」 사이의 구분자는 그대로 유지합니다.)。이렇게 요청을 보내면 의도한 결과 대로의 응답을 받을 수 있습니다.

또한 , 아예 구분하고 싶지 않은 경우에는 text 파라미터의 맨 끝에 콤마(,)를 붙입니다.
```
text=これはきってほしくない,
```