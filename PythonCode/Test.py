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

        # Movement control
        if fingers_right == [1, 1, 1, 1, 1] and fingers_left == [1, 1, 1, 1, 1]:
            action = "idle"
            print("aaaaaaa")
        elif fingers_right == [0, 0, 0, 0, 0] and fingers_left == [1, 1, 1, 1, 1]:
            action = "idle-walking"
        elif fingers_right == [1, 0, 0, 0, 0] and fingers_left == [1, 1, 1, 1, 1]:
            action = "left_turn"
        elif fingers_right == [0, 0, 0, 0, 1] and fingers_left == [1, 1, 1, 1, 1]:
            action = "right_turn"
        elif fingers_right == [1, 0, 0, 0, 1] and fingers_left == [1, 1, 1, 1, 1]:
            action = "idle-backward"
        elif fingers_right == [0, 0, 1, 1, 1] and fingers_left == [1, 1, 1, 1, 1]:
            action = "idle-running"
        elif fingers_right == [0, 1, 0, 1, 1] and fingers_left == [1, 1, 1, 1, 1]:
            action = "idle-fast_run"

        # Action 1-5
        elif fingers_right == [1, 0, 0, 0, 0] and fingers_left == [0, 0, 0, 0, 0]:
            action = "jump_attack"
        elif fingers_right == [0, 1, 0, 0, 0] and fingers_left == [0, 0, 0, 0, 0]:
            action = "punching_bag"
        elif fingers_right == [0, 0, 1, 0, 0] and fingers_left == [0, 0, 0, 0, 0]:
            action = "boxing"
        elif fingers_right == [1, 1, 0, 0, 0] and fingers_left == [0, 0, 0, 0, 0]:
            action = "hook_punch"
        elif fingers_right == [0, 1, 1, 0, 0] and fingers_left == [0, 0, 0, 0, 0]:
            action = "fireball"

        # Action 6-10
        elif fingers_right == [1, 0, 0, 0, 0] and fingers_left == [1, 0, 0, 0, 0]:
            action = "materlo_2"
        elif fingers_right == [0, 1, 0, 0, 0] and fingers_left == [1, 0, 0, 0, 0]:
            action = "chapa_giratoria"
        elif fingers_right == [0, 0, 1, 0, 0] and fingers_left == [1, 0, 0, 0, 0]:
            action = "front_twist_flip"
        elif fingers_right == [1, 1, 0, 0, 0] and fingers_left == [1, 0, 0, 0, 0]:
            action = "butterfly_twirl"
        elif fingers_right == [0, 1, 1, 0, 0] and fingers_left == [1, 0, 0, 0, 0]:
            action = "breakdance_1990"

        sock.sendto(str.encode(str(action)), serverAddressPort)

    cv2.imshow("Problem solve with ridoy", img)
    if cv2.waitKey(1) == ord("q"):
        break
