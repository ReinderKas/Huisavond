from qhue import Bridge
import lightMethods
import yaml

preRequestValues = {
    'bri'  : 0,
    'hue'  : 0,
    'xy'  : [0, 0],
}

def storeOgValues(light):
    preRequestValues['bri'] = light()['state']['bri']
    preRequestValues['hue'] = light()['state']['hue']
    preRequestValues['xy'] = light()['state']['xy']
    return light

def resetLight(light):
    light.state(bri=preRequestValues['bri'], hue=preRequestValues['hue'], xy = preRequestValues['xy'])
    pass

try:
    bridge = Bridge('192.168.1.145', 'LLHKC9B4pBSGfoAtOkRLeL3qZ6wvSl9Pns7doK46')

    # Connected Lights:
    #   1 : Main light
    #   3 : Wasbak
    #   4 : Led bij bed

    currentLight = storeOgValues(bridge.lights[3])
    delay = 0.5

    lightMethods.flash(currentLight, delay)
    lightMethods.switchRGB(currentLight, delay)

except Exception as e: 
    print(e)
finally:
    resetLight(currentLight)