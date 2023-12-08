import sys
import cv2
import numpy as np
import pyautogui

def find_element(reference_image_path):
    # Take a screenshot
    screenshot = pyautogui.screenshot()
    screenshot = np.array(screenshot)
    screenshot = cv2.cvtColor(screenshot, cv2.COLOR_RGB2BGR)

    # Load the reference image
    reference_image = cv2.imread(reference_image_path, 0)

    # Template matching to find the element
    result = cv2.matchTemplate(screenshot, reference_image, cv2.TM_CCOEFF_NORMED)
    _, _, _, max_loc = cv2.minMaxLoc(result)

    return max_loc

if __name__ == "__main__":
    ref_image_path = sys.argv[1]  # Take reference image path as command line argument
    coordinates = find_element(ref_image_path)
    print(coordinates)  # Output the coordinates
