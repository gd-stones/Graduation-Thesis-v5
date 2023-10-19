import cv2
import socket
from cvzone.HandTrackingModule import HandDetector

cap = cv2.VideoCapture(0)
cap.set(3, 1280)
cap.set(4, 720)

detector = HandDetector(detectionCon=0.8, maxHands=1)

sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
serverAddressPort = ("127.0.0.1", 5052)

while True:
    _, img = cap.read()
    hands, img = detector.findHands(img)
    action = ""

    if hands:
        fingers = detector.fingersUp(hands[0])
        if fingers == [0, 0, 0, 0, 0]:
            action = "jump_attack"
        elif fingers == [1, 1, 1, 1, 1]:
            action = "punching_bag"

        sock.sendto(str.encode(str(action)), serverAddressPort)

    cv2.imshow("Problem solve with ridoy", img)
    if cv2.waitKey(1) == ord("q"):
        break
