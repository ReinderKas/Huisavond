from qhue import Bridge
import time
import yaml
import math

colors = {
    'red'   : [255, 0, 0],
    'green' : [0, 255, 0],
    'blue'  : [0, 0, 255],
}

preRequestValues = {
    'bri'  : 0,
    'hue'  : 0,
    'xy'  : [0, 0],
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

def switchRGB(light):
    print('Switching RGB ...')
    for color in colors.values():
        light.state(xy = rgbToXY(color))
        time.sleep(1)
    pass

def flash(light):
    print('Flashing ...')
    for i in range(3):
        light.state(bri=0, xy = rgbToXY([245, 158, 66]))
        time.sleep(1)
        light.state(bri=255)
        time.sleep(1)
    pass

def setOgValues(light):
    preRequestValues['bri'] = light()['state']['bri']
    preRequestValues['hue'] = light()['state']['hue']
    preRequestValues['xy'] = light()['state']['xy']
    pass

def resetLight(light):
    light.state(bri=preRequestValues['bri'], hue=preRequestValues['hue'], xy = preRequestValues['xy'])
    pass

try:
    bridge = Bridge('192.168.1.145', 'LLHKC9B4pBSGfoAtOkRLeL3qZ6wvSl9Pns7doK46')
    lights = bridge.lights()

    time.sleep(0.5)
    currentLight = bridge.lights[4]

    setOgValues(currentLight)

    flash(currentLight)
    switchRGB(currentLight)
    
    time.sleep(1)
    resetLight(currentLight)
except Exception as e: 
    print(e)