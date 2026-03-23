# jiXun - Unity 行为仿真互动系统

> 一个基于 Unity 的 3D 互动仿真客户端项目，聚焦 **行为树 AI、栈式 UI 管理、数据驱动玩法** 与 **可扩展的场景架构**。

## 1. 项目简介

`jiXun` 是一个以“角色行为与信息流交互”为核心的 Unity 客户端项目。  
项目围绕视频/消息等互动内容构建玩法循环，并通过 AI 决策、UI 管理和数据配置实现可迭代的产品化开发流程。

## 2. 面向招聘者的技术亮点

- **行为树 AI 实践**：基于 Behavior Designer 开发自定义 Action/Conditional 节点，驱动角色状态与行为切换。
- **栈式 UI 框架**：使用 `Stack + Dictionary` 统一管理 UI 生命周期（进入/暂停/恢复/退出）与动态加载，提升复杂界面的可维护性。
- **数据驱动设计**：通过 Excel 配置表驱动内容生成与规则更新，将逻辑与数据解耦，支持快速迭代。
- **演出与交互反馈**：使用 LeanTween 与 Timeline/PlayableDirector 实现 UI 动效与剧情演出控制。
- **本地存档能力**：基于 JSON 与持久化路径实现存档读写，支持状态恢复。

## 3. 技术栈

### 引擎与语言
- Unity `2019.4.33f1c1` (LTS)
- C#

### Unity Packages（节选）
- `com.unity.ugui`
- `com.unity.textmeshpro`
- `com.unity.timeline`
- `com.unity.postprocessing`

### 第三方与插件
- Behavior Designer
- LeanTween
- ExcelDataReader（Excel 数据读取）
- EPPlus（已引入，当前主流程读取使用 ExcelDataReader）

## 4. 核心模块设计

### 4.1 场景状态管理
- 通过 `SceneState + SceneSystem` 管理场景切换生命周期。
- Build Settings 主流程场景：`Start` / `Main` / `search`。

### 4.2 UIFramework（栈式管理）
- `PanelManager`：维护面板栈，负责 Push/Pop/PopAll。
- `UIManager`：按 UIType 动态加载并缓存 UI 实例。
- `BasePanel`：统一面板生命周期接口（OnEnter/OnPause/OnResume/OnExit）。

### 4.3 AI（行为树）
- 自定义行为节点覆盖动画控制、条件判断、状态控制等子模块。
- 支持行为决策与游戏状态联动，形成可扩展的行为逻辑链路。

### 4.4 数据驱动与存档
- Excel 配置从 `StreamingAssets` 读取并映射为业务数据对象。
- 本地存档基于 `JsonUtility + persistentDataPath` 实现。

### 4.5 演出与动效
- `LeanTween`：用于队列位移、入场/离场等 UI 过渡反馈。
- `Timeline + PlayableDirector`：封装时间轴资源加载、轨道绑定与播放控制。

## 5. 项目结构（关键目录）

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
│  └─ streamingAssets/
├─ Packages/
└─ ProjectSettings/
```

## 6. 快速开始（本地运行）

### 环境要求
- Unity Hub
- Unity Editor `2019.4.33f1c1`

### 启动步骤
1. 使用 Unity Hub 打开项目目录：`E:\UnityProject\Console\jiXun`
2. 等待依赖导入完成
3. 打开任一主场景（推荐从 `Start.unity` 开始）
4. 点击 Play 运行

## 7. 工程说明

- 当前核心业务代码主要位于 `Assets/Scripts/`，规模约 100+ C# 脚本。
- 项目中包含 `Library/` 等 Unity 生成目录；若用于 GitHub 展示，建议结合 `.gitignore` 管理无关缓存文件。

## 8. 可用于简历的一句话描述

> 在 Unity 项目中主导客户端核心模块开发，完成行为树 AI、栈式 UI 框架、场景状态管理与数据驱动系统落地，具备从玩法逻辑到工程化结构设计的完整实践经验。
