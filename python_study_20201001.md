# 악튜러스님 강의 주피터 사용법 학습하기 

### 문서
https://docs.google.com/presentation/d/1wfqrYz1UBMHfKWK1OSVnbtxwVviNCUyei2Ygz0IC4rs/edit#slide=id.g91415cbda4_0_94

### #01 설치 파트
[악튜러스님 강의 #01(Install)](https://www.youtube.com/watch?v=6WcNabw7sQg&list=PL73qGQ0nG_q3qI1KNAdGb2ILhm8UXb4CH&index=4)


### #02 단축키 파트
[악튜러스님 강의 #02(단축키)](https://www.youtube.com/watch?v=_whbI6r2Gj4&list=PL73qGQ0nG_q3qI1KNAdGb2ILhm8UXb4CH&index=5)

커맨드모드와 편집모드로 나뉘어져있다.

#### 커맨드 모드
`ESC` : 편집모드 > 커맨드모드 전환 (셀수정하도록)<br />
`Enter` : 커맨드모드 > 편집모드 전환 (코드 수정하도록)

`Shift`+`Enter` : 셀 실행, 아래 셀 선택<br />
`Ctrl`+`Enter` : 선택된 셀 실행<br />
`Alt`+`Enter` : 셀실행 후 뒤에 셀 삽입<br />
`A` : 셀 상단에 추가(Above)<br />
`B` : 셀 하단에 추가 (Below)<br />
`D` `D` : 선택된 셀 삭제<br />
`Y` : 코드모드로 전환<br />
`M` : 마크다운모드로 전환<br />
`Shift` + `M` : 선택된 셀 병합<br />

#### 에디트모드
`Ctrl` + `Shift` + `-` : 커서기준으로 셀나누기<br />
`Shift` + `Enter` : 셀 실행후 뒷 셀 선택(뒷셀이 없는 경우 삽입됨..)<br />
`Alt` + `Enter` : 셀 실행후 뒷 셀 삽입<br />
`Ctrl` + `Enter` : 셀 실행(삽입없음)<br />
`Tab`: indent<br />

### 03 커널메뉴 파트
[악튜러스님 강의 #03(커널메뉴)](https://www.youtube.com/watch?v=Wf8uaassOn8&list=PL73qGQ0nG_q3qI1KNAdGb2ILhm8UXb4CH&index=8)

커널 메뉴 : 실행중인 셀에 인터럽트 걸거나 재시작 처리<br />
파일 메뉴 : 노트북을 저장하거나 불러오거나, PDF, HTML, Latex등으로 Export 할 수 있다.<br />

### 04 Magic명령어 파트
[악튜러스님 강의 #04(magic명령어)](https://www.youtube.com/watch?v=x-XmjsMu8SU&list=PL73qGQ0nG_q3qI1KNAdGb2ILhm8UXb4CH&index=6)

참고서적 : **Python Data Science Handbook by Jake VanderPlas O'REILLY**



실행시간이나, 메모리소요량등을 확인해볼 수 있다.<br />
혹은 아래 명령어를 통해 SQLite를 바로 사용해볼 수 있다..<br />


Line 매직과 Cell 매직으로 나뉜다..<br />
1. Line magics : %, 해당 Line 만 실행<br />
    - %lsmagic, %time, %matplotlib, %system (= !!), %who_ls (변수 출력)<br />
    - %ls (= !ls), %cat (= !cat), %cp (= !cp), %mkdir (= !mkdir), %mv (= !mv), …<br />
    - %run : python 스크립트 실행<br />
    - %load_ext: 3rd party magic 수행, ex) sql, hierarchymagic<br />
<br />
2. Cell magics : %%, Cell 안의 여러 줄 실행<br />
    - %%bash : Cell 내의 Bash 명령어들을 실행<br />
    - %%python (python script 를 실행)<br />
    - %%writefile (Cell 내의 내용을 파일로 저장)<br />
    - ! (= !!) : 쉘 실행 (쉘 커맨드 실행 및 결과 출력)<br />
 <br />
 
 **_SQL 예제_**<br />
```
!pip install sqlalchemy
!pip install ipython-sql
%load_ext sql
%sql sqlite:// 
%%sql
DROP TABLE IF EXISTS hockey;
CREATE TABLE hocket ("Team", "Stanley Cups Won", "Country");
INSERT INTO hocket ("A", "24", "Canada");
INSERT INTO hocket ("B", "7", "Canada");
INSERT INTO hocket ("C", "4", "USA");

%sql SELECT * FROM hockey
data = %sql SELECT * FROM hockey WHERE country = 'Canada'
data.pie()
```

 **_GraphViz 예제_**<br />
 ```
 digraph G {
  rankdir=LR;
  hello -> world;
  goodby -> cruel -> world;
  world -> of -> warcraft;
 }
 ```
 
 * colab : 구글에서 만든 노트북 실행환경, %%bash등을 실행해서 테스트 해볼 수 있음.
 
### 05 MD작성 및 Docstring 파트
[악튜러스님 강의 #05(Markdown 작성법 및 Docstring 확인법)](https://www.youtube.com/watch?v=JodL6144BCk&list=PL73qGQ0nG_q3qI1KNAdGb2ILhm8UXb4CH&index=7)

```
 - Headings : #, ##, ###, ####, #####, #####
    - Blockquotes : >
    - Code example : ```{}```
    - LaTex : $${}$$
    - Line Break : <br>
    - Bold Text : <b>{}</b>, **{}**, __{}__
    - Italic Text : <i>{}</i>, *{}*, _{}_
    - Horizontal Line : ---
    - Ordered List : 1. 2. 3. ...
    - Unordered List : -
    - External Link : <a href="https://www.google.com" >Link to Google</a>
    - Insert Image : "Edit" >> "Insert Image"
```
 
#### DocString 활용법
```
help(객체.메소드)
?객체.메소드
객체.메소드?
```

인자적는 란에서 `Shift` + `Tab`로 바로 확인 가능 `추천`<br />

 
> **_NOTE:_**  2020.10.01 작성

