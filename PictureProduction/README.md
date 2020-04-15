The task is to simulate multistage picture production process.

Pictures are created based on orders specifiyng:
- Shape - the same of picture frame
- Color - picture color
- Text - text placed on picture
- Operation - name of operation to apply to text before placing it on picture

Based on order, picture with the following properties is created:
- LeftFrame
- RightFrame
- Color
- Text

Where
- LeftFrame and RightFrame are shape markers, and are defined as the following (for frames with thickness 1)
  - for circle: ( and )
  - for square: [ and ]
  - for triangle: < and >
- For frames with thickness greater than 1, LeftFrame and RightFrame symbols are repeated the specified times, e.g. for double frame 'circle' markers are (( and ))
- Color is just a color used to paint the picture
- Text is Text from order modified according to operation specified by Operation

Additionally, Picture has a method Print(), which prints the following text on console:

{LeftFrame}{Color}{RightFrame} {Text} {LeftFrame}{Color}{RightFrame}

For example:

(red) HelloWorld (red)
[[[]]] H e l l o W o r l d [[[]]]
<<green>> HelloWorld <<green>>


The are several rules how pictures can be created:
- pictures are created on production lines, which consist on connected machines
- machine can specialize in only one operation (e.g. adding frame, paiting given color, adding text)
- operations shoud be executed in the following order: painting (adding Color) -> signing (adding Text) -> framing (adding LeftFrame and RightFrame)
- if production line has no machine that can paint picture with specified color, picture is left unpainted (Color property is an empty string)
- if production line has no machine that can execute given Operation, Text is left uprocessed (Text is simply rewritten from Order to Picture)
- picture must be painted and signed before can be framed (Picture cannod be framed if Color or Text are null)
- if production line cannot create a picture with given frame shape, it prints in console "Error: Cannot create picture!"
- before production starts, order must be validated: order is valid if all properties are not empty strings consist of small or big letters of english aplhabet; if order is invalid, the following text should be printed in console "Error: Invalid order!"
- at the end of each production line, there should be a machine that presents correctly created picture (calling method Print() on it)


Your task is to prepare two production lines:

Simple
- has only red color
- doesn't support any text operation
- can create shapes: circle and square
- always create frames with thickness 2

Complex:
- has red, green and blue colors
- can create shapes: circle, square, triangle
- supports the following text operations:
  - spacing: adds space between letters in Text (change Text to T e x t)
  - uppercase: changes all letters to uppercase (change Text to TEXT)
- if picture has no color (color is empty string) then frame thickness is 2
- if spacing opperation was used, then frame thickness is 2
- if both of above cases occures, then frame thickness is 3
- in other cases frame thickness is 1

Prepared solution should allow to add new shapes, colors and text operations to existing production lines, as well as creating new production lines without modification of existing code. 