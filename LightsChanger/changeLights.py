from qhue import Bridge
import lightMethods
import yaml
from dotenv import load_dotenv

load_dotenv()

ip      = os.get_env("IP")
api_key = os.get_env("API_KEY")


# Make sure we can turn back the lights to original values.
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

def change():
    try:
        bridge = Bridge(ip, api_key)

        # Connected Lights:
        #   1 : Main light
        #   3 : Sink
        #   4 : Bed led

        currentLight = storeOgValues(bridge.lights[4])
        delay = 0.5

        lightMethods.flash(currentLight, delay)

    except Exception as e: 
        print(e)
    finally:
        currentLight.state(bri=preRequestValues['bri'], hue=preRequestValues['hue'], xy = preRequestValues['xy'])