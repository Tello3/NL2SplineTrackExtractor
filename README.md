# NL2SplineTrackExtractor
A tool to extract individual track rails spline data from No Limits 2 Spline Data

![Screenshot_11](https://user-images.githubusercontent.com/109047611/213882708-d755ef69-16a8-4eee-b646-e0e9682d74af.png)

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
  - Select a split type or cut it yourself (left Mouse: add a split point, right: remove a split point, middle: reset viewport scaling)
      - Split after x nodes will split the data into splines of x amount of points the last spline will be made up of the remaining points
      - Split into x pieces will split the data into evenly sized splines (If the number of points cant be split into x pieces their may not be exactly the amount of     pieces specified)
  - Adjust the other settings to you liking (Note: for Fusion 360 you'll want to rotate 90° along the x axis)
  - Press "Calculate" and the output folder will be populated
 
  Have fun with the exported splines
