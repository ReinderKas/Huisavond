import math
import time
import random

colors = {
    'red'   : [255, 0, 0],          # Not allowed to say person's name.
    'green' : [0, 255, 0],          # Must drink with left hand.
    'yellow': [255, 255, 0],        # Must drink with right hand.
    'purple': [255, 0, 255],        # Every sentence must be a question. 
    'cyan'  : [0, 255, 255],        # 
    'blue'  : [0, 0, 255],          # Have to guess the next color. If correct --> give 3 sips.
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

def flash(light, delay):
    print('Flashing ...')
    for i in range(3):
        light.state(bri=0, xy = rgbToXY([245, 158, 66]))
        time.sleep(delay)
        light.state(bri=255)
        time.sleep(delay)
    pass

def randomLight(light):
    color_name, color_value = random.choice(list(colors.items()))
    light.state(xy = rgbToXY(color_value))
