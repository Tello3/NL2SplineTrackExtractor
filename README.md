# NL2SplineTrackExtractor
A tool to extract individual track rails spline data from No Limits 2 Spline Data

![Nl2SplineExtractor v1 2 0](https://user-images.githubusercontent.com/109047611/214991017-19cbfd51-2e0a-474d-877e-dbfdf0ce4720.png)

# Features
  - Extract individual splines (e.g left, right, center,...)
  - Split spline data, into a desired number of pieces, after a desired number of points, or fully custom, for easier handling/modeling
  - Preview the split profile before exporting
  - Rotate the coaster around the x,y and z Axes
  - Offset the coaster
  - Scale the coaster
  - Specify the distance of each rail to the center spline
  - Connect the end spline to the starting point for a complete round trip
 
 # How to use
  - Extract .exe from .zip that can be downloaded in releases
  - Export spline data from No Limits 2
  - Create an output folder for the generated splines
  - Select file and folder
  - Select which rails/splines you want to export
  - Select a split type or cut it yourself (left Mouse: add a split point, right: remove a split point, middle: reset viewport)
      - Split after x nodes will split the data into splines of x amount of points the last spline will be made up of the remaining points
      - Split into x pieces will split the data into evenly sized splines (If the number of points cant be split into x pieces their may not be exactly the amount of     pieces specified)
  - Set the Scale you want by using a fraction("n/m") or typing "n:m" (e.g 1:15) or using a decimal number
  - Adjust export scale depending on what your CAD software expects (Fusion360 expects the data in mm scaling)
  - Adjust the other settings to you liking (Note: for Fusion 360 you'll want to rotate 90° along the x axis)
  - Press "Calculate" and the output folder will be populated
 
  Have fun with the exported splines


__(Note: make sure to use a decimal point not comma when trying to input decimal numbers)__

Decimal numbers can also be written as "n/m" or "n:m" (e.g 0.5 = 1/2 = 1:2)
