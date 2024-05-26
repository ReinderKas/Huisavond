from qhue import Bridge
import time
import yaml
import math


def rgb(red, green, blue):
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

def switchRGB():
    bridge.lights[1].state(bri=180, hue=9000, xy = rgb(255, 0, 0))
    time.sleep(1)
    bridge.lights[1].state(bri=180, hue=9000, xy = rgb(0, 255, 0))
    time.sleep(1)
    bridge.lights[1].state(bri=180, hue=9000, xy = rgb(0, 0, 255))
    time.sleep(1)
    pass

def flash():
    bridge.lights[1].state(bri=10, hue=9000, xy = [0.4963, 0.4152])
    time.sleep(0.5)
    bridge.lights[1].state(bri=255, hue=9000, xy = [0.4963, 0.4152])
    time.sleep(0.5)
    bridge.lights[1].state(bri=10, hue=9000, xy = [0.4963, 0.4152])
    time.sleep(0.5)
    bridge.lights[1].state(bri=255, hue=9000, xy = [0.4963, 0.4152])
    time.sleep(0.5)
    bridge.lights[1].state(bri=10, hue=9000, xy = [0.4963, 0.4152])
    time.sleep(0.5)
    bridge.lights[1].state(bri=255, hue=9000, xy = [0.4963, 0.4152])
    time.sleep(1)
    pass

try:
    bridge = Bridge('192.168.1.145', 'LLHKC9B4pBSGfoAtOkRLeL3qZ6wvSl9Pns7doK46')
    lights = bridge.lights()
    
    print("{} lights:\n".format(len(lights)))
    print(yaml.safe_dump(bridge.lights['1'](), indent=4))

    time.sleep(1)

    flash()
    switchRGB()
    
    bridge.lights[1].state(bri=225, hue=7782, xy = [0.4963, 0.4152])
except Exception as e: 
    print(e)