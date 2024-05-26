import math
import time

colors = {
    'red'   : [255, 0, 0],
    'green' : [0, 255, 0],
    'blue'  : [0, 0, 255],
}

def rgbToXY(values):
    red = values[0]
    green = values[1]
    blue = values[2]

    if (red > 0.04045):
        red = math.pow((red + 0.055) / (1.0 + 0.055), 2.4)
    else:
        red = (red / 12.92)

    if (green > 0.04045):
        green = math.pow((green + 0.055) / (1.0 + 0.055), 2.4)
    else:
        green = (green / 12.92)
        
    if (blue > 0.04045):
        blue = math.pow((blue + 0.055) / (1.0 + 0.055), 2.4)
    else:
        blue = (blue / 12.92)

    X = red * 0.664511 + green * 0.154324 + blue * 0.162028
    Y = red * 0.283881 + green * 0.668433 + blue * 0.047685
    Z = red * 0.000088 + green * 0.072310 + blue * 0.986039
    x = X / (X + Y + Z)
    y = Y / (X + Y + Z)
    return [x, y]

def switchRGB(light, delay):
    print('Switching RGB ...')
    for color in colors.values():
        light.state(xy = rgbToXY(color))
        time.sleep(delay)
    pass

def flash(light, delay):
    print('Flashing ...')
    for i in range(3):
        light.state(bri=0, xy = rgbToXY([245, 158, 66]))
        time.sleep(delay)
        light.state(bri=255)
        time.sleep(delay)
    pass