# Console

A Unity-based 3D interactive simulation project focused on **Behavior Tree AI**, **stack-based UI management**, **data-driven gameplay**, and **extensible scene architecture**.

## Overview

`jiXun` is a Unity client project built around character behaviour and information-driven interaction.  
The project combines AI decision-making, UI flow control, content configuration, and local save/load support into a reusable gameplay framework.

## Highlights

- Built **Behavior Tree AI** with custom nodes using **Behavior Designer**
- Implemented a **stack-based UI framework** for panel lifecycle and dynamic loading
- Added **data-driven gameplay** using Excel-based configuration
- Integrated **LeanTween** and **Timeline / PlayableDirector** for UI transitions and cutscene control
- Implemented **local save/load** with `JsonUtility` and `persistentDataPath`
- Structured the project with reusable systems for **scene state management**, **UI**, **AI**, and **data flow**

## Tech Stack

- **Engine:** Unity 2019.4.33f1c1 (LTS)
- **Language:** C#
- **Packages:** UGUI, TextMeshPro, Timeline, Post Processing
- **Plugins / Tools:** Behavior Designer, LeanTween, ExcelDataReader, EPPlus

## Core Systems

### Behavior Tree AI
- custom action / conditional nodes
- behaviour switching and state-driven decision logic
- AI linked with gameplay and interaction flow

### UI Framework
- stack-based panel management with `Stack + Dictionary`
- unified panel lifecycle:
  - `OnEnter`
  - `OnPause`
  - `OnResume`
  - `OnExit`
- dynamic UI loading and caching

### Scene Management
- scene flow handled through `SceneState + SceneSystem`
- main scenes include `Start`, `Main`, and `search`

### Data-Driven Gameplay
- Excel configuration loaded from `StreamingAssets`
- gameplay rules and content separated from hardcoded logic
- easier balancing and rapid iteration

### Save System
- local save/load implemented with `JsonUtility`
- data stored through Unity `persistentDataPath`

### Presentation and Interaction
- `LeanTween` for UI transitions and movement feedback
- `Timeline + PlayableDirector` for sequence and cutscene control

## Project Structure

```text
jiXun/
├─ Assets/
│  ├─ Scripts/
│  │  ├─ AI/
│  │  ├─ controller/
│  │  ├─ Scene/
│  │  ├─ SaveSystem/
│  │  ├─ timeLIne/
│  │  └─ UIFramework/
│  ├─ Plugins/
│  │  └─ Excel/
│  ├─ Resources/
│  └─ StreamingAssets/
├─ Packages/
└─ ProjectSettings/
