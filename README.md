# NL2SplineTrackExtractor
A tool to extract individual track rails spline data from No Limits 2 Spline Data

![image](https://user-images.githubusercontent.com/109047611/210702032-1377828b-f68e-45d1-bf02-2b3f65079384.png)

# Features
  -Extract individual splines (e.g left, right, center,...)
  
  -Split spline data, into a desired number of pieces, or after a desired number of points, for easier handling/modeling
  
  -Rotate the coaster around the x,y and z Axes
 
  -Offset the coaster
  
  -Scale the coaster
  
  -Specify the distance of each rail to the center spline
 
 # How to use
  - Extract .exe from .zip that can be downloaded in releases
 
  - Export spline data from No Limits 2
  
  - Create an output folder for the generated splines
  
  - Select file and folder
  
  - Select which rails/splines you want to export
  
  - Select a split type
      
      -Split after x nodes will split the data into splines of x amount of points the last spline will be made up of the remaining points
      
      -Split into x pieces will split the data into evenly sized splines (If the number of points cant be split into x pieces the last spline will be bigger)
  
  - Adjust the other settings to you liking (Note: for Fusion 360 you'll want to rotate 90° along the x axis)
  
  - Press "Calculate" and the output folder will be populated
 
  Have fun with the exported splines
