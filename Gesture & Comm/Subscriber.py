import paho.mqtt.client as mqtt
import os
import numpy as np

MQTT_SERVER = "localhost"
MQTT_PATH = "test_channel"

outputtxtdir = "/Users/lostll/Desktop/out.txt"

# The callback for when the client receives a CONNACK response from the server.
def on_connect(client, userdata, flags, rc):
    print("Connected with result code "+str(rc))

    # Subscribing in on_connect() means that if we lose the connection and
    # reconnect then subscriptions will be renewed.
    client.subscribe(MQTT_PATH)

def range1(x, y):
    if ((x < - 135) or (x > 135)) and ((y < -135) or (y > 135)):
        return 0
    if ((x < 45) and (x > -45)) and ((y < 45) and (y > -45)):
        return 1
    if (x > 0):
        return 2
    return 3

def flex(x):
    if (x < 700):
        return 0
    return 1

# The callback for when a PUBLISH message is received from the server.
def on_message(client, userdata, msg):
    msg1 = str(msg.payload)[3:-1]
    x = 0
    y = 0
    count = 0
    data = np.zeros(5)

    prev = 0
    for i in range(len(msg1)):
        print(i)
        if msg1[prev] == " ":
            if msg[i] != " ":
                prev = i
                if count == 3:
                    data[count+1] = float(msg1[prev :])
                    break
        if msg1[i] == " " & msg1[prev] != " ":
            data[count] = float(msg1[prev:i])
            count += 1
            prev = i

    a = range1(data[0], data[1])
    bb = flex(data[2])
    cc = flex(data[3])
    dd = flex(data[4])
    f = open(outputtxtdir, 'w')
    print(str(a) + str(bb) + str(cc) + str(dd))
    f.write(str(a) + str(bb) + str(cc) + str(dd))
    f.close

# more callbacks, etc

client = mqtt.Client()
client.on_connect = on_connect
client.on_message = on_message

client.connect(MQTT_SERVER, 1883, 60)

# Blocking call that processes network traffic, dispatches callbacks and
# handles reconnecting.
# Other loop*() functions are available that give a threaded interface and a
# manual interface.
client.loop_forever()
