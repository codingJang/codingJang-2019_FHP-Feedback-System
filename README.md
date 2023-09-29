# Real-Time Feedback System for Forward Head Posture Using Markerless Skeletal Tracking

Download poster: https://drive.google.com/file/d/1SH-brTlvTuHnrXsnnd4DTG3ofRZK9sXW/view?usp=sharing

## Introduction

With the increasing use of computers and smartphones, many individuals are experiencing cervical issues such as turtleneck syndrome and disc herniation. These problems are primarily attributed to the Forward Head Posture (FHP), a condition where the neck is abnormally flexed forward. This project aims to develop a real-time feedback system for FHP using Markerless Skeletal Tracking, offering a solution that doesn't require device attachments.

## Key Features

- **Markerless Skeletal Tracking**: Implemented using the Intel RealSense D415 3D depth camera and the Nuitrack SDK.
- **Objective Posture Detection**: Uses angles between vectors connecting specific joints as objective criteria for FHP detection.
- **Real-time Feedback**: Provides immediate feedback to users without any equipment attached to the body.
- **High Correlation**: The system's measured angle Θ and the commonly used medical reference for FHP, CVA, showed a high correlation, indicating its potential for broader cervical vertebra-related studies.

## Development Process

1. **Implementing Markerless Skeletal Tracking**: Utilized the Intel RealSense D415 3D depth camera and the Nuitrack SDK for real-time skeletal tracking.
2. **Measuring Algorithm for the Angle of Judgement**: The system calculates angles between vectors connecting the head, collar, and torso joints to determine FHP.
3. **Real-time Posture Feedback Program**: Provides audio and text feedback when the postural judgement angle is below a certain threshold.

## Experimental Setup

The Intel RealSense D415 3D camera was positioned 133cm above the subject and tilted down by 15 degrees. The distance from the camera to the subject's abdomen was maintained at 150cm. A Panasonic Lumix G7 was used for side camera views.

## Results

Experiments demonstrated that activating the feedback system reduced the FHP-time ratio and increased the average value of Θ, proving the system's effectiveness in correcting posture.

## Conclusion

This study successfully developed a real-time FHP Correction Feedback System that offers practicality and convenience. It automates the FHP determination process, which traditionally required manual measurement and analysis. The system's potential extends to various platforms, including Android, iOS, Windows, and smart TVs, thanks to its compatibility with the Nuitrack SDK and Unity environment.
