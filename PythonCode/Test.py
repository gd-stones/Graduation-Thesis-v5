import mediapipe as mp
import cv2
import pydirectinput
import time


mp_hands = mp.solutions.hands
hands = mp_hands.Hands()

previous_state = [0, 0, 0, 0, 0]

def detect_gestures(hand_landmarks):
    thumb_tip = hand_landmarks.landmark[mp_hands.HandLandmark.THUMB_TIP]
    index_tip = hand_landmarks.landmark[mp_hands.HandLandmark.INDEX_FINGER_TIP]
    middle_tip = hand_landmarks.landmark[mp_hands.HandLandmark.MIDDLE_FINGER_TIP]
    ring_tip = hand_landmarks.landmark[mp_hands.HandLandmark.RING_FINGER_TIP]
    pinky_tip = hand_landmarks.landmark[mp_hands.HandLandmark.PINKY_TIP]

    if thumb_tip.y < index_tip.y:
        print("Press 'A'")
        # pydirectinput.press('a')
        # pydirectinput.keyDown('w')
        # time.sleep(1)
        # pydirectinput.keyUp('w')
        # time.sleep(1)
    elif index_tip.y < middle_tip.y:
        # print("Press 'B'")
        pydirectinput.press('b')
    elif middle_tip.y < ring_tip.y:
        # print("Press 'C'")
        pydirectinput.press('c')
    elif ring_tip.y < pinky_tip.y:
        # print("Press 'D'")
        pydirectinput.press('d')

cap = cv2.VideoCapture(0)

while True:
    success, frame = cap.read()
    rgb_frame = cv2.cvtColor(frame, cv2.COLOR_BGR2RGB)

    results = hands.process(rgb_frame)

    if results.multi_hand_landmarks:
        for hand_landmarks in results.multi_hand_landmarks:
            detect_gestures(hand_landmarks)

    cv2.imshow("Hand Gestures", frame)

    if cv2.waitKey(1) & 0xFF == ord('q'):
        break

cap.release()
cv2.destroyAllWindows()
