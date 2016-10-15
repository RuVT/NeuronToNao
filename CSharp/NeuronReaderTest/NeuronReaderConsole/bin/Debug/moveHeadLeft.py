# -*- encoding: UTF-8 -*- 

''' Task management: the second motion is not postponed '''

import sys
import math
import time
from naoqi import ALProxy

def main(robotIP):
    proxy = 0
    try:
        proxy = ALProxy("ALMotion", robotIP, 9559)
    except Exception, e:
        print "Could not create proxy to ALMotion"
        print "Error was: ", e

    proxy.setStiffnesses("Head", 1.0)

    # move slowly the head to look in the left direction
    names  = "HeadYaw"
    angles = math.pi/2
    fractionMaxSpeed  = .1
    proxy.setAngles(names, angles, fractionMaxSpeed)

    time.sleep(1.)


if __name__ == "__main__":
    robotIp = "169.254.254.250"

    if len(sys.argv) <= 1:
        print "Usage python motion_taskManagement2.py robotIP (optional default: 127.0.0.1)"
    else:
        robotIp = sys.argv[1]

    main(robotIp)
