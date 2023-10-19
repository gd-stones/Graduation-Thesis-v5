import cv2
import socket
from cvzone.HandTrackingModule import HandDetector

cap = cv2.VideoCapture(0)
cap.set(3, 1280)
cap.set(4, 720)

detector = HandDetector(detectionCon=0.7, maxHands=2)

sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
serverAddressPort = ("127.0.0.1", 5052)

while True:
    _, img = cap.read()
    hands, img = detector.findHands(img)
    action = ""

    if len(hands) == 2:
        fingers_right = detector.fingersUp(hands[0])
        fingers_left = detector.fingersUp(hands[1])
        if fingers_right == [0, 0, 0, 0, 0]:
            action = "jump_attack"
            print("aaaaaaa")
        elif fingers_left == [1, 1, 1, 1, 1]:
            action = "punching_bag"

        sock.sendto(str.encode(str(action)), serverAddressPort)

    cv2.imshow("Problem solve with ridoy", img)
    if cv2.waitKey(1) == ord("q"):
        break
